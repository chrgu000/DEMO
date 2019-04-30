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
    public partial class FrmRepWatchWip : Form
    {
        public FrmRepWatchWip()
        {
            InitializeComponent();

            repSale1.Conn = Config.ConnStr;
            repSale1.sUserName = "demo";
            repSale1.sUserID = "demo";
            repSale1.sAccID = "999";
            repSale1.sLogDate = "2016-5-3";
        }

        private void FrmRepWatchWip_Load(object sender, EventArgs e)
        {
          
        }
    }
}
