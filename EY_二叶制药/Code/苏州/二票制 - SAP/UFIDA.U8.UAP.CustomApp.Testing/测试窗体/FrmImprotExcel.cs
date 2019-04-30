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
    public partial class FrmImprotExcel : Form
    {
        public FrmImprotExcel()
        {
            InitializeComponent();

            improtExcel1.Conn = Config.ConnStr;
            improtExcel1.sUserID = "demo";
            improtExcel1.sUserName = "demo";
            improtExcel1.sAccID = "008";
            improtExcel1.sLogDate = "2018-04-28";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {


        }
    }
}
