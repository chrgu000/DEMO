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
    public partial class FrmProLine : Form
    {
        public FrmProLine()
        {
            InitializeComponent();

            proLine1.Conn = Config.ConnStr;
            proLine1.sUserName = "demo";
            proLine1.sUserID = "demo";
            proLine1.sAccID = "999";
            proLine1.sLogDate = "2016-5-3";
        }
    }
}
