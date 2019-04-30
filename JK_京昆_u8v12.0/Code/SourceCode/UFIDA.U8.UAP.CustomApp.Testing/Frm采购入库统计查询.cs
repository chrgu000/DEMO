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
    public partial class Frm产品入库统计查询 : Form
    {
        public Frm产品入库统计查询()
        {
            InitializeComponent();

            产品入库统计查询1.Conn = Config.ConnStr;
            产品入库统计查询1.sUserName = "demo";
        }
    }
}
