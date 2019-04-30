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
    public partial class FrmExchange : Form
    {
        public FrmExchange()
        {
            InitializeComponent();

            exchange1.Conn = Config.ConnStr;
            exchange1.sUserName = "demo1";
            exchange1.sUserID = "demo1";
            exchange1.sAccID = "888";
            exchange1.sLogDate = "2017-9-22";
        }
    }
}
