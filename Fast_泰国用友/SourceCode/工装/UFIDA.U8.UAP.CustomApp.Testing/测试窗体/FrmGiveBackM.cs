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
    public partial class FrmGiveBackM : Form
    {
        public FrmGiveBackM()
        {
            InitializeComponent();

            GiveBackM1.Conn = Config.ConnStr;
            GiveBackM1.sUserName = "demo";
            GiveBackM1.sUserID = "demo";
            GiveBackM1.sAccID = "200";
            GiveBackM1.sLogDate = "2015-12-12";
        }
    }
}
