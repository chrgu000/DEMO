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
    public partial class FrmGL_Code : Form
    {
        public FrmGL_Code()
        {
            InitializeComponent();

            gL_Code1.Conn = Config.ConnStr;
            gL_Code1.sUserName = "demo";
            gL_Code1.sUserID = "demo";
            gL_Code1.sAccID = "998";
            gL_Code1.sLogDate = "2016-1-9";
        }
    }
}
