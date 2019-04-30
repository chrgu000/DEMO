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

            rdInPu1.Conn = Config.ConnStr;
            rdInPu1.sUserName = "demo";
            rdInPu1.sUserID = "demo";
            rdInPu1.sAccID = "200";
        }
    }
}
