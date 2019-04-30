using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class FrmSendMail : Form
    {
       

        public FrmSendMail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddress.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("邮件地址不能为空！");
                    return;
                }

                if (txtMail.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("邮件内容不能为空！");
                    return;
                }

                系统服务.ClseMail clsMail = new 系统服务.ClseMail();
                clsMail.MailSend(txtAddress.Text.Trim(), txtSubject.Text.Trim(), txtMail.Text.Trim());

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("邮件发送失败！ " + ee.Message);
            }
        }
    }
}