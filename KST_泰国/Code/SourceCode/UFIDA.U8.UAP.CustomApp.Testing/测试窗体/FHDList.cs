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
    public partial class FHDList : Form
    {
        public FHDList()
        {
            InitializeComponent();

            发货单导入1.Conn = Config.ConnStr;
            发货单导入1.sUserName = "demo";
            发货单导入1.sUserID = "demo";
            发货单导入1.sAccID = "101";
            发货单导入1.sLogDate = "2017-9-9";
        }
    }
}
