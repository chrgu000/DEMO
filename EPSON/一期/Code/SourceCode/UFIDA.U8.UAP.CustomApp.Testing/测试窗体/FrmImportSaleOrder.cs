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
    public partial class FrmImportSaleOrder : Form
    {
        public FrmImportSaleOrder()
        {
            InitializeComponent();

            importSaleOrder1.Conn = Config.ConnStr;
            importSaleOrder1.sUserName = "demo";
            importSaleOrder1.sUserID = "demo";
            importSaleOrder1.sAccID = "999";
            importSaleOrder1.sLogDate = "2016-5-3";
        }
    }
}
