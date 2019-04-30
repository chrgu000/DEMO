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
    public partial class 帐套科目归属表 : Form
    {
        public 帐套科目归属表()
        {
            InitializeComponent();

            帐套科目归属表1.Conn = Config.ConnStr;
            帐套科目归属表1.sUserID = "demo";
            帐套科目归属表1.sUserName = "demo";
            帐套科目归属表1.sAccID = "100";
        }
    }
}
