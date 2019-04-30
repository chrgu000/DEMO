using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class IQCRMDFList : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        UFSoft.U8.Framework.Login.UI.clsLogin u8_Login;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        UFSoft.U8.Framework.Login.UI.clsLogin u8_login;

        public IQCRMDFList(UFSoft.U8.Framework.Login.UI.clsLogin login)
        {
            InitializeComponent();

            u8_login = login;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle >= 0)
                    {
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    else if (e.RowHandle < 0 && e.RowHandle > -1000)
                    {
                        e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                        e.Info.DisplayText = "G" + e.RowHandle.ToString();
                    }
                }
            }
            catch { }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel(*.xls)|*.xls|All Files(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
SELECT a.*,cus.cCusName,case when a.IQCStatus = 'IQC-Passed' then 'Passed' else 'Failed' end IQCResult
FROM _IQC_RMDF a
    left join Customer cus on a.cCusCode = cus.cCusCode
where 1=1
order by RMDFNo
";
                if (txtIQCNo.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and IQCNo = '" + txtIQCNo.Text.Trim() + "'");
                }
                if (txtLotNo.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and LotNo = '" + txtLotNo.Text.Trim() + "'");
                }
                if (dtm1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dtmCreate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dtmCreate < '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;

                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }

        private void IQCRMDFList_Load(object sender, EventArgs e)
        {
            try
            {
                dtm1.DateTime = BaseFunction.ReturnDate(sLogDate).AddDays(-7);
                dtm2.DateTime = BaseFunction.ReturnDate(sLogDate);

                dtm1.Enabled = true;
                dtm2.Enabled = true;

                txtLotNo.Enabled = true;
                txtIQCNo.Enabled = true;

                dtm1.Properties.ReadOnly = false;
                dtm2.Properties.ReadOnly = false;
                txtLotNo.Properties.ReadOnly = false;
                txtIQCNo.Properties.ReadOnly = false;

                SetEnable(false);

                txtUid.Enabled = true;
                txtPwd.Enabled = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string sCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColIQCNo).ToString().Trim();
                if (sCode != "")
                {
                    FrmIQCRMDF frm = new FrmIQCRMDF(u8_login, sCode, Conn,sLogDate);
                    frm.ShowDialog();
                }
            }
            catch (Exception ee)
            { 
                
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UFSoft.U8.Framework.LoginContext.UserData LoginInfo = new UFSoft.U8.Framework.LoginContext.UserData();
                LoginInfo = u8_login.GetLoginInfo();

                U8Login.clsLogin u8Login = new U8Login.clsLogin();
                String sSubId = LoginInfo.cSubID;
                String sAccID = LoginInfo.AccID;
                String sYear = LoginInfo.iYear;
                String sUser_ID = txtUid.Text.Trim();
                String sPassword = txtPwd.Text.Trim();
                String sDate = sLogDate;
                String sServer = LoginInfo.RightServer;
                String sSerial = "";
                if (u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUser_ID, ref sPassword, ref sDate, ref sServer, ref sSerial))
                {
                    sUserID = sUser_ID;
                    sUserName = LoginInfo.UserName;

                    string sSQL = @"
select a.cUser_Name ,b.cPsn_Name
from [UFSystem].[dbo].[UA_User] a inner join hr_hi_person b on a.cUser_Id = b.cPsn_Num
where a.cUser_Id = '{0}'
";
                    sSQL = string.Format(sSQL, sUser_ID);
                    DataTable dtPerson = DbHelperSQL.Query(sSQL);
                    if (dtPerson == null || dtPerson.Rows.Count == 0 || dtPerson.Rows[0]["cPsn_Name"].ToString().Trim() == "")
                    {
                        throw new Exception(sUser_ID + " is not plater");
                    }

                    txtUid.Enabled = false;
                    txtPwd.Enabled = false;

                    txtLotNo.Focus();

                    SetEnable(true);

                }
                else
                {
                    MessageBox.Show("The user does not exists or is logged out ,maybe password is incorrect!");

                    txtPwd.Text = "";

                    txtUid.Focus();
                    SetEnable(false);
                }
            }
            catch (Exception ee)
            {
                SetEnable(false);
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                txtUid.Text = "";
                txtPwd.Text = "";

                txtUid.Enabled = true;
                txtPwd.Enabled = true;

                txtUid.Focus();
                SetEnable(false);

                gridControl1.DataSource = null;
            }
            catch (Exception ee)
            {
                SetEnable(false);
                MessageBox.Show(ee.Message);
            }
        }

        private void SetEnable(bool b)
        {
            txtIQCNo.Enabled = b;
            txtLotNo.Enabled = b;

            dtm1.Enabled = b;
            dtm2.Enabled = b;

            btnRefresh.Enabled = b;
            btnExport.Enabled = b;

            gridControl1.Enabled = b;
        }

        private void txtUid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtUid.Text.Trim() != "")
                {
                    txtPwd.Focus();
                }
            }
            catch { }
        }

        private void txtPwd_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtUid.Text.Trim() != "")
                {
                    btnLogin_Click(null, null);
                }
            }
            catch { }
        }

        private void txtIQCNo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void txtLotNo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
