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
    public partial class FrmBraclose : Form
    {
        public FrmBraclose()
        {
            InitializeComponent();

            barClose1.Conn = Config.ConnStr;
            barClose1.sUserName = "demo";
            barClose1.sUserID = "demo";
            barClose1.sAccID = "999";
            barClose1.sLogDate = "2016-5-3";
        }
    }
}
