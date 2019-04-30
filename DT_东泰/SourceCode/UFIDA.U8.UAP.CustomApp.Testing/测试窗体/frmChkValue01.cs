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
    public partial class frmChkValue01 : Form
    {
        public frmChkValue01()
        {
            InitializeComponent();

            chkValue011.Conn = Config.ConnStr;
            chkValue011.sUserName = "demo";
            chkValue011.sUserID = "demo";
            chkValue011.sAccID = "901";
            chkValue011.sLogDate = "2018-10-01";
        }
    }
}
