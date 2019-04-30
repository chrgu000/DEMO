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
    public partial class FormSa_CloseBill : Form
    {
        public FormSa_CloseBill()
        {
            InitializeComponent();
            sa_CloseBill1.Conn = Config.ConnStr;
            sa_CloseBill1.sUserID = "demo";
        }
    }
}
