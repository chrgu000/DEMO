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
    public partial class FrmBarCodeStatus : Form
    {
        public FrmBarCodeStatus()
        {
            InitializeComponent();

            barCodeStatus1.Conn = Config.ConnStr;
            barCodeStatus1.sUserName = "demo";
            barCodeStatus1.sUserID = "demo";
            barCodeStatus1.sAccID = "999";
            barCodeStatus1.sLogDate = "2016-5-3";
        }
    }
}
