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
    public partial class frmPurBillVouch : Form
    {
        public frmPurBillVouch()
        {
            InitializeComponent();

            purBillVouch1.Conn = Config.ConnStr;
            purBillVouch1.sUserName = "demo";
            purBillVouch1.sUserID = "demo";
            purBillVouch1.sAccID = "999";
            purBillVouch1.sLogDate = "2016-5-3";
        }
    }
}
