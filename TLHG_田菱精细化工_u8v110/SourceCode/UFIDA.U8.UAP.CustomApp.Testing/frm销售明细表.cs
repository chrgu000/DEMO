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
    public partial class frm销售明细表 : Form
    {
        public frm销售明细表()
        {
            InitializeComponent();

            销售明细表1.Conn = Config.ConnStr;
            销售明细表1.sUserName = "demo";
            销售明细表1.sAccID = "100";
        }
    }
}
