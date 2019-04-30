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
    public partial class UserRight : Form
    {
        public UserRight()
        {
            InitializeComponent();

            userRight1.Conn = Config.ConnStr;
            userRight1.sUserName = "demo";
            userRight1.sUserID = "demo";
            userRight1.sAccID = "200";
            userRight1.sLogDate = "2015-12-12";
        }
    }
}
