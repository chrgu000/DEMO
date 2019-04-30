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
    public partial class FrmFrockClamp : Form
    {
        public FrmFrockClamp()
        {
            InitializeComponent();

            frockClamp1.Conn = Config.ConnStr;
            frockClamp1.sUserName = "demo";
            frockClamp1.sUserID = "demo";
            frockClamp1.sAccID = "200";
            frockClamp1.sLogDate = "2015-12-12";
        }
    }
}
