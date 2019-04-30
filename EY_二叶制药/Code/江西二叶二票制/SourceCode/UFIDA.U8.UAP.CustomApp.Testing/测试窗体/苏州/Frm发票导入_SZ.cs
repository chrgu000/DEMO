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
    public partial class Frm发票导入_SZ : Form
    {
        public Frm发票导入_SZ()
        {
            InitializeComponent();

            发票导入_SZ1.Conn = Config.ConnStr;
            发票导入_SZ1.sUserID = "demo";
            发票导入_SZ1.sUserName = "demo";
            发票导入_SZ1.sAccID = "008";
            发票导入_SZ1.sLogDate = "2019-03-28";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
