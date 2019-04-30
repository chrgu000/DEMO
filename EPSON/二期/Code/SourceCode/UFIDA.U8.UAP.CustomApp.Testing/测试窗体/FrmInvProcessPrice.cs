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
    public partial class FrmInvProcessPrice : Form
    {
        public FrmInvProcessPrice()
        {
            InitializeComponent();

            invProcessPrice1.Conn = Config.ConnStr;
            invProcessPrice1.sUserName = "demo";
            invProcessPrice1.sUserID = "demo";
            invProcessPrice1.sAccID = "999";
            invProcessPrice1.sLogDate = "2016-5-3";
        }
    }
}
