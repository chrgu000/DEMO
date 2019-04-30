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
    public partial class 帐套科目归属表 : UserControl
    {
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\print\\Model\\到货单条形码打印Mod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\print\\User\\到货单条形码打印User.dll";
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 帐套科目归属表()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                btnRefresh_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
SELECT iID,[帐套号]
      ,[科目]
      ,[归属公司]
      ,[对方科目]
      ,对方客户
      ,对方供应商
      ,cast(0 as bit) as 选择
FROM [UFSystem].[dbo].[帐套科目归属]
";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveFileDialog sF = new SaveFileDialog();
                //sF.DefaultExt = "xls";
                //sF.FileName = this.Text;
                //sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                //DialogResult dRes = sF.ShowDialog();
                //if (DialogResult.OK == dRes)
                //{
                //    gridView1.ExportToXls(sF.FileName);
                //    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                //}
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件|*.xls|Excel文件|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [帐套科目归属$]";

                    DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);
                    DataColumn dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.Boolean");
                    dc.ColumnName = "选择";
                    dt.Columns.Add(dc);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["选择"] = true;
                    }
                    gridControl1.DataSource = dt;

                    if (dt == null || dt.Rows.Count < 1)
                        throw new Exception("加载的文件没有数据，请核实后继续");
                }
                else
                {
                    throw new Exception("取消导入");
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "加载失败";
                f.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                string sSQL = "";

                int iFoc = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iFoc = gridView1.FocusedRowHandle;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i <  gridView1.RowCount; i++)
                    {
                        if (!SqlHelper.ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择)))
                        {
                            continue;
                        }

                        string s帐套号 = gridView1.GetRowCellValue(i,gridCol帐套号).ToString().Trim() ;
                        if (s帐套号 == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "来源帐套不能为空";
                            continue;
                        }

                        string s科目 = gridView1.GetRowCellValue(i, gridCol科目).ToString().Trim();
                        if (s科目 == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "科目不能为空";
                            continue;
                        }

                        sSQL = @"
if not exists(select * from [UFSystem].[dbo].[帐套科目归属] where 帐套号 = '111111' and 科目 = '222222')
        insert into [UFSystem].[dbo].[帐套科目归属](帐套号,科目,归属公司,对方科目,对方客户,对方供应商)
        values('111111','222222','333333','444444','555555','666666')

else
        update [UFSystem].[dbo].[帐套科目归属] set 归属公司 = '333333',对方科目 = '444444',对方客户 = '555555',对方供应商 = '666666'
         where 帐套号 = '111111' and 科目 = '222222'
";

                        sSQL = sSQL.Replace("111111", s帐套号);
                        sSQL = sSQL.Replace("222222", s科目);
                        sSQL = sSQL.Replace("333333", gridView1.GetRowCellValue(i, gridCol归属公司).ToString().Trim());
                        sSQL = sSQL.Replace("444444", gridView1.GetRowCellValue(i, gridCol对方科目).ToString().Trim());
                        sSQL = sSQL.Replace("555555", gridView1.GetRowCellValue(i, gridCol对方客户).ToString().Trim());
                        sSQL = sSQL.Replace("666666", gridView1.GetRowCellValue(i, gridCol对方供应商).ToString().Trim());
                      
                         SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();
                    MessageBox.Show("保存成功", "提示");

                    btnRefresh_Click(null, null);
                    gridView1.FocusedRowHandle = iFoc;
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
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                DialogResult d = MessageBox.Show("确定删除选定的行么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    return;
                }


                int iFoc = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iFoc = gridView1.FocusedRowHandle;

                string sSQL = "";

                DataTable dtGrid = (DataTable)gridControl1.DataSource;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                for (int i = 0; i < gridView1.RowCount;i++ )
                {
                    if (SqlHelper.ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        string s帐套号 = gridView1.GetRowCellValue(i, gridView1.Columns["帐套号"]).ToString().Trim();
                        string s科目 = gridView1.GetRowCellValue(i, gridView1.Columns["科目"]).ToString().Trim();


                        sSQL = "delete [UFSystem].[dbo].[帐套科目归属] where 帐套号 = '111111' and 科目 = '222222' ";

                        sSQL = sSQL.Replace("111111", s帐套号);
                        sSQL = sSQL.Replace("222222", s科目);
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }

                tran.Commit();
                MessageBox.Show("删除成功", "提示");

                btnRefresh_Click(null,null);
                gridView1.FocusedRowHandle = iFoc;
            }
            catch (Exception ee)
            {
                MessageBox.Show("删除失败:" + ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                if (e.Column != gridCol选择)
                {
                    gridView1.SetRowCellValue(iRow, gridCol选择, true);
                }
            }
            catch { }
        }
    }
}