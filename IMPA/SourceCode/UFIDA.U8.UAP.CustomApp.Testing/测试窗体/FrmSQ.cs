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
    public partial class FrmSQ : Form
    {
        public FrmSQ()
        {
            InitializeComponent();

            sq1.Conn = Config.ConnStr;
            sq1.sUserName = "demo";
            sq1.sUserID = "demo";
            sq1.sAccID = "004";
            sq1.sLogDate = "2018-11-18";
        }
    }
}
