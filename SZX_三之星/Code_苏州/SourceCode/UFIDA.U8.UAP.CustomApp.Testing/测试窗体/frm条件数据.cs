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
    public partial class frm条件数据 : Form
    {
        public frm条件数据()
        {
            InitializeComponent();

            条件数据1.Conn = Config.ConnStr;
            条件数据1.sUserName = "demo";
            条件数据1.sUserID = "demo";
            条件数据1.sAccID = "908";
            条件数据1.sLogDate = "2016-1-9";
        }
    }
}
