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
    public partial class FrmInvProcess : Form
    {
        public FrmInvProcess()
        {
            InitializeComponent();

            invProcess1.Conn = Config.ConnStr;
            invProcess1.sUserName = "demo";
            invProcess1.sUserID = "demo";
            invProcess1.sAccID = "999";
            invProcess1.sLogDate = "2016-5-3";
        }
    }
}
