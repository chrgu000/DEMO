using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Smartclient
{
    public partial class FrmChangePwd : FrmBase
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                txtUid.Enabled = false;
                txtUid.Text = TH.Smart.BaseClass.ClsBaseDataInfo.sUid;
                if (txtUid.Text.Trim() == "")
                {
                    throw new Exception("加载登陆账号失败");
                }
            }
            catch (Exception ee)
            {
                MsgBox("修改密码失败", ee.Message);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sUid = txtUid.Text.Trim();

                txtUid.Text = sUid;
                string sOldPwd = clsDES.Encrypt(txtOldPwd.Text.Trim());
                string sNewPwd = txtNewPwd.Text.Trim();
                string sNewPwd2 = txtNewPwd2.Text.Trim();

                if (sNewPwd != sNewPwd2)
                {
                    throw new Exception("两次密码输入不一致");
                }

                string s = clsWeb.sUpdatePwd(sUid, clsDES.Encrypt(sNewPwd), sOldPwd);
               if (s.Trim().Length > 0)
               {
                   throw new Exception(s);
               }
               MessageBox.Show("修改密码成功，下次登陆请使用新密码");

               this.DialogResult = DialogResult.Yes;
            }
            catch (Exception ee)
            {
                MsgBox("修改密码失败", ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

    }
}