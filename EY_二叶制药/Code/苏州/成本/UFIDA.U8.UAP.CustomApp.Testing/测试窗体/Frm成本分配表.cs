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
    public partial class Frm成本分配表 : Form
    {
        public Frm成本分配表()
        {
            InitializeComponent();

            成本分配表1.Conn = Config.ConnStr;
            成本分配表1.sUserID = "demo";
            成本分配表1.sUserName = "demo";
            成本分配表1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
