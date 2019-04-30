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
    public partial class Frm采购入库统计查询 : Form
    {
        public Frm采购入库统计查询()
        {
            InitializeComponent();

            采购入库统计查询1.Conn = Config.ConnStr;
            采购入库统计查询1.sUserName = "demo";
        }
    }
}
