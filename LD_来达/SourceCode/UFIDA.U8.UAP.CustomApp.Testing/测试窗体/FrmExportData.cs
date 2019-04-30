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
    public partial class FrmExportData : Form
    {
        public FrmExportData()
        {
            InitializeComponent();

            purchasePlan1.Conn = Config.ConnStr;
            purchasePlan1.sUserName = "demo";
            purchasePlan1.sUserID = "demo";
            purchasePlan1.sAccID = "003";
            purchasePlan1.sLogDate = "2016-1-9";
        }
    }
}
