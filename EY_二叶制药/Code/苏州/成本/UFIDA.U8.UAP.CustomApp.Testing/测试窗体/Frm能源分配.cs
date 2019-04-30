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
    public partial class Frm能源分配 : Form
    {
        public Frm能源分配()
        {
            InitializeComponent();

            能源分配1.Conn = Config.ConnStr;
            能源分配1.sUserID = "demo";
            能源分配1.sUserName = "demo";
            能源分配1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
