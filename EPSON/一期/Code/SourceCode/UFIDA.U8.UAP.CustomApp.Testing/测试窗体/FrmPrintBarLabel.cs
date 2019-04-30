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
    public partial class FrmPrintBarLabel : Form
    {
        public FrmPrintBarLabel()
        {
            InitializeComponent();

            printBarLabel1.Conn = Config.ConnStr;
            printBarLabel1.sUserName = "demo";
            printBarLabel1.sUserID = "demo";
            printBarLabel1.sAccID = "999";
            printBarLabel1.sLogDate = "2016-5-3";
        }
    }
}
