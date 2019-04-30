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
    public partial class Frm采购入库单 : Form
    {
        public Frm采购入库单()
        {
            InitializeComponent();

            importRdrecord011.Conn = Config.ConnStr;
            importRdrecord011.sUserName = "demo1";
            importRdrecord011.sUserID = "demo1";
            importRdrecord011.sAccID = "888";
            importRdrecord011.sLogDate = "2017-9-22";
        }
    }
}
