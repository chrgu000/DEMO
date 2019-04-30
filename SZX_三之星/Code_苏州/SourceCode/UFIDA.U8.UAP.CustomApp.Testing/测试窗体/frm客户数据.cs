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
    public partial class frm客户数据 : Form
    {
        public frm客户数据()
        {
            InitializeComponent();

            客户数据1.Conn = Config.ConnStr;
            客户数据1.sUserName = "demo";
            客户数据1.sUserID = "demo";
            客户数据1.sAccID = "908";
            客户数据1.sLogDate = "2016-1-9";
        }
    }
}
