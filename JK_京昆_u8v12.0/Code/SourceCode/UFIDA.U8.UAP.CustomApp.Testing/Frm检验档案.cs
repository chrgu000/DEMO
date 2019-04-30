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
    public partial class Frm检验档案 : Form
    {
        public Frm检验档案()
        {
            InitializeComponent();

            检验档案1.Conn = Config.ConnStr;
            检验档案1.sUserName = "demo";
        }
    }
}
