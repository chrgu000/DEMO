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
    public partial class FormSa_Certificate : Form
    {
        public FormSa_Certificate()
        {
            InitializeComponent();
            sa_Certificate1.Conn = Config.ConnStr;
            sa_Certificate1.sUserName = "demo";
        }
    }
}
