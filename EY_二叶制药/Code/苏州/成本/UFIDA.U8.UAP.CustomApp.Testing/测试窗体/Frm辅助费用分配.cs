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
    public partial class Frm辅助费用分配 : Form
    {
        public Frm辅助费用分配()
        {
            InitializeComponent();

            辅助费用分配1.Conn = Config.ConnStr;
            辅助费用分配1.sUserID = "demo";
            辅助费用分配1.sUserName = "demo";
            辅助费用分配1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
