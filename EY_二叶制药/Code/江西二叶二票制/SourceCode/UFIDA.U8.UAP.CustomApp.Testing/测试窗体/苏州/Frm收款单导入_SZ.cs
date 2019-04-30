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
    public partial class Frm收款单导入_SZ : Form
    {
        public Frm收款单导入_SZ()
        {
            InitializeComponent();

            回款导入_SZ1.Conn = Config.ConnStr;
            回款导入_SZ1.sUserID = "demo";
            回款导入_SZ1.sUserName = "demo";
            回款导入_SZ1.sAccID = "008";
            回款导入_SZ1.sLogDate = "2019-03-28";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
