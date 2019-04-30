using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarCode
{
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Frm登录 f登陆 = new Frm登录();
            DialogResult d = f登陆.ShowDialog();
            if (d != DialogResult.Yes)
            {
                MessageBox.Show("登陆失败");
                this.Close();
            }
        }

        private void btn采购入库_Click(object sender, EventArgs e)
        {
            Frm采购入库单 f = new Frm采购入库单();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btn材料出库_Click(object sender, EventArgs e)
        {
            Frm材料出库单 f = new Frm材料出库单();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btn产品入库_Click(object sender, EventArgs e)
        {
            Frm产品入库单 f = new Frm产品入库单();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btn销售出库_Click(object sender, EventArgs e)
        {
            Frm销售出库单 f = new Frm销售出库单();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
        }

        private void btn盘点_Click(object sender, EventArgs e)
        {
            Frm盘点 f = new Frm盘点();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm物料查询 f = new Frm物料查询();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm货位查询 f = new Frm货位查询();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm货位调拨 f = new Frm货位调拨();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

    }
}