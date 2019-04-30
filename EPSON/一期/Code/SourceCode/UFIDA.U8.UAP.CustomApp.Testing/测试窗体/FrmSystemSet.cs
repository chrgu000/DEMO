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
    public partial class FrmSystemSet : Form
    {
        public FrmSystemSet()
        {
            InitializeComponent();

            systemSet1.Conn = Config.ConnStr;
            systemSet1.sUserName = "demo";
            systemSet1.sUserID = "demo";
            systemSet1.sAccID = "999";
            systemSet1.sLogDate = "2016-5-3";
        }
    }
}
