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
            clsU8.Frm包装袋自动出库 frm = new clsU8.Frm包装袋自动出库("192.168.20.125", "sa", "189.cn", "UFDATA_997_2018", "PO2018-1034", "TH");
            frm.ShowDialog();
        }
    }
}
