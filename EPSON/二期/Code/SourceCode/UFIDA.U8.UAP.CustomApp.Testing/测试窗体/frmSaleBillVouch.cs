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
    public partial class frmSaleBillVouch : Form
    {
        public frmSaleBillVouch()
        {
            InitializeComponent();

            saleBillVouch1.Conn = Config.ConnStr;
            saleBillVouch1.sUserName = "demo";
            saleBillVouch1.sUserID = "demo";
            saleBillVouch1.sAccID = "999";
            saleBillVouch1.sLogDate = "2016-5-3";
        }
    }
}
