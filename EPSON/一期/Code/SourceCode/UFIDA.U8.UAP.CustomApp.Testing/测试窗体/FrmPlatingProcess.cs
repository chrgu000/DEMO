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
    public partial class FrmPlatingProcess : Form
    {
        public FrmPlatingProcess()
        {
            InitializeComponent();

            platingProcess1.Conn = Config.ConnStr;
            platingProcess1.sUserName = "demo";
            platingProcess1.sUserID = "demo";
            platingProcess1.sAccID = "999";
            platingProcess1.sLogDate = "2016-5-3";
        }
    }
}
