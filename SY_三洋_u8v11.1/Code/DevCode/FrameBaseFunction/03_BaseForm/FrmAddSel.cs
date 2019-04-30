using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmAddSel : Form
    {
        public FrmAddSel()
        {
            InitializeComponent();
        }

        private void FrmAddSel_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="sText">标题</param>
        /// <param name="sInfo">内容</param>
        /// <returns></returns>
        protected DialogResult MsgBox(string sTital, string sInfo)
        {
            FrmMsgBox fMsg = new FrmMsgBox();
            fMsg.richTextBox1.Text = sInfo;
            fMsg.Text = sTital;
            fMsg.ShowDialog();
            return fMsg.DialogResult;
        }

    }
}
