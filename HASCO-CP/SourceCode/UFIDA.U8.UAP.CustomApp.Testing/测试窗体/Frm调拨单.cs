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
    public partial class Frm调拨单 : Form
    {
        public Frm调拨单()
        {
            InitializeComponent();

            importTransVouch1.Conn = Config.ConnStr;
            importTransVouch1.sUserName = "demo1";
            importTransVouch1.sUserID = "demo1";
            importTransVouch1.sAccID = "888";
            importTransVouch1.sLogDate = "2017-9-22";
        }
    }
}
