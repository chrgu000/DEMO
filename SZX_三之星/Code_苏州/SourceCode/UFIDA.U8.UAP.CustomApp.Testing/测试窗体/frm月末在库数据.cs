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
    public partial class frm月末在库数据 : Form
    {
        public frm月末在库数据()
        {
            InitializeComponent();

            月末在库数据1.Conn = Config.ConnStr;
            月末在库数据1.sUserName = "demo";
            月末在库数据1.sUserID = "demo";
            月末在库数据1.sAccID = "908";
            月末在库数据1.sLogDate = "2016-1-9";
        }
    }
}
