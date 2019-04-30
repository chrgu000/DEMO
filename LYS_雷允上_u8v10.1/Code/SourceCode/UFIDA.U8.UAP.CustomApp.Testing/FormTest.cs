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

        private void button14_Click(object sender, EventArgs e)
        {
            FormSa_Type fm = new FormSa_Type();
            fm.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FormSa_CloseBill fm = new FormSa_CloseBill();
            fm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form销售发票导入 fm = new Form销售发票导入();
            fm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form销售发货单导入 fm = new Form销售发货单导入();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSa_Certificate fm = new FormSa_Certificate();
            fm.ShowDialog();
        }
    }
}
