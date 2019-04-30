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
    public partial class Frm发票汇总明细表 : Form
    {
        public Frm发票汇总明细表()
        {
            InitializeComponent();

            发票汇总明细表1.Conn = Config.ConnStr;
            发票汇总明细表1.sUserName = "demo";
        }
    }
}
