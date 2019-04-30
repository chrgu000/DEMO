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
    public partial class Form结算方式对应表 : Form
    {
        public Form结算方式对应表()
        {
            InitializeComponent();

            结算方式对应表1.Conn = Config.ConnStr;
            结算方式对应表1.sUserName = "demo";
            结算方式对应表1.sAccID = "008";
        }
    }
}
