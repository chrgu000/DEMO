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
    public partial class Frm应付余额表 : Form
    {
        public Frm应付余额表()
        {
            InitializeComponent();

            应付余额表1.Conn = Config.ConnStr;
            应付余额表1.sUserName = "demo";
        }
    }
}
