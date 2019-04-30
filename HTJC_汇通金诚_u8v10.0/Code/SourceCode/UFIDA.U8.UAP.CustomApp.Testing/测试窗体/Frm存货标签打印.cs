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
    public partial class Frm存货标签打印 : Form
    {
        public Frm存货标签打印()
        {
            InitializeComponent();


            库龄1.Conn = Config.ConnStr;
            库龄1.sUserID = "demo";
            库龄1.sUserName = "demo";
        }
    }
}
