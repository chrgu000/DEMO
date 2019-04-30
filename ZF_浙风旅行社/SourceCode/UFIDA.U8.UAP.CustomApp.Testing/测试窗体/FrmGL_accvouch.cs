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
    public partial class FrmGL_accvouch : Form
    {
        public FrmGL_accvouch()
        {
            InitializeComponent();

            gL_accvouch1.Conn = Config.ConnStr;
            gL_accvouch1.sUserName = "demo1";
            gL_accvouch1.sUserID = "demo1";
            gL_accvouch1.sAccID = "200";
            gL_accvouch1.sLogDate = "2016-1-9";
        }
    }
}
