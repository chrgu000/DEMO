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
    public partial class frm销售实绩数据 : Form
    {
        public frm销售实绩数据()
        {
            InitializeComponent();

            销售实绩数据1.Conn = Config.ConnStr;
            销售实绩数据1.sUserName = "demo";
            销售实绩数据1.sUserID = "demo";
            销售实绩数据1.sAccID = "908";
            销售实绩数据1.sLogDate = "2016-1-9";
        }
    }
}
