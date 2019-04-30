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
    public partial class FormSa_BOMAll : Form
    {
        public FormSa_BOMAll()
        {
            InitializeComponent();
            sa_BOMAll1.Conn = Config.ConnStr;
            sa_BOMAll1.sUserName = "demo";
        }
    }
}
