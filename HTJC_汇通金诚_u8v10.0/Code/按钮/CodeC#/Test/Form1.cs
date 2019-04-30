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

        private void btnPringMO_Click(object sender, EventArgs e)
        {
            clsU8.FrmPrintMO frm = new clsU8.FrmPrintMO("7.3.40.153", "saa", "demohtjc", "UFDATA_001_2013", "MO16101209", "demo");
            frm.ShowDialog();
        }

        private void btnRd32_Click(object sender, EventArgs e)
        {
            clsU8.FrmPrintRd32 frm = new clsU8.FrmPrintRd32("7.3.40.153", "saa", "demohtjc", "UFDATA_001_2013", "0000004619", "demo");
            frm.ShowDialog();
        }
    }
}
