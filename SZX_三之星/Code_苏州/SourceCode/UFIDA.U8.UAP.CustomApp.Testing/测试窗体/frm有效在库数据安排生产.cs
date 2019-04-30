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
    public partial class frm有效在库数据安排生产 : Form
    {
        public frm有效在库数据安排生产()
        {
            InitializeComponent();

            有效在库数据安排生产1.Conn = Config.ConnStr;
            有效在库数据安排生产1.sUserName = "demo";
            有效在库数据安排生产1.sUserID = "demo";
            有效在库数据安排生产1.sAccID = "908";
            有效在库数据安排生产1.sLogDate = "2016-1-9";
        }
    }
}
