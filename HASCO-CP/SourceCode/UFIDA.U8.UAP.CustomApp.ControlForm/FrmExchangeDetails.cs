using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmExchangeDetails : Form
    {
        public string sYear;
        public string sMonth;

        public FrmExchangeDetails(string year,string month)
        {
            InitializeComponent();

            this.sYear = year;
            this.sMonth = month;
        }

        private void btnExport_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmExchangeDetails_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void GetGrid()
        {
            try
            {
                if (sYear.Trim() == "")
                {
                    throw new Exception("Please set year");
                }
                if (sMonth.Trim() == "")
                {
                    throw new Exception("Please set month");
                }

                int iRow = gridView1.FocusedRowHandle;

                string sSQL = @"
select * 
from _AmountOfExchangeProfitAndLoss 
where iyear = aaaaaaaa and iperiod = bbbbbbbb
";
                sSQL = sSQL.Replace("aaaaaaaa", sYear);
                sSQL = sSQL.Replace("bbbbbbbb", sMonth);
                DataTable dt = TH.BaseClass.DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;

                gridView1.BestFitColumns();

                if (iRow >= 0 && iRow >= dt.Rows.Count)
                {
                    gridView1.FocusedRowHandle = iRow;
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
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
    }
}
