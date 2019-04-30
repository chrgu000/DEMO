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
    public partial class Form销售发票导入 : Form
    {
        public Form销售发票导入()
        {
            InitializeComponent();

            销售发票导入1.Conn = Config.ConnStr;
            销售发票导入1.sUserName = "demo";
            销售发票导入1.sAccID = "008";
        }

        private void 销售发票导入1_Load(object sender, EventArgs e)
        {

        }
    }
}
