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
    public partial class FrmBarTransfer : Form
    {
        public FrmBarTransfer()
        {
            InitializeComponent();

            barTransfer1.Conn = Config.ConnStr;
            barTransfer1.sUserName = "demo";
            barTransfer1.sUserID = "demo";
            barTransfer1.sAccID = "999";
            barTransfer1.sLogDate = "2016-5-3";
        }
    }
}
