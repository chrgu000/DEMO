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
            clsDllForVB.ClaPrintRdRecord cls = new clsDllForVB.ClaPrintRdRecord();
            cls.ShowQC01("192.168.31.222", "sa", "", "UFDATA_100_2014", "0415030155");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsDllForVB.ClaPrintRdRecord cls = new clsDllForVB.ClaPrintRdRecord();
            cls.ShowQC10("192.168.31.222", "sa", "", "UFDATA_100_2014", "0415030155");
        }

    }
}
