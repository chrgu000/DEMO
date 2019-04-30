using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;

namespace WindowsFormsApplication1
{
    public partial class Frm箱码打印 : Form
    {
        public Frm箱码打印()
        {
            InitializeComponent();


            printBarCode_Box1.Conn = Config.ConnStr;
            printBarCode_Box1.sUserID = "demo";
            printBarCode_Box1.sUserName = "demo";
            printBarCode_Box1.sAccID = "001";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
