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
    public partial class Frm科目对照 : Form
    {
        public Frm科目对照()
        {
            InitializeComponent();

            gL_Code1.Conn = Config.ConnStr;
            gL_Code1.sUserID = "demo";
            gL_Code1.sUserName = "demo";
            gL_Code1.sLogDate = "2018-12-31";
        }
    }
}
