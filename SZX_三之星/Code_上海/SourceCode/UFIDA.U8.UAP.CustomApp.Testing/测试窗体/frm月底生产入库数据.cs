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
    public partial class frm月底生产入库数据 : Form
    {
        public frm月底生产入库数据()
        {
            InitializeComponent();

            月底生产入库数据1.Conn = Config.ConnStr;
            月底生产入库数据1.sUserName = "demo";
            月底生产入库数据1.sUserID = "demo";
            月底生产入库数据1.sAccID = "908";
            月底生产入库数据1.sLogDate = "2016-1-9";
        }
    }
}
