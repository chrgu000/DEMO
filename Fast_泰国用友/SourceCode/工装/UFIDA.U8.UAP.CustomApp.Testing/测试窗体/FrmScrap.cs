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
    public partial class FrmScrap : Form
    {
        public FrmScrap()
        {
            InitializeComponent();

            scrap1.Conn = Config.ConnStr;
            scrap1.sUserName = "demo";
            scrap1.sUserID = "demo";
            scrap1.sAccID = "200";
            scrap1.sLogDate = "2015-12-12";
        }
    }
}
