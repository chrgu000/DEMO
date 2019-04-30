using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;
using System.Data.SqlClient;
using System.Collections;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmExportData : Form
    {
        DataTable dtGrid;

        public FrmExportData(DataTable dt)
        {
            InitializeComponent();

            dtGrid = dt;
        }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                gridControl1.DataSource = dtGrid;

                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                FrmMsgBox msgbox = new FrmMsgBox();
                msgbox.richTextBox1.Text = ee.Message;
                msgbox.ShowDialog();
            }
        }


        private void GridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void btnExportExcel_Click(object sender, EventArgs e)
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
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
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
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}