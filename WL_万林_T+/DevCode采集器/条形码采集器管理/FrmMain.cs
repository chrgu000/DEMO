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
            this.Text = MobileBaseDLL.ClsBaseDataInfo.sConnServer;

            Frm登录 f登陆 = new Frm登录();
            DialogResult d = f登陆.ShowDialog();
            if (d != DialogResult.Yes)
            {
                MessageBox.Show("登陆失败");
                this.Close();
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Frm其他出库 frm = new Frm其他出库();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void btn作废_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Frm撤销出库 frm = new Frm撤销出库();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}