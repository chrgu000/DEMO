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
    public partial class frmSaleBillVouchCSV : Form
    {
        public frmSaleBillVouchCSV()
        {
            InitializeComponent();

            saleBillVouchCSV1.Conn = Config.ConnStr;
            saleBillVouchCSV1.sUserName = "demo";
            saleBillVouchCSV1.sUserID = "demo";
            saleBillVouchCSV1.sAccID = "999";
            saleBillVouchCSV1.sLogDate = "2016-5-3";
        }
    }
}
