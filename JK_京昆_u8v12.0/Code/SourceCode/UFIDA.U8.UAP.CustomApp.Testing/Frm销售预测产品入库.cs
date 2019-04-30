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
    public partial class Frm销售预测产品入库 : Form
    {
        public Frm销售预测产品入库()
        {
            InitializeComponent();

            frm销售预测产品入库1.Conn = Config.ConnStr;
            frm销售预测产品入库1.sUserName = "demo";
            frm销售预测产品入库1.sLogDate = "2015-6-11";
        }
    }
}
