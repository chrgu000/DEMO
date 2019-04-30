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
    public partial class FrmXML文件转换 : Form
    {
        public FrmXML文件转换()
        {
            InitializeComponent();

            frmXML文件转换1.Conn = Config.ConnStr;
            frmXML文件转换1.sUserName = "demo";
            frmXML文件转换1.sUserID = "demo";
            frmXML文件转换1.sAccID = "200";
        }
    }
}
