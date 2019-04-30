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
    public partial class FrmeMail : Form
    {
        public FrmeMail()
        {
            InitializeComponent();


            eMail1.Conn = Config.ConnStr;
            eMail1.sUserID = "demo";
            eMail1.sUserName = "demo";
            eMail1.sAccID = "001";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
