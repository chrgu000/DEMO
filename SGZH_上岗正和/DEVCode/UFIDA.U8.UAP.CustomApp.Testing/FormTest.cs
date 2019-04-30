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

        private void button13_Click(object sender, EventArgs e)
        {
            Form销售发票导入 fm = new Form销售发票导入();
            fm.ShowDialog();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Form销售发票导入 fm = new Form销售发票导入();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form收款单导入 fm = new Form收款单导入();
            fm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form结算方式对应表 fm = new Form结算方式对应表();
            fm.ShowDialog();
        }
    }
}
