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
    public partial class frm产成品成本分配 : Form
    {
        public frm产成品成本分配()
        {
            InitializeComponent();

            产成品成本分配1.Conn = Config.ConnStr;
            产成品成本分配1.sUserName = "demo";
            产成品成本分配1.sUserID = "demo";
            产成品成本分配1.sAccID = "908";
            产成品成本分配1.sLogDate = "2016-1-9";
        }
    }
}
