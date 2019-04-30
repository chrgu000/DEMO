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
    public partial class OQCRMDF : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        public UFSoft.U8.Framework.Login.UI.clsLogin u8_login;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelErr.Text = "";

                SetEnable(false);
                SetBtnEnable(true);

                DbHelperSQL.connectionString = Conn;

                txtUid.Enabled = true;
                txtPwd.Enabled = true;

                SetTxtNull();

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

        public OQCRMDF()
        {
            InitializeComponent();
        }

        public OQCRMDF(UFSoft.U8.Framework.Login.UI.clsLogin login)
        {
            InitializeComponent();

            u8_login = login;
        }


        public OQCRMDF(UFSoft.U8.Framework.Login.UI.clsLogin login,string sCode)
        {
            InitializeComponent();

            u8_login = login;

            GetCode(sCode);
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
                    SetEnable(true);
                    txtStatus.Text = "Logged";
                    txtUserID.Text = sUser_ID;

                    sUserID = sUser_ID;
                    sUserName = LoginInfo.UserName;

                    txtUid.Enabled = false;
                    txtPwd.Enabled = false;

                    SetBtnEnable(false);
                    SetEnable(true);
                    SetLookup();

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
                    lookUpEditPlater.EditValue = dtPerson.Rows[0]["cPsn_Name"].ToString().Trim();

                    txtLotNo.Focus();
                }
                else
                {
                    MessageBox.Show("The user does not exists or is logged out ,maybe password is incorrect!");

                    SetEnable(false);
                    txtStatus.Text = "";
                    txtUserID.Text = "";
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
                txtUserID.Text = "";

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

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetCode(txtCode.Text.Trim());
                }
            }
            catch (Exception ee)
            { 
                
            }
        }

        private void SetEnable(bool b)
        {
            if (txtStatus.Text.ToLower().Trim() != "logged")
            {
                txtCode.Enabled = false;
                txtOQCNo.Enabled = false;
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
                lookUpEditAction.Enabled = false;
                txtcInvCode.Enabled = false;
                txtcInvName.Enabled = false;
                lookUpEditPlater.Enabled = false;
                txtRemark.Enabled = false;
            }
            else
            {
                txtCode.Enabled = true;

                txtOQCNo.Enabled = false;
                txtiSOsID.Enabled = false;

                txtcInvCode.Enabled = false;
                txtcInvName.Enabled = false;

                txtLotNo.Enabled = b;

                txtLotQty.Enabled = b;
                txtInsQty.Enabled = b;

                txtSampleSize.Enabled = b;

                txtcCusCode.Enabled = false;
                txtcCusName.Enabled = false;

                txtAQLLevel.Enabled = false;
                dtmReceived.Enabled = false;
                dtmInspected.Enabled = false;

                txtInspectedby.Enabled = false;

                lookUpEditAction.Enabled = b;
                lookUpEditPlater.Enabled = false;
                txtRemark.Enabled = b;

                gridView1.OptionsBehavior.Editable = b;
            }
        }

        private void SetTxtNull()
        {
            labelErr.Text = "";
            txtBarCode2.Text = "";

            txtOQCNo.Text = "";
            txtiSOsID.Text = "";

            txtLotNo.Text = "";

            lookUpEditAction.EditValue = DBNull.Value;

            txtLotQty.Text = "";
            txtInsQty.Text = "";

            txtSampleSize.EditValue = DBNull.Value;

            txtcCusCode.Text = "";
            txtcCusName.Text = "";

            txtAQLLevel.Text = "";
            txtAccept.Text = "";
            txtReject.Text = "";
            txtResult.Text = "";
            txtResult.BackColor = txtLotNo.BackColor;

            dtmReceived.Text = "";
            dtmInspected.Text = "";

            txtInspectedby.Text = "";

            txtcInvCode.Text = "";
            txtcInvName.Text = "";
            txtRemark.Text = "";

            gridControl1.DataSource = null;

            radioFailed.Checked = false;
            radioPassed.Checked = false;

            txtProcess.Text = "";

            if (txtUid.Text.Trim() == "")
            {
                lookUpEditPlater.EditValue = DBNull.Value;
            }
        }

        private void SetBtnEnable(bool b)
        {
            if (txtStatus.Text.ToLower().Trim() != "logged")
            {
                btnScan.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                btnScan.Enabled = true;
                btnSave.Enabled = true;
            }
        }


        public void GetCode(string sOQCNo)
        {
            //判断单据是否已经存在
            string sSQL = @"
select a.* ,cus.cCusName
from [_OQC_RMDF] a inner join Customer cus on cus.cCusCode = a.cCusCode 
where a.OQCNo = '{0}'
";
            sSQL = string.Format(sSQL, sOQCNo);
            DataTable dtVoucher = DbHelperSQL.Query(sSQL);
            if (dtVoucher != null && dtVoucher.Rows.Count > 0)
            {
                txtOQCNo.Text = dtVoucher.Rows[0]["OQCNo"].ToString().Trim();
                txtiSOsID.Text = dtVoucher.Rows[0]["iSOsID"].ToString().Trim();
                txtLotNo.Text = dtVoucher.Rows[0]["LotNo"].ToString().Trim();

                if (dtVoucher.Rows[0]["OQCStatus"].ToString().Trim().ToLower() == "oqc-passed")
                {
                    radioPassed.Checked = true;
                }
                else
                {
                    radioFailed.Checked = true;
                }

                txtBarCode2.Text = txtLotNo.Text;
                txtLotQty.Text = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["LotQty"]).ToString().Trim();

                txtInsQty.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["InsQty"]);
                txtSampleSize.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["SampleSize"]); ;
                txtcCusCode.Text = dtVoucher.Rows[0]["cCusCode"].ToString().Trim();
                txtcCusName.Text = dtVoucher.Rows[0]["cCusName"].ToString().Trim();
                txtAQLLevel.EditValue = BaseFunction.ReturnDecimal(dtVoucher.Rows[0]["AQLLevel"]);
                dtmReceived.DateTime = BaseFunction.ReturnDate(dtVoucher.Rows[0]["dtmReceived"]);
                dtmInspected.DateTime = BaseFunction.ReturnDate(dtVoucher.Rows[0]["dtmInspected"]);
                txtInspectedby.Text = dtVoucher.Rows[0]["InspectedBy"].ToString().Trim();
                txtProcess.Text = dtVoucher.Rows[0]["Process"].ToString().Trim();
                txtcInvCode.Text = dtVoucher.Rows[0]["cInvCode"].ToString().Trim();
                txtcInvName.Text = dtVoucher.Rows[0]["cInvName"].ToString().Trim();

                txtRemark.Text = dtVoucher.Rows[0]["Remark"].ToString().Trim();
                txtAccept.EditValue = BaseFunction.ReturnDate(dtVoucher.Rows[0]["Accept"].ToString().Trim());
                txtReject.EditValue = BaseFunction.ReturnDate(dtVoucher.Rows[0]["Reject"].ToString().Trim());

                SetLookup_Action(txtcCusCode.Text.Trim(), txtcInvCode.Text.Trim());

                lookUpEditAction.EditValue = dtVoucher.Rows[0]["Action"].ToString().Trim();
                lookUpEditPlater.EditValue = dtVoucher.Rows[0]["Plater"].ToString().Trim();
                
                sSQL = @"
select distinct a.DefectCode ,b.DefectName
from _Defects a left join [_DefectMaster_2] b on a.DefectCode = b.DefectCode
where cCusCode = '{0}'
order by a.DefectCode 
";
                sSQL = string.Format(sSQL, txtcCusCode.Text.Trim());
                DataTable dtDefects = DbHelperSQL.Query(sSQL);
                ItemLookUpEditDefectCode.DataSource = dtDefects;
                ItemLookUpEditDefectName.DataSource = dtDefects;

                sSQL = @"
select *
from _OQC_RMDFs 
where OQCNo = '{0}'
order by iRow
";
                sSQL = string.Format(sSQL, txtOQCNo.Text.Trim());
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
where a.BarCode = '{0}'and a.Process in (select cWhCode from Warehouse where cWhMemo like '%OQC%')
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
from [_OQC_RMDF] a inner join Customer cus on cus.cCusCode = a.cCusCode 
where a.LotNo = '{0}' and a.iSOsID = {1} and a.Process = '{2}'
";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim(), txtProcess.Text.Trim());
                    DataTable dtVoucher = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtVoucher != null && dtVoucher.Rows.Count > 0)
                    {
                        txtOQCNo.Text = dtVoucher.Rows[0]["OQCNo"].ToString().Trim();
                        txtiSOsID.Text = dtVoucher.Rows[0]["iSOsID"].ToString().Trim();
                        txtLotNo.Text = dtVoucher.Rows[0]["LotNo"].ToString().Trim();

                        if (dtVoucher.Rows[0]["OQCStatus"].ToString().Trim().ToLower() == "oqc-passed")
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

                        SetLookup_Action(txtcCusCode.Text.Trim(), txtcInvCode.Text.Trim());
                        lookUpEditAction.EditValue = dtVoucher.Rows[0]["Action"].ToString().Trim();

                        txtRemark.Text = dtVoucher.Rows[0]["Remark"].ToString().Trim();
                        txtAccept.EditValue = dtVoucher.Rows[0]["Accept"].ToString().Trim();
                        txtReject.EditValue = dtVoucher.Rows[0]["Reject"].ToString().Trim();

                        lookUpEditAction.EditValue = dtVoucher.Rows[0]["Action"].ToString().Trim();
                        lookUpEditPlater.EditValue = dtVoucher.Rows[0]["Plater"].ToString().Trim();
                        //                        sSQL = @"
                        //select distinct a.DefectCode ,b.DefectName
                        //from _Defects a left join [_DefectMaster_2] b on a.DefectCode = b.DefectCode
                        //where cCusCode = '{0}'
                        //order by a.DefectCode 
                        //";
                        sSQL = @"
SELECT distinct a.DefectCode,b.DefectName
FROM _DefectForOQC a inner join [_DefectMaster_2] b on a.DefectCode = b.DefectCode
where a.cInvCode = '{0}'
order by a.DefectCode
";
                        sSQL = string.Format(sSQL, txtcInvCode.Text.Trim());
                        DataTable dtDefects = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        ItemLookUpEditDefectCode.DataSource = dtDefects;
                        ItemLookUpEditDefectName.DataSource = dtDefects;

                        sSQL = @"
select *
from _OQC_RMDFs 
where OQCNo = '{0}'
order by iRow
";
                        sSQL = string.Format(sSQL, txtOQCNo.Text.Trim());
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
                        //OQCStatus = 'Pending OQC'  ,  b.Type = 'OQC'

                        txtResult.Text = "";

                        txtLotNo.Text = sBarCode;
                        txtiSOsID.Text = dt.Rows[0]["iSOsID"].ToString().Trim();
                        txtLotQty.Text = dt.Rows[0]["LotQty"].ToString().Trim();
                        txtInsQty.Text = dt.Rows[0]["LotQty"].ToString().Trim();

                        txtAQLLevel.Text = dt.Rows[0]["cidefine4"].ToString().Trim();
                        if (txtAQLLevel.Text.Trim() == "")
                        {
                            throw new Exception("Please set aql level");
                        }

                        if (BaseFunction.ReturnDecimal(txtLotQty.Text) == 1)
                        {
                            txtSampleSize.Text = "1";
                        }

                        txtcCusCode.Text = dt.Rows[0]["cCusCode"].ToString().Trim();
                        txtcCusName.Text = dt.Rows[0]["cCusName"].ToString().Trim();

                        txtProcess.Text = dt.Rows[0]["Process"].ToString().Trim();

                        txtcInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                        txtcInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();


                        dtmReceived.DateTime = BaseFunction.ReturnDate(dt.Rows[0]["CreateDate"]);

                        SetLookup_Action(txtcCusCode.Text.Trim(), txtcInvCode.Text.Trim());

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
select cwhphone 
from Warehouse 
where cWhCode = '{0}'
";
                        sSQL = string.Format(sSQL, txtProcess.Text.Trim());
                        DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (BaseFunction.ReturnInt(dtTemp.Rows[0]["cwhphone"]) == 1)
                        {
                            sSQL = @"
select cast(null as varchar(60)) as OQCNo,cast(null as int) as iRow,DefectCode as Defect,cast(null as decimal(16,2)) as Qty,cast(null as varchar(60)) as Attacthment,cast(null as varchar(60)) as Remark,a.cWhCode
from  _DefectForOQC a left join Warehouse wh on a.cWhCode = wh.cWhCode
where wh.cWhPhone = 1 and cInvCode = '{0}' and a.cWhCode = '{1}'
order by DefectCode
";
                            sSQL = string.Format(sSQL, txtcInvCode.Text.Trim(), txtProcess.Text.Trim());
                            DataTable dts = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            gridControl1.DataSource = dts;
                            while (gridView1.RowCount < 10)
                            {
                                gridView1.AddNewRow();
                            }
                            gridView1.FocusedRowHandle = 0;
                        }
                        else
                        {
                            sSQL = @"
select cast(null as varchar(60)) as OQCNo,cast(null as int) as iRow,DefectCode as Defect,cast(null as decimal(16,2)) as Qty,cast(null as varchar(60)) as Attacthment,cast(null as varchar(60)) as Remark
from  _DefectForOQC
where 1=-1
order by DefectCode
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
SELECT distinct a.DefectCode,b.DefectName
FROM _DefectForOQC a inner join [_DefectMaster_2] b on a.DefectCode = b.DefectCode
where a.cInvCode = '{0}'
order by a.DefectCode
";
                        sSQL = string.Format(sSQL, txtcInvCode.Text.Trim());
                        DataTable dtDefects = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        ItemLookUpEditDefectCode.DataSource = dtDefects;
                        ItemLookUpEditDefectName.DataSource = dtDefects;
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
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
            catch { }
        }

        private void SaveOQC(SqlTransaction tran, string sStatusCode)
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
                    string s1 = gridView1.GetRowCellValue(i, gridColDefectCode).ToString().Trim().ToLower();
                    if (s1 == "")
                    {
                        continue;
                    }

                    for (int j = i + 1; j < gridView1.RowCount; j++)
                    {
                        string s2 = gridView1.GetRowCellValue(j, gridColDefectCode).ToString().Trim().ToLower();

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
where BarCode = '{0}' and iSOsID = {1} and [Process] in (select cWhCode from Warehouse where cWhMemo like '%OQC%')
    and Process = '{2}'
";
                sSQL = string.Format(sSQL, txtLotNo.Text.Trim(), txtiSOsID.Text.Trim(), txtProcess.Text.Trim());
                DataTable dtBarCodeLabel = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtBarCodeLabel == null || dtBarCodeLabel.Rows.Count == 0)
                {
                    throw new Exception("Process is err");
                }
                decimal dLotQty = BaseFunction.ReturnDecimal(dtBarCodeLabel.Rows[0]["LotQty"]);
                if (dLotQty != BaseFunction.ReturnDecimal(txtLotQty.Text.Trim()))
                {
                    throw new Exception("Barcode splited");
                }

                sSQL = @"
select * from [_OQC_RMDF]
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
                    txtOQCNo.Text = dtVoucher.Rows[0]["OQCNo"].ToString().Trim();
                }

                string sCode = txtOQCNo.Text.Trim();
                if (!bExists)
                {
                    sSQL = @"
select isnull(max(OQCNo),0) as OQCNo
from _OQC_RMDF
where OQCNo like '{0}%'
";
                    sSQL = string.Format(sSQL, "OQC" + dtmNow.ToString("yyMM"));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iCode = 0;

                    if (dt.Rows[0]["OQCNo"].ToString().Length > 7)
                    {
                        iCode = BaseFunction.ReturnInt(dt.Rows[0]["OQCNo"].ToString().Trim().Substring(7));
                    }

                    sCode = (iCode + 1).ToString();
                    sCode = sCode.PadLeft(6, '0');
                    sCode = "OQC" + dtmNow.ToString("yyMM") + sCode;
                    txtOQCNo.Text = sCode;
                }

                Model._OQC_RMDF mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._OQC_RMDF();
                mod.OQCNo = txtOQCNo.Text.Trim();
                mod.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text.Trim());
                mod.LotNo = txtBarCode2.Text.Trim();
                mod.Plater = lookUpEditPlater.Text.Trim();
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
                    mod.OQCStatus = "OQC-Passed";
                }
                if (radioFailed.Checked)
                {
                    mod.OQCStatus = "OQC-ONHOLD";

                    if (lookUpEditAction.Text.Trim() != "")
                    {
                        mod.OQCStatus = "OQC-" + lookUpEditAction.Text.Trim();
                    }
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
              
                mod.Process = txtProcess.Text.Trim();
              
                mod.AQLLevel = txtAQLLevel.Text.Trim();
                mod.Accept = BaseFunction.ReturnDecimal(txtAccept.Text.Trim());
                mod.Reject = BaseFunction.ReturnDecimal(txtReject.Text.Trim());
                mod.Result = txtResult.Text.Trim();
                mod.Action = lookUpEditAction.Text.Trim();

                DAL._OQC_RMDF dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._OQC_RMDF();
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
update _OQC_RMDF set SaveCount = isnull(SaveCount,0) + 1 
where  OQCNo = '{0}'
";
                sSQL = string.Format(sSQL, mod.OQCNo);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (bExists)
                {
                    sSQL = @"
delete _OQC_RMDFs where OQCNo = '{0}'
";
                    sSQL = string.Format(sSQL, mod.OQCNo);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                decimal dQtyList = 0;
                int iRow = 0;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    Model._OQC_RMDFs mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._OQC_RMDFs();
                    mods.Defect = gridView1.GetRowCellValue(i, gridColDefectCode).ToString().Trim();

                    if (mods.Defect == "")
                        continue;

                    mods.OQCNo = mod.OQCNo;
                    iRow += 1;
                    mods.iRow = iRow;

                    mods.Qty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty), 2);
                    if (mods.Qty <= 0)
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

                    mods.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();

                    DAL._OQC_RMDFs dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._OQC_RMDFs();
                    sSQL = dals.Add(mods);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                //if (dQtyList > BaseFunction.ReturnDecimal(lookUpEditSampleSize.Text.Trim()))
                //{
                //    sErr = sErr + "The number is beyond\n";
                //}

                if (dQtyList >= BaseFunction.ReturnDecimal(txtReject.Text.Trim()))
                {
                    txtResult.Text = "Reject";
                }
                if (dQtyList <= BaseFunction.ReturnDecimal(txtAccept.Text.Trim()))
                {
                    txtResult.Text = "Accept";
                }

                #region Log

                string sGuid = Guid.NewGuid().ToString().Trim();
                sSQL = @"
insert into [dbo].[_OQC_RMDF_log]([GUID], OQCNo, iSOsID, LotNo, cInvCode, cInvName, sStatus, [Action], LotQty, InsQty, 
    SampleSize, cCusCode, AQLLevel, Accept, Reject, Result, dtmReceived, dtmInspected, InspectedBy
	, CreateUid, dtmCreate, UpdateUid, dtmUpdate, AuditUid, dtmAudit, SendMailCount, SendMailUid
	, dtmSendMail, SaveCount, Process, ClosedUid, dtmClose,  Plater , Remark ,dtm_Log
)
select '{1}',OQCNo, iSOsID, LotNo, cInvCode, cInvName, sStatus, [Action], LotQty, InsQty, 
    SampleSize, cCusCode, AQLLevel, Accept, Reject, Result, dtmReceived, dtmInspected, InspectedBy
	, CreateUid, dtmCreate, UpdateUid, dtmUpdate, AuditUid, dtmAudit, SendMailCount, SendMailUid
	, dtmSendMail, SaveCount, Process, ClosedUid, dtmClose,  Plater ,Remark,getdate()
from [dbo].[_OQC_RMDF]
where OQCNo = '{0}'
";
                sSQL = string.Format(sSQL, mod.OQCNo, sGuid);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into [dbo].[_OQC_RMDFs_log](GUIDHead, OQCNo, iRow, Defect, Qty, Attachment, Remark,dtmLog)
select '{1}',OQCNo,iRow,Defect,Qty,Attachment,Remark,getdate()
from [dbo].[_OQC_RMDFs]
where OQCNo = '{0}'
";
                sSQL = string.Format(sSQL, mod.OQCNo, sGuid);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                #endregion

                Model.BarStatus model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                model.BarCode = mod.LotNo;
                model.iSOsID = (long)mod.iSOsID;
                if (sStatusCode == "add" || sStatusCode == "update")
                {
                    if (radioPassed.Checked)
                    {
                        model.Type = "OQC-Passed";
                    }
                    else
                    {
                        model.Type = "OQC-ONHOLD";
                    }
                }
                else
                {
                    model.Type = "OQC" + lookUpEditAction.Text.Trim();
                }

                sSQL = @"
update [_BarCodeLabel] set OQCStatus = '{0}',[Status] = 'OQC'
where BarCode = '{1}' and iSOsID = {2}
";
                sSQL = string.Format(sSQL, mod.OQCStatus, model.BarCode, model.iSOsID);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

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

        private void SetLookup_Action(string sCusCode, string sInvCode)
        {
            string sSQL = @" 
select distinct b.[Action]
from [dbo].[_ActionFCost] a inner join [dbo].[_Action] b on a.ActionCode = b.ActionCode
where a.cCusCode = '{0}' and a.cInvCode = '{1}'
    and ISNULL(dtmEnd,'2099-12-31') > '{2}'
";
            sSQL = string.Format(sSQL, sCusCode, sInvCode,sLogDate);
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditAction.Properties.DataSource = dt;

//            sSQL = @"
//select distinct SampleSize from [dbo].[_AQLSampleSizeMap] order by SampleSize
//";
//            dt = DbHelperSQL.Query(sSQL);
//            txtSampleSize.Properties.DataSource = dt;
        }

        private void SetLookup()
        {
            string sSQL = @"
select cPsn_Name as cPersonName from hr_hi_person order by cPsn_Name
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditPlater.Properties.DataSource = dt;
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


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ClsUserRight cls = new ClsUserRight();
                if (!cls.HasRight("2000", sUserID, DbHelperSQL.connectionString))
                {
                    throw new Exception("User has no permissions");
                }

                if (lookUpEditAction.EditValue != null && lookUpEditAction.EditValue.ToString().Trim() != "")
                {
                    lookUpEditAction.Focus();
                    throw new Exception("Action is not empty");
                }
                if (lookUpEditPlater.EditValue == null || lookUpEditPlater.EditValue.ToString().Trim() == "")
                {
                    lookUpEditPlater.Focus();
                    throw new Exception("Please set plater");
                }

                if (txtLotNo.Text.Trim() == "")
                {
                    txtLotNo.Focus();
                    throw new Exception("Please scan lotno");
                }

                if (radioFailed.Checked == false && radioPassed.Checked == false)
                {
                    throw new Exception("Please set status");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sS = "";

                    string sSQL = @"
select *
from [_OQC_RMDF] 
where LotNo = '{0}'
";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sS = "add";
                    }
                    else
                    {
                        sS = "update";
                    }

                    SaveOQC(tran, sS);

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

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                ClsUserRight cls = new ClsUserRight();
                if (!cls.HasRight("2010", sUserID, DbHelperSQL.connectionString))
                {
                    throw new Exception("User has no permissions");
                }

                if (lookUpEditAction.EditValue == null || lookUpEditAction.EditValue.ToString().Trim() == "")
                {
                    lookUpEditAction.Focus();
                    throw new Exception("Please set action");
                }
                if (lookUpEditPlater.EditValue == null || lookUpEditPlater.EditValue.ToString().Trim() == "")
                {
                    lookUpEditPlater.Focus();
                    throw new Exception("Please set plater");
                }

                if (txtLotNo.Text.Trim() == "")
                {
                    txtLotNo.Focus();
                    throw new Exception("Please scan lotno");
                }

                if (radioFailed.Checked == false && radioPassed.Checked == false)
                {
                    throw new Exception("Please set status");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sS = "";

                    string sSQL = @"
select *
from [_OQC_RMDF] 
where LotNo = '{0}'
";
                    sSQL = string.Format(sSQL, txtLotNo.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sS = "add";
                    }
                    else
                    {
                        sS = "update";
                    }

                    SaveOQC(tran, sS);

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
                sSQL = string.Format(sSQL, BaseFunction.ReturnDecimal(txtSampleSize.Text.Trim()), txtcInvCode.Text.Trim());
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
