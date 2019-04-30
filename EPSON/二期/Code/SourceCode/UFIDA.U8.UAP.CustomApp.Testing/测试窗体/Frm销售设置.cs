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
    public partial class Frm销售设置 : Form
    {
        public Frm销售设置()
        {
            InitializeComponent();

            salesSet1.Conn = Config.ConnStr;
            salesSet1.sUserName = "demo";
            salesSet1.sUserID = "demo";
            salesSet1.sAccID = "999";
            salesSet1.sLogDate = "2016-5-3";
        }
    }
}
