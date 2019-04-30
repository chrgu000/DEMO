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
    public partial class FrmCustomerFeedback : Form
    {
        public FrmCustomerFeedback()
        {
            InitializeComponent();

            customerFeedback1.Conn = Config.ConnStr;
            customerFeedback1.sUserName = "demo";
            customerFeedback1.sUserID = "demo";
            customerFeedback1.sAccID = "999";
            customerFeedback1.sLogDate = "2016-5-3";
        }
    }
}
