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
    public partial class Frm主要物资采购明细表查询 : Form
    {
        public Frm主要物资采购明细表查询()
        {
            InitializeComponent();

            主要物资采购明细表查询1.Conn = Config.ConnStr;
            主要物资采购明细表查询1.sUserName = "demo";
        }
    }
}
