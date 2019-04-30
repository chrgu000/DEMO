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
    public partial class Frm采购入库单条形码打印 : Form
    {
        public Frm采购入库单条形码打印()
        {
            InitializeComponent();

            printBarCode_RdRecord011.Conn = Config.ConnStr;
            printBarCode_RdRecord011.sUserID = "demo";
            printBarCode_RdRecord011.sUserName = "demo";
            printBarCode_RdRecord011.sAccID = "001";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
