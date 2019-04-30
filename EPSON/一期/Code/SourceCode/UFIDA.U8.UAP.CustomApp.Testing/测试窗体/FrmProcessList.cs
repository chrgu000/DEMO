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
    public partial class FrmProcessList : Form
    {
        public FrmProcessList()
        {
            InitializeComponent();

            processList1.Conn = Config.ConnStr;
            processList1.sUserName = "demo";
            processList1.sUserID = "demo";
            processList1.sAccID = "999";
            processList1.sLogDate = "2016-5-3";
        }
    }
}
