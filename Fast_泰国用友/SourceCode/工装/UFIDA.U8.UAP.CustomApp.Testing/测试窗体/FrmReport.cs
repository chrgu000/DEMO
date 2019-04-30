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
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();

            Report1.Conn = Config.ConnStr;
            Report1.sUserName = "demo";
            Report1.sUserID = "demo";
            Report1.sAccID = "200";
            Report1.sLogDate = "2015-12-12";
        }
    }
}
