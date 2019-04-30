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
    public partial class FrmGiveBack : Form
    {
        public FrmGiveBack()
        {
            InitializeComponent();

            giveBack1.Conn = Config.ConnStr;
            giveBack1.sUserName = "demo";
            giveBack1.sUserID = "demo";
            giveBack1.sAccID = "200";
            giveBack1.sLogDate = "2015-12-12";
        }
    }
}
