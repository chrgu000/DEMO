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
    public partial class frm生产入库数据每月明细 : Form
    {
        public frm生产入库数据每月明细()
        {
            InitializeComponent();

            生产入库数据每月明细1.Conn = Config.ConnStr;
            生产入库数据每月明细1.sUserName = "demo";
            生产入库数据每月明细1.sUserID = "demo";
            生产入库数据每月明细1.sAccID = "908";
            生产入库数据每月明细1.sLogDate = "2016-1-9";
        }
    }
}
