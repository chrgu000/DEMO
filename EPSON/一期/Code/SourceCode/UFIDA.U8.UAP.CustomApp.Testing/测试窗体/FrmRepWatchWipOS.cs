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
    public partial class FrmRepWatchWipOS : Form
    {
        public FrmRepWatchWipOS()
        {
            InitializeComponent();

            repWatchWipOS1.Conn = Config.ConnStr;
            repWatchWipOS1.sUserName = "demo";
            repWatchWipOS1.sUserID = "demo";
            repWatchWipOS1.sAccID = "999";
            repWatchWipOS1.sLogDate = "2016-5-3";
        }

        private void FrmRepWatchWipOS_Load(object sender, EventArgs e)
        {
          
        }
    }
}
