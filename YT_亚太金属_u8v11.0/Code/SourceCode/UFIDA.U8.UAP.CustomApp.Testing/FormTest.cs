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

        private void button2_Click(object sender, EventArgs e)
        {
            Frm到货单条形码打印 f = new Frm到货单条形码打印();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm存货条形码打印 f = new Frm存货条形码打印();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm凭证传递 f = new Frm凭证传递();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            帐套科目归属表 f = new 帐套科目归属表();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            帐套档案对照表 f = new 帐套档案对照表();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frm产品入库条码测试 f = new Frm产品入库条码测试();
            f.ShowDialog();
        }
    }
}
