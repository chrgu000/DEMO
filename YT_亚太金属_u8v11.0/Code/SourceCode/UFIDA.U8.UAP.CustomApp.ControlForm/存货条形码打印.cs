using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using TH.BaseClass;
using System.IO;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 存货条形码打印 : UserControl
    {
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\print\\Model\\存货条形码打印Mod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\print\\User\\存货条形码打印User.dll";
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 存货条形码打印()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ee)
            {
                //MessageBox.Show("加载数据失败");
                throw new Exception(ee.Message);
            }
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

            //    OpenFileDialog oFile = new OpenFileDialog();
            //    oFile.Filter = "Excel文件|*.xls|Excel文件|*.xlsx";
            //    if (oFile.ShowDialog() == DialogResult.OK)
            //    {
            //        string sFilePath = oFile.FileName;
            //        string sSQL = "select * from [导入格式$]";

            //        DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //        gridView1.Columns.Clear();

            //        for (int i = dt.Rows.Count - 1; i >= 0; i--)
            //        {
            //            if (dt.Rows[i]["单据编码"].ToString().Trim() == "" && dt.Rows[i]["合同编号"].ToString().Trim() == "" && dt.Rows[i]["单据日期"].ToString().Trim() == "")
            //            {
            //                dt.Rows.RemoveAt(i);
            //            }
            //        }

            //        gridControl1.DataSource = dt;


            //        if (dt == null || dt.Rows.Count < 1)
            //            throw new Exception("加载的文件没有数据，请核实后继续");
            //    }
            //    else
            //    {
            //        throw new Exception("取消导入");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    FrmMsgBox f = new FrmMsgBox();
            //    f.richTextBox1.Text = ee.Message;
            //    f.Text = "加载失败";
            //    f.ShowDialog();
            //}
        }


        ////根据历史单据生成最新单据号
        //private string ReturnCode(DateTime d, long o)
        //{
        //    string s = o.ToString();
        //    int iLength = 4;

        //    for (int i = 0; i < iLength; i++)
        //    {
        //        if (s.Length < iLength)
        //        {
        //            s = "0" + s;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    s = d.ToString("yyMM") + s;
        //    return s;
        //}

        //private string ReturnID(object o)
        //{
        //    string s = o.ToString().Trim();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (s.Length < 9)
        //            s = "0" + s;
        //        else if (s.Length == 9)
        //            s = "1" + s;
        //        else
        //            break;
        //    }
        //    return s;
        //}

        //private string ReturnDBString(decimal o)
        //{
        //    return o.ToString();
        //}

        //private string ReturnDBString(object o)
        //{
        //    if (o.ToString().Trim() == "")
        //        return "null";
        //    else
        //    {
        //        return "'" + o.ToString().Trim() + "'";
        //    }
        //}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"

select distinct cast(0 as bit) as 选择,a.cInvCode as 存货编码,a.cInvName as 存货名称,a.cInvStd as 规格型号,b.cBatch as 批号,b.cFree1 as 材质,b.cFree2 as 渗层,b.cFree3 as 统一号,b.cFree4 as 工艺要求
    ,right('0000000000' + cast(b.AutoID as varchar(10)),10) as 条形码,1 as 打印次数
from inventory a left join dbo._BarCodeInventory b on a.cInvCode = b.cInvCode
    inner join InventoryClass c on a.cInvCCode = c.cInvCCode
where 1=1 and 2=2 
--union all
--select  cast(0 as bit) as 选择,a.cInvCode as 存货编码,a.cInvName as 存货名称,a.cInvStd as 规格型号,null as 批号,null as 材质,null as 渗层,null as 统一号,null as 工艺要求
--    ,cast(null as varchar(10)) as 条形码,null as 打印次数 from inventory a  inner join InventoryClass c on a.cInvCCode = c.cInvCCode
--where 1=1
order by a.cInvCode
";

                if (textEdit存货.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (a.cInvCode like '%" + textEdit存货.Text.Trim() + "%' or a.cInvName like '%" + textEdit存货.Text.Trim() + "%')");
                }
                if (textEdit存货分类.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (c.cInvCName like '%" + textEdit存货分类.Text.Trim() + "%' or c.cInvCName like '%" + textEdit存货分类.Text.Trim() + "%')");
                }
                if (textEdit材质.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("2=2", "2=2 and b.cFree1 like '%" + textEdit材质.Text.Trim() + "%' ");
                }
            
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                gridView1.OptionsView.ColumnAutoWidth = true;
                gridControl1.DataSource = dt;

                gridView1.OptionsBehavior.Editable = true;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                { 
                   string sColName = gridView1.Columns[i].FieldName.Trim();
                   if (sColName == "选择" || sColName == "打印次数" || sColName == "批号" || sColName == "材质" || sColName == "渗层" || sColName == "统一号" || sColName == "工艺要求")
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = true ;
                    }
                    else
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                } 
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "过滤失败";
                f.ShowDialog();
            }
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
                MessageBox.Show(ee.Message);
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
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

                if (Rep.dsPrint == null)
                    throw new Exception("没有需要打印的数据");

                Rep.dsPrint.Tables.Clear();

                try
                {
                    SqlConnection conn = new SqlConnection(Conn);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    //dtGrid = Select(dtGrid, "选择='True'", "");
                    try
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (SqlHelper.ReturnObjectToBool(gridView1.GetRowCellValue(i, "选择")))
                            {
                                string sSQL = "select * from _BarCodeInventory with(NOLOCK)  where cInvCode='" + gridView1.GetRowCellValue(i, "存货编码").ToString().Trim() + "' and isnull(cBatch,'')='" + gridView1.GetRowCellValue(i, "批号").ToString().Trim() + "' " +
        "and isnull(cFree1,'')='" + gridView1.GetRowCellValue(i, "材质").ToString().Trim() + "' and isnull(cFree2,'')='" + gridView1.GetRowCellValue(i, "渗层").ToString().Trim() + "' and isnull(cFree3,'')='" + gridView1.GetRowCellValue(i, "统一号").ToString().Trim() + "' and isnull(cFree4,'')='" + gridView1.GetRowCellValue(i, "工艺要求").ToString().Trim() + "'";
                                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                                if (dt.Rows.Count == 0)
                                {
                                    sSQL = @"insert into _BarCodeInventory(cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10) values(
'" + gridView1.GetRowCellValue(i, "存货编码").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "批号").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "材质").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "渗层").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "统一号").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "工艺要求").ToString().Trim() + "',NULL,NULL,NULL,NULL,NULL,NULL)";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    sSQL = "select right('0000000000' + cast(AutoID as varchar(10)),10) as 条形码 from _BarCodeInventory with(NOLOCK)  where cInvCode='" + gridView1.GetRowCellValue(i, "存货编码").ToString().Trim() + "' and isnull(cBatch,'')='" + gridView1.GetRowCellValue(i, "批号").ToString().Trim() + "'" +
        "and isnull(cFree1,'')='" + gridView1.GetRowCellValue(i, "材质").ToString().Trim() + "' and isnull(cFree2,'')='" + gridView1.GetRowCellValue(i, "渗层").ToString().Trim() + "' and isnull(cFree3,'')='" + gridView1.GetRowCellValue(i, "统一号").ToString().Trim() + "' and isnull(cFree4,'')='" + gridView1.GetRowCellValue(i, "工艺要求").ToString().Trim() + "'";
                                    DataTable dts = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                                    if (dts.Rows.Count > 0)
                                    {
                                        gridView1.SetRowCellValue(i, "条形码", dts.Rows[0]["条形码"].ToString().Trim());
                                    }
                                }
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();
                        throw new Exception(error.Message);
                    }

                }
                catch
                {

                }


                DataTable dtGrid = ((DataTable)gridControl1.DataSource).Copy();
                dtGrid.TableName = "dtGrid";

                DataTable dtPrint = new DataTable();
                dtPrint.TableName = "dtGrid";
                for (int i = 0; i < dtGrid.Columns.Count; i++)
                {
                    dtPrint.Columns.Add(dtGrid.Columns[i].ColumnName, dtGrid.Columns[i].DataType);
                }

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (SqlHelper.ReturnObjectToBool(dtGrid.Rows[i]["选择"]))
                    {
                        int count = SqlHelper.ReturnObjectToInt(dtGrid.Rows[i]["打印次数"]);
                        if (count == 0)
                        {
                            count = 1;
                        }
                        for (int j = 1; j <= count; j++)
                        {
                            dtPrint.ImportRow(dtGrid.Rows[i]);
                        }
                    }
                }

                Rep.dsPrint.Tables.Add(dtPrint);
                if (dtPrint.Rows.Count < 1)
                {
                    throw new Exception("没有要打印的单据");
                }

                Rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void tsbClearCon_Click(object sender, EventArgs e)
        {
            textEdit存货.Text = "";
            textEdit存货分类.Text = "";
            textEdit材质.Text = "";
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["选择"], chk全选.Checked);
                }
            }
            catch { }
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }


        public static DataTable Select(DataTable dt, string Sel, string Order)
        {
            DataRow[] dw = dt.Select(Sel, Order);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            return dts;
        }
    }
}
//select distinct cast(0 as bit) as 选择,a.cInvCode as 存货编码,a.cInvName as 存货名称,a.cInvStd as 规格型号,b.cFree1 as 材质,b.cFree2 as 渗层,b.cFree3 as 统一号,b.cFree4 as 工艺要求
//    ,right('0000000000' + cast(b.AutoID as varchar(10)),10) as 条形码,1 as 打印次数
//from inventory a left join dbo._BarCodeInventory b on a.cInvCode = b.cInvCode
//    inner join InventoryClass c on a.cInvCCode = c.cInvCCode
//where 1=1
//order by a.cInvCode