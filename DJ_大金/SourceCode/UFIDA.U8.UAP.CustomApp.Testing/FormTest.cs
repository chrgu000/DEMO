using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.MetaData;

namespace WindowsFormsApplication1
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void btn凭证导入_Click(object sender, EventArgs e)
        {
            Frm凭证导入 frm = new Frm凭证导入();
            frm.ShowDialog();
        }

        private void btn科目对照_Click(object sender, EventArgs e)
        {
            Frm科目对照 frm = new Frm科目对照();
            frm.ShowDialog();
        }

        private void btn凭证导入2_Click(object sender, EventArgs e)
        {
            Frm凭证导入2 frm = new Frm凭证导入2();
            frm.ShowDialog();
        }
     
    }
}
