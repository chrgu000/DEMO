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
    public partial class Frm材料退回单 : Form
    {
        public Frm材料退回单()
        {
            InitializeComponent();

            rdIn1.Conn = Config.ConnStr;
            rdIn1.sUserName = "demo";
            rdIn1.sUserID = "demo";
            rdIn1.sAccID = "200";
        }
    }
}
