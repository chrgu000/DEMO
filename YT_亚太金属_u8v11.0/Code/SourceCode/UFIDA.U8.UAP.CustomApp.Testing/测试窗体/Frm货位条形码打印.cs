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
    public partial class Frm货位条形码打印 : Form
    {
        public Frm货位条形码打印()
        {
            InitializeComponent();

            货位条形码打印1.Conn = Config.ConnStr;
            货位条形码打印1.sUserID = "demo";
            货位条形码打印1.sUserName = "demo";
            货位条形码打印1.sAccID = "100";
        }

        private void Frm货位条形码打印_Load(object sender, EventArgs e)
        {

        }
    }
}
