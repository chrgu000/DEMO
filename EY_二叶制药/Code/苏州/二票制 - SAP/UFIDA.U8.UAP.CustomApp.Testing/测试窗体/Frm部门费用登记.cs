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
    public partial class Frm部门费用登记 : Form
    {
        public Frm部门费用登记()
        {
            InitializeComponent();

            部门费用登记1.Conn = Config.ConnStr;
            部门费用登记1.sUserID = "demo";
            部门费用登记1.sUserName = "demo";
            部门费用登记1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
