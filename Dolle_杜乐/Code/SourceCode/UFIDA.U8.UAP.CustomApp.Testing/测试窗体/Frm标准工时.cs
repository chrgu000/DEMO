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
    public partial class Frm标准工时 : Form
    {
        public Frm标准工时()
        {
            InitializeComponent();

            标准工时1.Conn = Config.ConnStr;
            标准工时1.sUserName = "demo";
            标准工时1.sUserID = "demo";
            标准工时1.sAccID = "200";
            标准工时1.sLogDate = "2016-01-12";
        }
    }
}
