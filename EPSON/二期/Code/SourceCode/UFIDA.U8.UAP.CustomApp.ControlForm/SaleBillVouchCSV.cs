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
    public partial class SaleBillVouchCSV : UserControl
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

                dateEdit1.DateTime = DateTime.Today;
                dateEdit2.DateTime = DateTime.Today;
                SetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cSBVCode from SaleBillVouch order by cSBVCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcSBVCode1.Properties.DataSource = dt;
            lookUpEditcSBVCode2.Properties.DataSource = dt;
        }

        public SaleBillVouchCSV()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                string sSTCode = "";
                if (radioWC.Checked)
                    sSTCode = "WC";
                if (radioWP.Checked)
                    sSTCode = "WP";
                if (radioPP.Checked)
                    sSTCode = "PP";
                if (radioIC.Checked)
                    sSTCode = "";


                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "csv";
                if (radioWC.Checked)
                {
                    sF.FileName = "EPJWCDO_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                }
                if (radioWP.Checked)
                {
                    sF.FileName = "EPJMPDO_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                }
                if (radioIC.Checked)
                {
                    sF.FileName = "SEP3DO_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                }
                if (radioPP.Checked)
                {
                    sF.FileName = "EPJPPDO_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                }
                sF.Filter = "CSV文件(*.csv)|*.csv|All(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }
                string sPath = sF.FileName;

                TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();
                if (radioIC.Checked)
                {
                    DataTable dt = ((DataTable)gridControl2.DataSource).Copy();
                    dt.Columns.RemoveAt(6);
                    if (SaveCSV(dt, sPath, false))
                    {
                        MessageBox.Show("OK");
                    }
                }
                else
                {
                    DataTable dt = ((DataTable)gridControl1.DataSource).Copy();
                    dt.Columns.RemoveAt(21);
                    dt.Columns.RemoveAt(20);
                    dt.Columns.RemoveAt(19);
                    if (SaveCSV(dt, sPath, false))
                    {
                        MessageBox.Show("OK");
                    }
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("Error:" + ee.Message);
            }
        }

        /// <summary>
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        /// <param name="bTitle">CSV的是否包含标题行</param>
        public bool SaveCSV(DataTable dt, string fullPath, bool bTitle)
        {
            bool b = false;
            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";

            if (bTitle)
            {
                //写出列名称
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data += dt.Columns[i].ColumnName.ToString();
                    if (i < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            //写出各行数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(',') || str.Contains('"') || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
            b = true;
            return b;
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


        private void GetGrid()
        {
            string sSQL = @"

";

            // IC模式不在这里处理
            if (radioWP.Checked)
            {
                sSQL = @" 
SELECT * FROM [dbo].[_SaleBillVouchExportToCSV3] 
WHERE cSTCode = 'WP' and 1=1
ORDER BY autoid 
";

                if (lookUpEditcSBVCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and SEPINVOICENO >= '" + lookUpEditcSBVCode1.Text.Trim().Trim() + "'");
                }
                if (lookUpEditcSBVCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and SEPINVOICENO <= '" + lookUpEditcSBVCode2.Text.Trim().Trim() + "'");
                }
                if (dateEdit1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and EPJONBOARDDATE >= '" + dateEdit1.DateTime.ToString("yyyyMMdd") + "'");
                }
                if (dateEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and EPJONBOARDDATE <= '" + dateEdit2.DateTime.ToString("yyyyMMdd") + "'");
                }
            }
            if (radioWC.Checked)
            {
                sSQL = @"
SELECT * FROM [dbo].[_SaleBillVouchExportToCSV] 
WHERE cSTCode = 'WC' and 1=1
ORDER BY autoid 
";

                if (lookUpEditcSBVCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and SEPINVOICENO >= '" + lookUpEditcSBVCode1.Text.Trim().Trim() + "'");
                }
                if (lookUpEditcSBVCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and SEPINVOICENO <= '" + lookUpEditcSBVCode2.Text.Trim().Trim() + "'");
                }
                if (dateEdit1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and EPJONBOARDDATE >= '" + dateEdit1.DateTime.ToString("yyyyMMdd") + "'");
                }
                if (dateEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and EPJONBOARDDATE <= '" + dateEdit2.DateTime.ToString("yyyyMMdd") + "'");
                }
            }
            if (radioPP.Checked)
            {
                sSQL = @"
SELECT * FROM [dbo].[_SaleBillVouchExportToCSV] 
WHERE cSTCode = 'PP' and 1=1
ORDER BY autoid 
";

                if (lookUpEditcSBVCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and SEPINVOICENO >= '" + lookUpEditcSBVCode1.Text.Trim().Trim() + "'");
                }
                if (lookUpEditcSBVCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and SEPINVOICENO <= '" + lookUpEditcSBVCode2.Text.Trim().Trim() + "'");
                }
                if (dateEdit1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and EPJONBOARDDATE >= '" + dateEdit1.DateTime.ToString("yyyyMMdd") + "'");
                }
                if (dateEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and EPJONBOARDDATE <= '" + dateEdit2.DateTime.ToString("yyyyMMdd") + "'");
                }
            }

            if (radioIC.Checked)
            {
                sSQL = @"
SELECT * FROM [dbo].[_SaleBillVouchExportToCSV2] 
WHERE cSBVCode in (select cSBVCode from SaleBillVouch where cSTCode = 'IC' and 1=1 )
ORDER BY cSBVCode 
";
                if (lookUpEditcSBVCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cSBVCode >= '" + lookUpEditcSBVCode1.Text.Trim().Trim() + "'");
                }
                if (lookUpEditcSBVCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cSBVCode <= '" + lookUpEditcSBVCode2.Text.Trim().Trim() + "'");
                }
                if (dateEdit1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dateEdit2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'");
                }
            }

            if (sSQL.Trim() == "")
            {
                throw new Exception("Please choose sales type");
            }

            DataTable dt = DbHelperSQL.Query(sSQL);

            if (radioIC.Checked)
            {
                gridControl1.Visible = false;
                gridControl2.Visible = true;
                gridControl2.DataSource = dt;
                gridView2.BestFitColumns();

                gridView2.FocusedRowHandle = 0;
            }
            else
            {
                gridControl2.Visible = false;
                gridControl1.Visible = true;
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();

                gridView1.FocusedRowHandle = 0;
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private string SetStringFormat(object o, int iLength)
        {
            string sTxt = "";
            if (o != null)
            {
                sTxt = o.ToString().Trim();
            }

            while (System.Text.Encoding.Default.GetBytes(sTxt).Length < iLength)
            {
                sTxt = sTxt + ' '.ToString();
            }


            return sTxt;
        }

        private string SetStringFormat(object o, int iLength, char sValue)
        {
            string sTxt = "";
            if (o != null)
            {
                sTxt = o.ToString().Trim();
            }

            while (System.Text.Encoding.Default.GetBytes(sTxt).Length < iLength)
            {
                sTxt = sValue.ToString() + sTxt;
            }


            return sTxt;
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            GetGrid();
        }       
    }
}
