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
    public partial class Frm收发存汇总查询 : Form
    {
        public Frm收发存汇总查询()
        {
            InitializeComponent();

            收发存汇总查询1.Conn = Config.ConnStr;
            收发存汇总查询1.sUserName = "demo";
        }
    }
}
