using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Frm存货条形码打印 : Form
    {
        public Frm存货条形码打印()
        {
            InitializeComponent();

            存货条形码打印1.Conn = Config.ConnStr;
            存货条形码打印1.sUserID = "demo";
            存货条形码打印1.sUserName = "demo";
            存货条形码打印1.sAccID = "100";
        }

        private void rm存货条形码打印_Load(object sender, EventArgs e)
        {

        }
    }
}
