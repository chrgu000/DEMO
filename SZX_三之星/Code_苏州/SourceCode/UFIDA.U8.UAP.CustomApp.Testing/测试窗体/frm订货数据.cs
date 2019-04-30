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
    public partial class frm订货数据 : Form
    {
        public frm订货数据()
        {
            InitializeComponent();

            订货数据1.Conn = Config.ConnStr;
            订货数据1.sUserName = "demo";
            订货数据1.sUserID = "demo";
            订货数据1.sAccID = "908";
            订货数据1.sLogDate = "2016-1-9";
        }
    }
}
