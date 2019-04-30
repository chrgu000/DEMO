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
    public partial class FrmIQCRMDF : Form
    {
        string sCode;
        UFSoft.U8.Framework.Login.UI.clsLogin u8login;
        public FrmIQCRMDF(UFSoft.U8.Framework.Login.UI.clsLogin login, string s_Code, string sConnString, string sDate)
        {
            InitializeComponent();

            iqcrmdf1.u8_login = login;
            this.sCode = s_Code;

            iqcrmdf1.Conn = sConnString;
            iqcrmdf1.sLogDate = sDate;

            u8login = login;

        }

        private void FrmIQCRMDF_Load(object sender, EventArgs e)
        {
            try
            {
                UFSoft.U8.Framework.LoginContext.UserData LoginInfo = new UFSoft.U8.Framework.LoginContext.UserData();
                LoginInfo = u8login.GetLoginInfo();

                iqcrmdf1.txtUid.Text = LoginInfo.UserId;
                iqcrmdf1.txtPwd.Text = LoginInfo.Password;

                iqcrmdf1.btnLogin_Click(null, null);
                iqcrmdf1.GetCode(sCode);
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }
    }
}
