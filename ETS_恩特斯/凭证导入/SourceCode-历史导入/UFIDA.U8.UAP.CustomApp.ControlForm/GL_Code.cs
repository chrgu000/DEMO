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

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class GL_Code : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

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
                DbHelperSQL.connectionString = Conn;

                string sSQL = "SELECT DISTINCT ltrim(rtrim(iYear)) as iYear FROM [UFSystem]..UA_Account_sub WHERE iYear <> '9999' ORDER BY iYear";
                DataTable dt = DbHelperSQL.Query(sSQL);
                lookUpEditiYear.Properties.DataSource = dt;
                lookUpEditiYear.EditValue = DateTime.Now.Year.ToString().Trim();

                sSQL = "select ccode,ccode_name from code where ISNULL(bend ,0) = 1 and iyear = aaaaaa order by ccode";
                sSQL = sSQL.Replace("aaaaaa", lookUpEditiYear.Text.Trim());
                DataTable dt1 = DbHelperSQL.Query(sSQL);
                ItemLookUpEdit科目编码.DataSource = dt1;
                ItemLookUpEdit科目名称.DataSource = dt1;
                GetGrid();

                gridView1.FocusedRowHandle = 0;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void GetGrid()
        {
            int iRow = gridView1.FocusedRowHandle;
            string sSQL = @"
SELECT cast(0 as bit) as choose,b.iID
    ,a.ccode as 会计科目,a.ccode_name, b.年度, b.对照科目,'edit' as iSave,b.Remark ,b.RemarkJ ,b.RemarkD
FROM code a LEFT JOIN [_科目对照] b ON a.ccode = b.会计科目 AND a.iyear = b.年度
WHERE ISNULL(bend ,0) = 1 and a.iyear = aaaaaa
ORDER BY a.ccode,b.iID
";
            sSQL = sSQL.Replace("aaaaaa", lookUpEditiYear.Text.Trim());
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            gridView1.BestFitColumns();

            gridView1.FocusedRowHandle = iRow;
            gridView1.AddNewRow();

            gridColRemark.Width = 200;
            gridColRemarkJ.Width = 200;
            gridColRemarkD.Width = 200;

            gridView1.FocusedRowHandle = iRow;
        }

        public GL_Code()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sErr = "";
            int iCount = 0;
            try
            {
                if (lookUpEditiYear.EditValue == null || lookUpEditiYear.EditValue.ToString().Trim() == "")
                {
                    lookUpEditiYear.Focus();
                    throw new Exception("请选择年度");
                }

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "";
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose));
                        if (!b)
                            continue;

                        Model._科目对照 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._科目对照();
                        model.会计科目 = gridView1.GetRowCellValue(i, gridCol会计科目).ToString().Trim();
                        model.对照科目 = gridView1.GetRowCellValue(i, gridCol对照科目).ToString().Trim();
                        model.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                        model.RemarkJ = gridView1.GetRowCellValue(i, gridColRemarkJ).ToString().Trim();
                        model.RemarkD = gridView1.GetRowCellValue(i, gridColRemarkD).ToString().Trim();

                        model.年度 = lookUpEditiYear.EditValue.ToString().Trim();
                        model.iID = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                        //if (model.对照科目.Trim() == "")
                        //{
                        //    sErr = sErr + "行" + (i + 1).ToString() + "对照科目没有设置\n";
                        //    continue;
                        //}

                        DAL._科目对照 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._科目对照();
                        sSQL = dal.Exists(model.年度, model.对照科目, model.iID.ToString());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            throw new Exception("行"+(i+1)+"对照科目不可重复");
                        }
                        if (model.iID==0)
                        {
                            sSQL = dal.Add(model);
                        }
                        else
                        {
                            sSQL = dal.Update(model);
                        }
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    
                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n" );

                        GetGrid();
                    }
                    else
                    {
                        throw new Exception("no data");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;
            if (e.Column != gridColchoose)
            {
                gridView1.SetRowCellValue(iRow, gridColchoose, true);
            }

            if (e.Column != gridColchoose && e.RowHandle == gridView1.RowCount - 1)
            {
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = iRow;
            }
        }

        private void lookUpEditiYear_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            string sErr = "";
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans;
            con.Open();
            cmd.Connection = con;
            trans = con.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (gridView1.GetRowCellValue(i, gridColchoose).ToString().Trim() == "True")
                    {
                        string iID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                        if (iID != "")
                        {
                            cmd.CommandText = "delete _科目对照  where iID='" + iID + "'";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                trans.Commit();
                MessageBox.Show("删除成功");
                GetGrid();
            }
            catch (Exception ee)
            {
                trans.Rollback();

                MessageBox.Show("删除失败:" + ee.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.AddNewRow();
            }
            catch { }
        }
    }
}
