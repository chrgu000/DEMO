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
    public partial class FrmActionFCost : Form
    {
        public FrmActionFCost()
        {
            InitializeComponent();

            actionFCost1.Conn = Config.ConnStr;
            actionFCost1.sUserName = "demo";
            actionFCost1.sUserID = "demo";
            actionFCost1.sAccID = "999";
            actionFCost1.sLogDate = "2016-5-3";
        }
    }
}
