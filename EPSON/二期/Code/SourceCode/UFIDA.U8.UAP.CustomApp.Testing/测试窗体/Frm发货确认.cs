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
    public partial class Frm发货确认 : Form
    {
        public Frm发货确认()
        {
            InitializeComponent();

            barSalesShipmentAudit1.Conn = Config.ConnStr;
            barSalesShipmentAudit1.sUserName = "demo";
            barSalesShipmentAudit1.sUserID = "demo";
            barSalesShipmentAudit1.sAccID = "999";
            barSalesShipmentAudit1.sLogDate = "2016-5-3";
        }
    }
}
