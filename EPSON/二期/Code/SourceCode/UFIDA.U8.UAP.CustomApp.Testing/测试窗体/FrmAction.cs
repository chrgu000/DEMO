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
    public partial class FrmAction : Form
    {
        public FrmAction()
        {
            InitializeComponent();

            action1.Conn = Config.ConnStr;
            action1.sUserName = "demo";
            action1.sUserID = "demo";
            action1.sAccID = "999";
            action1.sLogDate = "2016-5-3";
        }
    }
}
