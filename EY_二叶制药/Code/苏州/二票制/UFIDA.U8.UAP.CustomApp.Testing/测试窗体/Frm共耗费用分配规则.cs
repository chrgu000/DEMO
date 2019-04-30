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
    public partial class Frm分配规则 : Form
    {
        public Frm分配规则()
        {
            InitializeComponent();

            分配规则1.Conn = Config.ConnStr;
            分配规则1.sUserID = "demo";
            分配规则1.sUserName = "demo";
            分配规则1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
