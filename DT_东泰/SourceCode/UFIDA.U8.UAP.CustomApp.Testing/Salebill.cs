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
    public partial class Salebill : Form
    {
        public Salebill()
        {
            InitializeComponent();

            salebillvouch1.Conn = Config.ConnStr;
            salebillvouch1.sUserName = "demo";
            salebillvouch1.sUserID = "demo";
            salebillvouch1.sAccID = "101";
            salebillvouch1.sLogDate = "2017-9-9";
        }
    }
}
