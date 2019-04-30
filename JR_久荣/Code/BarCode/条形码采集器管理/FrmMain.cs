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
            try
            {

                Frm登录 f登陆 = new Frm登录();
                DialogResult d = f登陆.ShowDialog();
                if (d != DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ee)
            {
                Msg(ee.Message);
            }
        }

        private void btn现品票登记_Click(object sender, EventArgs e)
        {
            try
            {
                Frm现品票登记 f = new Frm现品票登记();
                f.ShowDialog();
                //f.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ee)
            {
                Msg(ee.Message);
            }
        }

        private void btn出库_Click(object sender, EventArgs e)
        {
            try
            {
                Frm出库 f = new Frm出库();
                f.ShowDialog();
                //f.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ee)
            {
                Msg(ee.Message);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}