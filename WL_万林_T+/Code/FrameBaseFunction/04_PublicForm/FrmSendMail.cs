using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
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
                    MessageBox.Show("�ʼ���ַ����Ϊ�գ�");
                    return;
                }

                if (txtMail.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("�ʼ����ݲ���Ϊ�գ�");
                    return;
                }

                FrameBaseFunction.ClseMail clsMail = new FrameBaseFunction.ClseMail();
                clsMail.MailSend(txtAddress.Text.Trim(), txtSubject.Text.Trim(), txtMail.Text.Trim());

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("�ʼ�����ʧ�ܣ� " + ee.Message);
            }
        }
    }
}