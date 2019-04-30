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
    public partial class Frm成本对比表 : Form
    {
        public Frm成本对比表()
        {
            InitializeComponent();

            成本对比表1.Conn = Config.ConnStr;
            成本对比表1.sUserName = "demo";
            成本对比表1.sUserID = "demo";
            成本对比表1.sAccID = "200";
            成本对比表1.sLogDate = "2016-01-12";
        }
    }
}
