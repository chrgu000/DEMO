using System;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.MetaData;
using System.Globalization;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm发票汇总明细表 f = new Frm发票汇总明细表();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Frm发货单生成发票 f = new Frm发货单生成发票();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

    }
}
