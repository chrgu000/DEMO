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
    public partial class Frm产成品入库单条形码打印 : Form
    {
        public Frm产成品入库单条形码打印()
        {
            InitializeComponent();

            printBarCode_RdRecord101.Conn = Config.ConnStr;
            printBarCode_RdRecord101.sUserID = "demo";
            printBarCode_RdRecord101.sUserName = "demo";
            printBarCode_RdRecord101.sAccID = "001";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {

        }
    }
}
