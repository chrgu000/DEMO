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

        private void btn存货标签打印_Click(object sender, EventArgs e)
        {
            Frm存货标签打印 f = new Frm存货标签打印();
            f.ShowDialog();
        }

        private void btn货位标签打印_Click(object sender, EventArgs e)
        {
            Frm货位标签打印 f = new Frm货位标签打印();
            f.ShowDialog();
        }

        private void btn产品标签打印_Click(object sender, EventArgs e)
        {
            Frm产品标签打印 f = new Frm产品标签打印();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm采购标签打印 f = new Frm采购标签打印();
            f.ShowDialog();
        }

        private void btn发货_Click(object sender, EventArgs e)
        {
            Frm发货打印 f = new Frm发货打印();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm现存产品标签打印 f = new Frm现存产品标签打印();
            f.ShowDialog();
        }
    }
}
