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
    public partial class 帐套档案对照表 : Form
    {
        public 帐套档案对照表()
        {
            InitializeComponent();

            帐套档案对照表1.Conn = Config.ConnStr;
            帐套档案对照表1.sUserID = "demo";
            帐套档案对照表1.sUserName = "demo";
            帐套档案对照表1.sAccID = "100";
        }
    }
}
