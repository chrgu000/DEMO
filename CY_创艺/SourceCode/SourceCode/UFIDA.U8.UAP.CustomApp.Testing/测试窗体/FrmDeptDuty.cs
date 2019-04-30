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
    public partial class FrmDeptDuty : Form
    {
        public FrmDeptDuty()
        {
            InitializeComponent();

            DeptDuty1.Conn = Config.ConnStr;
            DeptDuty1.sUserName = "demo";
            DeptDuty1.sUserID = "demo";
            DeptDuty1.sAccID = "200";
            DeptDuty1.sLogDate = "2015-12-12";
        }
    }
}
