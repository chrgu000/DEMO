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
    public partial class FrmProcess : Form
    {
        public FrmProcess()
        {
            InitializeComponent();

            process1.Conn = Config.ConnStr;
            process1.sUserName = "demo";
            process1.sUserID = "demo";
            process1.sAccID = "999";
            process1.sLogDate = "2016-5-3";
        }
    }
}
