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
    public partial class Frm发货单生成发票 : Form
    {
        public Frm发货单生成发票()
        {
            InitializeComponent();

            frm发货单生成发票1.Conn = Config.ConnStr;
            frm发货单生成发票1.sUserID = "demo";
            frm发货单生成发票1.sUserName = "demo";
            frm发货单生成发票1.sLogDate = "2017-09-03";
            frm发货单生成发票1.sAccID = "101";
        }
    }
}
