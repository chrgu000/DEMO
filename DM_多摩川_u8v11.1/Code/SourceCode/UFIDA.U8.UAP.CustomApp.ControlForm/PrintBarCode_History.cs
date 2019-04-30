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
    public partial class PrintBarCode_History : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        DAL_BarCodeList DAL = new DAL_BarCodeList();
        string sProPath = Application.StartupPath;

        string sU8UapPath = "\\UAP\\Runtime";
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\历史条形码打印Mod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\历史条形码打印User.dll";

        string sPrintLayOutMod2 = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\历史箱码打印Mod.dll";
        string sPrintLayOutUser2 = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\历史箱码打印User.dll";

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

        public PrintBarCode_History()
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
                lookUpEditBarCode1.EditValue = DBNull.Value;
                lookUpEditBarCode2.EditValue = DBNull.Value;
                lookUpEditRdCode011.EditValue = DBNull.Value;
                lookUpEditRdCode012.EditValue = DBNull.Value;
                lookUpEditcVenCode.EditValue = DBNull.Value;
                lookUpEditcVenName.EditValue = DBNull.Value;
                lookUpEditExType.EditValue = DBNull.Value;
                lookUpEditcInvCode.EditValue = DBNull.Value;
                lookUpEditcInvName.EditValue = DBNull.Value;
                lookUpEditcWhCode.EditValue = DBNull.Value;
                lookUpEditcWhName.EditValue = DBNull.Value;
                lookUpEditMom1.EditValue = DBNull.Value;
                lookUpEditMom2.EditValue = DBNull.Value;
                lookUpEditOM1.EditValue = DBNull.Value;
                lookUpEditOM2.EditValue = DBNull.Value;


                dtm1.Text = "";
                dtm2.Text = "";
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

                Rep.dsPrint.Tables.Clear();

                if (radioCG.Checked)
                {
                    sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\历史条形码打印Mod.dll";
                    sPrintLayOutUser = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\历史条形码打印User.dll";

                    if (radioBarCode.Checked)
                    {
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
                    }
                    if (radioBarCodeBox.Checked)
                    {
                        if (File.Exists(sPrintLayOutUser2))
                        {
                            Rep.LoadLayout(sPrintLayOutUser2);
                        }
                        else if (File.Exists(sPrintLayOutMod2))
                        {
                            Rep.LoadLayout(sPrintLayOutMod2);
                        }
                        else
                        {
                            MessageBox.Show("加载报表模板失败，请与管理员联系");
                            return;
                        }
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

                        string sCode = dDateSer.ToString("yyMMrrhhmmss");

                        long lMaxID = 0;
                        if (radioBarCode.Checked)
                        {
                            sSQL = "select max(BarCode) from dbo._BarCodeList where BarCode like '" + dDateSer.ToString("yyMMdd") + "%' ";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            string sMaxCode = "";
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                sMaxCode = dt.Rows[0][0].ToString().Trim();
                            }
                            if (sMaxCode != "")
                            {
                                lMaxID = BaseFunction.ReturnLong(sMaxCode.Substring(6));
                            }
                        }
                        if (radioBarCodeBox.Checked)
                        {
                            sSQL = "select max(BarCode) from dbo._BarCodeList where BarCode not like '" + dDateSer.ToString("yyMMdd") + "%' ";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            string sMaxCode = "";
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                sMaxCode = dt.Rows[0][0].ToString().Trim();
                            }
                            if (sMaxCode != "")
                            {
                                lMaxID = BaseFunction.ReturnLong(sMaxCode.Substring(7));
                            }
                        }

                        Guid sGuid = Guid.NewGuid();

                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                            {
                                string sBarCodeHis = gridView1.GetRowCellValue(i, gridColBarCode).ToString().Trim();
                                DataRow[] drList = dtGrid.Select("BarCode = '" + sBarCodeHis + "'");
                                DataRow dr = drList[0];

                                Model_BarCodeList model = new Model_BarCodeList();

                                lMaxID += 1;

                                string sBarCode = "";
                                if (radioBarCode.Checked)
                                {
                                    sBarCode = getBaseData.GetBarCode(dDateSer, lMaxID);
                                }
                                if (radioBarCodeBox.Checked)
                                {
                                    sBarCode = getBaseData.GetBarCodeBox(dDateSer, lMaxID);
                                }

                                model = DAL.DataRowToModel(dr);

                                model.BarCode = sBarCode;
                                model.BarCodeHis = sBarCodeHis;
                                model.ExQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiQty));

                                model.iQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUseQty));
                                model.CreateUserName = sUserName;
                                model.CreateDate = dDateSer;
                                model.valid = true;
                                model.Used = 0;
                                model.GUID = sGuid;

                                sSQL = DAL.Add(model);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "update _BarCodeList set valid = 0 where BarCode = '" + sBarCodeHis + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                if (radioBarCode.Checked)
                                {
                                    //登记源条码作废
                                    Model_BarCodeRD modelRD = new Model_BarCodeRD();
                                    DAL_BarCodeRD dalRD = new DAL_BarCodeRD();
                                    modelRD.sCode = sCode;
                                    modelRD.BarCode = sBarCodeHis;
                                    modelRD.sType = "历史条码打印";
                                    modelRD.cInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                                    modelRD.Qty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUseQty));
                                    modelRD.CreateUid = sUserName;
                                    modelRD.CreateDate = dDateSer;
                                    modelRD.ExCode = sBarCodeHis;
                                    modelRD.RDType = 2;
                                    sSQL = dalRD.Add(modelRD);
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    modelRD.BarCode = sBarCode;
                                    modelRD.RDType = 1;
                                    sSQL = dalRD.Add(modelRD);
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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

                        //Rep.Print();
                        Rep.ShowPreview();

                        tran.Commit();

                        btnRefresh_Click(null, null);
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();
                        throw new Exception(error.Message);
                    }
                }
                if (radioQC.Checked)
                {
                    sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\期初条形码打印Mod.dll";
                    sPrintLayOutUser = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\期初条形码打印User.dll";

                    if (radioBarCode.Checked)
                    {
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
                    }

                    DataTable dtPrint = (DataTable)gridControl1.DataSource;

                    DataTable dtPrTemp = dtPrint.Copy();
                    for (int i = dtPrTemp.Rows.Count-1; i >= 0; i--)
                    { 
                        bool b = BaseFunction.ReturnBool(dtPrTemp.Rows[i]["choose"]);
                        if (!b)
                        {
                            dtPrTemp.Rows.RemoveAt(i);
                        }
                    }

                    dtPrTemp.TableName = "dtGrid";


                    Rep.dsPrint.Tables.Add(dtPrTemp.Copy());

                    if (dtPrint.Rows.Count < 1)
                    {
                        throw new Exception("没有要打印的单据");
                    }
                    //Rep.Print();
                    Rep.ShowPreview();

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


                if (radioQC.Checked)
                {
                    sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\期初条形码打印Mod.dll";
                    sPrintLayOutUser = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\期初条形码打印User.dll";
                }
                if (radioCG.Checked)
                {
                    sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\历史条形码打印Mod.dll";
                    sPrintLayOutUser = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\历史条形码打印User.dll";
                }

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
            string sSQL = @"select BarCode from dbo._BarCodeList where BarCode not like 'X%' order by BarCode";
            if (radioBarCodeBox.Checked)
            {
                sSQL = @"select BarCode from dbo._BarCodeList where BarCode like 'X%' order by BarCode";
            }
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dr["BarCode"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditBarCode1.Properties.DataSource = dt;
            lookUpEditBarCode2.Properties.DataSource = dt;

            sSQL = @"
select distinct cCode,dDate from RdRecord01 order by cCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cCode"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditRdCode011.Properties.DataSource = dt;
            lookUpEditRdCode012.Properties.DataSource = dt;

            sSQL = @"
select distinct cCode,dDate from OM_MOMain order by cCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cCode"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditOM1.Properties.DataSource = dt;
            lookUpEditOM2.Properties.DataSource = dt;

            sSQL = @"
select distinct MoCode as cCode,CreateDate as dDate from mom_order order by cCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cCode"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditMom1.Properties.DataSource = dt;
            lookUpEditMom2.Properties.DataSource = dt;

            sSQL = "select cVenCode,cVenName from Vendor order by cVenCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cVenCode"] = string.Empty;
            dr["cVenName"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcVenCode.Properties.DataSource = dt;
            lookUpEditcVenName.Properties.DataSource = dt;



            sSQL = "select distinct ExType from _BarCodeList where isnull(ExType,'') <> '' order by ExType";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["ExType"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditExType.Properties.DataSource = dt;

            sSQL = "select cWhCode,cWhName from Warehouse order by cWhCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cWhCode"] = string.Empty;
            dr["cWhName"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcWhCode.Properties.DataSource = dt;
            lookUpEditcWhName.Properties.DataSource = dt;


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

select cast(0 as bit) as choose , a.*,isnull(b.Qty,0) as UseQty,cast(case when isnull(Used,0) = 0 then 0 else 1 end as bit) as bUsed
	,b.InvCode
from _BarCodeList a
	left join 
		(
			select sum(case when isnull(RDType,0) = 1 then Qty when  isnull(RDType,0) = 2 then -1 * Qty else 0 end) as Qty,BarCode,InvCode
			from (
					select b.Qty,b.sType,b.RdType,a.BarCode,null as InvCode
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord01 a inner join rdrecords01 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '采购入库单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
			union
			select b.Qty,b.sType,b.RdType,a.BarCode,InvCode 
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode,b.InvCode from rdrecord11 a inner join rdrecords11 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '材料出库单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 	
			union
			select b.Qty,b.sType,b.RdType,a.BarCode,null
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord08 a inner join rdrecords08 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '其他入库单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
			union
			select b.Qty,b.sType,b.RdType,a.BarCode,null
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord09 a inner join rdrecords09 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '其他出库单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
			union
			select b.Qty,b.sType,b.RdType,a.BarCode,null
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord10 a inner join rdrecords10 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '产成品入库单'
				and isnull(a.valid,0) = 1

			union
			select b.Qty,b.sType,b.RdType,a.BarCode,null
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cDLCode,b.iRowno,b.autoid,b.cinvcode from DispatchList a inner join DispatchLists b on a.DLID  = b.DLID ) c 
					on b.ExsID = c.autoid and c.cDLCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '销售发货单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 

	        union
			select a.Qty,a.sType,a.RdType,a.BarCode,null
			from dbo._BarCodeRD a
			where a.sType = '历史条码打印'

             union
			select a.Qty,a.sType,a.RdType,a.BarCode,null
			from dbo._BarCodeRD a
			where a.sType = '条码数量调整'

             union
			select a.Qty,a.sType,a.RdType,a.BarCode,null
			from dbo._BarCodeRD a
			where a.sType = '期初'
			) b 
			group by BarCode,InvCode
		) b on a.BarCode = b.BarCode
where 1=1
order by a.BarCode

";
                if (radioCG.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and Extype <> '期初'");  
                }
                if (radioQC.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and Extype = '期初'");
                }

                if (radioValid.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.valid,0) = 1");  
                }
                if (radioUnValid.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.valid,0) = 0");
                }


                if (radioBarCode.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.BarCode not like 'X%'");
                }
                if (radioBarCodeBox.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.BarCode like 'X%'");
                }

                if (lookUpEditBarCode1.EditValue != null && lookUpEditBarCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.BarCode >= '" + lookUpEditRdCode011.Text.Trim() + "'");
                }
                if (lookUpEditBarCode2.EditValue != null && lookUpEditBarCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.BarCode <= '" + lookUpEditBarCode2.Text.Trim() + "'");
                }

                if (lookUpEditRdCode011.EditValue != null && lookUpEditRdCode011.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExCode >= '" + lookUpEditRdCode011.Text.Trim() + "'");
                }
                if (lookUpEditRdCode012.EditValue != null && lookUpEditRdCode012.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExCode <= '" + lookUpEditRdCode012.Text.Trim() + "'");
                }

                if (lookUpEditOM1.EditValue != null && lookUpEditOM1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExCode >= '" + lookUpEditOM1.Text.Trim() + "'");
                }
                if (lookUpEditOM2.EditValue != null && lookUpEditOM2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExCode <= '" + lookUpEditOM2.Text.Trim() + "'");
                }

                if (lookUpEditMom1.EditValue != null && lookUpEditMom1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExCode >= '" + lookUpEditMom1.Text.Trim() + "'");
                }
                if (lookUpEditMom2.EditValue != null && lookUpEditMom2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExCode <= '" + lookUpEditMom2.Text.Trim() + "'");
                }

                if (dtm1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.CreateDate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.CreateDate < '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }

                if (lookUpEditcVenCode.EditValue != null && lookUpEditcVenCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExVenCode = '" + lookUpEditcVenCode.EditValue.ToString().Trim() + "'");
                }

                if (lookUpEditExType.EditValue != null && lookUpEditExType.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExType = '" + lookUpEditExType.EditValue.ToString().Trim() + "'");
                }

                if (lookUpEditcInvCode.EditValue != null && lookUpEditcInvCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cInvCode = '" + lookUpEditcInvCode.EditValue.ToString().Trim() + "'");
                }

                if (lookUpEditcWhCode.EditValue != null && lookUpEditcWhCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cWhCode = '" + lookUpEditcWhCode.EditValue.ToString().Trim() + "'");
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

        private void lookUpEditcVenCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcVenName.EditValue = lookUpEditcVenCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcVenName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcVenCode.EditValue = lookUpEditcVenName.EditValue;
            }
            catch { }
        }

     

        private void lookUpEditcWhCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcWhName.EditValue = lookUpEditcWhCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcWhName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcWhCode.EditValue = lookUpEditcWhName.EditValue;
            }
            catch { }
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

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"select BarCode from dbo._BarCodeList where BarCode not like 'X%' order by BarCode";
                if (radioBarCodeBox.Checked)
                {
                    sSQL = @"select BarCode from dbo._BarCodeList where BarCode like 'X%' order by BarCode";
                }
                DataTable dt = DbHelperSQL.Query(sSQL);
                DataRow dr = dt.NewRow();
                dr["BarCode"] = string.Empty;
                dt.Rows.InsertAt(dr, 0);
                lookUpEditBarCode1.Properties.DataSource = dt;
                lookUpEditBarCode2.Properties.DataSource = dt;

                if (radioBarCodeBox.Checked)
                {
                    lookUpEditExType.EditValue = DBNull.Value;
                }
            }
            catch { }
        }
    }
}
