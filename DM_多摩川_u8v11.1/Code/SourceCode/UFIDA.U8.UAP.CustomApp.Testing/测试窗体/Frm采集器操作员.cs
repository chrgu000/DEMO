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
    public partial class Frm采集器操作员 : Form
    {
        public Frm采集器操作员()
        {
            InitializeComponent();

            smartUser1.Conn = Config.ConnStr;
            smartUser1.sUserID = "demo";
            smartUser1.sUserName = "demo";
            smartUser1.sAccID = "001";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
