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
    public partial class frm出货完成 : Form
    {
        public frm出货完成()
        {
            InitializeComponent();

            出货完成1.Conn = Config.ConnStr;
            出货完成1.sUserName = "demo";
            出货完成1.sUserID = "demo";
            出货完成1.sAccID = "908";
            出货完成1.sLogDate = "2016-1-9";
        }
    }
}
