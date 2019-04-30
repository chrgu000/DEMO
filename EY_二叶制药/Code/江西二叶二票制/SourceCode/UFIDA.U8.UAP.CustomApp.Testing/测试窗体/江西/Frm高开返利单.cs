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
    public partial class Frm高开返利单 : Form
    {
        public Frm高开返利单()
        {
            InitializeComponent();

            高开返利单1.Conn = Config.ConnStr;
            高开返利单1.sUserID = "demo";
            高开返利单1.sUserName = "demo";
            高开返利单1.sAccID = "008";
            高开返利单1.sLogDate = "2018-04-28";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
