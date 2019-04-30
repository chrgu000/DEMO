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
    public partial class Frm产品材料耗用登记 : Form
    {
        public Frm产品材料耗用登记()
        {
            InitializeComponent();

            printBarCode_SEL1.Conn = Config.ConnStr;
            printBarCode_SEL1.sUserID = "demo";
            printBarCode_SEL1.sUserName = "demo";
            printBarCode_SEL1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
