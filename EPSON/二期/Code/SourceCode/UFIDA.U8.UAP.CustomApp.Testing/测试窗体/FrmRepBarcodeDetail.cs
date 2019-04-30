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
    public partial class FrmRepBarcodeDetail : Form
    {
        public FrmRepBarcodeDetail()
        {
            InitializeComponent();

            repBarcodeDetail1.Conn = Config.ConnStr;
            repBarcodeDetail1.sUserName = "demo";
            repBarcodeDetail1.sUserID = "demo";
            repBarcodeDetail1.sAccID = "999";
            repBarcodeDetail1.sLogDate = "2016-5-3";
        }
    }
}
