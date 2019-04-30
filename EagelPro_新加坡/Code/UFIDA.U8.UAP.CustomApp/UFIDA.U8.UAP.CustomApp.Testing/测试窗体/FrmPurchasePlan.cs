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
    public partial class FrmPurchasePlan : Form
    {
        public FrmPurchasePlan()
        {
            InitializeComponent();

            purchasePlan1.Conn = Config.ConnStr;
            purchasePlan1.sUserName = "demo";
            purchasePlan1.sUserID = "demo";
            purchasePlan1.sAccID = "101";
            purchasePlan1.sLogDate = "2017-1-9";
        }
    }
}
