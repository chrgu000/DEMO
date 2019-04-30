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
    public partial class FrmRepBarcodeAverage : Form
    {
        public FrmRepBarcodeAverage()
        {
            InitializeComponent();

            repBarcode1.Conn = Config.ConnStr;
            repBarcode1.sUserName = "demo";
            repBarcode1.sUserID = "demo";
            repBarcode1.sAccID = "999";
            repBarcode1.sLogDate = "2016-5-3";
        }
    }
}
