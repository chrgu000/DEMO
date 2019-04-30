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
    public partial class Frm高开返利核销单_SZ : Form
    {
        public Frm高开返利核销单_SZ()
        {
            InitializeComponent();

            高开返利核销单_SZ1.Conn = Config.ConnStr;
            高开返利核销单_SZ1.sUserID = "demo";
            高开返利核销单_SZ1.sUserName = "demo";
            高开返利核销单_SZ1.sAccID = "008";
            高开返利核销单_SZ1.sLogDate = "2019-03-28";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
