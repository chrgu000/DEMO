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
    public partial class Frm凭证传递 : Form
    {
        public Frm凭证传递()
        {
            InitializeComponent();

            凭证传递1.Conn = Config.ConnStr;
            凭证传递1.sUserID = "demo";
            凭证传递1.sUserName = "demo";
            凭证传递1.sAccID = "100";
        }
    }
}
