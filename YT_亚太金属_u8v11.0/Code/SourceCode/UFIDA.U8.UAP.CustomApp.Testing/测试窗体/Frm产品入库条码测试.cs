using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Frm产品入库条码测试 : Form
    {
        public Frm产品入库条码测试()
        {
            InitializeComponent();

            产品入库条码测试1.Conn = Config.ConnStr;
            产品入库条码测试1.sUserID = "demo";
            产品入库条码测试1.sUserName = "demo";
            产品入库条码测试1.sAccID = "100";
        }

        private void Frm产品入库条码测试_Load(object sender, EventArgs e)
        {

        }
    }
}
