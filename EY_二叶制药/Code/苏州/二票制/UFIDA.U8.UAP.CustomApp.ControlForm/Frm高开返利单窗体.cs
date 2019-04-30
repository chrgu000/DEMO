using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm高开返利单窗体 : Form
    {
        public Frm高开返利单窗体(string sCode, string Conn, string sUserID, string sUserName, string sLogDate, string sAccID)
        {
            InitializeComponent();

            高开返利单1.s_Code = sCode;
            高开返利单1.Conn = Conn;
            高开返利单1.sUserID = sUserID;
            高开返利单1.sUserName = sUserName;
            高开返利单1.sLogDate = sLogDate;
            高开返利单1.sAccID = sAccID;
        }
    }
}
