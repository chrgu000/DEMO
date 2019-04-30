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
    public partial class Frm发货打印 : Form
    {
        public Frm发货打印()
        {
            InitializeComponent();

            发货单打印1.Conn = Config.ConnStr;
            发货单打印1.sUserID = "demo";
            发货单打印1.sUserName = "demo";
        }
    }
}
