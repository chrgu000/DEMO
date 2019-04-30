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
    public partial class FrmPayment : Form
    {
        public FrmPayment()
        {
            InitializeComponent();

            payment1.Conn = Config.ConnStr;
            payment1.sUserName = "demo";
            payment1.sUserID = "demo";
            payment1.sAccID = "999";
            payment1.sLogDate = "2016-5-3";
        }
    }
}
