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
    public partial class Form销售发货单导入 : Form
    {
        public Form销售发货单导入()
        {
            InitializeComponent();

            销售发货单1.Conn = Config.ConnStr;
            销售发货单1.sUserID = "00001";
            销售发货单1.sUserName = "朱成耀";
            销售发货单1.sAccID = "100";
        }
    }
}
