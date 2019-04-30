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
    public partial class FrmWorkAttendance : Form
    {
        public FrmWorkAttendance()
        {
            InitializeComponent();

            rdIn1.Conn = Config.ConnStr;
            rdIn1.sUserName = "demo";
            rdIn1.sUserID = "demo";
            rdIn1.sAccID = "002";
        }
    }
}
