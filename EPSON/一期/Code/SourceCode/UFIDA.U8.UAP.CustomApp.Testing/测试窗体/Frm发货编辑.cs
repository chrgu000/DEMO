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
    public partial class Frm发货编辑 : Form
    {
        public Frm发货编辑()
        {
            InitializeComponent();

            barSalesShipmentEdit1.Conn = Config.ConnStr;
            barSalesShipmentEdit1.sUserName = "demo";
            barSalesShipmentEdit1.sUserID = "demo";
            barSalesShipmentEdit1.sAccID = "999";
            barSalesShipmentEdit1.sLogDate = "2016-5-3";
        }
    }
}
