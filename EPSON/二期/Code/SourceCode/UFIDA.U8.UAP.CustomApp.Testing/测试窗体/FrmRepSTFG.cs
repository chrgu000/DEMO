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
    public partial class FrmRepSTFG : Form
    {
        public FrmRepSTFG()
        {
            InitializeComponent();

            repPur1.Conn = Config.ConnStr;
            repPur1.sUserName = "demo";
            repPur1.sUserID = "demo";
            repPur1.sAccID = "999";
            repPur1.sLogDate = "2016-5-3";
        }

        private void FrmRepSTFG_Load(object sender, EventArgs e)
        {
          
        }
    }
}
