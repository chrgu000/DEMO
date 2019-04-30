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
    public partial class FrmDSSaleBaseInfo : Form
    {
        public FrmDSSaleBaseInfo()
        {
            InitializeComponent();

            rep1.Conn = Config.ConnStr;
            rep1.sUserName = "demo";
            rep1.sUserID = "demo";
            rep1.sAccID = "004";
            rep1.sLogDate = "2017-6-9";
        }
    }
}
