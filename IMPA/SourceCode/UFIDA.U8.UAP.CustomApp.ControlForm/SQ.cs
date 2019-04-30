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

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class SQ : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        private void SetLookUp()
        {
            string sSQL = @"
select cPersonCode,cPersonName,cDepCode from Person order by cPersonCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditSalesman.Properties.DataSource = dt;

            sSQL = @"
select cCusCode,cCusName,cCusAddress,cCusPerson ,cCusPPerson ,cCusDepart   
from Customer 
order by cCusCode
";

            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditAC.Properties.DataSource = dt;
            lookUpEditCustomer.Properties.DataSource = dt;

            sSQL = @"
select citemcode as VesselCode,citemName as VesselName from fitemss97 order by citemcode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditVessel.Properties.DataSource = dt;

            sSQL = @"
select inv.cInvCode,inv.cInvName,inv.cInvStd,inv.cComUnitCode ,com.cComUnitName 
from Inventory inv
    left join ComputationUnit com on inv.cComUnitCode = com.cComUnitCode
order by cInvCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;

            sSQL = @"
select cexch_code,cexch_name from foreigncurrency order by cexch_name
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditCurrency.Properties.DataSource = dt;

            sSQL = @"
select cValue as Terms
FROM [UserDefine] 
WHERE 1=1 and [cID]=N'37'
order by cValue
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditTerms.Properties.DataSource = dt;

            sSQL = @"
 select cValue as Delivery
FROM [UserDefine] 
WHERE 1=1 and [cID]=N'39'
order by cValue
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditDelivery.Properties.DataSource = dt;
            

            sSQL = @"
select cValue as Dept
FROM [UserDefine] 
WHERE 1=1 and [cID]=N'1001'
order by cValue
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditDept.Properties.DataSource = dt;
            

            sSQL = @"
select cTax,cNo as GSTCode
from AS_GSTTypeFile
order by cNo
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditGSTCode.Properties.DataSource = dt;
            

            sSQL = @"
select cValue as [Flag]
FROM [UserDefine] 
WHERE 1=1 and [cID]=N'1002'
order by cValue
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditFlag.Properties.DataSource = dt;
            

            sSQL = @"
select cValue as [Status],[cID]
FROM [UserDefine] 
WHERE 1=1 and [cID]=N'1003'
order by cValue
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditStatus.Properties.DataSource = dt;

                        sSQL = @"
select cSTCode,cSTName from SaleType order by cSTCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcSTCode.Properties.DataSource = dt;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
                SetLookUp();

                SetBtnEnable(true);
                SetReadOnly(true);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public SQ()
        {
            InitializeComponent();
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (txtSQ.Text.Trim() != "")
            {
                GetGrid(txtSQ.Text.Trim());
            }
            else
            {
                SetTxtNull();
            }

            SetBtnEnable(true);
            SetReadOnly(true);
        }


        private void GetPrice(string sInvCode)
        {
            string sSQL = @"
select a.cVenCode,v.cVenName, a.cPOID,a.dPODate,b.cInvCode,inv.cInvName
	,b.iUnitPrice ,b.iTaxPrice,a.cexch_name 
from po_pomain a  inner join po_podetails b on a.poid = b.POID 
	inner join Inventory inv on b.cInvCode = inv.cInvCode
	left join Vendor v on a.cVenCode = v.cVenCode
where b.cInvCode = '{0}'
order by b.ID desc
";
            sSQL = string.Format(sSQL, sInvCode);
            DataTable dt = DbHelperSQL.Query(sSQL);

            gridControlPurchase.DataSource = dt;
            gridViewPurchase.BestFitColumns();

            sSQL = @"
select b.cvencode, b.dstartdate ,v.cVenName,b.cinvcode , inv.cInvName,b.iTaxUnitPrice ,b.iUnitPrice ,b.cexch_name
from PU_PriceJustMain a inner join PU_PriceJustDetail b on a.id = b.id
	inner join inventory inv on b.cinvcode = inv.cInvCode
	left join Vendor v on b.cvencode = v.cVenCode
where b.cinvcode = '{0}'
order by b.dstartdate,b.autoid desc
";
            sSQL = string.Format(sSQL, sInvCode);
//            sSQL = @"
// select b.ccuscode as ccuscode ,b.cinvcode,b.iinvnowcost ,b.iinvscost ,b.fminquantity ,b.dstartdate ,b.denddate ,b.cdefine26  as cjsl,b.cdefine22 as ywy
//from SA_CusPriceJustMain a inner join SA_CusPriceJustDetail b on a.id = b.id
//where b.cinvcode = '{0}' and b.ccuscode = '{1}'
//";
//            sSQL = string.Format(sSQL, sInvCode, lookUpEditAC.EditValue.ToString().Trim());
            dt = DbHelperSQL.Query(sSQL);
            gridControlPriceList.DataSource = dt;
            gridViewPriceList.BestFitColumns();

            sSQL = @"
select a.cCusCode ,a.dDate ,a.cexch_name,b.cInvCode,inv.cInvName,b.iUnitPrice ,b.iTaxUnitPrice,a.cexch_name,a.cCode
from SA_QuoMain a inner join SA_QuoDetails b on a.ID= b.ID
	inner join inventory inv on b.cinvcode = inv.cInvCode
where  b.cInvCode = '{0}'
order by b.autoid desc
";
            sSQL = string.Format(sSQL, sInvCode);
            dt = DbHelperSQL.Query(sSQL);
            gridControlSQ2.DataSource = dt;
            gridViewSQ2.BestFitColumns();

        }

        private void gridViewSQ_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string sInvCode = gridViewSQ.GetRowCellValue(gridViewSQ.FocusedRowHandle, gridCol_purchase_StkID).ToString().Trim();

                if (sInvCode != "")
                {
                    GetPrice(sInvCode);
                }
            }
            catch (Exception ee)
            {

            }
        }

        private void lookUpEditAC_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditCustomer.EditValue = lookUpEditAC.EditValue;

                if (lookUpEditAC.EditValue != DBNull.Value)
                {
                    string sSQL = @"
select cus.cCusPerson,cus.cCusAddress ,cus.cCusOAddress ,cus.cCusPPerson ,cus.cCusDepart ,dep.cDepName
    ,cus.cCusDefine5 as [Validity],cus.cCusDefine4 as Terms
from Customer cus left join Department dep on cus.cCusDepart = dep.cDepCode
where cCusCode = '{0}'
";
                    sSQL = string.Format(sSQL, lookUpEditAC.EditValue.ToString().Trim());
                    DataTable dt = DbHelperSQL.Query(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        txtAttn.EditValue = dt.Rows[0]["cCusPerson"];
                        txtBillTo.EditValue = dt.Rows[0]["cCusAddress"];
                        txtShipTo.EditValue = dt.Rows[0]["cCusOAddress"];
                        lookUpEditSalesman.EditValue = dt.Rows[0]["cCusPPerson"];
                        txtUserDept.EditValue = dt.Rows[0]["cDepName"];
                        txtValidity.EditValue = dt.Rows[0]["Validity"];
                        lookUpEditTerms.EditValue = dt.Rows[0]["Terms"];
                    }
                }
            }
            catch { }
        }

        private void lookUpEditCustomer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditAC.EditValue = lookUpEditCustomer.EditValue;
            }
            catch { }
        }

        private void btnTxtSQ_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (btnTxtSQ.Text.Trim() != "")
                {
                    GetGrid(btnTxtSQ.Text.Trim());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid(string sCode)
        {
            string sSQL = @"
select p.cDepCode,dep.cDepName 
	,b.irowno,b.cInvCode,inv.cInvName,b.iQuantity,b.iNum,inv.cComUnitCode,unit.cComUnitName
    ,cus.cCusName,p.cDepCode,cus.cCusAddress 
	,case when isnull(b.iNum,0) <> 0 then b.iQuantity / b.iNum end as Ratio
	,b.inum,curr.iQty as ATP
	,b.iUnitPrice as ListPrice
	,b.cDefine26 as HistPrice
	,a.cDefine7 as Disc
	,b.cdefine27 as Nett
	,b.cDefine28 as Supp
	,b.cDefine35 as Cost
	,cast(a.cdefine9 as decimal(16,2)) as Markup
	,(b.iUnitPrice - cast(0 as decimal(16,2)))* b.iQuantity  as EstGP
	,b.cDefine25 as Ref
    ,cus.cCusDefine1
    ,aa.*,bb.*
	,a.*
    ,bb.cbdefine5 as No
from SA_QuoMain a inner join SA_QuoDetails b on a.ID = b.id
	left join SA_QuoMain_extradefine aa on a.id = aa.ID
	left join SA_QuoDetails_extradefine bb on b.AutoID = bb.AutoID
	inner join Inventory inv on inv.cInvCode =b.cInvCode
    left join Customer cus on a.cCusCode = cus.cCusCode 
    left join Person p on p.cPersonCode = a.cPersonCode
	left join ComputationUnit unit on unit.cComunitCode = inv.cComUnitCode
	left join (select cinvCode ,sum(iQuantity) as iQty from CurrentStock group by cinvCode) Curr on Curr.cInvCode = b.cInvCode
	left join department dep on p.cDepCode = dep.cDepCode
where a.cCode = '{0}'
order by b.irowno
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (dt != null && dt.Rows.Count > 0)
            {
                txtSQ.EditValue = dt.Rows[0]["cCode"].ToString().Trim();
                dtm1.EditValue = BaseFunction.ReturnDate(dt.Rows[0]["dDate"]);
                lookUpEditCurrency.EditValue = dt.Rows[0]["cexch_name"].ToString().Trim();
                lookUpEditDelivery.EditValue = dt.Rows[0]["cDefine14"].ToString().Trim();
                lookUpEditAC.EditValue = dt.Rows[0]["cCusCode"].ToString().Trim();
                lookUpEditCustomer.EditValue = dt.Rows[0]["cCusCode"].ToString().Trim();
                lookUpEditVessel.EditValue = dt.Rows[0]["chdefine5"].ToString().Trim();
                lookUpEditDept.EditValue = dt.Rows[0]["chdefine1"];
                txtUserDept.EditValue = dt.Rows[0]["cDepName"].ToString().Trim();
                txtAttn.EditValue = dt.Rows[0]["cCusPerson"].ToString().Trim();
                lookUpEditTerms.EditValue = dt.Rows[0]["cDefine12"].ToString().Trim();
                txtYourRef.EditValue = dt.Rows[0]["cDefine10"].ToString().Trim();
                txtBillTo.EditValue = dt.Rows[0]["cCusAddress"].ToString().Trim();
                txtCC.EditValue = dt.Rows[0]["cDefine11"].ToString().Trim();
                txtDisc.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cDefine7"]);
                lookUpEditGSTCode.EditValue = dt.Rows[0]["cCusDefine1"].ToString().Trim();
                txtValidity.EditValue = dt.Rows[0]["chdefine6"].ToString().Trim();
                txtUser.EditValue = sUserName;
                txtShipTo.EditValue = dt.Rows[0]["cCusOAddress"].ToString().Trim();
                txtMarkup.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cDefine9"]);
                lookUpEditcSTCode.EditValue = dt.Rows[0]["cSTCode"];

                lookUpEditFlag.EditValue = dt.Rows[0]["chdefine2"];
                lookUpEditStatus.EditValue = dt.Rows[0]["chdefine3"];
                lookUpEditSalesman.EditValue = dt.Rows[0]["cPersonCode"].ToString().Trim();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal HistPrice = BaseFunction.ReturnDecimal(dt.Rows[i]["HistPrice"]);
                    if (HistPrice == 0)
                    {
                        string sInvCode = dt.Rows[i]["cInvCode"].ToString().Trim();
                        long lID = BaseFunction.ReturnLong(dt.Rows[i]["ID"]);

                        sSQL = @"
select top 1 b.iUnitPrice
from SA_QuoMain a inner join SA_QuoDetails b on a.ID = b.id
where b.cInvCode = '{0}' and a.id < {1}
order by b.AutoID  desc
";
                        sSQL = string.Format(sSQL, sInvCode, lID);
                        DataTable dtTemp = DbHelperSQL.Query(sSQL);
                        if (dtTemp != null && dtTemp.Rows.Count > 0)
                        {
                            dt.Rows[i]["HistPrice"] = dtTemp.Rows[0]["iUnitPrice"];
                        }
                    }
                }
            }
            else
            {
                SetTxtNull();
            }
            gridControlSQ.DataSource = dt;

            SetReadOnly(true);
            SetBtnEnable(true);
        }

        private void SetTxtNull()
        {
            try
            {
                txtSQ.EditValue = DBNull.Value;
                dtm1.EditValue = DBNull.Value;
                lookUpEditCurrency.EditValue = DBNull.Value;
                lookUpEditDelivery.EditValue = DBNull.Value;
                lookUpEditSalesman.EditValue = DBNull.Value;
                lookUpEditAC.EditValue = DBNull.Value;
                lookUpEditCustomer.EditValue = DBNull.Value;
                lookUpEditVessel.EditValue = DBNull.Value; ;
                txtUserDept.EditValue = DBNull.Value;
                txtAttn.EditValue = DBNull.Value;
                lookUpEditTerms.EditValue = DBNull.Value;
                txtYourRef.EditValue = DBNull.Value;
                lookUpEditDept.EditValue = DBNull.Value;
                txtBillTo.EditValue = DBNull.Value;
                txtCC.EditValue = DBNull.Value;
                txtDisc.EditValue = DBNull.Value;
                lookUpEditGSTCode.EditValue = DBNull.Value;
                txtUser.EditValue = DBNull.Value;
                txtShipTo.EditValue = DBNull.Value;
                txtMarkup.EditValue = DBNull.Value;
                txtExchangeRate.EditValue = DBNull.Value;
                txtValidity.EditValue = DBNull.Value;

                lookUpEditFlag.EditValue = DBNull.Value;
                lookUpEditStatus.EditValue = DBNull.Value;

                gridControlSQ.DataSource = null;
                gridControlPurchase.DataSource = null;
                gridControlPriceList.DataSource = null;
                gridControlSQ2.DataSource = null;

            }
            catch { }
        }

        private void SetReadOnly(bool b)
        {
            try
            {
                txtSQ.Properties.ReadOnly = true;
                dtm1.Properties.ReadOnly = true;
                lookUpEditCurrency.Properties.ReadOnly = b;
                lookUpEditDelivery.Properties.ReadOnly = b;
                lookUpEditSalesman.Properties.ReadOnly = b;
                lookUpEditAC.Properties.ReadOnly = b;
                lookUpEditCustomer.Properties.ReadOnly = b;
                lookUpEditVessel.Properties.ReadOnly = b; ;
                txtUserDept.Properties.ReadOnly = b;
                txtAttn.Properties.ReadOnly = b;
                lookUpEditTerms.Properties.ReadOnly = b;
                txtYourRef.Properties.ReadOnly = b;
                lookUpEditDept.Properties.ReadOnly = b;
                txtBillTo.Properties.ReadOnly = b;
                txtCC.Properties.ReadOnly = b;
                txtDisc.Properties.ReadOnly = b;
                lookUpEditGSTCode.Properties.ReadOnly = b;
                txtUser.Properties.ReadOnly = b;
                txtShipTo.Properties.ReadOnly = b;
                txtMarkup.Properties.ReadOnly = b;

                gridViewSQ.OptionsBehavior.ReadOnly = b;
                gridViewSQ.OptionsBehavior.Editable = !b;

                lookUpEditFlag.Properties.ReadOnly = b;
                lookUpEditStatus.Properties.ReadOnly = b;

                txtExchangeRate.Properties.ReadOnly = true;
                txtValidity.Properties.ReadOnly = true;

                lookUpEditcSTCode.Properties.ReadOnly = b;

                gridViewPurchase.OptionsBehavior.ReadOnly = true;
                gridViewPriceList.OptionsBehavior.ReadOnly = true;
                gridViewSQ2.OptionsBehavior.ReadOnly = true;
            }
            catch { }
        }

        private void lookUpEditSalesman_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select p.cPersonCode,p.cPersonName,p.cDepCode,d.cDepName
from Person p 
	left join Department d on p.cDepCode = d.cDepCode 
where p.cPersonCode = '{0}'
";
                sSQL = string.Format(sSQL, lookUpEditSalesman.EditValue.ToString().Trim());
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtUserDept.EditValue = dt.Rows[0]["cDepName"];
                }
            }
            catch (Exception ee)
            { }
        }

        private void btnTxtSQ_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTxtSQ_ButtonClick(null, null);
                }
            }
            catch { }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                gridViewSQ.AddNewRow();
            }
            catch { }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                gridViewSQ.DeleteRow(gridViewSQ.FocusedRowHandle);
            }
            catch { }
        }

        private void SetBtnEnable(bool b)
        {
            btnRefresh.Enabled = true;

            btnAdd.Enabled = b;
            btnEdit.Enabled = b;
            btnDel.Enabled = b;

            btnSave.Enabled = !b;

            btnApproval.Enabled = b;
            btnRevertApproval.Enabled = b;
            btnSQList.Enabled = b;
            btnImportSQ.Enabled = b;
            btnExportSQ.Enabled = b;

            btnAddLine.Enabled = !b;
            btnDelLine.Enabled = !b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridViewSQ.FocusedRowHandle -= 1;
                    gridViewSQ.FocusedRowHandle += 1;

                    for (int i = gridViewSQ.RowCount-1; i >= 0; i--)
                    {
                        if (gridViewSQ.GetRowCellValue(i, gridColStkID).ToString().Trim() == "")
                        {
                            gridViewSQ.DeleteRow(i);
                        }
                    }

                    if (gridViewSQ.RowCount == 0)
                    {
                        MessageBox.Show("请编辑清单");
                        return;
                    }

                }
                catch { }

                string sErr = "";
                if (lookUpEditAC.EditValue == null || lookUpEditAC.EditValue.ToString().Trim()=="")
                {
                    lookUpEditAC.Focus();
                    throw new Exception("请登记 A/C");
                }

                if (lookUpEditCurrency.EditValue == null || lookUpEditCurrency.EditValue.ToString().Trim() == "")
                {
                    lookUpEditCurrency.Focus();
                    throw new Exception("请登记Currency");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dtmNow = BaseFunction.ReturnDate(dtTemp.Rows[0][0]);
                    DateTime dtmToday = BaseFunction.ReturnDate(dtmNow.ToString("yyyy-MM-dd"));
                    DateTime dtmLog = BaseFunction.ReturnDate(sLogDate);

                    if (txtSQ.Text.Trim() != "")
                    {
                        sSQL = @"
select * from SA_QuoMain a where a.cCode = '{0}'
";
                        sSQL = string.Format(sSQL, txtSQ.Text.Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string cVerifier = dt.Rows[0]["cVerifier"].ToString().Trim();
                            string cCloser = dt.Rows[0]["cCloser"].ToString().Trim();

                            if (cCloser != "")
                            {
                                throw new Exception("单据已关闭");
                            }
                            if (cVerifier != "")
                            {
                                throw new Exception("单据已审核");
                            }
                        }

                        sSQL = @"

if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[SA_QuoDetails_ExtraDefine]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
    delete SA_QuoDetails_ExtraDefine where autoid in (select autoid from SA_QuoDetails where id = {0})

if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[SA_QuoMain_ExtraDefine]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
    delete SA_QuoMain_ExtraDefine  where id = {0}

delete SA_QuoDetails where id = {0}
delete SA_QuoMain where id = {0}

";
                        sSQL = string.Format(sSQL, BaseFunction.ReturnLong(dt.Rows[0]["ID"]));
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

          

                    if (txtSQ.Text.Trim() != "")
                    {
                        sSQL = @"
select * from SA_QuoMain a where a.cCode = '{0}'
";
                        sSQL = string.Format(sSQL, txtSQ.Text.Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string cVerifier = dt.Rows[0]["cVerifier"].ToString().Trim();
                            string cCloser = dt.Rows[0]["cCloser"].ToString().Trim();

                            if (cCloser != "")
                            {
                                throw new Exception("单据已关闭");
                            }
                            if (cVerifier != "")
                            {
                                throw new Exception("单据已审核");
                            }
                        }
                    }

                    //1.   判断是否结账
                    sSQL = "select * from gl_mend where iperiod=month('" + dtmLog + "') and iyear = year('" + dtmLog + "')";
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("加载模块结账信息失败");
                    }
                    int iR = BaseFunction.ReturnInt(dtTemp.Rows[0]["bflag_SA"]);
                    if (iR == 1)
                    {
                        throw new Exception(dtmLog.ToString("yyyy-MM") + " 已经结账");
                    }

                    sSQL = @"
declare @p5 int
set @p5=0
declare @p6 int
set @p6=0
exec sp_getID '00','{0}','QuoMain',{1},@p5 output,@p6 output
select @p5, @p6
";
                    sSQL = string.Format(sSQL, sAccID, gridViewSQ.RowCount);
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lID = BaseFunction.ReturnLong(dtTemp.Rows[0][0]) - 1;
                    long lIDs = BaseFunction.ReturnLong(dtTemp.Rows[0][1]) - gridViewSQ.RowCount;

                    string sCode = "";
                    if (txtSQ.Text.Trim() != "")
                    {
                        sCode = txtSQ.Text.Trim();
                    }
                    else
                    {
                        //                        long lCode = 0;
                        //                        sSQL = @"
                        //select MAX(cCode) AS cCode from SA_QuoMain where cCode like 'SQ{0}%'
                        //";
                        //                        sSQL = string.Format(sSQL, dtmNow.ToString("yyyyMM"));
                        //                        dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        //                        if (dtTemp == null || dtTemp.Rows.Count == 0 || dtTemp.Rows[0][0].ToString().Trim() == "")
                        //                        {
                        //                            lCode = 1;
                        //                        }
                        //                        else
                        //                        {
                        //                            lCode = BaseFunction.ReturnLong(dtTemp.Rows[0][0].ToString().Substring(8)) + 1;
                        //                        }

                        //                        sCode = "SQ" + dtmNow.ToString("yyyyMM") + lCode.ToString().PadLeft(6, '0');

                        long iCode = 0;
                        DAL.VoucherHistory dalcode = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.VoucherHistory();
                        sSQL = dalcode.Exists("CardNumber = '16' and cSeed like 'SQ/" + BaseFunction.ReturnDate(sLogDate).ToString("yy") + "%'");
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                        Model.VoucherHistory modCode = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.VoucherHistory();
                        modCode.CardNumber = "16";
                        modCode.cContent = "手工输入|单据日期";
                        modCode.cContentRule = "SQ/|年";
                        modCode.cSeed = "SQ/" + BaseFunction.ReturnDate(sLogDate).ToString("yy");
                        modCode.cNumber = "1";
                        modCode.bEmpty = false;

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            iCode = 1;
                            modCode.cNumber = iCode.ToString();

                            sSQL = dalcode.Add(modCode);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            iCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]) + 1;
                            modCode.cNumber = iCode.ToString();

                            sSQL = dalcode.Update(modCode);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        sCode = "SQ/" + BaseFunction.ReturnDate(sLogDate).ToString("yyMM") + iCode.ToString().PadLeft(5, '0');
                    }

                    if (lookUpEditcSTCode.EditValue == null || lookUpEditcSTCode.EditValue.ToString().Trim() == "")
                    {
                        throw new Exception("Please set sale type");
                    }

                    Model.SA_QuoMain mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.SA_QuoMain();
                    mod.cSTCode = lookUpEditcSTCode.EditValue.ToString().Trim();
                    mod.dDate = dtmLog;
                    mod.cCode = sCode;
                    mod.cCusCode = lookUpEditAC.EditValue.ToString().Trim();

                    sSQL = @"select cDepCode from Department where cDepName = '{0}'";
                    sSQL = string.Format(sSQL, txtUserDept.Text.Trim());
                    dtTemp = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        mod.cDepCode = dtTemp.Rows[0]["cDepCode"].ToString().Trim();
                    }
                    mod.cPersonCode = lookUpEditSalesman.EditValue.ToString().Trim();
                    //mod.cSCCode
                    mod.cCusOAddress = txtShipTo.Text.Trim();
                    //mod.cPayCode
                    mod.cexch_name = lookUpEditCurrency.EditValue.ToString().Trim();

                    mod.iExchRate = BaseFunction.ReturnDecimal(txtExchangeRate.Text);

                    sSQL = @"
select * from foreigncurrency where cexch_name = '{0}'
";
                    sSQL = string.Format(sSQL, mod.cexch_name);
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        if (BaseFunction.ReturnInt(dtTemp.Rows[0]["iotherused"]) == 0)
                        {
                            sSQL = @"
select * from exch where cexch_name = '{2}' and iyear = {0} and iperiod = {1} and itype = 2
";
                            sSQL = string.Format(sSQL, dtmLog.Year, dtmLog.Month, mod.cexch_name);
                            dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtTemp != null && dtTemp.Rows.Count > 0)
                            {
                                mod.iExchRate = BaseFunction.ReturnDecimal(dtTemp.Rows[0]["nflat"]);
                            }
                        }
                    }



                    //mod.iExchRate 
                    //mod.iTaxRate = 
                    mod.cMaker = sUserName;
                    if (txtDisc.Text.Trim() != "")
                    {
                        mod.cDefine7 = BaseFunction.ReturnDecimal(txtDisc.Text.Trim());
                    }
                    if (txtMarkup.Text.Trim() != "")
                    {
                        mod.cDefine9 = BaseFunction.ReturnDecimal(txtMarkup.Text.Trim()).ToString().Trim();
                    }
                    mod.cDefine10 = txtYourRef.Text.Trim();
                    mod.cDefine14 = lookUpEditDelivery.Text.Trim();

                    lID += 1;
                    mod.ID = lID;
                    mod.iVTid = 8048;
                    mod.cBusType = "普通销售";
                    mod.iverifystate = 0;
                    mod.iswfcontrolled = 0;
                    mod.ccusperson = txtAttn.Text.Trim();
                    mod.dcreatesystime = dtmNow;
                    mod.ccuspersoncode = txtAttn.Text.Trim();
                    mod.cSysBarCode = "||SA16|" + mod.cCode;
                    mod.cCrmPersonCode = txtAttn.Text.Trim();
                    mod.cMainPersonCode = txtAttn.Text.Trim();
                    mod.cDefine11 = txtCC.Text.Trim();
                    mod.cDefine12 = lookUpEditTerms.EditValue.ToString().Trim();
                    DAL.SA_QuoMain dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SA_QuoMain();
                    sSQL = dal.Add(mod);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    Model.SA_QuoMain_extradefine modext = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.SA_QuoMain_extradefine();
                    modext.ID = mod.ID;
                    modext.chdefine1 = lookUpEditDept.EditValue.ToString().Trim();
                    modext.chdefine2 = lookUpEditFlag.EditValue.ToString().Trim();
                    modext.chdefine3 = lookUpEditStatus.EditValue.ToString().Trim();
                    modext.chdefine7 = lookUpEditGSTCode.EditValue.ToString().Trim();
                    modext.chdefine5 = lookUpEditVessel.EditValue.ToString().Trim();

                    DAL.SA_QuoMain_extradefine dalExt = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SA_QuoMain_extradefine();
                    sSQL = dalExt.Add(modext);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridViewSQ.RowCount; i++)
                    {
                        sSQL = @"
select * from Inventory where cInvCode = '{0}' 
";
                        sSQL = string.Format(sSQL, gridViewSQ.GetRowCellValue(i, gridColStkID).ToString().Trim());
                        DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        Model.SA_QuoDetails mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.SA_QuoDetails();

                        lIDs +=1;
                        mods.AutoID = lIDs;
                        mods.cDefine25 = gridViewSQ.GetRowCellValue(i, gridColRef).ToString().Trim();
                        mods.cInvCode = gridViewSQ.GetRowCellValue(i, gridColStkID).ToString().Trim();
                        mods.iQuantity = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(i, gridColQty));
                        if (mods.iQuantity <= 0)
                        {
                            sErr  = sErr + "行" + (i + 1).ToString() + "数量不正确\n";
                        }

                        mods.iQuotedPrice = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(i, gridColListPrice));
                        if (mods.iQuotedPrice < 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "报价不正确\n";
                        }

                        mods.iUnitPrice = mods.iQuotedPrice;
                        mods.iTaxUnitPrice = mods.iQuotedPrice * (1 + BaseFunction.ReturnDecimal(mod.iTaxRate) / 100);
                        mods.iMoney = mods.iUnitPrice * mods.iQuantity;
                        mods.iSum = mods.iTaxUnitPrice * mods.iQuantity;
                        mods.iTax = mods.iSum - mods.iMoney;
                        mods.iDisCount = mods.iSum * (1 - BaseFunction.ReturnDecimal(mods.KL) / 100);       //需要验证

                        mods.iNatUnitPrice = mods.iUnitPrice * mod.iExchRate;
                        mods.iNatMoney = mods.iNatUnitPrice * mods.iQuantity;
                        mods.iNatSum = mods.iTaxUnitPrice * mod.iExchRate * mods.iQuantity;
                        mods.iNatTax = mods.iNatSum - mods.iNatMoney;
                        mods.iNatDisCount = mods.iDisCount * mod.iExchRate;

                        mods.KL = 100;
                        mods.KL2 = 100;
                        mods.iTaxRate = mod.iTaxRate;
                        mods.ID = mod.ID;
                        mods.fSaleCost = 0;
                        mods.fSalePrice = 0;
                        mods.cItem_class = "00";
                        mods.cItem_CName = "COASTAL JUPITER";
                        mods.cItemCode = modext.chdefine5;
                        mods.cItemName = lookUpEditVessel.Text.Trim();

                        if (dtInv.Rows[0]["iInvLSCost"].ToString().Trim() != "")
                        {
                            mods.fcusminprice = BaseFunction.ReturnDecimal(dtInv.Rows[0]["iInvLSCost"]);
                        }
                    
                        mods.cDefine25 = gridViewSQ.GetRowCellValue(i, gridColRef).ToString().Trim();
                        if (gridViewSQ.GetRowCellValue(i, gridColHistPrice).ToString().Trim() != "")
                        {
                            mods.cDefine26 = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(i, gridColHistPrice));
                        }
                        if (gridViewSQ.GetRowCellValue(i, gridColNett).ToString().Trim() != "")
                        {
                            mods.cDefine27 = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(i, gridColNett));
                        }
                        mods.cDefine28 = gridViewSQ.GetRowCellValue(i, gridColSupp).ToString().Trim();
                        if (gridViewSQ.GetRowCellValue(i, gridColCost).ToString().Trim() != "")
                        {
                            mods.cDefine35 = BaseFunction.ReturnLong(gridViewSQ.GetRowCellValue(i, gridColCost));
                        }

                        sSQL = @"
select * from CusInvContrapose where cCusCode = '{0}' and cInvCode = '{1}'
";
                        sSQL = string.Format(sSQL, mod.cCusCode, mods.cInvCode);
                        dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtTemp != null && dtTemp.Rows.Count > 0)
                        {
                            mods.cCusInvCode = dtTemp.Rows[0]["cCusInvCode"].ToString().Trim();
                            mods.cCusInvName = dtTemp.Rows[0]["cCusInvName"].ToString().Trim();
                        }
                        mods.cUnitID = dtInv.Rows[0]["cComUnitCode"].ToString().Trim();
                        mods.brefpa = false;
                        mods.irowno = i + 1;
                        mods.bsaleprice = false;
                        mods.bgift = false;
                        mods.cbSysBarCode = mod.cSysBarCode + "|" + mods.irowno.ToString();

                        DAL.SA_QuoDetails dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SA_QuoDetails();
                        sSQL = dals.Add(mods);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        Model.SA_QuoDetails_extradefine modsExt = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.SA_QuoDetails_extradefine();
                        modsExt.AutoID = mods.AutoID;
                        modsExt.cbdefine5 = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(i, gridColNo));
                        modsExt.cbdefine4 = gridViewSQ.GetRowCellValue(i, gridColDescription).ToString().Trim();

                        DAL.SA_QuoDetails_extradefine dalsExt = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SA_QuoDetails_extradefine();
                        sSQL = dalsExt.Add(modsExt);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    txtSQ.Text = mod.cCode;
                    tran.Commit();
                    MessageBox.Show("保存成功");

                    SetBtnEnable(true);
                    SetReadOnly(true);

                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid("-1");
                dtm1.DateTime = BaseFunction.ReturnDate(sLogDate);

                txtUser.EditValue = sUserName;

                gridViewSQ.OptionsBehavior.ReadOnly = false;
                gridViewSQ.OptionsBehavior.Editable = true;

                SetBtnEnable(false);
                SetReadOnly(false);

                for (int i = 0; i < 10; i++)
                {
                    gridViewSQ.AddNewRow();
                }
                gridViewSQ.FocusedRowHandle = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSQ.Text.Trim() == "")
                {
                    return;
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "";

                    sSQL = @"
select * from SA_QuoMain a where a.cCode = '{0}'
";
                    sSQL = string.Format(sSQL, txtSQ.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string cVerifier = dt.Rows[0]["cVerifier"].ToString().Trim();
                        string cCloser = dt.Rows[0]["cCloser"].ToString().Trim();
                        long lID = BaseFunction.ReturnLong(dt.Rows[0]["ID"]);

                        if (cCloser != "")
                        {
                            throw new Exception("单据已关闭");
                        }
                        if (cVerifier != "")
                        {
                            throw new Exception("单据已审核");
                        }


                        sSQL = @"

if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[SA_QuoDetails_ExtraDefine]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
    delete SA_QuoDetails_ExtraDefine where autoid in (select autoid from SA_QuoDetails where id = {0})

delete SA_QuoDetails where id = {0}
delete SA_QuoMain where id = {0}

";
                        sSQL = string.Format(sSQL, BaseFunction.ReturnLong(dt.Rows[0]["ID"]));
                        int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (iCou > 0)
                        {

                            tran.Commit();
                            MessageBox.Show("删除成功");
                            SetTxtNull();

                            SetReadOnly(true);

                            SetBtnEnable(true);
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridViewSQ_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string sSQL = "";
                if (e.Column == gridColStkID)
                {
                    string sInvCode = gridViewSQ.GetRowCellValue(e.RowHandle, gridColStkID).ToString().Trim();
                    sSQL = @"
select inv.cInvCode,inv.cInvName,inv.cInvStd,inv.cComUnitCode ,com.cComUnitName ,inv.cGroupCode ,inv.cComUnitCode ,inv.cSAComUnitCode 
	,inv.cInvCCode
from Inventory inv
    left join ComputationUnit com on inv.cComUnitCode = com.cComUnitCode
where inv.cInvCode = '{0}'
order by cInvCode
";
                    sSQL = string.Format(sSQL, sInvCode);
                    DataTable dt = DbHelperSQL.Query(sSQL);

                    gridViewSQ.SetRowCellValue(e.RowHandle, gridColUOM, dt.Rows[0]["cComUnitName"]);

                    if (dt.Rows[0]["cSAComUnitCode"].ToString().Trim() != "")
                    {

                    }
                    if (BaseFunction.ReturnDecimal(txtDisc.Text.Trim()) != 0)
                    {
                        gridViewSQ.SetRowCellValue(e.RowHandle, gridColDisc, BaseFunction.ReturnDecimal(txtDisc.Text.Trim()));
                    }

                    if (BaseFunction.ReturnDecimal(txtMarkup.Text.Trim()) != 0)
                    {
                        gridViewSQ.SetRowCellValue(e.RowHandle, gridColMarkup, BaseFunction.ReturnDecimal(txtMarkup.Text.Trim()));
                    }
                    if (dt.Rows[0]["cInvCCode"].ToString().Trim() == "01")      //Normal
                    {
                        decimal iInvLSCost = BaseFunction.ReturnDecimal(dt.Rows[0]["iInvLSCost "]);
                        gridViewSQ.SetRowCellValue(e.RowHandle, gridColCost, iInvLSCost);
                    }
                    else
                    {
                        //缺价格
                        gridViewSQ.SetRowCellValue(e.RowHandle, gridColSupp, "IMPA W/H");
                    }
                    sSQL = @"
select cinvCode ,sum(iQuantity) as iQty from CurrentStock where cInvCode = '{0}' group by cinvCode
";
                    sSQL = string.Format(sSQL, sInvCode);
                    DataTable dtCurr = DbHelperSQL.Query(sSQL);
                    if (dtCurr != null && dtCurr.Rows.Count > 0)
                    {
                        gridViewSQ.SetRowCellValue(e.RowHandle, gridColStkQty, BaseFunction.ReturnDecimal(dtCurr.Rows[0]["iQty"]));
                    }
                    else
                    {
                        gridViewSQ.SetRowCellValue(e.RowHandle, gridColStkQty, 0);
                    }
                }
                if (e.Column == gridColRef || e.Column == gridColStkID)
                {
                    if (BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(e.RowHandle, gridColNo)) == 0)
                    {
                        gridViewSQ.SetRowCellValue(e.RowHandle, gridColNo, e.RowHandle + 1);
                    }
                }

                if (e.Column == gridColListPrice || e.Column == gridColMarkup || e.Column == gridColDisc)
                {
                    decimal dQty = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(e.RowHandle, gridColQty));
                    decimal dListPrice = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(e.RowHandle, gridColListPrice));
                    decimal dDisc = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(e.RowHandle, gridColDisc));
                    decimal dMrakup = BaseFunction.ReturnDecimal(gridViewSQ.GetRowCellValue(e.RowHandle, gridColMarkup));
                    decimal dPriceDisc = dListPrice * (1 - dDisc / 100);
                    decimal dPriceMrakup = dListPrice * (1 + dMrakup / 100);

                    gridViewSQ.SetRowCellValue(e.RowHandle, gridColNett, dPriceDisc);

                    decimal dSum = dQty * (dPriceMrakup - dPriceDisc);
                    gridViewSQ.SetRowCellValue(e.RowHandle, gridColEstGP, dSum);
                }
            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "";


                    if (txtSQ.Text.Trim() != "")
                    {
                        sSQL = @"
select * from SA_QuoMain a where a.cCode = '{0}'
";
                        sSQL = string.Format(sSQL, txtSQ.Text.Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string cVerifier = dt.Rows[0]["cVerifier"].ToString().Trim();
                            string cCloser = dt.Rows[0]["cCloser"].ToString().Trim();

                            if (cCloser != "")
                            {
                                throw new Exception("单据已关闭");
                            }
                            if (cVerifier != "")
                            {
                                throw new Exception("单据已审核");
                            }
                        }
                    }

                    SetReadOnly(false);

                    SetBtnEnable(false);
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            { 
                for(int i=0;i<gridViewSQ.RowCount;i++)
                {
                    gridViewSQ.SetRowCellValue(i, gridColDisc, BaseFunction.ReturnDecimal(txtDisc.Text.Trim()));

                    gridViewSQ.SetRowCellValue(i, gridColMarkup, BaseFunction.ReturnDecimal(txtMarkup.Text.Trim()));
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "";


                    if (txtSQ.Text.Trim() != "")
                    {
                        sSQL = @"
select * from SA_QuoMain a where a.cCode = '{0}'
";
                        sSQL = string.Format(sSQL, txtSQ.Text.Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string cVerifier = dt.Rows[0]["cVerifier"].ToString().Trim();
                            string cCloser = dt.Rows[0]["cCloser"].ToString().Trim();

                            if (cCloser != "")
                            {
                                throw new Exception("单据已关闭");
                            }
                            if (cVerifier != "")
                            {
                                throw new Exception("单据已审核");
                            }
                        }

                        sSQL = @"
update SA_QuoMain set dverifydate = '{0}',cVerifier = '{1}',dverifysystime = getdate() where cCode = '{2}'
";
                        sSQL = string.Format(sSQL, sLogDate, sUserName, txtSQ.Text.Trim());
                        int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (iCou > 0)
                        {
                            tran.Commit();
                            MessageBox.Show("审核成功");
                        }
                    }

                    SetReadOnly(true);

                    SetBtnEnable(true);
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnRevertApproval_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "";


                    if (txtSQ.Text.Trim() != "")
                    {
                        sSQL = @"
select * from SA_QuoMain a where a.cCode = '{0}'
";
                        sSQL = string.Format(sSQL, txtSQ.Text.Trim());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string cVerifier = dt.Rows[0]["cVerifier"].ToString().Trim();
                            string cCloser = dt.Rows[0]["cCloser"].ToString().Trim();

                            if (cCloser != "")
                            {
                                throw new Exception("单据已关闭");
                            }
                            if (cVerifier == "")
                            {
                                throw new Exception("单据未审核");
                            }
                        }

                        sSQL = @"
update SA_QuoMain set dverifydate = null,cVerifier = null,dverifysystime =null where cCode = '{2}'
";
                        sSQL = string.Format(sSQL, sLogDate, sUserName, txtSQ.Text.Trim());
                        int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (iCou > 0)
                        {
                            tran.Commit();
                            MessageBox.Show("弃审成功");
                        }
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridViewPurchase_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewSQ.OptionsBehavior.ReadOnly)
                {
                    return;
                }

                decimal dPrice = BaseFunction.ReturnDecimal(gridViewPurchase.GetRowCellValue(gridViewPurchase.FocusedRowHandle, gridCol_purchase_PurPrice));
                string sInvCode = gridViewPurchase.GetRowCellValue(gridViewPurchase.FocusedRowHandle, gridCol_purchase_StkID).ToString().Trim();
                string sSupp = gridViewPurchase.GetRowCellValue(gridViewPurchase.FocusedRowHandle, gridCol_purchase_Supp).ToString().Trim();

                if (gridViewSQ.GetRowCellValue(gridViewSQ.FocusedRowHandle, gridColStkID).ToString().Trim() == sInvCode)
                {
                    gridViewSQ.SetRowCellValue(gridViewSQ.FocusedRowHandle, gridColListPrice, dPrice);
                    gridViewSQ.SetRowCellValue(gridViewSQ.FocusedRowHandle, gridColSupp, sSupp);
                }
            }
            catch { }
        }

        private void gridViewPriceList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewSQ.OptionsBehavior.ReadOnly)
                {
                    return;
                }

                decimal dPrice = BaseFunction.ReturnDecimal(gridViewPriceList.GetRowCellValue(gridViewPriceList.FocusedRowHandle, gridCol_PriceList_Curr));
                string sInvCode = gridViewPriceList.GetRowCellValue(gridViewPriceList.FocusedRowHandle, gridCol_PriceList_StkID).ToString().Trim();
                string sSupp = gridViewPriceList.GetRowCellValue(gridViewPriceList.FocusedRowHandle, gridCol_PriceList_Supplier).ToString().Trim();

                if (gridViewSQ.GetRowCellValue(gridViewSQ.FocusedRowHandle, gridColStkID).ToString().Trim() == sInvCode)
                {
                    gridViewSQ.SetRowCellValue(gridViewSQ.FocusedRowHandle, gridColListPrice, dPrice);
                    gridViewSQ.SetRowCellValue(gridViewSQ.FocusedRowHandle, gridColSupp, sSupp);
                }
            }
            catch { }
        }

        private void gridViewSQ2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewSQ.OptionsBehavior.ReadOnly)
                {
                    return;
                }

                decimal dPrice = BaseFunction.ReturnDecimal(gridViewSQ2.GetRowCellValue(gridViewSQ2.FocusedRowHandle, gridCol_SQ2_PurPrice));
                string sInvCode = gridViewSQ2.GetRowCellValue(gridViewSQ2.FocusedRowHandle, gridCol_SQ2_StkID).ToString().Trim();

                if (gridViewSQ.GetRowCellValue(gridViewSQ.FocusedRowHandle, gridColStkID).ToString().Trim() == sInvCode)
                {
                    gridViewSQ.SetRowCellValue(gridViewSQ.FocusedRowHandle, gridColListPrice, dPrice);
                    gridViewSQ.SetRowCellValue(gridViewSQ.FocusedRowHandle, gridColSupp, DBNull.Value);
                }
            }
            catch { }
        }

        private void btnSQList_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSQList frm = new FrmSQList(Conn);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                DialogResult d = frm.ShowDialog();

                if (d == DialogResult.OK)
                {
                    GetGrid(frm.sSQCode);
                }

            }
            catch { }
        }

        private void lookUpEditCurrency_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditCurrency.EditValue == null || lookUpEditCurrency.EditValue.ToString().Trim() == "")
                {
                    txtExchangeRate.EditValue = DBNull.Value;
                }
                else
                {
                    if (lookUpEditCurrency.EditValue.ToString().Trim() == "SGD")
                    {
                        txtExchangeRate.EditValue = 1;
                    }
                    else
                    {
                        string sSQL = @"
select nflat from exch where itype = 2 and cexch_name = '{0}' and iYear = {1} and iperiod = {2}
";
                        sSQL = string.Format(sSQL, lookUpEditCurrency.EditValue.ToString().Trim(), BaseFunction.ReturnDate(sLogDate).Year, BaseFunction.ReturnDate(sLogDate).Month);
                        DataTable dt = DbHelperSQL.Query(sSQL);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            txtExchangeRate.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["nflat"]);
                        }
                        else
                        {
                            MessageBox.Show("Please set exchange rate");
                        }
                    }
                }
            }
            catch { }
        }


        private void SQ_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                splitContainerControl1.Panel1.MinSize = BaseFunction.ReturnInt(splitContainerControl1.Width * 0.7);
                splitContainerControl2.SplitterPosition = BaseFunction.ReturnInt(splitContainerControl2.Height * 0.3);
                splitContainerControl3.SplitterPosition = BaseFunction.ReturnInt(splitContainerControl3.Height * 0.49);
            }
            catch (Exception ee)
            {

            }
        }
    }
}
