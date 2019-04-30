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
    public partial class Frm基础档案对照表 : Form
    {
        public Frm基础档案对照表()
        {
            InitializeComponent();

            基础档案对照表1.Conn = Config.ConnStr;
            基础档案对照表1.sUserID = "demo";
            基础档案对照表1.sUserName = "demo";
            基础档案对照表1.sAccID = "100";
        }
    }
}
