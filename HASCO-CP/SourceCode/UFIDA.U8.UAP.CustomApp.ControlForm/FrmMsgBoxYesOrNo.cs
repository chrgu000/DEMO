using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmMsgBoxYesOrNo : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FrmMsgBoxYesOrNo()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMsgBox_Load(object sender, EventArgs e)
        {
            this.Text = "Continue to click yes,Cancel to click no";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sPathConfig = Application.StartupPath + @"\ErrInfo.txt";
            SaveFileDialog sa = new SaveFileDialog();
            sa.Filter = "txt files(*.txt)|*.txt";
            sa.DefaultExt = "txt";
            sa.FileName = sPathConfig;
            
            if (DialogResult.OK == sa.ShowDialog())
            {
                sPathConfig = sa.FileName;

                string sErr = richTextBox1.Text.Trim();
                sErr = sErr.Replace("\n", "\r\n");

                if (File.Exists(sPathConfig))
                    File.Delete(sPathConfig);
                File.WriteAllText(sPathConfig, sErr);
                MessageBox.Show("Sucess£¡\nPath£º" + sPathConfig);
            }
        }
    }
}