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
    public partial class FrmRepSTFGOS : Form
    {
        public FrmRepSTFGOS()
        {
            InitializeComponent();

            repSTFGOS1.Conn = Config.ConnStr;
            repSTFGOS1.sUserName = "demo";
            repSTFGOS1.sUserID = "demo";
            repSTFGOS1.sAccID = "999";
            repSTFGOS1.sLogDate = "2016-5-3";
        }

        private void FrmRepSTFGOS_Load(object sender, EventArgs e)
        {
          
        }
    }
}
