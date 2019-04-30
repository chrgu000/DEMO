using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FrameBaseFunction;

namespace WorkInformation
{
    public partial class FrmWorkPer : FrameBaseFunction.Frm列表窗体模板
    {
        public string sFCode = "";
        public string sFName = "";

        public FrmWorkPer(string sPer)
        {
            InitializeComponent();

            txtPer.Text = sPer;
        }

        private void FrmWorkPer_Load(object sender, EventArgs e)
        {
            try
            {
                GetPer(txtPer.Text.Trim());
            }
            catch (Exception ee)
            {
                MessageBox.Show("获人员信息失败！  " + ee.Message);
            }
        }

        private void GetPer(string sPer)
        {
            
            string sSQL = "select * from WorkDepment order by FCode";
            gridControl2.DataSource = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from EmployeeInfo where FCode like '%" + sPer + "%' or FName like '%" + sPer + "%' order by FCode";
            gridControl1.DataSource = clsSQLCommond.ExecQuery(sSQL);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                sFCode = gridView1.GetRowCellValue(iRow, gridColFCode).ToString().Trim();
                sFName = gridView1.GetRowCellValue(iRow, gridColFName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回人员信息失败！  " + ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                sFCode = gridView1.GetRowCellValue(iRow, gridColFCode).ToString().Trim();
                sFName = gridView1.GetRowCellValue(iRow, gridColFName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回人员信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow =0;
                if(gridView2.RowCount >0)
                    iRow = gridView2.FocusedRowHandle;

                string s = gridView2.GetRowCellValue(iRow, gridColFID).ToString().Trim();

                string sSQL = "select * from EmployeeInfo where FWorkerGroupID = '" + s + "' order by FCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
            catch
            { }
        }
    }
}