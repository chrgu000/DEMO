using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmMailSend : Form
    {
        public FrmMailSend()
        {
            InitializeComponent();
        }

        public FrmMailSend(string smail, string shead, string stext)
        {
            InitializeComponent();

            txtAddress.Text = smail;
            txtMail.Text = stext;
            txtSubject.Text = shead;
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

                ClseMail clsMail = new ClseMail();
                clsMail.MailSend(txtAddress.Text.Trim(), txtSubject.Text.Trim(), txtMail.Text.Trim());

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("邮件发送失败！ " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
