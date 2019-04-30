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
    public partial class Frm凭证导入 : Form
    {
        public Frm凭证导入()
        {
            InitializeComponent();

            gL_accvouch1.Conn = Config.ConnStr;
            gL_accvouch1.sUserID = "demo";
            gL_accvouch1.sUserName = "demo";

        }
    }
}
