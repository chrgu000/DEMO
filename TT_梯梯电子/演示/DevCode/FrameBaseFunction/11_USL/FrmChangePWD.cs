using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmChangePWD : Form
    {
        public FrmChangePWD()
        {
            InitializeComponent();
            
        }

        public string sNewPWD;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtpwd2.Text.Trim() == txtpwd1.Text.Trim())
            {
                sNewPWD = txtpwd1.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("密码不一致,请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpwd1.Focus();
            }
        }
    }
}