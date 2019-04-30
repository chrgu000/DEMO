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
    public partial class Frm凭证导入2 : Form
    {
        public Frm凭证导入2()
        {
            InitializeComponent();

            gL_accvouchToJP1.Conn = Config.ConnStr;
            gL_accvouchToJP1.sUserID = "demo";
            gL_accvouchToJP1.sUserName = "demo";
            gL_accvouchToJP1.sLogDate = "2018-01-01";

        }
    }
}
