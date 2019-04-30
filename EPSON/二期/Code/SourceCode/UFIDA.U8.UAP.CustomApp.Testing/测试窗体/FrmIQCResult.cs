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
    public partial class FrmIQCResult : Form
    {
        public FrmIQCResult()
        {
            InitializeComponent();

            barIQCResult1.Conn = Config.ConnStr;
            barIQCResult1.sUserName = "demo";
            barIQCResult1.sUserID = "demo";
            barIQCResult1.sAccID = "999";
            barIQCResult1.sLogDate = "2016-5-3";
        }
    }
}
