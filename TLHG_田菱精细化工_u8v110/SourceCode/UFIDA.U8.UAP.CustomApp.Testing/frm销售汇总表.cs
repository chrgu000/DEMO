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
    public partial class frm销售汇总表 : Form
    {
        public frm销售汇总表()
        {
            InitializeComponent();

            销售汇总表1.Conn = Config.ConnStr;
            销售汇总表1.sUserID = "00001";
            销售汇总表1.sUserName = "朱成耀";
            销售汇总表1.sAccID = "100";
        }
    }
}
