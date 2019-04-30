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
    public partial class FrmDefect : Form
    {
        public FrmDefect()
        {
            InitializeComponent();

            defects1.Conn = Config.ConnStr;
            defects1.sUserName = "demo";
            defects1.sUserID = "demo";
            defects1.sAccID = "999";
            defects1.sLogDate = "2016-5-3";
        }
    }
}
