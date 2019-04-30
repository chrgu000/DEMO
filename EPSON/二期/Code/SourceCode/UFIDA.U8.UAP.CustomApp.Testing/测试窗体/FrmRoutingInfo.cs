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
    public partial class FrmRoutingInfo : Form
    {
        public FrmRoutingInfo()
        {
            InitializeComponent();

            routingInfo1.Conn = Config.ConnStr;
            routingInfo1.sUserName = "demo";
            routingInfo1.sUserID = "demo";
            routingInfo1.sAccID = "999";
            routingInfo1.sLogDate = "2016-5-3";
        }
    }
}
