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
    public partial class Frm检验项目 : Form
    {
        public Frm检验项目()
        {
            InitializeComponent();

            检验项目1.Conn = Config.ConnStr;
            检验项目1.sUserName = "demo";
        }
    }
}
