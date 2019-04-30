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
    public partial class Form收款单导入 : Form
    {
        public Form收款单导入()
        {
            InitializeComponent();

            收款单导入1.Conn = Config.ConnStr;
            收款单导入1.sUserName = "demo";
            收款单导入1.sAccID = "100";
        }
    }
}
