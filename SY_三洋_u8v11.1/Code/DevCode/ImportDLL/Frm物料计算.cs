using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ImportDLL
{
    public partial class Frm物料计算 : Form
    {
        TH.DAL.生产排产 DAL = new TH.DAL.生产排产();

        DataTable dtGrid;
        public Frm物料计算(DataTable dt)
        {
            InitializeComponent();

            dtGrid = dt.Copy();
        }

        private void Frm物料计算_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;

                this.WindowState = FormWindowState.Maximized;

                btn刷新_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn刷新_Click(object sender, EventArgs e)
        {
            try
            {
                //gridControl1.DataSource = DAL.GetCheckInventory(dtGrid);

              
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //decimal d = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["仓库现存量"]), 6);
            //decimal d1 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量1"]), 6);
            //decimal d2 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量2"]), 6);
            //decimal d3 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量3"]), 6);

            //if (d3 > d)
            //    e.Appearance.BackColor = Color.LightYellow;
            //if (d2 > d)
            //    e.Appearance.BackColor = Color.Yellow;
            //if (d1 > d)
            //    e.Appearance.BackColor = Color.Tomato;



        }
    }
}
