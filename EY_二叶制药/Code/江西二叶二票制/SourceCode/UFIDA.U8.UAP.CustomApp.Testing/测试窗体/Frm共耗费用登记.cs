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
    public partial class Frm共耗费用登记 : Form
    {
        public Frm共耗费用登记()
        {
            InitializeComponent();

            费用登记1.Conn = Config.ConnStr;
            费用登记1.sUserID = "demo";
            费用登记1.sUserName = "demo";
            费用登记1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
