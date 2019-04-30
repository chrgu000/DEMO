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
    public partial class Frm插件权限设置 : Form
    {
        public Frm插件权限设置()
        {
            InitializeComponent();


            userRight1.Conn = Config.ConnStr;
            userRight1.sUserID = "demo";
            userRight1.sUserName = "demo";
            userRight1.sAccID = "001";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
