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

        private void button5_Click(object sender, EventArgs e)
        {
            clsU8.Frm发货单导入 frm = new clsU8.Frm发货单导入("192.168.39.101", "sa", "189.cn", "UFDATA_012_2015", "0000000025", "30105");
            frm.Show();
        }
    }
}
