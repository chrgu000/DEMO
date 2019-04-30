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
    public partial class Frm发货 : Form
    {
        public Frm发货()
        {
            InitializeComponent();

            barSalesShipment1.Conn = Config.ConnStr;
            barSalesShipment1.sUserName = "demo";
            barSalesShipment1.sUserID = "demo";
            barSalesShipment1.sAccID = "999";
            barSalesShipment1.sLogDate = "2016-5-3";
        }
    }
}
