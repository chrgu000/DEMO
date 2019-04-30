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
    public partial class Frm采购发票 : Form
    {
        public Frm采购发票()
        {
            InitializeComponent();

            importPurBillVouch1.Conn = Config.ConnStr;
            importPurBillVouch1.sUserName = "demo1";
            importPurBillVouch1.sUserID = "demo1";
            importPurBillVouch1.sAccID = "888";
            importPurBillVouch1.sLogDate = "2017-9-22";
        }
    }
}
