using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ϵͳ����
{
    public partial class FrmMsgBox : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FrmMsgBox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMsgBox_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sPathConfig = Application.StartupPath +@"\��������.txt";
            if (File.Exists(sPathConfig))
                File.Delete(sPathConfig);
            File.WriteAllText(sPathConfig, richTextBox1.Text.Trim());
            MessageBox.Show("��¼����ɹ���·����" + sPathConfig);
        }
    }
}