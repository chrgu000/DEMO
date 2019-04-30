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

        private void btn费用录入_Click(object sender, EventArgs e)
        {
            clsU8.Frm费用录入 frm = new clsU8.Frm费用录入("192.168.30.130", "sa", "189.cn", "UFDATA_901_2018", "1000000001", "demo");
            frm.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
