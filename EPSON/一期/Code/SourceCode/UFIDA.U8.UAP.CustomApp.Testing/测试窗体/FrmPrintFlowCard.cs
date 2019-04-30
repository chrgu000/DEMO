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
    public partial class FrmPrintFlowCard : Form
    {
        public FrmPrintFlowCard()
        {
            InitializeComponent();

            printFlowCard1.Conn = Config.ConnStr;
            printFlowCard1.sUserName = "demo";
            printFlowCard1.sUserID = "demo";
            printFlowCard1.sAccID = "999";
            printFlowCard1.sLogDate = "2016-5-3";
        }
    }
}
