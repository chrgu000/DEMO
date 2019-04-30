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
    public partial class Frm费用分配 : Form
    {
        public Frm费用分配()
        {
            InitializeComponent();

            费用分配表1.Conn = Config.ConnStr;
            费用分配表1.sUserID = "demo";
            费用分配表1.sUserName = "demo";
            费用分配表1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
