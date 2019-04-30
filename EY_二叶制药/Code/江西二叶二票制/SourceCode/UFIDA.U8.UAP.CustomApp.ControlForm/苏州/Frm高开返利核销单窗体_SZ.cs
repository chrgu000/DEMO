using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm高开返利核销单窗体_SZ : Form
    {  
        public Frm高开返利核销单窗体_SZ(string sCode, string Conn, string sUserID, string sUserName, string sLogDate, string sAccID)
        {
            InitializeComponent();

            高开返利核销单_SZ1.s_Code = sCode;
            高开返利核销单_SZ1.Conn = Conn;
            高开返利核销单_SZ1.sUserID = sUserID;
            高开返利核销单_SZ1.sUserName = sUserName;
            高开返利核销单_SZ1.sLogDate = sLogDate;
            高开返利核销单_SZ1.sAccID = sAccID;
        }

      
    }
}
