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
    public partial class FrmOQCRMDF : Form
    {
        string sCode;
        UFSoft.U8.Framework.Login.UI.clsLogin u8login;
        public FrmOQCRMDF(UFSoft.U8.Framework.Login.UI.clsLogin login, string s_Code, string sConnString, string sDate)
        {
            InitializeComponent();

            oqcrmdf1.u8_login = login;
            this.sCode = s_Code;

            oqcrmdf1.Conn = sConnString;
            oqcrmdf1.sLogDate = sDate;

            u8login = login;

        }

        private void FrmOQCRMDF_Load(object sender, EventArgs e)
        {
            try
            {
                UFSoft.U8.Framework.LoginContext.UserData LoginInfo = new UFSoft.U8.Framework.LoginContext.UserData();
                LoginInfo = u8login.GetLoginInfo();

                oqcrmdf1.txtUid.Text = LoginInfo.UserId;
                oqcrmdf1.txtPwd.Text = LoginInfo.Password;

                oqcrmdf1.btnLogin_Click(null, null);

                oqcrmdf1.GetCode(sCode);
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
