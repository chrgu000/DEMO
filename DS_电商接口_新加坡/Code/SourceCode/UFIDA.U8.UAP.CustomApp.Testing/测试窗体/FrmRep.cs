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
    public partial class FrmRep : Form
    {
        public FrmRep()
        {
            InitializeComponent();

            repCreateDisInfo1.Conn = Config.ConnStr;
            repCreateDisInfo1.sUserName = "demo";
            repCreateDisInfo1.sUserID = "demo";
            repCreateDisInfo1.sAccID = "004";
            repCreateDisInfo1.sLogDate = "2017-6-9";
        }
    }
}
