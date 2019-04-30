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
    public partial class Frm条形码扫描记录查看 : Form
    {
        public Frm条形码扫描记录查看()
        {
            InitializeComponent();

            printBarCode_SEL1.Conn = Config.ConnStr;
            printBarCode_SEL1.sUserID = "demo";
            printBarCode_SEL1.sUserName = "demo";
            printBarCode_SEL1.sAccID = "001";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
