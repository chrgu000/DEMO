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
    public partial class RepFHDList : Form
    {
        public RepFHDList()
        {
            InitializeComponent();

            repFHDList1.Conn = Config.ConnStr;
            repFHDList1.sUserName = "demo";
            repFHDList1.sUserID = "demo";
            repFHDList1.sAccID = "101";
            repFHDList1.sLogDate = "2017-9-9";
        }
    }
}
