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
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class IQCRMDF : UserControl
    {
        string sFileLocal = Application.StartupPath + "\\UAP\\Runtime\\Attachment";
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\BarLabel1.dll";

        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        public UFSoft.U8.Framework.Login.UI.clsLogin u8_login;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sServerPath;
        int iAttSize;

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelErr.Text = "";

                SetTxtNull();

                SetEnable(false);
                SetBtnEnable(true);

                DbHelperSQL.connectionString = Conn;

                txtUid.Enabled = true;
                txtPwd.Enabled = true;

                string sSQL = @"
select * from _Code where sType = 'IQC'
";
                DataTable dtCode = DbHelperSQL.Query(sSQL);

                if (dtCode == null || dtCode.Rows.Count != 1)
                {
                    throw new Exception("Please set code[sql server]");
                }

                sServerPath = dtCode.Rows[0]["s1"].ToString().Trim();
                if (sServerPath == "")
                {
                    throw new Exception("Please set code[sql server]");
                }

                iAttSize = BaseFunction.ReturnInt(dtCode.Rows[0]["i1"]);
                if (iAttSize == 0)
                {
                    throw new Exception("Please set code[sql server]");
                }

                List<String> list = LocalPrinter.GetLocalPrinters(); //获得系统中的打印机列表
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Printer";
                dt.Columns.Add(dc);

                foreach (String s in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["Printer"] = s;
                    dt.Rows.Add(dr);
                }
                lookUpEditPrinter.Properties.DataSource = dt;
                lookUpEditPrinter.EditValue = LocalPrinter.DefaultPrinter();

                txtUid.Focus();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public IQCRMDF()
        {
            InitializeComponent();
        }

        public IQCRMDF(UFSoft.U8.Framework.Login.UI.clsLogin login)
        {
            InitializeComponent();

            u8_login = login;
        }


        public IQCRMDF(UFSoft.U8.Framework.Login.UI.clsLogin login,string sCode)
        {
            InitializeComponent();

            u8_login = login;

            txtLotNo.Text = sCode;
            GetGrid();
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

        public void btnLogin_Click(object sender, EventArgs e)
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
                    txtStatus.Text = "Logged";

                    sUserID = sUser_ID;
                    sUserName = LoginInfo.UserName;

                    txtUid.Enabled = false;
                    txtPwd.Enabled = false;

                    SetLookup();

                    SetBtnEnable(false);

                    SetEnable(true);

                    lGUID.Text = Guid.NewGuid().ToString();

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
                    txtInspectedby.Text = dtPerson.Rows[0]["cPsn_Name"].ToString().Trim();

                    txtLotNo.Focus();
                }
                else
                {
                    MessageBox.Show("The user does not exists or is logged out ,maybe password is incorrect!");

                    SetEnable(false);
                    txtStatus.Text = "";
                    txtPwd.Text = "";

                    txtUid.Focus();
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
                txtStatus.Text = "";

                SetEnable(false);

                txtUid.Enabled = true;
                txtPwd.Enabled = true;

                txtUid.Focus();

                SetBtnEnable(true);
                SetEnable(true);

                SetTxtNull();
            }
            catch (Exception ee)
            {
                SetEnable(false);
                MessageBox.Show(ee.Message);
            }
        }

        private void SendeMail()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                if (txtRMDFNo.Text.Trim() == "")
                {
                    throw new Exception("Please choose data");
                }

                string sCode = txtIQCNo.Text.Trim();
                string sSQL = @"
select a.*,b.*,cus.cCusName ,cusE.ccdefine3,dep.cDepMemo,sos.cDefine25 + '   ' + sos.cMemo as sosMemo
from _IQC_RMDF a left join _IQC_RMDFs b on a.IQCNo = b.IQCNo
	inner join Customer cus on a.cCusCode = cus.cCusCode
	left join [dbo].[Customer_extradefine] cusE on cus.cCusCode = cusE.cCusCode
	left join Inventory inv on a.cInvCode = inv.cInvCode
	left join Department dep on inv.cInvDefine9 = dep.cDepCode
	left join SO_SODetails sos on sos.iSOsID = a.iSOsID
where a.IQCNo = '{0}'
";
                sSQL = string.Format(sSQL, sCode);
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("Please choose data");
                }

                if (dt.Rows[0]["AuditUid"].ToString().Trim() != "")
                {
                    DialogResult d = MessageBox.Show("Document is audit", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d != DialogResult.Yes)
                    {
                        throw new Exception("User cancelled");
                    }
                }

                sSQL = "exec [_EPSON_SP_RMDFEmail] '{0}' ";
                sSQL = string.Format(sSQL, txtcInvCode.Text.Trim());
                DataTable dtMail = DbHelperSQL.Query(sSQL);
                if (dtMail == null || dtMail.Rows.Count == 0)
                {
                    throw new Exception("Please set email");
                }

                string sMail = "";
                for (int i = 0; i < dtMail.Rows.Count; i++)
                {
                    if (sMail == "")
                    {
                        sMail = dtMail.Rows[i]["cPersonEmail"].ToString().Trim();
                    }
                    else
                    {
                        sMail = sMail + ";" + dtMail.Rows[i]["cPersonEmail"].ToString().Trim();
                    }
                }
                if (sMail.Trim() == "")
                {
                    throw new Exception("Please set email");
                }

                string sSubject ="IQC No:" + dt.Rows[0]["IQCNo"].ToString().Trim();
                if (txtRMDFNo.Text.Trim() != "")
                {
                    sSubject = sSubject + "; RMDF No:" + txtRMDFNo.Text.Trim(); 
                }
                sSubject = sSubject + "(" + dt.Rows[0]["cCusCode"].ToString().Trim() + ")";
                StringBuilder s = new StringBuilder();

                string sSampleHtml = Application.StartupPath + "\\UAP\\Runtime\\Sample\\RMDFSample.html";

                string sTemp = File.ReadAllText(sSampleHtml);

                sTemp = sTemp.Replace("@RMDF NO", txtRMDFNo.Text.Trim());
                sTemp = sTemp.Replace("@COMPANY", txtcCusName.Text.Trim());
                sTemp = sTemp.Replace("@CONFIRMED BY", dt.Rows[0]["cDepMemo"].ToString().Trim());
                sTemp = sTemp.Replace("@PART NAME", txtcInvName.Text.Trim());
                sTemp = sTemp.Replace("@QTY RECEIVED", txtLotQty.Text.Trim());
                sTemp = sTemp.Replace("@PART NO", txtcInvCode.Text.Trim());
                sTemp = sTemp.Replace("@SAMPLE SIZE", txtSampleSize.Text.Trim());
                sTemp = sTemp.Replace("@LOT NO", txtLotNo.Text.Trim());
                sTemp = sTemp.Replace("@A.O.L LEVEL", txtAQLLevel.Text.Trim());
                sTemp = sTemp.Replace("@D/O NO", txtDONO.Text.Trim());
                sTemp = sTemp.Replace("@DEFECTIVE %", txtDEFECTIVE.Text.Trim());
                sTemp = sTemp.Replace("@DATE RECEIVED", dtmReceived.DateTime.ToString("yyyy-MM-dd"));
                sTemp = sTemp.Replace("@INSPECTED BY", txtInspectedby.Text.Trim());
                sTemp = sTemp.Replace("@DATE INSPECTED", dtmInspected.DateTime.ToString("yyyy-MM-dd"));
                sTemp = sTemp.Replace("@ATTENTION", dt.Rows[0]["ccdefine3"].ToString().Trim());
                sTemp = sTemp.Replace("@SOSMEMO", dt.Rows[0]["sosMemo"].ToString().Trim());

                string sDefect = "";

                if (!Directory.Exists(sFileLocal))
                {
                    Directory.CreateDirectory(sFileLocal);
                }
                else
                {
                    string[] sFilesTemp = Directory.GetFiles(sFileLocal);
                    for (int j = sFilesTemp.Length - 1; j >= 0; j--)
                    {
                        if (sFilesTemp[j].Trim() != "")
                        {
                            try
                            {
                                File.Delete(sFilesTemp[j].Trim());
                            }
                            catch { }
                        }
                    }
                }
                string sFiles = "";

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColDefect).ToString().Trim() == "")
                        continue;

                    if (sDefect == "")
                    {
                        string sTemp1 = " &nbsp;&nbsp;&nbsp;&nbsp " + gridView1.GetRowCellValue(i, gridColDefect).ToString().Trim() + " &nbsp " + gridView1.GetRowCellDisplayText(i, gridColDefectName).ToString().Trim()
                            + " &nbsp :  &nbsp " + gridView1.GetRowCellValue(i, gridColQty).ToString().Trim();

                        if (gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim() != "")
                        {
                            sTemp1 = sTemp1 + "  &nbsp (" + gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim() + ")";
                        }

                        sDefect = sTemp1;
                    }
                    else
                    {
                        string sTemp2 = " &nbsp;&nbsp;&nbsp;&nbsp " + gridView1.GetRowCellValue(i, gridColDefect).ToString().Trim() + " &nbsp " + gridView1.GetRowCellDisplayText(i, gridColDefectName).ToString().Trim()
                            + " &nbsp :  &nbsp " + gridView1.GetRowCellValue(i, gridColQty).ToString().Trim();

                        if (gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim() != "")
                        {
                            sTemp2 = sTemp2 + "  &nbsp (" + gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim() + ")";
                        }

                        sDefect = sDefect + "<br>" + sTemp2;
                    }

                    if (gridView1.GetRowCellValue(i, gridColAttachmentName).ToString().Trim() != "")
                    {
                        if (!File.Exists(sFileLocal + "\\" + gridView1.GetRowCellValue(i, gridColAttachment).ToString().Trim()))
                        {
                            File.Copy(sServerPath + "\\" + gridView1.GetRowCellValue(i, gridColAttachmentName).ToString().Trim(), sFileLocal + "\\" + gridView1.GetRowCellValue(i, gridColAttachment).ToString().Trim());
                        }
                        if (sFiles == "")
                        {
                            sFiles = sFileLocal + "\\" + gridView1.GetRowCellValue(i, gridColAttachment).ToString().Trim();
                        }
                        else
                        {
                            sFiles = sFiles + ";" + sFileLocal + "\\" + gridView1.GetRowCellValue(i, gridColAttachment).ToString().Trim();
                        }
                    }
                }
                sTemp = sTemp.Replace("@DESCRIPTION OF DEFECTS", sDefect);

                if (chk1.Checked)
                {
                    sTemp = sTemp.Replace("@PLEASETICK_Row1", "√");
                }
                else
                {
                    sTemp = sTemp.Replace("@PLEASETICK_Row1", "&nbsp;&nbsp;");
                }
                if (chk2.Checked)
                {
                    sTemp = sTemp.Replace("@PLEASETICK_Row2", "√");
                }
                else
                {
                    sTemp = sTemp.Replace("@PLEASETICK_Row2", "&nbsp;&nbsp;");
                }
                if (chk3.Checked)
                {
                    sTemp = sTemp.Replace("@PLEASETICK_Row3", "√");
                }
                else
                {
                    sTemp = sTemp.Replace("@PLEASETICK_Row3", "&nbsp;&nbsp;");
                }
                sTemp = sTemp.Replace("@OTHER", txtOthers.Text.Trim());
                sTemp = sTemp.Replace("@NAME", "");
                sTemp = sTemp.Replace("@DESIGNATION", "");
                sTemp = sTemp.Replace("@SIGNATURE/DATE", "");



                sSQL = @"
select * from _eMailInfo
";
                DataTable dtMailInfo = DbHelperSQL.Query(sSQL);
                if (dtMailInfo == null || dtMailInfo.Rows.Count < 1)
                {
                    throw new Exception("Please set table '_eMailInfo'");
                }
                string sUidMail = dtMailInfo.Rows[0]["UidMail"].ToString().Trim() + "|"
                        + dtMailInfo.Rows[0]["PwdMail"].ToString().Trim() + "|"
                        + dtMailInfo.Rows[0]["SMTP"].ToString().Trim() + "|"
                        + dtMailInfo.Rows[0]["Port"].ToString().Trim() + "|"
                        + dtMailInfo.Rows[0]["SSL"].ToString().Trim();


                FrmIQC_EMail frm = new FrmIQC_EMail(sUidMail, sMail, sSubject, sTemp, sFiles, Conn, sUserID, txtIQCNo.Text.Trim());
                frm.StartPosition = FormStartPosition.CenterParent;
                DialogResult dialog = frm.ShowDialog();
                if (dialog == DialogResult.Yes)
                {
                    sSQL = @"
update _IQC_RMDF set SendMailCount = isnull(SendMailCount,0) + 1 ,SendMailUid = '{0}',dtmSendMail = getdate()
where RMDFNo = '{1}'
";
                    sSQL = string.Format(sSQL, txtUid.Text.Trim(), sCode);
                    DbHelperSQL.ExecuteSql(sSQL);
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
            finally
            {

            }
        }

        private void SetEnable(bool b)
        {
            if (txtStatus.Text.ToLower().Trim() != "logged")
            {
                txtRMDFNo.Enabled = false;
                txtiSOsID.Enabled = false;
                txtLotNo.Enabled = false;
                txtLotQty.Enabled = false;
                txtInsQty.Enabled = false;
                txtSampleSize.Enabled = false;
                txtcCusCode.Enabled = false;
                txtcCusName.Enabled = false;
                txtAQLLevel.Enabled = false;
                dtmReceived.Enabled = false;
                dtmInspected.Enabled = false;
                txtInspectedby.Enabled = false;
                gridView1.OptionsBehavior.Editable = false;
                lookUpEditFeedback.Enabled = false;
                txtcInvCode.Enabled = false;
                txtcInvName.Enabled = false;

                txtATTENTION.Enabled = false;
                txtDONO.Enabled = false;
                txtCONFIRMEDBY.Enabled = false;
                txtDEFECTIVE.Enabled = false;
                chk1.Enabled = false;
                chk2.Enabled = false;
                chk3.Enabled = false;
                txtOthers.Enabled = false;

                txtAQLLevel.Enabled = false;
                txtAccept.Enabled = false;
                txtReject.Enabled = false;
                txtResult.Enabled = false;

                radioPassed.Enabled = false;
                radioFailed.Enabled = false;

                txtRemark.Enabled = false;

                lookUpEditPrinter.Enabled = false;
                radioPreview.Enabled = false;
                radioPrint.Enabled = false;
            }
            else
            {
                txtRMDFNo.Enabled = false;
                txtiSOsID.Enabled = false;

                txtcInvCode.Enabled = false;
                txtcInvName.Enabled = false;

                txtLotNo.Enabled = b;

                txtLotQty.Enabled = false;
                txtInsQty.Enabled = false;

                txtSampleSize.Enabled = b;

                txtcCusCode.Enabled = false;
                txtcCusName.Enabled = false;

                txtAQLLevel.Enabled = false;
                txtAccept.Enabled = false;
                txtReject.Enabled = false;
                txtResult.Enabled = false;


                dtmReceived.Enabled = false;
                dtmInspected.Enabled = false;

                txtInspectedby.Enabled = false;

                lookUpEditFeedback.Enabled = b;

                radioPassed.Enabled = b;
                radioFailed.Enabled = b;

                gridView1.OptionsBehavior.Editable = b;

                
                txtATTENTION.Enabled = b;
                txtDONO.Enabled = false;
                txtCONFIRMEDBY.Enabled = b;
                txtDEFECTIVE.Enabled = b;
                chk1.Enabled = false;
                chk2.Enabled = false;
                chk3.Enabled = false;
                txtOthers.Enabled = b;

                txtRemark.Enabled = b;

                lookUpEditPrinter.Enabled = true;
                radioPreview.Enabled = true;
                radioPrint.Enabled = true;
            }
        }

        private void SetTxtNull()
        {
            labelErr.Text = "";
            txtBarCode2.Text = "";

            txtIQCNo.Text = "";
            txtRMDFNo.Text = "";
            txtiSOsID.Text = "";

            txtProcess.Text = "";

            txtLotNo.Text = "";

            lookUpEditFeedback.EditValue = DBNull.Value;

            txtLotQty.Text = "";
            txtInsQty.Text = "";

            txtSampleSize.EditValue = DBNull.Value;
            txtResult.Text = "";
            txtAQLLevel.Text = "";
            txtReject.Text = "";
            txtAccept.Text = "";

            txtcCusCode.Text = "";
            txtcCusName.Text = "";

            txtAQLLevel.Text = "";
            dtmReceived.Text = "";
            dtmInspected.Text = "";

            txtcInvCode.Text = "";
            txtcInvName.Text = "";

            txtRemark.Text = "";

            txtATTENTION.Text = "";
            txtDONO.Text = "";
            txtCONFIRMEDBY.Text = "";
            txtDEFECTIVE.Text = "";
            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;
            txtOthers.Text = "";

            radioPassed.Checked = false;
            radioFailed.Checked = false;

            gridControl1.DataSource = null;

            txtResult.Text = "";
            txtResult.BackColor = txtLotNo.BackColor;

            lGUID.Text = "";

            lBarCodeG.Text = "";
            lBarCodeNG.Text = "";

            txtSortGQty.Text = "";
            txtSortNGQty.Text = "";


            if (txtUid.Text.Trim() == "")
            {
                txtInspectedby.Text = "";
            }
        }

        private void SetBtnEnable(bool b)
        {
            if (txtStatus.Text.ToLower().Trim() != "logged")
            {
                btnScan.Enabled = false;
                btnSave.Enabled = false;
                btnAudit.Enabled = false;
            }
            else
            {
                btnScan.Enabled = true;
                
                btnSave.Enabled = true;
                btnAudit.Enabled = true;
            }
        }

        public void GetCode(string sIQCNo)
        {
            //判断单据是否已经存在
            string sSQL = @"
select a.* ,cus.cCusName
from [_IQC_RMDF] a inner join Customer cus on cus.cCusCode = a.cCusCode 
where a.IQCNo = '{0}'
";
            sSQL = string.Format(sSQL, sIQCNo);
            DataTable dtVoucher = DbHelperSQL.Query(sSQL);
            if (dtVoucher != null && dtVoucher.Rows.Count > 0)
            {
                txtIQCNo.Text = dtVoucher.Rows[0]["IQCNo"].ToString().Trim();
                txtRMDFNo.Text = dtVoucher.Rows[0]["RMDFNo"].ToString().Trim();
                txtiSOsID.Text = dtVoucher.Rows[0]["iSOsID"].ToString().Trim();
                txtLotNo.Text = dtVoucher.Rows[0]["LotNo"].ToString().Trim();

                if (dtVoucher.Rows[0]["IQCStatus"].ToString().Trim().ToLower() == "iqc-passed")
                {
                    radioPassed.Checked = true;
                }
                else
                {
                    radioFailed.Checked = true;
                }

                txtBarCode2.Text = txtLotNo.Text;
                txtLotQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["LotQty"]);

                txtInsQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["InsQty"]);
                txtSampleSize.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["SampleSize"].ToString().Trim());
                txtcCusCode.Text = dtVoucher.Rows[0]["cCusCode"].ToString().Trim();
                txtcCusName.Text = dtVoucher.Rows[0]["cCusName"].ToString().Trim();
                txtAQLLevel.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["AQLLevel"].ToString().Trim());
                dtmReceived.DateTime = BaseFunction.ReturnDate(dtVoucher.Rows[0]["dtmReceived"]);
                dtmInspected.DateTime = BaseFunction.ReturnDate(dtVoucher.Rows[0]["dtmInspected"]);
                txtInspectedby.Text = dtVoucher.Rows[0]["InspectedBy"].ToString().Trim();
                txtProcess.Text = dtVoucher.Rows[0]["Process"].ToString().Trim();
                txtcInvCode.Text = dtVoucher.Rows[0]["cInvCode"].ToString().Trim();
                txtcInvName.Text = dtVoucher.Rows[0]["cInvName"].ToString().Trim();

                txtATTENTION.Text = dtVoucher.Rows[0]["ATTENTION"].ToString().Trim();
                txtDONO.Text = dtVoucher.Rows[0]["DONO"].ToString().Trim();
                txtCONFIRMEDBY.Text = dtVoucher.Rows[0]["CONFIRMEDBY"].ToString().Trim();
                txtDEFECTIVE.Text = dtVoucher.Rows[0]["DEFECTIVE"].ToString().Trim();
                txtOthers.Text = dtVoucher.Rows[0]["REPLAYSLIP_Others"].ToString().Trim();
                chk1.Checked = BaseFunction.ReturnBool(dtVoucher.Rows[0]["REPLAYSLIP_row1"]);
                chk2.Checked = BaseFunction.ReturnBool(dtVoucher.Rows[0]["REPLAYSLIP_row2"]);
                chk3.Checked = BaseFunction.ReturnBool(dtVoucher.Rows[0]["REPLAYSLIP_row3"]);
                txtRemark.Text = dtVoucher.Rows[0]["Remark"].ToString().Trim();
                txtAccept.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["Accept"].ToString().Trim());
                txtReject.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["Reject"].ToString().Trim());

                lookUpEditFeedback.EditValue = dtVoucher.Rows[0]["Feedback"].ToString().Trim();
                if (BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["SortG"].ToString().Trim()) != 0)
                {
                    txtSortGQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["SortG"].ToString().Trim());
                    txtSortNGQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["SortNG"].ToString().Trim());
                }

                sSQL = @"
select distinct a.DefectCode ,b.DefectName
from _Defects a left join [_DefectMaster_2] b on a.DefectCode = b.DefectCode
where cCusCode = '{0}'
order by a.DefectCode 
";
                sSQL = string.Format(sSQL, txtcCusCode.Text.Trim());
                DataTable dtDefects = DbHelperSQL.Query(sSQL);
                ItemLookUpEdit1DefectCode.DataSource = dtDefects;
                ItemLookUpEdit1DefectName.DataSource = dtDefects;

                sSQL = @"
select *
from _IQC_RMDFs 
where IQCNo = '{0}'
order by iRow
";
                sSQL = string.Format(sSQL, txtIQCNo.Text.Trim());
                DataTable dts = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dts;
                while (gridView1.RowCount < 10)
                {
                    gridView1.AddNewRow();
                }

                gridView1.FocusedRowHandle = 0;

                decimal d = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    d = d + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty));
                }
                if (d <= BaseFunction.ReturnDecimal(txtAccept.Text.Trim()))
                {
                    txtResult.Text = "Accept";
                    txtResult.BackColor = Color.Green;
                }
                if (d >= BaseFunction.ReturnDecimal(txtReject.Text.Trim()))
                {
                    txtResult.Text = "Reject";
                    txtResult.BackColor = Color.Red;
                }

                if (lookUpEditFeedback.Text.Trim().ToLower() == "sort")
                {
                    lSortedNGQty.Visible = true;
                    txtSortNGQty.Visible = true;
                }
                else
                {
                    lSortedNGQty.Visible = false;
                    txtSortNGQty.Visible = false;
                }
            }
        }

        public void GetGrid()
        {
            try
            {
                string sBarCode = txtLotNo.Text.Trim();
                if (sBarCode == "")
                {
                    txtLotNo.Focus();
                    throw new Exception("Please sacn barcode");
                }
                SetTxtNull();

                txtBarCode2.Text = sBarCode;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = @"
select a.*,so.cCusCode,cus.cCusName,cast(null as nvarchar(50)) as Feedback,soss.cbdefine3,invExt.cidefine4
from [dbo].[_BarCodeLabel] a
	inner join 
		(
			select * from _BarStatus where iID in (select max(iID) from _BarStatus where BarCode = '{0}')
		)b on a.BarCode = b.BarCode and a.iSOsID = b.iSOsID
	left join SO_SODetails sos on a.iSOsID = sos.iSOsID
    left join SO_SODetails_extradefine soss on soss.iSOsID = sos.iSOsID
	left join SO_SOMain so on so.ID = SOS.ID
	left join Customer cus on so.cCusCode = cus.cCusCode
    left join [Inventory_extradefine] invExt on invExt.cInvCode = a.cInvCode
where a.BarCode = '{0}'and a.Process in (select cWhCode from Warehouse where cWhMemo like '%IQC%')
";
                    sSQL = string.Format(sSQL, sBarCode);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Please check barcode or process is err");
                    }

                    txtLotNo.Text = dt.Rows[0]["BarCode"].ToString().Trim();
                    txtiSOsID.Text = dt.Rows[0]["iSOsID"].ToString().Trim();
                    txtProcess.Text = dt.Rows[0]["Process"].ToString().Trim();

                    //判断单据是否已经存在
                    sSQL = @"
select a.* ,cus.cCusName
from [_IQC_RMDF] a inner join Customer cus on cus.cCusCode = a.cCusCode 
where a.LotNo = '{0}' and a.iSOsID = {1} and a.Process = '{2}'
";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim(), txtProcess.Text.Trim());
                    DataTable dtVoucher = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtVoucher != null && dtVoucher.Rows.Count > 0)
                    {
                        txtIQCNo.EditValue = dtVoucher.Rows[0]["IQCNo"].ToString().Trim();
                        txtRMDFNo.Text = dtVoucher.Rows[0]["RMDFNo"].ToString().Trim();
                        txtiSOsID.Text = dtVoucher.Rows[0]["iSOsID"].ToString().Trim();
                        txtLotNo.Text = dtVoucher.Rows[0]["LotNo"].ToString().Trim();

                        if (dtVoucher.Rows[0]["IQCStatus"].ToString().Trim().ToLower() == "iqc-passed")
                        {
                            radioPassed.Checked = true;
                        }
                        else
                        {
                            radioFailed.Checked = true;
                        }

                        txtBarCode2.Text = txtLotNo.Text;
                        txtLotQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["LotQty"]);

                        txtInsQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["InsQty"]);
                        txtSampleSize.EditValue = dtVoucher.Rows[0]["SampleSize"];
                        txtcCusCode.Text = dtVoucher.Rows[0]["cCusCode"].ToString().Trim();
                        txtcCusName.Text = dtVoucher.Rows[0]["cCusName"].ToString().Trim();
                        txtAQLLevel.EditValue = dtVoucher.Rows[0]["AQLLevel"];
                        dtmReceived.DateTime = BaseFunction.ReturnDate(dtVoucher.Rows[0]["dtmReceived"]);
                        dtmInspected.DateTime = BaseFunction.ReturnDate(dtVoucher.Rows[0]["dtmInspected"]);
                        txtInspectedby.Text = dtVoucher.Rows[0]["InspectedBy"].ToString().Trim();
                        txtProcess.Text = dtVoucher.Rows[0]["Process"].ToString().Trim();
                        txtcInvCode.Text = dtVoucher.Rows[0]["cInvCode"].ToString().Trim();
                        txtcInvName.Text = dtVoucher.Rows[0]["cInvName"].ToString().Trim();

                        txtATTENTION.Text = dtVoucher.Rows[0]["ATTENTION"].ToString().Trim();
                        txtDONO.Text = dtVoucher.Rows[0]["DONO"].ToString().Trim();
                        txtCONFIRMEDBY.Text = dtVoucher.Rows[0]["CONFIRMEDBY"].ToString().Trim();
                        txtDEFECTIVE.Text = dtVoucher.Rows[0]["DEFECTIVE"].ToString().Trim();
                        txtOthers.Text = dtVoucher.Rows[0]["REPLAYSLIP_Others"].ToString().Trim();
                        chk1.Checked = BaseFunction.ReturnBool(dtVoucher.Rows[0]["REPLAYSLIP_row1"]);
                        chk2.Checked = BaseFunction.ReturnBool(dtVoucher.Rows[0]["REPLAYSLIP_row2"]);
                        chk3.Checked = BaseFunction.ReturnBool(dtVoucher.Rows[0]["REPLAYSLIP_row3"]);
                        txtRemark.Text = dtVoucher.Rows[0]["Remark"].ToString().Trim();
                        txtAccept.EditValue = dtVoucher.Rows[0]["Accept"].ToString().Trim();
                        txtReject.EditValue = dtVoucher.Rows[0]["Reject"].ToString().Trim();

                        lBarCodeG.Text = dtVoucher.Rows[0]["BarCodeG"].ToString().Trim();
                        lBarCodeNG.Text = dtVoucher.Rows[0]["BarCodeNG"].ToString().Trim();

                        lookUpEditFeedback.EditValue = dtVoucher.Rows[0]["Feedback"].ToString().Trim();
                        if (BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["SortG"].ToString().Trim()) != 0)
                        {
                            txtSortGQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["SortG"].ToString().Trim());
                            txtSortNGQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["SortNG"].ToString().Trim());
                        }

                        sSQL = @"
select distinct a.DefectCode ,b.DefectName
from _Defects a left join [_DefectMaster_2] b on a.DefectCode = b.DefectCode
where cCusCode = '{0}'
order by a.DefectCode 
";
                        sSQL = string.Format(sSQL, txtcCusCode.Text.Trim());
                        DataTable dtDefects = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        ItemLookUpEdit1DefectCode.DataSource = dtDefects;
                        ItemLookUpEdit1DefectName.DataSource = dtDefects;

                        sSQL = @"
select *
from _IQC_RMDFs 
where IQCNo = '{0}'
order by iRow
";
                        sSQL = string.Format(sSQL, txtIQCNo.Text.Trim());
                        DataTable dts = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        gridControl1.DataSource = dts;
                        while (gridView1.RowCount < 10)
                        {
                            gridView1.AddNewRow();
                        }

                        gridView1.FocusedRowHandle = 0;

                        decimal d = 0;
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            d = d + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty));
                        }
                        if (d <= BaseFunction.ReturnDecimal(txtAccept.Text.Trim()))
                        {
                            txtResult.Text = "Accept";
                            txtResult.BackColor = Color.Green;
                        }
                        if (d >= BaseFunction.ReturnDecimal(txtReject.Text.Trim()))
                        {
                            txtResult.Text = "Reject";
                            txtResult.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        //IQCStatus = 'Pending IQC'  ,  b.Type = 'IQC'

                        txtResult.Text = "";

                        txtLotNo.Text = sBarCode;
                        txtiSOsID.Text = dt.Rows[0]["iSOsID"].ToString().Trim();
                        txtLotQty.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["LotQty"].ToString().Trim(), 2);
                        txtInsQty.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["LotQty"].ToString().Trim(), 2);
                        txtDONO.Text = dt.Rows[0]["cbdefine3"].ToString().Trim();
                        txtAQLLevel.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cidefine4"].ToString().Trim(), 2);
                        if (txtAQLLevel.Text.Trim() == "")
                        {
                            throw new Exception("Please set aql level");
                        }

                        if (BaseFunction.ReturnDecimal(txtLotQty.Text) == 1)
                        {
                            txtSampleSize.Text = "1";
                        }
                        else
                        {
                            txtcCusCode.Text = dt.Rows[0]["cCusCode"].ToString().Trim();
                            txtcCusName.Text = dt.Rows[0]["cCusName"].ToString().Trim();

                            txtProcess.Text = dt.Rows[0]["Process"].ToString().Trim();

                            txtcInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                            txtcInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();

                            lookUpEditFeedback.EditValue = dt.Rows[0]["Feedback"].ToString().Trim();

                            dtmReceived.DateTime = BaseFunction.ReturnDate(dt.Rows[0]["CreateDate"]);

                            sSQL = @"
exec _GetAQL {0},0,N'{1}'
";
                            sSQL = string.Format(sSQL, BaseFunction.ReturnDecimal(txtLotQty.Text.Trim()), txtcInvCode.Text.Trim());
                            DataTable dtAQL = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtAQL == null || dtAQL.Rows.Count == 0)
                            {
                                txtAccept.EditValue = DBNull.Value;
                                txtReject.EditValue = DBNull.Value;
                                txtSampleSize.EditValue = DBNull.Value;

                                throw new Exception("Please set aql inspection level");
                            }
                            txtSampleSize.EditValue = BaseFunction.ReturnDecimal(dtAQL.Rows[0]["SampleSize"]);
                            txtAccept.EditValue = BaseFunction.ReturnDecimal(dtAQL.Rows[0]["Accept"].ToString().Trim(), 2);
                            txtReject.EditValue = BaseFunction.ReturnDecimal(dtAQL.Rows[0]["Reject"].ToString().Trim(), 2);

                            sSQL = @"
select *
from [dbo].[_IQC_RMDFs]
where 1=-1
";
                            DataTable dts = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            gridControl1.DataSource = dts;
                            while (gridView1.RowCount < 10)
                            {
                                gridView1.AddNewRow();
                            }
                            gridView1.FocusedRowHandle = 0;
                        }

                        sSQL = @"
select distinct a.DefectCode ,b.DefectName
from _Defects a left join [_DefectMaster_2] b on a.DefectCode = b.DefectCode
where cCusCode = '{0}'
order by a.DefectCode 
";
                        sSQL = string.Format(sSQL, txtcCusCode.Text.Trim());
                        DataTable dtDefects = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        ItemLookUpEdit1DefectCode.DataSource = dtDefects;
                        ItemLookUpEdit1DefectName.DataSource = dtDefects;
                    }
                    lGUID.Text = Guid.NewGuid().ToString();

                    tran.Commit();

                    labelErr.BackColor = this.BackColor;
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                SetTxtNull();

                labelErr.BackColor = Color.Red;
                labelErr.Text = ee.Message;

                txtLotNo.Focus();
            }
        }

        private void txtLotNo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string sBarCode = txtLotNo.Text.Trim();
                    
                    if (sBarCode == "")
                        return;

                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                string sBarCode = txtLotNo.Text.Trim();
                if (sBarCode == "")
                    return;

                txtBarCode2.Text = sBarCode;

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }

        private void SetLookup()
        {
            string sSQL = @"
select CustomerFeedback as Feedback
from [dbo].[_CustomerFeedback]
order by CustomerFeedback
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditFeedback.Properties.DataSource = dt;

//            sSQL = @"
//select distinct SampleSize from [dbo].[_AQLSampleSizeMap] order by SampleSize
//";
//            dt = DbHelperSQL.Query(sSQL);
//            lookUpEditSampleSize.Properties.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";

                ClsUserRight cls = new ClsUserRight();
                if (!cls.HasRight("1000", sUserID, DbHelperSQL.connectionString))
                {
                    throw new Exception("User has no permissions");
                }
               
                if (BaseFunction.ReturnDecimal(txtSampleSize.Text.Trim()) == 0)
                {
                    txtSampleSize.Focus();
                    throw new Exception("Sample Size Err");
                }


                string sSQL = "";
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                if (lookUpEditFeedback.EditValue != null && lookUpEditFeedback.EditValue.ToString().Trim() != "" && txtIQCNo.Text.Trim() != "")
                {
                    DialogResult d = MessageBox.Show("Feedback is not empty,Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.Yes)
                    {
                        try
                        {
                            //判断单据是否存在，存在则保存表体，不存在退出并提示
                            sSQL = @"
select IQCNo from [dbo].[_IQC_RMDF] where IQCNo = '{0}'
";
                            sSQL = string.Format(sSQL, txtIQCNo.Text.Trim());
                            DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtTemp == null || dtTemp.Rows.Count == 0)
                            {
                                throw new Exception("No data");
                            }
                            else
                            {
                                sSQL = @"
delete _IQC_RMDFs where IQCNo = '{0}'
";
                                sSQL = string.Format(sSQL, txtIQCNo.Text.Trim());
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                decimal dQtyList = 0;
                                int iRow = 0;

                                for (int i = 0; i < gridView1.RowCount; i++)
                                {
                                    Model._IQC_RMDFs mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._IQC_RMDFs();
                                    mods.Defect = gridView1.GetRowCellValue(i, gridColDefect).ToString().Trim();

                                    if (mods.Defect == "")
                                        continue;

                                    mods.IQCNo = txtIQCNo.Text.Trim();
                                    iRow += 1;
                                    mods.iRow = iRow;

                                    mods.Qty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty), 2);
                                    if (mods.Qty < 0)
                                    {
                                        sErr = sErr + "Row " + (i + 1).ToString() + " qty is err\n";
                                        continue;
                                    }
                                    dQtyList = dQtyList + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty), 2);

                                    mods.Attachment = gridView1.GetRowCellValue(i, gridColAttachment).ToString().Trim();
                                    mods.AttachmentName = gridView1.GetRowCellValue(i, gridColAttachmentName).ToString().Trim();
                                    mods.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();


                                    if (mods.Attachment.Trim().Length > 0)
                                    {
                                        int iLastIndex = mods.Attachment.LastIndexOf('.');
                                        if (iLastIndex > 0 && mods.Attachment.Length > iLastIndex)
                                        {
                                            mods.fileext = mods.Attachment.Substring(iLastIndex + 1);
                                        }
                                    }


                                    DAL._IQC_RMDFs dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._IQC_RMDFs();
                                    sSQL = dals.Add(mods);
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                            }

                            if (sErr.Length > 0)
                            {
                                throw new Exception(sErr);
                            }

                            tran.Commit();

                            SetTxtNull();
                            labelErr.Text = "Save Ok";

                            txtLotNo.Focus();
                        }
                        catch (Exception ee)
                        {
                            tran.Rollback();

                            throw new Exception(ee.Message);
                        }
                    }
                    else
                    {
                        throw new Exception("User cancelled");
                    }
                }
                else
                {
                    if (txtLotNo.Text.Trim() == "")
                    {
                        txtLotNo.Focus();
                        throw new Exception("Please scan lotno");
                    }

                    try
                    {
                        if (radioPassed.Checked == false && radioFailed.Checked == false)
                        {
                            throw new Exception("Please check status");
                        }

                        string sStatusCode = "";

                        sSQL = @"
select *
from [_IQC_RMDF] 
where LotNo = '{0}' and iSOsID = {1}
";
                        sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            sStatusCode = "add";
                        }
                        else
                        {
                            if (dt.Rows[0]["Feedback"].ToString().Trim() == "")
                            {
                                sStatusCode = "update";
                            }
                            else
                            {
                                sStatusCode = "audit";
                                throw new Exception("be Feedback");
                            }
                        }

                        SaveIQC(tran, sStatusCode);

                        tran.Commit();

                        if (radioFailed.Checked)
                        {
                            SendeMail();
                        }

                        SetTxtNull();
                        SetEnable(true);
                        SetBtnEnable(true);

                        labelErr.Text = "OK";
                        labelErr.BackColor = Color.Green;
                        txtLotNo.Focus();
                    }
                    catch (Exception ee)
                    {
                        tran.Rollback();
                        throw new Exception(ee.Message);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SetEnable(true);
                SetTxtNull();
            }
            catch { }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.AddNewRow();
            }
            catch { }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                string sSerFileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColAttachmentName).ToString().Trim();

                try
                {
                    if (sSerFileName != "")
                    {
                        if (File.Exists(sServerPath + "\\" + sSerFileName))
                        {
                            File.Delete(sServerPath + "\\" + sSerFileName);
                        }
                    }
                }
                catch { }

                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
            catch { }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                ClsUserRight cls = new ClsUserRight();
                if (!cls.HasRight("1010", sUserID, DbHelperSQL.connectionString))
                {
                    throw new Exception("User has no permissions");
                }

                if (radioPassed.Checked)
                {
                    txtLotNo.Text = "";
                    txtLotNo.Focus();
                    throw new Exception("This barcode is passed");
                }

                //if (lookUpEditFeedback.EditValue.ToString().Trim().ToLower() == "sort")
                //{ 
                //    if(BaseFunction.ReturnDecimal(txtSortNGQty.Text.Trim()) + BaseFunction.ReturnDecimal(txtSortGQty.Text.Trim()) != BaseFunction.ReturnDecimal(txtLotQty.Text.Trim()))
                //    {
                //        throw new Exception("Sort Qty is err");
                //    }
                //}
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sStatusCode = "audit";

                    if (lookUpEditFeedback.Text.Trim() == "")
                    {
                        throw new Exception("Please set feedback");
                    }

                    string sSQL = @"
select *
from _BarCodeLabel
where BarCode = '{0}' and iSOsID = {1}
";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim());
                    DataTable dtBarCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    decimal dG = BaseFunction.ReturnDecimal(txtSortGQty.Text.Trim());
                    decimal dNG = BaseFunction.ReturnDecimal(txtSortNGQty.Text.Trim());
                    decimal dLotQty = BaseFunction.ReturnDecimal(txtLotQty.Text.Trim());
                    decimal dLotQty_BarCode = BaseFunction.ReturnDecimal(dtBarCode.Rows[0]["LotQty"]);

                    if (dLotQty_BarCode != dLotQty)
                    {
                        throw new Exception("The bar code has been splited");
                    }

                    SaveIQC(tran, sStatusCode);

                    sSQL = @"
Update [_IQC_RMDF] set Feedback = '{2}'
where LotNo = '{0}' and iSOsID = {1}
";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim(), lookUpEditFeedback.EditValue.ToString().Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
update _BarCodeLabel set IQCStatus = 'IQC-{2}'
where BarCode = '{0}' and iSOsID = {1}
                    ";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim(), lookUpEditFeedback.EditValue.ToString().Trim().ToUpper());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    SetTxtNull();
                    SetEnable(true);
                    SetBtnEnable(true);

                    labelErr.Text = "OK";
                    labelErr.BackColor = Color.Green;

                    txtLotNo.Focus();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }

        private void lookUpEditFeedback_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtRemark.Enabled = true;
                txtOthers.Enabled = false;


                if (lookUpEditFeedback.EditValue.ToString().Trim().ToLower() == "SORT".ToLower())
                {
                    labelSortGQty.Visible = true;
                    txtSortGQty.Visible = true;
                    txtSortGQty.EditValue = DBNull.Value;

                    lSortedNGQty.Visible = true;
                    txtSortNGQty.Visible = true;
                    txtSortNGQty.EditValue = DBNull.Value;

                    lookUpEditPrinter.Enabled = true;
                    radioPreview.Enabled = true;
                    radioPrint.Enabled = true;
                }
                else
                {
                    labelSortGQty.Visible = false;
                    txtSortGQty.Visible = false;

                    lSortedNGQty.Visible = false;
                    txtSortNGQty.Visible = false;
                }

                if (lookUpEditFeedback.EditValue.ToString().Trim().ToLower() == "other".ToLower())
                {
                    chk1.Checked = false;
                    chk2.Checked = false;
                    chk3.Checked = false;
                    txtRemark.Text = "";
                    txtRemark.Enabled = false;
                    txtOthers.Enabled = true;
                }
                else
                {
                    txtOthers.Text = "";
                }

                if (lookUpEditFeedback.EditValue.ToString().Trim().ToLower() == "SORT".ToLower())
                {
                    chk1.Checked = false;
                    chk2.Checked = false;
                    chk3.Checked = true;
                }
                if (lookUpEditFeedback.EditValue.ToString().Trim().ToLower() == "UAI".ToLower())
                {
                    chk1.Checked = false;
                    chk2.Checked = true;
                    chk3.Checked = false;
                }
                if (lookUpEditFeedback.EditValue.ToString().Trim().ToLower() == "RETURN".ToLower())
                {
                    chk1.Checked = true;
                    chk2.Checked = false;
                    chk3.Checked = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }

        private void BarCodeSplit(SqlTransaction tran)
        {
            string sSQL = "select getdate()";
            DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
            DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

            sSQL = @"
select * 
from _BarCodeLabel 
where 1=1 
order by BarCode desc
";
            sSQL = sSQL.Replace("1=1", "1=1 and BarCode = '" + txtBarCode2.Text.Trim() + "'");
            sSQL = sSQL.Replace("1=1", "1=1 and  iSOsID = '" + txtiSOsID.Text.Trim() + "'");

            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("Please scan barcode");
            }

            string sStatus = BaseFunction.ReturnStatus(dt.Rows[0]["status"].ToString().Trim());
            if (sStatus.ToLower() == "pending")
            {
                throw new Exception("Lot no is pending err\n");
            }

            sSQL = @"
select *
FROM      _BarStatus
where  1=1
order by iID desc
";
            sSQL = sSQL.Replace("1=1", "1=1 and BarCode = '" + txtBarCode2.Text.Trim() + "'");
            sSQL = sSQL.Replace("1=1", "1=1 and  iSOsID = '" + txtiSOsID.Text.Trim() + "'");
            DataTable dtBarStatus = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


//            //原条码置为 0 
//            sSQL = @"
//update _BarCodeLabel set [Status] = 'IQC-SORT',LOTQTY = 0,LOTQTY2 = {0}
//WHERE BarCode = '{1}' and iSOsID = '{2}'
//";
//            sSQL = string.Format(sSQL, dt.Rows[0]["LOTQTY"], txtBarCode2.Text.Trim(), txtiSOsID.Text.Trim());
//            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//            DAL.BarStatus dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
//            Model.BarStatus models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
//            models = dals.DataRowToModel(dtBarStatus.Rows[0]);
//            models.Type = "IQC-SORT";
//            sSQL = dals.Add(models);
//            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//            //回写上一道工序的结束时间
//            sSQL = @"
//declare @iID int 
//select @iID = max(iID)
//from _BarStatus
//where [BarCode] = '{0}' and iSOsID = '{1}'
//    and iID < (
//        select max(iID) as maxID
//        from _BarStatus
//        where [BarCode] = '{0}' and iSOsID = '{1}'
//    )
//
//update _BarStatus set EndTime = '{2}' where iID = @iID and [BarCode] = '{0}' and iSOsID = '{1}'
//";
//            sSQL = string.Format(sSQL, models.BarCode, models.iSOsID, dNow);
//            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            int iBarCodeList = 0;

            //SORT G
            DAL._BarCodeLabel dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._BarCodeLabel();
            Model._BarCodeLabel model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel();
            model = dal.DataRowToModel(dt.Rows[0]);

            string[] sBarCodeList = txtBarCode2.Text.Split('-');

            sSQL = @"
select max(BarCode) as BarCodeNew 
from _BarCodeLabel 
where 1=1 
";
            sSQL = sSQL.Replace("1=1", "1=1 and BarCode like '" + sBarCodeList[0].Trim() + "%'");
            sSQL = sSQL.Replace("1=1", "1=1 and  iSOsID = '" + txtiSOsID.Text.Trim() + "'");

            DataTable dtBarCodeNew = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            sBarCodeList = dtBarCodeNew.Rows[0]["BarCodeNew"].ToString().Trim().Split('-');
            string sBarCodeNew = sBarCodeList[0].Trim();
            if (sBarCodeList.Length == 1)
            {
                iBarCodeList = 1;
            }
            else
            {
                iBarCodeList = BaseFunction.ReturnInt(sBarCodeList[1]) + 1;
            }
            sBarCodeNew = sBarCodeNew + "-" + iBarCodeList.ToString().PadLeft(4, '0');

            model.oldBarCode = txtBarCode2.Text.Trim();
            model.BarCode = sBarCodeNew;
            model.LOTQTY = BaseFunction.ReturnDecimal(txtSortGQty.Text.Trim());
            model.Status = "IQC";
            model.IQCStatus = "IQC-SORT-G";

            sSQL = dal.Add(model);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            lBarCodeG.Text = model.BarCode;

            Model.BarStatus models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
            models.BarCode = model.BarCode;
            models.Type = model.IQCStatus;
            models.QTY = model.LOTQTY;
            models.UpdateTime = dNow;
            models.CreateDate = dNowDate;
            models.CreateUid = sUserID;
            models.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text);
            models.RoutingFrom = dtBarStatus.Rows[0]["RoutingFrom"].ToString().Trim();
            models.RoutingTo = dtBarStatus.Rows[0]["RoutingTo"].ToString().Trim();
            DAL.BarStatus dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
            sSQL = dals.Add(models);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


            //回写上一道工序的结束时间
            sSQL = @"
declare @iID int 
select @iID = max(iID)
from _BarStatus
where [BarCode] = '{0}' and iSOsID = '{1}'
    and iID < (
        select max(iID) as maxID
        from _BarStatus
        where [BarCode] = '{0}' and iSOsID = '{1}'
    )

update _BarStatus set EndTime = '{2}' where iID = @iID and [BarCode] = '{0}' and iSOsID = '{1}'
";
            sSQL = string.Format(sSQL, models.BarCode, models.iSOsID, dNow);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            //SORT NG

            dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._BarCodeLabel();
            model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel();
            model = dal.DataRowToModel(dt.Rows[0]);
            model.BarCode = sBarCodeList[0].Trim() + "-" + (iBarCodeList + 1).ToString().PadLeft(4, '0');
            model.Status = "IQC";
            model.IQCStatus = "IQC-SORT-NG";
            model.LOTQTY = BaseFunction.ReturnDecimal(txtSortNGQty.Text.Trim());
            model.oldBarCode = txtBarCode2.Text.Trim();
            sSQL = dal.Add(model);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            lBarCodeNG.Text = model.BarCode;

            models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
            models.BarCode = model.BarCode;
            models.Type = model.IQCStatus;
            models.QTY = model.LOTQTY;
            models.UpdateTime = dNow;
            models.CreateDate = dNowDate;
            models.CreateUid = sUserID;
            models.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text);
            models.RoutingFrom = dtBarStatus.Rows[0]["RoutingFrom"].ToString().Trim();
            models.RoutingTo = dtBarStatus.Rows[0]["RoutingTo"].ToString().Trim();
            dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
            sSQL = dals.Add(models);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


            //回写上一道工序的结束时间
            sSQL = @"
declare @iID int 
select @iID = max(iID)
from _BarStatus
where [BarCode] = '{0}' and iSOsID = '{1}'
    and iID < (
        select max(iID) as maxID
        from _BarStatus
        where [BarCode] = '{0}' and iSOsID = '{1}'
    )

update _BarStatus set EndTime = '{2}' where iID = @iID and [BarCode] = '{0}' and iSOsID = '{1}'
";
            sSQL = string.Format(sSQL, models.BarCode, models.iSOsID, dNow);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
        }


        private void SaveIQC(SqlTransaction tran,string sStatusCode)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";

            int iCount = 0;
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string s1 = gridView1.GetRowCellValue(i, gridColDefect).ToString().Trim().ToLower();
                    if (s1 == "")
                    {
                        continue;
                    }

                    for (int j = i + 1; j < gridView1.RowCount; j++)
                    {
                        string s2 = gridView1.GetRowCellValue(j, gridColDefect).ToString().Trim().ToLower();

                        if (s1 == s2)
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " Row " + (j + 1) + " defect is same\n";
                            break;
                        }
                    }
                }

                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (txtLotNo.Text.Trim() != txtBarCode2.Text.Trim())
                {
                    txtLotNo.Focus();
                    throw new Exception("Lot no is err");
                }
                string sSQL = "select getdate()";
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                DateTime dtmNow = BaseFunction.ReturnDate(dt.Rows[0][0]);

                sSQL = @"
select top 1 * from [dbo].[_BarCodeLabel]
where BarCode = '{0}' and iSOsID = {1} and [Process] in (select cWhCode from Warehouse where cWhMemo like '%IQC%')
    and Process = '{2}'
";
                sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim(), txtProcess.Text.Trim());
                DataTable dtBarCodeLabel = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtBarCodeLabel == null || dtBarCodeLabel.Rows.Count == 0)
                {
                    throw new Exception("Process is err");
                }
                decimal dLotQty = BaseFunction.ReturnDecimal(dtBarCodeLabel.Rows[0]["LotQty"]);
                if(dLotQty != BaseFunction.ReturnDecimal(txtLotQty.Text.Trim()))
                {
                    throw new Exception("Barcode splited");
                }

                sSQL = @"
select * from [_IQC_RMDF]
where LotNo = '{0}' and iSOsID = {1} and Process = '{2}'
";
                sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim(), txtProcess.Text.Trim());
                DataTable dtVoucher = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                bool bExists = false;
                if (dtVoucher != null && dtVoucher.Rows.Count > 0)
                {
                    if (dtVoucher.Rows[0]["ClosedUid"].ToString().Trim() != "")
                    {
                        throw new Exception("Closed");
                    }

                    bExists = true;
                    txtIQCNo.Text = dtVoucher.Rows[0]["IQCNo"].ToString().Trim();
                    txtRMDFNo.Text = dtVoucher.Rows[0]["RMDFNo"].ToString().Trim();
                }

                string sCode = txtIQCNo.Text.Trim();
                if (!bExists)
                {
                    sSQL = @"
select isnull(max(IQCNo),0) as IQCNo
from _IQC_RMDF
where IQCNo like '{0}%'
";
                    sSQL = string.Format(sSQL, "IQC" + dtmNow.ToString("yyMM"));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iCode = 0;

                    if (dt.Rows[0]["IQCNo"].ToString().Length > 7)
                    {
                        iCode = BaseFunction.ReturnInt(dt.Rows[0]["IQCNo"].ToString().Trim().Substring(7));
                    }

                    sCode = (iCode + 1).ToString();
                    sCode = sCode.PadLeft(6, '0');
                    sCode = "IQC" + dtmNow.ToString("yyMM") + sCode;
                    txtIQCNo.Text = sCode;
                }

                if (txtRMDFNo.Text.Trim() == "" && radioFailed.Checked)
                {
                    sSQL = @"
select isnull(max(RMDFNo),0) as RMDFNo
from _IQC_RMDF
where RMDFNo like '{0}%'
";
                    sSQL = string.Format(sSQL, "RMDF" + dtmNow.ToString("yyMMdd"));
                    DataTable dtRMDFNo = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iCodeRMDF = 0;

                    if (dtRMDFNo.Rows[0]["RMDFNo"].ToString().Length > 10)
                    {
                        iCodeRMDF = BaseFunction.ReturnInt(dtRMDFNo.Rows[0]["RMDFNo"].ToString().Trim().Substring(10));
                    }
                    string sCodeRMDF = (iCodeRMDF + 1).ToString();
                    sCodeRMDF = sCodeRMDF.PadLeft(4, '0');
                    sCodeRMDF = "RMDF" + dtmNow.ToString("yyMMdd") + sCodeRMDF;
                    txtRMDFNo.Text = sCodeRMDF;
                }

                Model._IQC_RMDF mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._IQC_RMDF();
                mod.IQCNo = txtIQCNo.Text.Trim();
                mod.RMDFNo = txtRMDFNo.Text.Trim();
                mod.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text.Trim());
                mod.LotNo = txtBarCode2.Text.Trim();
                mod.Remark = txtRemark.Text.Trim();

                if (mod.LotNo == "")
                {
                    txtLotNo.Focus();
                    throw new Exception("Please scan barcode");
                }

                mod.LotQty = BaseFunction.ReturnDecimal(txtLotQty.Text.Trim(), 2);
                mod.InsQty = BaseFunction.ReturnDecimal(txtInsQty.Text.Trim(), 2);
                if (mod.InsQty <= 0)
                {
                    txtInsQty.Focus();
                    throw new Exception("Please set inspection qty");
                }

                if (radioPassed.Checked)
                {
                    mod.IQCStatus = "IQC-Passed";
                }
                if (radioFailed.Checked)
                {
                    mod.IQCStatus = "IQC-ONHOLD";
                }

                mod.SampleSize = BaseFunction.ReturnDecimal(txtSampleSize.Text.Trim(), 2);
                mod.cCusCode = txtcCusCode.Text.Trim();
                mod.AQLLevel = txtAQLLevel.Text.Trim();
                mod.dtmReceived = dtmReceived.DateTime;
                mod.dtmInspected = dtmNow;

                string sSQLTemp = @"
select cPsn_Name as cPersonName from hr_hi_person where cPsn_Num = '{0}'
";
                sSQLTemp = string.Format(sSQLTemp, txtUid.Text.Trim());
                DataTable dtPersonName = DbHelperSQL.Query(sSQLTemp);
                mod.InspectedBy = dtPersonName.Rows[0]["cPersonName"].ToString().Trim();

                mod.CreateUid = txtUid.Text.Trim();
                mod.dtmCreate = dtmNow;
                mod.cInvCode = txtcInvCode.Text.Trim();
                mod.cInvName = txtcInvName.Text.Trim();
                mod.ATTENTION = txtATTENTION.Text.Trim();
                mod.DONO = txtDONO.Text.Trim();
                mod.CONFIRMEDBY = txtCONFIRMEDBY.Text.Trim();
                mod.DEFECTIVE = txtDEFECTIVE.Text.Trim();
                mod.Process = txtProcess.Text.Trim();

                if (chk1.Checked)
                {
                    mod.REPLAYSLIP_row1 = true;
                }
                else
                {
                    mod.REPLAYSLIP_row1 = false;
                }
                if (chk2.Checked)
                {
                    mod.REPLAYSLIP_row2 = true;
                }
                else
                {
                    mod.REPLAYSLIP_row2 = false;
                }
                if (chk3.Checked)
                {
                    mod.REPLAYSLIP_row3 = true;
                }
                else
                {
                    mod.REPLAYSLIP_row3 = false;
                }
                mod.REPLAYSLIP_Others = txtOthers.Text.Trim();

                if (lookUpEditFeedback.Text.Trim() != "")
                {
                    mod.Feedback = lookUpEditFeedback.Text.Trim();
                }

                mod.AQLLevel = txtAQLLevel.Text.Trim();
                mod.Accept = BaseFunction.ReturnDecimal(txtAccept.Text.Trim());
                mod.Reject = BaseFunction.ReturnDecimal(txtReject.Text.Trim());
                mod.Result = txtResult.Text.Trim();

                DAL._IQC_RMDF dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._IQC_RMDF();
                if (bExists)
                {
                    sSQL = dal.Update(mod);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                else
                {
                    sSQL = dal.Add(mod);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                sSQL = @"
update _IQC_RMDF set SaveCount = isnull(SaveCount,0) + 1 
where  RMDFNo = '{0}'
";
                sSQL = string.Format(sSQL, mod.RMDFNo);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (bExists)
                {
                    sSQL = @"
delete _IQC_RMDFs where IQCNo = '{0}'
";
                    sSQL = string.Format(sSQL, mod.IQCNo);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                decimal dQtyList = 0;
                int iRow = 0;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    Model._IQC_RMDFs mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._IQC_RMDFs();
                    mods.Defect = gridView1.GetRowCellValue(i, gridColDefect).ToString().Trim();

                    if (mods.Defect == "")
                        continue;

                    mods.IQCNo = mod.IQCNo;
                    iRow += 1;
                    mods.iRow = iRow;

                    mods.Qty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty), 2);
                    if (mods.Qty < 0)
                    {
                        sErr = sErr + "Row " + (i + 1).ToString() + " qty is err\n";
                        continue;
                    }
                    dQtyList = dQtyList + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty), 2);

                    //if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty), 2) > BaseFunction.ReturnDecimal(lookUpEditSampleSize.Text.Trim()))
                    if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty), 2) > BaseFunction.ReturnDecimal(txtLotQty.Text.Trim()))
                    {
                        sErr = sErr + "Row " + (i + 1).ToString() + " the number is beyond\n";
                    }
                    mods.Attachment = gridView1.GetRowCellValue(i, gridColAttachment).ToString().Trim();
                    mods.AttachmentName = gridView1.GetRowCellValue(i, gridColAttachmentName).ToString().Trim();
                    mods.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();

                    if (mods.Attachment.Trim().Length > 0)
                    {
                        int iLastIndex = mods.Attachment.LastIndexOf('.');
                        if (iLastIndex > 0 && mods.Attachment.Length > iLastIndex)
                        {
                            mods.fileext = mods.Attachment.Substring(iLastIndex + 1);
                        }
                    }

                    DAL._IQC_RMDFs dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._IQC_RMDFs();
                    sSQL = dals.Add(mods);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                //if (dQtyList > BaseFunction.ReturnDecimal(lookUpEditSampleSize.Text.Trim()))
                //{
                //    sErr = sErr + "The number is beyond\n";
                //}

                if(dQtyList >= BaseFunction.ReturnDecimal(txtReject.Text.Trim()))
                {
                    txtResult.Text = "Reject";
                }
                if(dQtyList <= BaseFunction.ReturnDecimal(txtAccept.Text.Trim()))
                {
                    txtResult.Text = "Accept";
                }

                #region Log

                string sGuid = Guid.NewGuid().ToString().Trim();
                sSQL = @"
insert into [dbo].[_IQC_RMDF_log]([GUID], IQCNo, RMDFNo, IQCStatus, iSOsID, LotNo, cInvCode, cInvName, 
    sStatus, [Action], LotQty, InsQty, SampleSize, cCusCode, AQLLevel, Accept, Reject, Result, 
    dtmReceived, dtmInspected, InspectedBy, CreateUid, dtmCreate, UpdateUid, dtmUpdate, 
    AuditUid, dtmAudit, SendMailCount, SendMailUid, dtmSendMail, Feedback, SaveCount, 
    Process, ATTENTION, DONO, CONFIRMEDBY, DEFECTIVE, REPLAYSLIP_row1, 
    REPLAYSLIP_row2, REPLAYSLIP_row3, REPLAYSLIP_Others, ClosedUid, dtmClose, 
    Remark, dtmLog
)
select '{1}',IQCNo, RMDFNo, IQCStatus, iSOsID, LotNo, cInvCode, cInvName, 
    sStatus, [Action], LotQty, InsQty, SampleSize, cCusCode, AQLLevel, Accept, Reject, Result, 
    dtmReceived, dtmInspected, InspectedBy, CreateUid, dtmCreate, UpdateUid, dtmUpdate, 
    AuditUid, dtmAudit, SendMailCount, SendMailUid, dtmSendMail, Feedback, SaveCount, 
    Process, ATTENTION, DONO, CONFIRMEDBY, DEFECTIVE, REPLAYSLIP_row1, 
    REPLAYSLIP_row2, REPLAYSLIP_row3, REPLAYSLIP_Others, ClosedUid, dtmClose, 
    Remark,getdate()
from [dbo].[_IQC_RMDF]
where IQCNo = '{0}'
";
                sSQL = string.Format(sSQL, mod.IQCNo, sGuid);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into [dbo].[_IQC_RMDFs_log](GUIDHead, IQCNo, iRow, Defect, Qty, Attachment,AttachmentName, Remark,dtmLog)
select '{1}',IQCNo,iRow,Defect,Qty,Attachment,AttachmentName,Remark,getdate()
from [dbo].[_IQC_RMDFs]
where IQCNo = '{0}'
";
                sSQL = string.Format(sSQL, mod.IQCNo, sGuid);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                #endregion

                Model.BarStatus model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                model.BarCode = mod.LotNo;
                model.iSOsID = (long)mod.iSOsID;
                if (sStatusCode == "add" || sStatusCode == "update")
                {
                    if (radioPassed.Checked)
                    {
                        model.Type = "IQC-Passed";
                    }
                    else
                    {
                        model.Type = "IQC-ONHOLD";
                    }
                    sSQL = @"
update [_BarCodeLabel] set IQCStatus = '{0}',[Status] = 'IQC'
where BarCode = '{1}' and iSOsID = {2}
";
                    sSQL = string.Format(sSQL, model.Type, model.BarCode, model.iSOsID);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                else
                {
                    model.Type = "IQC-" + lookUpEditFeedback.EditValue.ToString().Trim();

                    sSQL = @"
update [_BarCodeLabel] set IQCStatus = '{2}'
where [BarCode] = '{0}' and iSOsID = '{1}'
";
                    sSQL = string.Format(sSQL, model.BarCode, model.iSOsID, model.Type);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                model.RoutingFrom = txtProcess.Text.Trim();
                model.RoutingTo = txtProcess.Text.Trim();
                model.UpdateTime = dtmNow;
                model.QTY = mod.LotQty;
                model.CreateUid = txtUid.Text.Trim();
                model.CreateDate = dtmNow;
                DAL.BarStatus dalStatus = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();

                //sSQL = dalStatus.Add(model);
                //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                //当状态没有改变时，不增加状态记录
                sSQL = @"
select * 
from _BarStatus 
WHERE 1=1 and Type = '{4}' and  iID in (
    select max(iID)
    from _BarStatus
    where BarCode = '{0}' and iSOsID = {1} and RoutingFrom = '{2}' and RoutingTo = '{3}' 
)
";
                sSQL = string.Format(sSQL, model.BarCode, model.iSOsID, model.RoutingFrom, model.RoutingTo, model.Type);
                DataTable dtExist = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtExist == null || dtExist.Rows.Count == 0)
                {
                    sSQL = dalStatus.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //回写上一道工序的结束时间
                    sSQL = @"
declare @iID int 
select @iID = max(iID)
from _BarStatus
where [BarCode] = '{0}' and iSOsID = '{1}'
    and iID < (
        select max(iID) as maxID
        from _BarStatus
        where [BarCode] = '{0}' and iSOsID = '{1}'
    )

update _BarStatus set EndTime = '{2}' where iID = @iID and [BarCode] = '{0}' and iSOsID = '{1}'
";
                    sSQL = string.Format(sSQL, model.BarCode, model.iSOsID, dtmNow);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                else
                {
                    model.UpdateTime = BaseFunction.ReturnDate("1900-01-01");
                    sSQL = dalStatus.Update(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                dtmInspected.DateTime = dtmNow;
                txtInspectedby.Text = mod.InspectedBy;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void ItemButtonEditFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColDefect).ToString().Trim() == "")
                {
                    return;
                }

                OpenFileDialog o = new OpenFileDialog();
                o.ShowDialog();
                string sPath = o.FileName.Trim();

                if (sPath != "")
                {
                    if (!File.Exists(sPath))
                    {
                        throw new Exception("File is not exists");
                    }
                    FileInfo file = new FileInfo(sPath);
                    long size = file.Length;  //文件大小。byte
                    decimal lSizeM = (decimal)size / (decimal)1024.00 / (decimal)1024.00;
                    if (lSizeM > iAttSize)
                    {
                        throw new Exception("File over " + iAttSize.ToString() + "M");
                    }

                    string[] sTemp = sPath.Split('\\');
                    string sFileName = sTemp[sTemp.Length - 1];
                    string[] s = sFileName.Split('.');


                    //if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColAttachmentName).ToString().Trim() == "")
                    //{
                        string sGuid = Guid.NewGuid().ToString();
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColAttachmentName, sGuid + "." + s[s.Length - 1]);
                    //}
                    string sSerFileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColAttachmentName).ToString().Trim();

                    try
                    {
                        if (File.Exists(sServerPath + "\\" + sSerFileName))
                        {
                            File.Delete(sServerPath + "\\" + sSerFileName);
                        }
                        File.Copy(sPath, sServerPath + "\\" + sSerFileName);
                    }
                    catch (Exception ee)
                    {
                        throw new Exception("Failed to upload file:" + ee.Message);
                    }

                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColAttachment, sFileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);    
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColQty)
                {
                    txtResult.BackColor = txtLotNo.BackColor;
                    decimal d = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        d = d + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty));
                    }
                    
                    if (d <= BaseFunction.ReturnDecimal(txtAccept.Text.Trim()))
                    {
                        txtResult.Text = "Accept";
                        txtResult.BackColor = Color.Green;
                    }
                    if (d >= BaseFunction.ReturnDecimal(txtReject.Text.Trim()))
                    {
                        txtResult.Text = "Reject";
                        txtResult.BackColor = Color.Red;
                    }

                    if (d > BaseFunction.ReturnDecimal(txtSampleSize.Text.Trim()))
                    {
                        txtSampleSize.BackColor = Color.Red;
                    }
                    else
                    {
                        txtSampleSize.BackColor = txtLotNo.BackColor;
                    }
                }
            }
            catch { }
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

        private void txtSortGQty_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSortNGQty_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void PrintBarCode()
        {
            try
            {
                string sSQL = @"
select distinct
    a.barCode, a.SaleOrderNo, a.SaleOrderRowNo, a.iSOsID, a.cInvCode, a.cInvName, a.cInvStd, Inv.cInvDepCode as DEPT 
    ,b.cDepName as DEPTName, CUST,ORDERNO AS ORDNO, CUSTDO, LOTNO, ORDERQTY, LOTQTY, RECDate, DueDate, Creater, CreateDate 
    ,PrintTime, PrintCount, a.cInvCode AS ITEMNO, a.cInvName AS ITEMDESC 
    ,RECDate,DueDate
    ,cast(null as varchar(50)) as RECDate2,cast(null as varchar(50)) as DueDate2
    ,ORDERQTY as ORDQTY
    ,CUSTLOT
    ,'Printed on ' as PrintInfo
    ,c.cMemo
    ,Inv.cInvDefine6
    ,Inv.cComUnitCode as cUnitID
from _BarCodeLabel a
    inner join Inventory Inv on a.cInvCode = Inv.cInvCode
    left join Department b on Inv.cInvDepCode = b.cDepCode
    left join SO_SODetails c on c.iSOsID = a.iSOsID
where (a.barCode = '{0}' or a.barCode = '{1}') and a.iSOsID = {2}
order by a.barCode
";
                if (lookUpEditFeedback.Text.Trim().ToLower() == "sort")
                {
                    sSQL = string.Format(sSQL, lBarCodeG.Text.Trim(), lBarCodeNG.Text.Trim(),txtiSOsID.Text.Trim());
                }
                else
                {
                    sSQL = string.Format(sSQL, txtBarCode2.Text.Trim(), txtBarCode2.Text.Trim(), txtiSOsID.Text.Trim());
                }
                DataTable dtBarCode = DbHelperSQL.Query(sSQL);
                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    throw new Exception("No barcode");
                }

                for (int i = 0; i < dtBarCode.Rows.Count; i++)
                {
                    dtBarCode.Rows[i]["PrintInfo"] = "Printed on " + BaseFunction.ReturnDate(dtBarCode.Rows[i]["PrintTime"]).ToString("yyyy/MM/dd HH:mm:ss");
                    dtBarCode.Rows[i]["RECDate2"] = BaseFunction.ReturnDate(dtBarCode.Rows[i]["RECDate"]).ToString("yyyy-MM-dd");
                    dtBarCode.Rows[i]["DueDate2"] = BaseFunction.ReturnDate(dtBarCode.Rows[i]["DueDate"]).ToString("yyyy-MM-dd");
                }

                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }
                Rep.dsPrint.Tables.Clear();
                Rep.dsPrint.Tables.Add(dtBarCode.Copy());
                Rep.dsPrint.Tables[0].TableName = "dtGrid";

                if (radioPreview.Checked)
                {
                    Rep.ShowPreview();
                }
                if (radioPrint.Checked)
                {
                    if (lookUpEditPrinter.Text.Trim() == "")
                    {
                        lookUpEditPrinter.Focus();
                        throw new Exception("Please choose printer");
                    }
                    Rep.PrinterName = lookUpEditPrinter.Text.Trim();
                    Rep.Print();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void txtSortGQty_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtSortGQty.Text.Trim() == "")
                {
                    return;
                }

                decimal dQty = BaseFunction.ReturnDecimal(txtLotQty.Text.Trim());
                decimal dSortG = BaseFunction.ReturnDecimal(txtSortGQty.Text.Trim());
                decimal dSortNG = BaseFunction.ReturnDecimal(txtSortNGQty.Text.Trim());

                if (dSortG >= dQty)
                {
                    txtSortGQty.Focus();
                    txtSortGQty.EditValue = DBNull.Value;
                    throw new Exception("Sort G Qty err");
                }

                if (dQty == dSortG + dSortNG)
                {
                    return;
                }

                txtSortNGQty.EditValue = dQty - dSortG;
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void txtSortNGQty_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtSortNGQty.Text.Trim() == "")
                {
                    return;
                }

                decimal dQty = BaseFunction.ReturnDecimal(txtLotQty.Text.Trim());
                decimal dSortG = BaseFunction.ReturnDecimal(txtSortGQty.Text.Trim());
                decimal dSortNG = BaseFunction.ReturnDecimal(txtSortNGQty.Text.Trim());

                if (dSortNG >= dQty)
                {
                    txtSortNGQty.EditValue = DBNull.Value;
                    txtSortNGQty.Focus();
                    throw new Exception("Sort NG Qty err");
                }

                if (dQty == dSortG + dSortNG)
                {
                    return;
                }

                txtSortGQty.EditValue = dQty - dSortNG;
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void btnSortSplit_Click(object sender, EventArgs e)
        {
            try
            {
                ClsUserRight cls = new ClsUserRight();
                if (!cls.HasRight("1020", sUserID, DbHelperSQL.connectionString))
                {
                    throw new Exception("User has no permissions");
                }

                if (txtIQCNo.Text.Trim() == "")
                {
                    throw new Exception("No IQCNo");
                }
                if (txtRMDFNo.Text.Trim() == "")
                {
                    throw new Exception("No RMDFNo");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (lookUpEditFeedback.Text.Trim().ToLower() != "sort" && lookUpEditFeedback.Visible != true)
                    {
                        throw new Exception("Not sort");
                    }

                    string sSQL = @"
select *
from _BarCodeLabel
where BarCode = '{0}' and iSOsID = {1}
";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim());
                    DataTable dtBarCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dtBarCode.Rows[0]["Status"].ToString().ToLower() != "iqc"
                            || dtBarCode.Rows[0]["IQCStatus"].ToString().ToLower() != "iqc-sort")
                    {
                        throw new Exception("Not in IQC-SORT");
                    }

                    decimal dG = BaseFunction.ReturnDecimal(txtSortGQty.Text.Trim());
                    decimal dNG = BaseFunction.ReturnDecimal(txtSortNGQty.Text.Trim());
                    decimal dLotQty = BaseFunction.ReturnDecimal(txtLotQty.Text.Trim());
                    decimal dLotQty_BarCode = BaseFunction.ReturnDecimal(dtBarCode.Rows[0]["LotQty"]);

                    if (dG == 0 || dNG == 0)
                    {
                        txtSortGQty.Focus();
                        throw new Exception("Please set sorted g qty");
                    }

                    if (dLotQty_BarCode != dLotQty)
                    { 
                        throw new Exception("Not in IQC-SORT");
                    }

                    if (dLotQty != dG + dNG)
                    {
                        txtSortGQty.Focus();
                        throw new Exception("Sort Qty is err");
                    }

                    sSQL = @"
update _BarCodeLabel set IQCStatus = 'IQC-SORT',LOTQTY = 0
where BarCode = '{0}' and iSOsID = {1}
                    ";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
declare @iID int 
select @iID = max(iID)
from _BarStatus
where [BarCode] = '{0}' and iSOsID = '{1}'

update _BarStatus set [Type] =  'IQC-SORT',QTY = 0 where iID = @iID and [BarCode] = '{0}' and iSOsID = '{1}'
";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    lBarCodeG.Text = "";
                    lBarCodeNG.Text = "";
                    //自动条码拆分
                    BarCodeSplit(tran);

                    sSQL = @"
update [dbo].[_IQC_RMDF] set [SortG] = {0},[SortNG] = {1},BarCodeG = '{4}',BarCodeNG = '{5}'
where [IQCNo] = '{2}' and [RMDFNo] = '{3}'
";
                    sSQL = string.Format(sSQL, dG, dNG, txtIQCNo.Text.Trim(), txtRMDFNo.Text.Trim(),lBarCodeG.Text.Trim(),lBarCodeNG.Text.Trim());
                    int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (iCou == 0)
                    {
                        throw new Exception("Sort Split err");
                    }

                    tran.Commit();

                    SetTxtNull();
                    SetEnable(true);
                    SetBtnEnable(true);

                    labelErr.Text = "Sort OK";
                    labelErr.BackColor = Color.Green;

                    txtLotNo.Focus();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void btnPrintBarCode_Click(object sender, EventArgs e)
        {
            try
            {
                ClsUserRight cls = new ClsUserRight();
                if (!cls.HasRight("1030", sUserID, DbHelperSQL.connectionString))
                {
                    throw new Exception("User has no permissions");
                }

                PrintBarCode();
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }

        }

        private void txtSampleSize_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal dSampleSize = BaseFunction.ReturnDecimal(txtSampleSize.Text.Trim());
                string sInvCode = txtcInvCode.Text.Trim();

                if (dSampleSize == 0 || sInvCode == "")
                {
                    return;
                }

                string sSQL = @"
exec _GetAQL 0,{0},N'{1}'
";
                sSQL = string.Format(sSQL, dSampleSize, sInvCode);
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt == null || dt.Rows.Count == 0)
                {
                    txtAccept.EditValue = DBNull.Value;
                    txtReject.EditValue = DBNull.Value;
                    txtSampleSize.EditValue = DBNull.Value;

                    throw new Exception("Please set aql inspection level");
                }
                txtAccept.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["Accept"].ToString().Trim(), 2);
                txtReject.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["Reject"].ToString().Trim(), 2);

                txtResult.BackColor = txtLotNo.BackColor;
                decimal d = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    d = d + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty));
                }

                if (d <= BaseFunction.ReturnDecimal(txtAccept.Text.Trim()))
                {
                    txtResult.Text = "Accept";
                    txtResult.BackColor = Color.Green;
                }
                if (d >= BaseFunction.ReturnDecimal(txtReject.Text.Trim()))
                {
                    txtResult.Text = "Reject";
                    txtResult.BackColor = Color.Red;
                }

                if (d > BaseFunction.ReturnDecimal(txtSampleSize.Text.Trim()))
                {
                    txtSampleSize.BackColor = Color.Red;
                }
                else
                {
                    txtSampleSize.BackColor = txtLotNo.BackColor;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }

        private void txtSampleSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSampleSize_Validated(null, null);
            }
        }

    }
}
