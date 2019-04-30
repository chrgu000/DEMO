using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class PrintBarCode_mom_order : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        DAL_BarCodeList DAL = new DAL_BarCodeList();
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\生产订单条形码打印Mod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\生产订单条形码打印User.dll";

        string sPrintLayOutModBox = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\生产订单箱码打印Mod.dll";
        string sPrintLayOutUserBox = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\生产订单箱码打印User.dll";

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                dtm1.DateTime = DateTime.Today.AddDays(-7);
                dtm2.DateTime = DateTime.Today;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public PrintBarCode_mom_order()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void tsbClearCon_Click(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCode1.EditValue = DBNull.Value;
                lookUpEditcCode2.EditValue = DBNull.Value;
             
                lookUpEditcInvCode.EditValue = DBNull.Value;
                lookUpEditcInvName.EditValue = DBNull.Value;

                dtm1.Text = "";
                dtm2.Text = "";

                radioUnAudit.Checked = true;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "清空过滤条件失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }

                string sErr = "";
                string sWarn = "";

                if (Rep.dsPrint == null)
                    throw new Exception("没有需要打印的数据");

                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    Rep.dsPrint.Tables.Clear();

                    DataTable dtGrid = ((DataTable)gridControl1.DataSource).Copy();

                    string sSQL = "select getdate()";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dDateSer = BaseFunction.ReturnDate(dt.Rows[0][0]);
                    if (dDateSer.Date < BaseFunction.ReturnDate("2014-8-1"))
                    {
                        throw new Exception("获得系统日期失败");
                    }

                    sSQL = "select max(BarCode) from dbo._BarCodeList where BarCode like '" + dDateSer.ToString("yyMMdd") + "%' ";
                    dt =  DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    string sMaxCode = "";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        sMaxCode = dt.Rows[0][0].ToString().Trim();
                    }
                    long lMaxID = 0;
                    if (sMaxCode != "")
                    {
                        lMaxID = BaseFunction.ReturnLong(sMaxCode.Substring(6));
                    }

                    Guid sGuid = Guid.NewGuid();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridColchoose)))
                        {
                            decimal dQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiQuantity));
                            if (dQuantity < 0)
                                dQuantity = -1 * dQuantity;

                            for (int j = 0; j < dQuantity; j++)
                            {
                                Model_BarCodeList model = new Model_BarCodeList();

                                lMaxID += 1;
                                string sBarCode = getBaseData.GetBarCode(dDateSer, lMaxID);

                                model.cInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                                model.cInvName = gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                                model.cInvStd = gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim();
                                model.BarCode = sBarCode;
                                model.ExsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColAutoID));
                                model.ExCode = gridView1.GetRowCellValue(i, gridColcCode).ToString().Trim();
                                model.ExRowNo = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColirowno));
                                model.ExQuantity = dQuantity;
                                model.iQty = 1;
                                model.ExType = "生产订单";
                                model.ExDepCode = gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim();
                                model.ExDepName = gridView1.GetRowCellValue(i, gridColcDepName).ToString().Trim();
                                model.ExcMemo = gridView1.GetRowCellValue(i, gridColExcMemo).ToString().Trim();
                              
                                model.GUID = sGuid;
                                model.CreateUserName = sUserName;
                                model.CreateDate = dDateSer;
                                model.valid = true;
                                model.Used = 0;

                                string sInvCode = model.cInvCode;
                                while (sInvCode.Trim().Length < 7)
                                {
                                    sInvCode = sInvCode + " ";
                                }

                                sInvCode = sInvCode.Substring(0, 7);
                                sSQL = "select max(SerialNO) from _BarCodeList where SerialNO like '" + sInvCode + "%'";
                                DataTable dtSerialNO = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                string sSerialNO = dtSerialNO.Rows[0][0].ToString().Trim();
                                model.SerialNO = getBaseData.GetSerialNO(sSerialNO, sInvCode, 5);

                                sSQL = "select count(1) from  _BarCodeList where SerialNO = '" + model.SerialNO + "'";
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (BaseFunction.ReturnInt(dt.Rows[0][0]) > 0)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + "序列号已经存在\n";
                                    continue;
                                }

                                model.PosCode = gridView1.GetRowCellValue(i, gridCol货位).ToString().Trim();

                                sSQL = DAL.Add(model);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }

                    sSQL = "select * from [_BarCodeList] where GUID = '" + sGuid.ToString().Trim() + "'";
                    DataTable dtPrint = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    dtPrint.TableName = "dtGrid";

                    //序列号中间增加一个空格
                    //for (int i = 0; i < dtPrint.Rows.Count; i++)
                    //{
                    //    string sSerialNO = dtPrint.Rows[i]["SerialNO"].ToString().Trim();
                    //    if (sSerialNO.Length > 7)
                    //    {
                    //        dtPrint.Rows[i]["SerialNO"] = sSerialNO.Substring(0, 7) + " " + sSerialNO.Substring(7);
                    //    }
                    //}

                    Rep.dsPrint.Tables.Add(dtPrint.Copy());

                    if (dtPrint.Rows.Count < 1)
                    {
                        throw new Exception("没有要打印的单据");
                    }
                    if (sErr.Trim() != "")
                        throw new Exception(sErr);

                    if (iCou == 0)
                        throw new Exception("请选择需要保存的数据");

                    //Rep.Print();
                    Rep.ShowPreview();

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "打印失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            try
            {
                bool bMod = false;
                if (sUserID == "demo")
                {
                    bMod = true;
                }

                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");
                if (!Directory.Exists(sProPath + "\\print\\Model"))
                    Directory.CreateDirectory(sProPath + "\\print\\Model");
                if (!Directory.Exists(sProPath + "\\print\\User"))
                    Directory.CreateDirectory(sProPath + "\\print\\User");

                if (bMod)
                {
                    if (File.Exists(sPrintLayOutMod))
                    {
                        Rep.LoadLayout(sPrintLayOutMod);
                    }
                }
                else
                {
                    if (File.Exists(sPrintLayOutUser))
                    {
                        Rep.LoadLayout(sPrintLayOutUser);
                    }
                    else if (File.Exists(sPrintLayOutMod))
                    {
                        Rep.LoadLayout(sPrintLayOutMod);
                    }
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n否：恢复默认打印模板\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    if (bMod)
                    {
                        Rep.SaveLayoutToXml(sPrintLayOutMod);
                    }
                    else
                    {
                        Rep.SaveLayoutToXml(sPrintLayOutUser);
                    }
                }
                else if (DialogResult.No == d)
                {
                    if (File.Exists(sPrintLayOutUser))
                    {
                        File.Delete(sPrintLayOutUser);
                    }
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "设置打印模板失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void GetLookUp()
        {
            string sSQL = @"
select distinct mocode as cCode,CreateDate  as dDate from mom_order order by dDate,cCode
";

            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dr["cCode"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcCode1.Properties.DataSource = dt;
            lookUpEditcCode2.Properties.DataSource = dt;


            sSQL = "select cInvCode,cInvName,cInvStd from Inventory order by cInvCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cInvCode"] = string.Empty;
            dr["cInvName"] = string.Empty;
            dr["cInvStd"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcInvCode.Properties.DataSource = dt;
            lookUpEditcInvName.Properties.DataSource = dt;

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select cast(0 as bit) as choose
    ,a.MoCode as cCode,a.CreateDate as dDate,b.MDeptCode as cDepCode,c.cDepName,a.CreateUser as cMaker,a.CreateDate as cHandler
	,b.InvCode as cInvCode,f.cInvName,f.cInvStd,b.Qty as iQuantity,b.Define27 as 包装批量,b.Define28 as 货位,b.Define30 as 批号
    ,b.MoDId  as AutoID,b.SortSeq  as irowno,g.PrintQty,g.PrintNum
    ,b.Status as 审核状态,b.Remark  as ExcMemo
from mom_order a
	inner join mom_orderdetail b on a.moid = b.moid 
	left join Department c on c.cDepCode = b.MDeptCode
	left join Inventory f on f.cInvCode = b.InvCode
    left join (select sum(iQty) as PrintQty,count(1) as PrintNum,ExsID from _BarCodeList group by ExsID) g on g.ExsID = b.MoDId
where 1=1
order by a.moid,b.MoDId

";
                if (lookUpEditcCode1.EditValue != null && lookUpEditcCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.MoCode >= '" + lookUpEditcCode1.Text.Trim() + "'");
                }
                if (lookUpEditcCode2.EditValue != null && lookUpEditcCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.MoCode <= '" + lookUpEditcCode2.Text.Trim() + "'");
                }

                if (dtm1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.CreateDate  >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.CreateDate  < '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }


                if (lookUpEditcInvCode.EditValue != null && lookUpEditcInvCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.InvCode = '" + lookUpEditcInvCode.EditValue.ToString().Trim() + "'");
                }

                if (radioUnAudit.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.Status,0) = 2");
                }
                if (radioAudit.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.Status,0) = 3");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;

                chkAll.Checked = false;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载数据失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }     

        private void lookUpEditcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvName.EditValue = lookUpEditcInvCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcInvName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvCode.EditValue = lookUpEditcInvName.EditValue;
            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
                }
            }
            catch { }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle >= 0)
                    {
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    else if (e.RowHandle < 0 && e.RowHandle > -1000)
                    {
                        e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                        e.Info.DisplayText = "G" + e.RowHandle.ToString();
                    }
                }
            }
            catch { }
        }

        private void btnPrintSetBox_Click(object sender, EventArgs e)
        {
            try
            {
                bool bMod = false;
                if (sUserID == "demo")
                {
                    bMod = true;
                }

                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");
                if (!Directory.Exists(sProPath + "\\print\\Model"))
                    Directory.CreateDirectory(sProPath + "\\print\\Model");
                if (!Directory.Exists(sProPath + "\\print\\User"))
                    Directory.CreateDirectory(sProPath + "\\print\\User");

                if (bMod)
                {
                    if (File.Exists(sPrintLayOutModBox))
                    {
                        Rep.LoadLayout(sPrintLayOutModBox);
                    }
                }
                else
                {
                    if (File.Exists(sPrintLayOutUserBox))
                    {
                        Rep.LoadLayout(sPrintLayOutUserBox);
                    }
                    else if (File.Exists(sPrintLayOutModBox))
                    {
                        Rep.LoadLayout(sPrintLayOutModBox);
                    }
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n否：恢复默认打印模板\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    if (bMod)
                    {
                        Rep.SaveLayoutToXml(sPrintLayOutModBox);
                    }
                    else
                    {
                        Rep.SaveLayoutToXml(sPrintLayOutUserBox);
                    }
                }
                else if (DialogResult.No == d)
                {
                    if (File.Exists(sPrintLayOutUserBox))
                    {
                        File.Delete(sPrintLayOutUserBox);
                    }
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "设置打印模板失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnPrintBox_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutUserBox))
                {
                    Rep.LoadLayout(sPrintLayOutUserBox);
                }
                else if (File.Exists(sPrintLayOutModBox))
                {
                    Rep.LoadLayout(sPrintLayOutModBox);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }

                string sErr = "";
                string sWarn = "";

                if (Rep.dsPrint == null)
                    throw new Exception("没有需要打印的数据");

                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    Rep.dsPrint.Tables.Clear();

                    DataTable dtGrid = ((DataTable)gridControl1.DataSource).Copy();

                    string sSQL = "select getdate()";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dDateSer = BaseFunction.ReturnDate(dt.Rows[0][0]);
                    if (dDateSer.Date < BaseFunction.ReturnDate("2014-8-1"))
                    {
                        throw new Exception("获得系统日期失败");
                    }

                    sSQL = "select max(BarCode) from dbo._BarCodeList where BarCode like 'X" + dDateSer.ToString("yyMMdd") + "%' ";
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    string sMaxCode = "";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        sMaxCode = dt.Rows[0][0].ToString().Trim();
                    }
                    long lMaxID = 0;
                    if (sMaxCode != "")
                    {
                        lMaxID = BaseFunction.ReturnLong(sMaxCode.Substring(7));
                    }

                    Guid sGuid = Guid.NewGuid();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                        {
                            decimal dQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiQuantity));
                            if (dQuantity < 0)
                                dQuantity = -1 * dQuantity;

                            decimal dBatch = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol包装批量));
                            if (dBatch == 0)
                            {
                                sErr = sErr + "行" + (i+1).ToString().Trim() + "请设置包装批量\n";
                                continue;
                            }

                            int iCount = BaseFunction.ReturnInt(Math.Ceiling(dQuantity / dBatch));

                            for (int j = 0; j < iCount; j++)
                            {
                                Model_BarCodeList model = new Model_BarCodeList();

                                lMaxID += 1;
                                string sBarCode = getBaseData.GetBarCodeBox(dDateSer, lMaxID);
                                model.BarCode = sBarCode;
                                model.ExsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColAutoID));
                                model.ExCode = gridView1.GetRowCellValue(i, gridColcCode).ToString().Trim();
                                model.ExRowNo = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColirowno));
                                model.ExQuantity = dQuantity;
                                model.ExDepCode = gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim();
                                model.ExDepName = gridView1.GetRowCellValue(i, gridColcDepName).ToString().Trim();
                                model.ExBatchQty = dBatch;
                                model.Used = 0;

                                if (j == iCount - 1)
                                {
                                    model.iQty = dQuantity - dBatch * (iCount - 1);
                                }
                                else
                                {
                                    model.iQty = dBatch;
                                }
                                model.CreateUserName = sUserName;
                                model.CreateDate = dDateSer;  

                                model.ExType = "生产订单";

                                model.GUID = sGuid;
                                model.valid = true;

                                model.PosCode = gridView1.GetRowCellValue(i, gridCol货位).ToString().Trim();

                                sSQL = DAL.Add(model);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }

                    sSQL = "select * from [_BarCodeList] where GUID = '" + sGuid.ToString().Trim() + "'";
                    DataTable dtPrint = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    dtPrint.TableName = "dtGrid";

                    Rep.dsPrint.Tables.Add(dtPrint.Copy());

                    if (dtPrint.Rows.Count < 1)
                    {
                        throw new Exception("没有要打印的单据");
                    }
                    if (sErr.Trim() != "")
                        throw new Exception(sErr);

                    if (iCou == 0)
                        throw new Exception("请选择需要保存的数据");

                    if(sErr.Length >0)
                    {
                        throw new Exception(sErr);
                    }

                    Rep.ShowPreview();

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "打印失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        //public string GetBarCode(DateTime dDate, long l)
        //{
        //    string sBarCode = dDate.ToString("yyMMdd");
        //    if (l == 0)
        //        l = 1;
        //    string s = l.ToString();
        //    while (s.Length < 6)
        //    {
        //        s = "0" + s;
        //    }

        //    sBarCode = sBarCode + s;

        //    return sBarCode;
        //}
    }
}
