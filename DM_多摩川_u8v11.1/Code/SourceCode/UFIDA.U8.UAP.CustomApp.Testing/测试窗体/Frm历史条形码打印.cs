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
    public partial class Frm历史条形码打印 : Form
    {
        public Frm历史条形码打印()
        {
            InitializeComponent();

            printBarCode_History1.Conn = Config.ConnStr;
            printBarCode_History1.sUserID = "demo";
            printBarCode_History1.sUserName = "demo";
            printBarCode_History1.sAccID = "001";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
