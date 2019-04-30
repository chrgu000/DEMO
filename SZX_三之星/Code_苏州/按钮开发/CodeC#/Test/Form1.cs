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
            clsU8.Frm销售订单导入 frm = new clsU8.Frm销售订单导入("192.168.150.121", "sa", "189.cn", "UFDATA_008_2016", "0000000025", "30105");
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //clsU8.Frm其他入库单 frm = new clsU8.Frm其他入库单("192.168.150.111", "sa", "189.cn", "UFDATA_008_2016", "0000000004", "30105");
            //frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            clsU8.Frm产成品入库单导入 frm= new clsU8.Frm产成品入库单导入("192.168.150.121", "sa", "189.cn", "UFDATA_008_2016", "0000000025", "30105");
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clsU8.Frm采购订单导入 frm = new clsU8.Frm采购订单导入("192.168.150.121", "sa", "189.cn", "UFDATA_008_2016", "0000000025", "30105");
            clsU8.Frm采购订单导入 frm = new clsU8.Frm采购订单导入("7.19.111.101", "sa", "911120", "UFDATA_008_2016", "0000000025", "30105");
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clsU8.Frm采购入库单导入 frm = new clsU8.Frm采购入库单导入("192.168.150.121", "sa", "189.cn", "UFDATA_008_2016", "0000000025", "30105");
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clsU8.Frm发货单导入 frm = new clsU8.Frm发货单导入("192.168.150.121", "sa", "189.cn", "UFDATA_008_2016", "0000000025", "30105");
            frm.Show();
        }

        private void btnImportSale2_Click(object sender, EventArgs e)
        {
            clsU8.Frm销售订单导入_上海 frm = new clsU8.Frm销售订单导入_上海("192.168.150.121", "sa", "189.cn", "UFDATA_008_2016", "0000000025", "30105");
            frm.Show();
        }

    }
}
