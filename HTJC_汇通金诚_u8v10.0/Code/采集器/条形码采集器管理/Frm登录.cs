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
    public partial class Frm登录 : FrmBase
    {
        public Frm登录()
        {
            InitializeComponent();
        }

        private void btn登录_Click(object sender, EventArgs e)
        {
            try
            {
                string sUid = txt账号.Text.Trim();
                string sPwd = clsDES.Encrypt(txt密码.Text.Trim());
                
                //object o = clsWeb.b登陆(sUid,sPwd);
                if (clsWeb.b登陆(sUid, sPwd))
                {

                    this.DialogResult = DialogResult.Yes;
                    sUserID = sUid;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("账号、密码不匹配");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Frm登录_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime d = clsWeb.dtm当前服务器时间();
                if (d > Convert.ToDateTime("1900-01-01"))
                {
                    dtmLogin.Value = d;
                }

                txt账号.Focus();
            }
            catch (Exception ee)
            {

            }
        }

        private void msgBox_Load(object sender, EventArgs e)
        {

        }

        private void txt账号_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt账号.Text.Trim() != "" && e.KeyCode == Keys.Enter)
                {
                    txt密码.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void txt密码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btn登录_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}