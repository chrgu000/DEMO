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
    public partial class 货位条形码打印 : UserControl
    {
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\print\\Model\\货位条形码打印Mod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\print\\User\\货位条形码打印User.dll";
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 货位条形码打印()
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
select distinct cast(0 as bit) as 选择,cPosCode as 货位编码, cPosName as 货位名称, iPosGrade as 编码级次, bPosEnd as 是否末级, cWhCode as 仓库编码, iMaxCubage as 最大体积 , iMaxWeight as 最大重量, cMemo 备注

    ,cBarCode as 条形码
from Position a 
where 1=1
order by a.cPosCode
";

                if (textEdit货位.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (a.cPosCode like '%" + textEdit货位.Text.Trim() + "%' or a.cPosName like '%" + textEdit货位.Text.Trim() + "%')");
                }
            
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                gridView1.OptionsView.ColumnAutoWidth = true;
                gridControl1.DataSource = dt;

                gridView1.OptionsBehavior.Editable = true;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                { 
                   string sColName = gridView1.Columns[i].FieldName.Trim();
                    if(sColName == "选择")
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

                DataTable dtGrid = ((DataTable)gridControl1.DataSource).Copy();
                dtGrid.TableName = "dtGrid";

                for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
                {
                    if (!SqlHelper.ReturnObjectToBool(dtGrid.Rows[i]["选择"]))
                    {
                        dtGrid.Rows.RemoveAt(i);
                    }
                }

                Rep.dsPrint.Tables.Add(dtGrid);
                if (dtGrid.Rows.Count < 1)
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
            textEdit货位.Text = "";
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

    }
}