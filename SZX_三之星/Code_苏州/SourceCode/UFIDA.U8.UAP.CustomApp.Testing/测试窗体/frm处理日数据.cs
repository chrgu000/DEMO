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
    public partial class frm处理日数据 : Form
    {
        public frm处理日数据()
        {
            InitializeComponent();

            处理日数据1.Conn = Config.ConnStr;
            处理日数据1.sUserName = "demo";
            处理日数据1.sUserID = "demo";
            处理日数据1.sAccID = "908";
            处理日数据1.sLogDate = "2016-1-9";
        }
    }
}
