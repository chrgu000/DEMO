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
    public partial class Frm车间材料领用汇总月报 : Form
    {
        public Frm车间材料领用汇总月报()
        {
            InitializeComponent();

            车间材料领用汇总月报1.Conn = Config.ConnStr;
            车间材料领用汇总月报1.sUserID = "demo";
            车间材料领用汇总月报1.sUserName = "demo";
            车间材料领用汇总月报1.sAccID = "002";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
