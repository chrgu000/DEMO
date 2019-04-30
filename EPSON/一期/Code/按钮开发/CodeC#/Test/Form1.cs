using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clsU8.Frm销售订单导入 frm = new clsU8.Frm销售订单导入("192.168.150.111", "sa", "189.cn", "UFDATA_099_2016", "ES20160000001", "TH");
            //frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsU8.Frm其他入库单 frm = new clsU8.Frm其他入库单(".", "sa", "189.cn", "UFDATA_001_2016", "ES20160000001", "TH");
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsU8.Frm收款单导入 frm = new clsU8.Frm收款单导入("192.168.150.111", "sa", "189.cn", "UFDATA_099_2016", "0000000004", "TH");
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clsU8.Frm销售发票导出 frm = new clsU8.Frm销售发票导出("192.168.150.111", "sa", "189.cn", "UFDATA_001_2016", "WC2016000001", "TH");
            frm.ShowDialog();
        }
    }
}
