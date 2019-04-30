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
    public partial class Frm高开返利单列表 : Form
    {
        public Frm高开返利单列表()
        {
            InitializeComponent();

            高开返利单列表1.Conn = Config.ConnStr;
            高开返利单列表1.sUserID = "demo";
            高开返利单列表1.sUserName = "demo";
            高开返利单列表1.sAccID = "001";
            高开返利单列表1.sLogDate = "2017-12-31";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
