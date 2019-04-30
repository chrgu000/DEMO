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


        private void button15_Click(object sender, EventArgs e)
        {
            FormSa_BOMAll fm = new FormSa_BOMAll();
            fm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSa_BOMAll2 fm = new FormSa_BOMAll2();
            fm.ShowDialog();
        }
    }
}
