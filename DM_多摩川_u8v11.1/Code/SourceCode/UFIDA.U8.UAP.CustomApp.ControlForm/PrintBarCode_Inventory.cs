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
    public partial class PrintBarCode_Inventory : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        DAL_BarCodeList DAL = new DAL_BarCodeList();
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\存货条形码打印Mod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\存货条形码打印User.dll";


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

                GetGrid();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public PrintBarCode_Inventory()
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

                    long lMaxID = 0;
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

                    Guid sGuid = Guid.NewGuid();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                        if (sInvCode == "")
                        {
                            continue;
                        }

                        if (BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                        {
                            string sGuidTemp = gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim();
                            DataRow[] drList = dtGrid.Select("GUID = '" + sGuidTemp + "'");
                            DataRow dr = drList[0];

                            Model_BarCodeList model = new Model_BarCodeList();

                            decimal dQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiQty));
                            decimal dBatch = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColExBatchQty));
                            if (dBatch == 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "包装批量不能为零\n";
                                continue;
                            }

                            int iCount = BaseFunction.ReturnInt(Math.Ceiling(dQuantity / dBatch));

                            for (int j = 0; j < iCount; j++)
                            {
                                lMaxID += 1;

                                string sBarCode = "";

                                sBarCode = getBaseData.GetBarCode(dDateSer, lMaxID);


                                model = DAL.DataRowToModel(dr);

                                model.ExDepName = gridView1.GetRowCellDisplayText(i, gridColExDepName).ToString().Trim();

                                model.cInvName = gridView1.GetRowCellDisplayText(i, gridColcInvName).ToString().Trim();
                                model.cInvStd = gridView1.GetRowCellDisplayText(i, gridColcInvStd).ToString().Trim();

                                model.ExVenName = gridView1.GetRowCellDisplayText(i, gridColExVenName).ToString().Trim();

                                model.cWhName = gridView1.GetRowCellDisplayText(i, gridColcWhName).ToString().Trim();

                                model.BarCode = sBarCode;
                                model.ExQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiQty));

                                if (j != iCount - 1)
                                {
                                    model.iQty = dBatch;
                                }
                                else
                                {
                                    model.iQty = dQuantity - dBatch * (iCount - 1);
                                }
                                model.CreateUserName = sUserName;
                                model.CreateDate = dDateSer;
                                model.valid = true;
                                model.Used = 0;
                                model.GUID = sGuid;

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
            string sSQL = "select cVenCode,cVenName from Vendor order by cVenCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dr["cVenCode"] = string.Empty;
            dr["cVenName"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditcVenCode.DataSource = dt;
            ItemLookUpEditcVenName.DataSource = dt;


            sSQL = "select cWhCode,cWhName from Warehouse order by cWhCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cWhCode"] = string.Empty;
            dr["cWhName"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditcWhCode.DataSource = dt;
            ItemLookUpEditcWhName.DataSource = dt;


            sSQL = "select cInvCode,cInvName,cInvStd from Inventory order by cInvCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cInvCode"] = string.Empty;
            dr["cInvName"] = string.Empty;
            dr["cInvStd"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;

            sSQL = "select cDepCode,cDepName from Department order by cDepCode";
            dt =  DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cDepCode"] = string.Empty;
            dr["cDepName"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditcDepCode.DataSource = dt;
            ItemLookUpEditcDepName.DataSource = dt;
        }
        private void GetGrid()
        {
            try
            {
                string sSQL = @"
select cast(0 as bit) as choose , a.*
from _BarCodeList a
where 1=-1
order by a.BarCode

";
               
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
                gridView1.AddNewRow();

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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColchoose)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColchoose, true);

                    if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiQty)) == 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColiQty, 1);
                    }
                    if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColExBatchQty)) == 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColExBatchQty, 1);
                    }

                    if (gridView1.GetRowCellValue(e.RowHandle, gridColGUID).ToString().Trim() == "")
                    {
                        Guid guid = Guid.NewGuid();

                        gridView1.SetRowCellValue(e.RowHandle, gridColGUID, guid.ToString());
                    }
                }
                if (e.Column != gridColchoose && e.RowHandle == gridView1.RowCount -1)
                {
                    int iRow = e.RowHandle;
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }
            }
            catch { }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i =  gridView1.RowCount-1; i >=0; i--)
                { 
                    string sInvCode = gridView1.GetRowCellValue(i,gridColcInvCode).ToString().Trim();
                    if(sInvCode == "")
                        continue;

                    if(BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridColchoose)))
                    {
                        gridView1.DeleteRow(i);
                    }
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "删行失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
