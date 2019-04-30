using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;



namespace clsU8
{
    public partial class Frm销售发票导出 : Form
    {
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;

        public Frm销售发票导出()
        {
            InitializeComponent();
        }


        public Frm销售发票导出(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";
        }

        string sSTCode = "";
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
SELECT * FROM [dbo].[_SaleBillVouchExportToCSV] 
WHERE cSBVCode = 'aaaaaa' 
ORDER BY autoid 
";
                sSQL = sSQL.Replace("aaaaaa", s单据号);
                DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];

                sSTCode = dt.Rows[0]["cSTCode"].ToString().Trim();


                if (sSTCode.ToLower() != "ic")
                {
                    gridControl2.Visible = false;
                    gridControl1.Visible = true;

                    if (sSTCode.ToLower() == "wp")
                    {
                        sSQL = @"
SELECT * FROM [dbo].[_SaleBillVouchExportToCSV3] 
WHERE cSBVCode = 'aaaaaa' 
ORDER BY autoid 
";
                        sSQL = sSQL.Replace("aaaaaa", s单据号);
                        dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                    }
                    gridControl1.DataSource = dt;
                }
                else
                {
                    sSQL = @"
SELECT * FROM [dbo].[_SaleBillVouchExportToCSV2] 
WHERE cSBVCode = 'aaaaaa' 

";
                    sSQL = sSQL.Replace("aaaaaa", s单据号);
                    dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                    gridControl1.Visible = false;
                    gridControl2.Visible = true;
                    gridControl2.DataSource = dt;
                    gridView2.BestFitColumns();
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "csv";
                if (sSTCode.ToLower() != "ic")
                {
                    sF.FileName = "EPJ(" + sSTCode + "DO)_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                }
                else
                {
                    sF.FileName = "EPJ3DO_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                }
                sF.Filter = "CSV文件(*.csv)|*.csv|All(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }
                string sPath = sF.FileName;
                if (sSTCode.ToLower() != "ic")
                {
                    gridView1.ExportToCsv(sPath);
                }
                else
                {
                    gridView2.ExportToCsv(sPath);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error:" + ee.Message);
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

        private void btnGroupbyItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string sCode = gridView1.GetRowCellValue(i, gridColPARENTCODE).ToString().Trim();
                    for (int j = 0; j < aList.Count; j++)
                    {
                        if (aList[j].ToString().Trim() == sCode)
                            continue;
                    }
                    aList.Add(sCode);

                    decimal dAmount = 0;
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        string sCode2 = gridView1.GetRowCellValue(j, gridColPARENTCODE).ToString().Trim();
                        if (sCode == sCode2)
                        {
                            dAmount = dAmount + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColDELIVERYQTY)) * BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColSEPPLTPRICE));
                        }
                    }
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        string sCode2 = gridView1.GetRowCellValue(j, gridColPARENTCODE).ToString().Trim();
                        if (sCode == sCode2)
                        {
                            gridView1.SetRowCellValue(j, gridColSEPAMOUNT, BaseFunction.ReturnDecimal(dAmount, 2));
                        }
                    }
                }
                btnExport_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error:" + ee.Message);
            }
        }
    }
}
