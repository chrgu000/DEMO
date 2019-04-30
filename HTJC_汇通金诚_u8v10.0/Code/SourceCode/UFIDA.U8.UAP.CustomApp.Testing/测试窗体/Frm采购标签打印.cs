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
    public partial class Frm采购标签打印 : Form
    {
        public Frm采购标签打印()
        {
            InitializeComponent();

            采购标签打印1.Conn = Config.ConnStr;
            采购标签打印1.sUserID = "demo";
            采购标签打印1.sUserName = "demo";
        }
    }
}
