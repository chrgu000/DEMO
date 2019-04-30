using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmSalebillvouchEdit : Form
    {
        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public string cDLCode;

        public FrmSalebillvouchEdit(string conn, string userid, string username, string logdate, string accid)
        {
            InitializeComponent();
            Conn = conn;
            sUserID = userid;
            sUserName = username;
            sLogDate = logdate;
            sAccID = accid;

            txtStatus.Text = "Add";

            lGUID.Text = Guid.NewGuid().ToString();

            SetTxtEnable(true);
            SetBtnEnable(false);
        }

        public FrmSalebillvouchEdit(string conn, string userid, string username, string logdate, string accid, string sGUID)
        {
            InitializeComponent();

            Conn = conn;
            sUserID = userid;
            sUserName = username;
            sLogDate = logdate;
            sAccID = accid;

            lGUID.Text = sGUID;

            txtStatus.Text = "Edit";

            SetTxtEnable(false);
            SetBtnEnable(true);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                lExchRate.Text = "";

                dtmLog.DateTime = BaseFunction.ReturnDate(sLogDate);

                dateEdit1.DateTime = BaseFunction.ReturnDate(dtmLog.DateTime.ToString("yyyy-MM-01"));
                dateEdit2.DateTime = dtmLog.DateTime;

                GetGridViewSet(gridView1);

                SetLookUp();

                if (txtStatus.Text.Trim().ToLower() == "add")
                {
                    btnDel.Enabled = false;
                }
                else
                {
                    btnDel.Enabled = true;
                    btnSel_Click(null, null);

                    btnQuery.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获取销售发货单明细失败！  " + ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cCusCode,cCusName,cCusAbbName from Customer order by cCusCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;
            lookUpEditcCusAbbName.Properties.DataSource = dt;

            sSQL = @"
select cCode,cName,dblZQNum
from AA_Agreement 
where iLZYJ = 1
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditSKXY.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cBusType";
            dt.Columns.Add(dc);
            dr = dt.NewRow();
            dr["cBusType"] = "Receiving by stages";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["cBusType"] = "General sales";
            dt.Rows.Add(dr);
            lookUpEditcBusType.Properties.DataSource = dt;
            lookUpEditcBusType.EditValue = "Receiving by stages";

            sSQL = @"select  cexch_name from dbo.foreigncurrency";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditCurrency.Properties.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStatus.Text.Trim().ToLower() == "add")
                {
                    if (lookUpEditcCusCode.EditValue == null || lookUpEditcCusCode.EditValue.ToString().Trim() == "")
                    {
                        lookUpEditcCusCode.Focus();
                        throw new Exception("Please choose customer");
                    }

                    if (lookUpEditcBusType.EditValue == null || lookUpEditcBusType.EditValue.ToString().Trim() == "")
                    {
                        lookUpEditcBusType.Focus();
                        throw new Exception("Please choose Business type");
                    }

                    string sBusType = "分期收款";
                    if (lookUpEditcBusType.EditValue.ToString().Trim().ToLower() == "Receiving by stages".ToLower())
                    {
                        sBusType = "分期收款";
                    }
                    if (lookUpEditcBusType.EditValue.ToString().Trim().ToLower() == "General sales".ToLower())
                    {
                        sBusType = "普通销售";
                    }

                    string sSQL = @"
select CAST(1 as bit) as Selected, a.cdlcode,a.ddate,b.cdefine29 as Item,b.cinvcode,b.cinvname,b.cwhcode as cWhCode,b.ccomunitcode as cunitid
    ,cast (b.iquantity as decimal(16,2)) as iQty
	,cast(case when ISNULL(iquantity,0)=0 then cast(ISNULL(isum,0)-isnull(fretsum,0)-ISNULL(isettlenum,0) as decimal(26,6)) else cast(ISNULL(b.iQuantity,0)-ISNULL(b.iSettleQuantity,0)-ISNULL(fretqtywkp,0) as decimal(26,9)) end as decimal(16,2)) as unQty
    ,cast(case when ISNULL(iquantity,0)=0 then cast(ISNULL(isum,0)-isnull(fretsum,0)-ISNULL(isettlenum,0) as decimal(26,6)) else cast(ISNULL(b.iQuantity,0)-ISNULL(b.iSettleQuantity,0)-ISNULL(fretqtywkp,0) as decimal(26,9)) end as decimal(16,2)) as nowQty
    ,b.iDLsID,a.dlid
    ,cast(a.itaxrate as decimal(16,2)) as itaxrate,cast(b.iTaxRate as decimal(16,2)) as iTaxRate2
    ,a.iExchRate ,a.cexch_name
    ,cast(b.iUnitPrice as decimal(16,6)) as iUnitPrice,cast(b.iTaxUnitPrice as decimal(16,6)) as iTaxUnitPrice ,cast(b.iMoney as decimal(16,4)) as iMoney ,cast(b.iTax as decimal(16,4)) as iTax ,cast(b.iSum as decimal(16,4)) as iSum 
    ,cast(b.iNatUnitPrice as decimal(16,6)) as iNatUnitPrice ,cast(b.iNatMoney as decimal(16,4)) as iNatMoney ,cast(b.iNatTax as decimal(16,4)) as iNatTax ,cast(b.iNatSum as decimal(16,4)) as iNatSum ,cast(b.iInvExchRate as decimal(16,6)) as iInvExchRate 
from sale_DispToSaleVouch_T a WITH (NOLOCK) inner join sale_DispToSaleVouch_B b WITH (NOLOCK) on a.dlid=b.dlid 
where 1=1
	and a.ccuscode = '{0}'
	and cbustype = '{1}'
	and (cVouchType=N'05' AND b.bSettleAll=0 AND ISNULL(iSale,0)=0 AND IsNULL(cVerifier,N'')<>N'' 
	and (isnull(icorid,0)=0 or isnull(bneedbill,0)=1) 
	and (ISNULL(bsaleoutcreatebill ,0)=0 OR (ISNULL(bsaleoutcreatebill ,0)=1 and ISNULL(cwhcode,N'')=N''))) 
	and ( (isnull(bneedsign,0)=0 or (isnull(bneedsign,0)=1 and isnull(bsignover,0)=1 and isnull(bneedloss,0)=0)  or (isnull(iflowid,0)=0 )) 
	and  (case when ISNULL(iquantity,0)=0 then cast(ISNULL(isum,0)-isnull(fretsum,0)-ISNULL(isettlenum,0) as decimal(26,6)) else cast(ISNULL(b.iQuantity,0)-ISNULL(b.iSettleQuantity,0)-ISNULL(fretqtywkp,0) as decimal(26,9)) end )>0)
order by b.autoid, a.cdlcode,b.cdefine29

";
                    sSQL = string.Format(sSQL, lookUpEditcCusCode.EditValue.ToString().Trim(), sBusType);
                    if (lookUpEditcCode1.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode >= '" + lookUpEditcCode1.Text.Trim() + "'");
                    }
                    if (lookUpEditcCode2.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode <= '" + lookUpEditcCode2.Text.Trim() + "'");
                    }
                    if (dateEdit1.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
                    }
                    if (dateEdit2.Text.Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                    }

                    DataTable dtGrid = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dtGrid;

                    if (dtGrid != null && dtGrid.Rows.Count > 0)
                    {
                        string sexch_name = lookUpEditCurrency.EditValue.ToString().Trim();
                        if (gridView1.GetRowCellValue(0, gridColcexch_name).ToString().Trim() != "")
                        {
                            sexch_name = gridView1.GetRowCellValue(0, gridColcexch_name).ToString().Trim();
                            lookUpEditCurrency.EditValue = sexch_name;
                        }

                        btntxtTaxRate.Text = dtGrid.Rows[0]["itaxrate"].ToString().Trim();

                        sSQL = "select  cexch_name from dbo.foreigncurrency  where iotherused =-1";
                        DataTable dtTemp = DbHelperSQL.Query(sSQL);
                        string sBZ = dtTemp.Rows[0]["cexch_name"].ToString().Trim();
                        if (sBZ.ToLower().Trim() == sexch_name.ToLower())
                        {
                            lExchRate.Text = "1";
                        }
                        else
                        {
                            sSQL = @"
select iyear,iperiod ,nflat,cexch_name
from exch 
where itype = 2 and iYear = {0} and iperiod = {1} and cexch_name = '{2}'
";
                            sSQL = string.Format(sSQL, dtmLog.DateTime.Year, dtmLog.DateTime.Month, sexch_name);
                            DataTable dtExchRate = DbHelperSQL.Query(sSQL);
                            if (dtExchRate == null || dtExchRate.Rows.Count == 0)
                            {
                                throw new Exception("Please set exchage rate");
                            }
                            lExchRate.Text = BaseFunction.ReturnDecimal(dtExchRate.Rows[0]["nflat"]).ToString();
                        }
                    }

                    chkAll.Checked = true;
                }
                else
                {
                    string sSQL = @"
SELECT CAST(1 as bit) as Selected,a.DLCode as cdlcode,a.Item as Item,a.cInvCode as cinvcode, inv.cInvName as cinvname,a.cWhCode as cWhCode,bills.cUnitID as cunitid
	,cast(a.DLsQty as decimal(16,2)) as iQty 	,cast(null as decimal(16,2)) as unQty 	,cast(a.SaleBillsQty as decimal(16,2)) as nowQty 	,a.DLsID as iDLsID,dis.DLID as dlid 	,bill.iExchRate ,a.cexch_name
    ,cast(a.iUnitPrice as decimal(16,6)) as iUnitPrice,cast(a.iTaxUnitPrice as decimal(16,6)) as iTaxUnitPrice ,cast(a.iMoney as decimal(16,4)) as iMoney ,cast(a.iTax as decimal(16,4)) as iTax ,cast(a.iSum as decimal(16,4)) as iSum 
    ,cast(a.iNatUnitPrice as decimal(16,6)) as iNatUnitPrice ,cast(a.iNatMoney as decimal(16,4)) as iNatMoney ,cast(a.iNatTax as decimal(16,4)) as iNatTax ,cast(a.iNatSum as decimal(16,4)) as iNatSum 
    ,cast(diss.iInvExchRate as decimal(16,6)) as iInvExchRate 
    ,bill.cCusCode,bill.cBusType,bill.iTaxRate,bill.cSBVCode ,bill.cPayCode,bill.cgatheringplan
    ,a.[GUID],bill.cMemo
    ,bill.cChecker ,bill.cVerifier 
FROM  _DispatchLists_SaleBillVouchs a 
	left join Inventory inv on a.cInvCode = inv.cInvCode
	left join DispatchLists diss on a.DLsID = diss.iDLsID
	left join DispatchList dis on dis.DLID = diss.DLID
	left join SaleBillVouchs bills on a.SaleBillsID = bills.AutoID
	left join SaleBillVouch bill on bill.SBVID = bills.SBVID
where a.[GUID] = '{0}'
";
                    sSQL = string.Format(sSQL, lGUID.Text.Trim());
                    DataTable dt = DbHelperSQL.Query(sSQL);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lookUpEditcCusCode.EditValue = dt.Rows[0]["cCusCode"].ToString().Trim();
                        lExchRate.Text = dt.Rows[0]["iExchRate"].ToString().Trim();
                        lGUID.Text = dt.Rows[0]["GUID"].ToString().Trim();
                        btntxtTaxRate.Text = dt.Rows[0]["iTaxRate"].ToString().Trim();
                        txtInvoice.Text = dt.Rows[0]["cSBVCode"].ToString().Trim();

                        string sBusType = dt.Rows[0]["cBusType"].ToString().Trim();
                        if (sBusType == "分期收款")
                        {
                            lookUpEditcBusType.EditValue = "Receiving by stages";
                        }
                        if (sBusType == "普通销售")
                        {
                            lookUpEditcBusType.EditValue = "General sales";
                        }
                        lookUpEditSKXY.EditValue = dt.Rows[0]["cgatheringplan"].ToString().Trim();
                        lookUpEditCurrency.EditValue = dt.Rows[0]["cexch_name"].ToString().Trim();
                        txtRemark.Text = dt.Rows[0]["cMemo"].ToString().Trim();

                        if (dt.Rows[0]["cChecker"].ToString().Trim() != "" || dt.Rows[0]["cVerifier"].ToString().Trim() != "")
                        {
                            txtStatus.Text = "Audit";
                        }
                    }

                    gridControl1.DataSource = dt;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColSelected, chkAll.Checked);
                }
            }
            catch { }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStatus.Text.Trim().ToLower() != "add" && txtStatus.Text.Trim().ToLower() != "edit")
                {
                    throw new Exception("Status is err");
                }

                string sSQL = "";
                string sWarn = "";
                string sErr = "";
                int iCou = 0;


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    //1.  判断是否结账
                    sSQL = "select * from gl_mend where iyear=year('" + sLogDate + "') and iperiod=month('" + sLogDate + "')";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("The current month has been checked out");
                    }
                    string iR = dtTemp.Rows[0]["bflag_SA"].ToString();
                    if (iR == "1")
                    {
                        throw new Exception("The current month has been checked out");
                    }

                    long lBillID = 0;

                    if (gridView1.RowCount <= 0)
                    {
                        throw new Exception("No data");
                    }


                    #region 修改的单据直接删除重新生成
                    // 1 删除发票
                    // 2 删除中间表

                    if (txtStatus.Text.Trim().ToLower() == "edit")
                    {
                        sSQL = @"

select distinct *
from SaleBillVouch 
where cSBVCode in (
		select SaleBillCode 
		from dbo._DispatchLists_SaleBillVouchs 
		where [GUID] = '{0}'
    )
	
";
                        sSQL = string.Format(sSQL, lGUID.Text.Trim());
                        DataTable dtVouch = DbHelperSQL.Query(sSQL);
                        if (dtVouch == null || dtVouch.Rows.Count == 0)
                        {
                            throw new Exception("Failed to obtain document information");
                        }

                        if (dtVouch.Rows[0]["cVerifier"].ToString().Trim() != "" || dtVouch.Rows[0]["cChecker"].ToString().Trim() != "" || dtVouch.Rows[0]["cAccounter"].ToString().Trim() != "")
                        {
                            throw new Exception("Status error of document");
                        }

                        string sBVCode = dtVouch.Rows[0]["cSBVCode"].ToString().Trim();
                        string sBVID = dtVouch.Rows[0]["SBVID"].ToString().Trim();
                        lBillID = BaseFunction.ReturnLong(sBVID);

                        //删除发票体
                        sSQL = @"
delete SaleBillVouchs where SBVID = '{0}'
";
                        sSQL = string.Format(sSQL, sBVID);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //删除发票头
                        sSQL = @"
delete SaleBillVouch where SBVID = '{0}'
";
                        sSQL = string.Format(sSQL, sBVID);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //回写发货单
                        sSQL = @"
select *
from _DispatchLists_SaleBillVouchs
where [GUID] = '{0}'
";
                        sSQL = string.Format(sSQL, lGUID.Text.Trim());
                        DataTable dtDel = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        for (int i = 0; i < dtDel.Rows.Count; i++)
                        {
                            sSQL = @"
update DispatchLists  set iSettleQuantity  = isnull(iSettleQuantity ,0) - {0},iSettleNum = isnull(iSettleNum,0) - {1}
where iDLsID = {2}
";
                            sSQL = string.Format(sSQL, dtDel.Rows[i]["SaleBillsQty"], dtDel.Rows[i]["iSum"], dtDel.Rows[i]["DLsID"]);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    #endregion

                    //删除中间表数据
                    sSQL = "delete dbo._DispatchLists_SaleBillVouchs where GUID = '" + lGUID.Text.Trim() + "'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (lGUID.Text.Trim() == "")
                    {
                        throw new Exception("System err,please exit and retry");
                    }

                    iCou = 0;

                    decimal dExchRate = 1;

                    string sexch_name = lookUpEditCurrency.EditValue.ToString().Trim();
                    sSQL = "select  cexch_name from dbo.foreigncurrency  where iotherused =-1";
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    string sBZ = dtTemp.Rows[0]["cexch_name"].ToString().Trim();
                    if (sBZ.ToLower() == sexch_name.ToLower())
                    {
                        dExchRate = 1;
                        lExchRate.Text = "1";
                    }
                    else
                    {
                        sSQL = @"
select iyear,iperiod ,nflat,cexch_name
from exch 
where itype = 2 and iYear = {0} and iperiod = {1} and cexch_name = '{2}'
";
                        sSQL = string.Format(sSQL, dtmLog.DateTime.Year, dtmLog.DateTime.Month, sexch_name);
                        DataTable dtExchRate = DbHelperSQL.Query(sSQL);
                        if (dtExchRate == null || dtExchRate.Rows.Count == 0)
                        {
                            throw new Exception("Please set exchage rate");
                        }
                        dExchRate = BaseFunction.ReturnDecimal(dtExchRate.Rows[0]["nflat"]);
                        lExchRate.Text = dExchRate.ToString();
                    }
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColSelected));
                        if (!b)
                            continue;

                        if (gridView1.GetRowCellValue(i, gridColcexch_name).ToString().Trim().ToLower() != sexch_name.ToLower())
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " currency is err\n";
                            continue;
                        }

                        Model._DispatchLists_SaleBillVouchs mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._DispatchLists_SaleBillVouchs();
                        mod.GUID = lGUID.Text.Trim();
                        mod.DLsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiDLsID));
                        mod.DLsQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiQty));
                        mod.SaleBillsQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColnowQty));
                        mod.DLCode = gridView1.GetRowCellValue(i, gridColcDLCode).ToString().Trim();
                        mod.CreateUid = sUserID;
                        mod.dtmLogin = BaseFunction.ReturnDate(sLogDate);
                       
                        mod.cWhCode = gridView1.GetRowCellValue(i, gridColcWhCode).ToString().Trim();
                        mod.Item = gridView1.GetRowCellValue(i, gridColitem).ToString().Trim();
                        mod.cInvCode = gridView1.GetRowCellValue(i, gridColcinvcode).ToString().Trim();

                        if (mod.iUnitPrice == 0 || mod.iTaxUnitPrice == 0)
                        {
                            sWarn = sWarn + "Line " + (i + 1) + " the price is 0\n";
                        }
                        mod.cexch_name = gridView1.GetRowCellValue(i,gridColcexch_name).ToString().Trim();

                        mod.iUnitPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiUnitPrice));
                        mod.iTaxUnitPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiTaxUnitPrice));
                        mod.iMoney = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiMoney));
                        mod.iSum =  BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiSum));
                        mod.iTax = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiTax));

                        mod.iNatMoney = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiNatMoney));
                        mod.iNatSum = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiNatSum));
                        mod.iNatTax = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiNatTax));
                        mod.iNatUnitPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiNatUnitPrice));

                        

                        DAL._DispatchLists_SaleBillVouchs dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._DispatchLists_SaleBillVouchs();
                        sSQL = dal.Add(mod);

                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCou == 0)
                    {
                        throw new Exception("Please choose data");
                    }

                    if (sWarn.Trim() != "")
                    {
                        FrmMsgBox frm = new FrmMsgBox();
                        frm.richTextBox1.Text = "Click 'Yes' to continue, else to cancel\n\n";
                        frm.richTextBox1.Text = sWarn;
                        if (DialogResult.OK != frm.ShowDialog())
                        {
                            throw new Exception("User cancel");
                        }
                    }

                    iCou = 0;

                    sSQL = @"
SELECT     a.cWhCode,   a.cInvCode , a.Item, sum(a.DLsQty) as DlsQty,sum(a.SaleBillsQty) as SaleBillsQty
	, sum(a.iMoney) as  iMoney ,sum(a.iSum)  as iSum,SUM(iTax) as iTax,AVG(iUnitPrice) as iUnitPrice,AVG(iTaxUnitPrice) as iTaxUnitPrice
	, sum(iNatSum) as iNatSum, sum(iNatMoney) as iNatMoney, AVG(iNatUnitPrice) as iNatUnitPrice, sum(iNatTax) as iNatTax
    ,inv.cInvName    ,COUNT(1) as iCou                  
FROM         _DispatchLists_SaleBillVouchs a left join Inventory inv on a.cInvCode = inv.cInvCode
where a.[GUID] = '{0}'
group by a.cWhCode,a.cInvCode , a.Item,inv.cInvName
";
                    sSQL = string.Format(sSQL, lGUID.Text.Trim());
                    DataTable dtGrid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    //2. 获得单据ID

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'BILLVOUCH',eeeeee,@p5 output,@p6 output,default
select @p5, @p6
                    ";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("dddddd", sAccID);
                    sSQL = sSQL.Replace("eeeeee", dtGrid.Rows.Count.ToString());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]);
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - dtGrid.Rows.Count;

                    string sCode = txtInvoice.Text.Trim();
                    if (txtStatus.Text.Trim().ToLower() == "add")
                    {
                        //3. 获得单据号
                        long iCode = 0;
                        sSQL = "select isnull(cNumber,0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='13' and cContent='单据日期' and cSeed = year('" + sLogDate + "')";
                        dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtTemp == null || dtTemp.Rows.Count < 1)
                        {
                            iCode = 1;
                        }
                        else
                        {
                            iCode = BaseFunction.ReturnLong(dtTemp.Rows[0]["Maxnumber"]) + 1;
                        }
                        //更新单据号
                        if (iCode == 1)
                        {
                            sSQL = @"
insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
values('13','单据日期','年','{0}','1',0)
";
                            sSQL = string.Format(sSQL, dtmLog.DateTime.Year);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = @"
update VoucherHistory set cNumber = {0}
where  CardNumber='13' and cContent='单据日期' and cSeed = year('" + sLogDate + "')";
                            sSQL = string.Format(sSQL, iCode);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        sCode = iCode.ToString().Trim().PadLeft(5, '0');
                        sCode = "SI-" + dtmLog.DateTime.ToString("yyyy") + sCode;
                    }

                    sSQL = @"
SELECT  a.cDepCode,a.cPersonCode,a.cSOCode,a.cCusCode,a.cexch_name,a.iTaxRate,a.iExchRate,a.cBusType,a.cCusName,a.icreditdays
    ,a.cdefine1,a.cdefine2,a.cdefine3,a.cdefine4,a.cdefine5,a.cdefine6,a.cdefine7,a.cdefine8,a.cdefine9,a.cdefine10,a.cdefine11,a.cdefine12,a.cdefine13,a.cdefine14,a.cdefine15,a.cdefine16              
FROM   _DispatchLists_SaleBillVouchs _temp 
	left join DispatchLists b on _temp.dlsid = b.iDLsID
	 left join DispatchList a on a.DLID = b.DLID
where _temp.[GUID] = '{0}'
";
                    sSQL = string.Format(sSQL, lGUID.Text.Trim());
                    DataTable dtDis = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = @"
SELECT distinct a.cDLCode          
FROM   _DispatchLists_SaleBillVouchs _temp 
	left join DispatchLists b on _temp.dlsid = b.iDLsID
	 left join DispatchList a on a.DLID = b.DLID
where _temp.[GUID] = '{0}'
";
                    sSQL = string.Format(sSQL, lGUID.Text.Trim());
                    DataTable dtDLCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    string sDLCode = "";

                    for (int i = 0; i < dtDLCode.Rows.Count; i++)
                    {
                        if (i == 3)
                            break;

                        if (sDLCode == "")
                        {
                            sDLCode = dtDLCode.Rows[i]["cDLCode"].ToString().Trim();
                        }
                        else
                        {
                            sDLCode = sDLCode + "," + dtDLCode.Rows[i]["cDLCode"].ToString().Trim();
                        }
                    }

                    DataTable dtZQ = new DataTable();
                    if (lookUpEditSKXY.Text.Trim() != "")
                    {
                        sSQL = @"
select cCode,cName,dblZQNum
from AA_Agreement 
where iLZYJ = 1 and cCode = '{0}'
";
                        sSQL = string.Format(sSQL, lookUpEditSKXY.EditValue.ToString().Trim());
                        dtZQ = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    }

                    #region 发票表头
                    Model.SaleBillVouch model = new Model.SaleBillVouch();

                    model.SBVID = lID;
                    model.cSBVCode = sCode;
                    model.cVouchType = "27";
                    model.cSTCode = "10";
                    model.iVTid = 17;
                    model.dDate = dtmLog.DateTime;
                    model.cDepCode = dtDis.Rows[0]["cDepCode"].ToString().Trim();
                    model.cPersonCode = dtDis.Rows[0]["cPersonCode"].ToString().Trim();
                    model.cSOCode = dtDis.Rows[0]["cSOCode"].ToString().Trim();
                    model.cCusCode = dtDis.Rows[0]["cCusCode"].ToString().Trim();
                    model.cexch_name = dtDis.Rows[0]["cexch_name"].ToString().Trim();
                    model.iTaxRate = BaseFunction.ReturnDecimal(dtDis.Rows[0]["iTaxRate"]);
                    model.iExchRate = BaseFunction.ReturnDecimal(dtDis.Rows[0]["iExchRate"]);
                    model.bReturnFlag = false;
                    //model.cBCode
                    model.cMaker = sUserName;
                    model.cBusType = dtDis.Rows[0]["cBusType"].ToString().Trim();
                    model.bFirst = false;
                    model.iDisp = 1;
                    model.cCusName = dtDis.Rows[0]["cCusName"].ToString().Trim();
                    //model.cDLCode = sDLCode;
                    model.bIAFirst = false;
                    //if (lookUpEditSKXY.EditValue != null && lookUpEditSKXY.EditValue.ToString().Trim() != "")
                    //{
                    //    model.cPayCode = lookUpEditSKXY.EditValue.ToString().Trim();
                    //}

                    if (dtZQ != null && dtZQ.Rows.Count > 0)
                    {
                        model.cgatheringplan = dtZQ.Rows[0]["cCode"].ToString().Trim();
                        model.dCreditStart = dtmLog.DateTime;
                        model.dGatheringDate = dtmLog.DateTime.AddDays(BaseFunction.ReturnInt(dtZQ.Rows[0]["dblZQNum"]));
                        model.icreditdays = BaseFunction.ReturnInt(dtZQ.Rows[0]["dblZQNum"]);
                    }
                    model.bCredit = true;
                    model.iverifystate = 0;
                    model.iswfcontrolled = 0;
                    model.iflowid = 0;
                    model.bcashsale = false;
                    
                    model.cSource = "销售";
                    model.dcreatesystime = dtmLog.DateTime;
                    model.cSysBarCode = "||SA72|" + model.cSBVCode;
                    model.cMemo = txtRemark.Text.Trim();

                    #region cDefine
                    model.cDefine1 =  dtDis.Rows[0]["cDefine1"].ToString().Trim();
                    model.cDefine2 =  dtDis.Rows[0]["cDefine2"].ToString().Trim();
                    model.cDefine3 =  dtDis.Rows[0]["cDefine3"].ToString().Trim();
                    if (dtDis.Rows[0]["cDefine4"].ToString().Trim() != "")
                    {
                        model.cDefine4 = BaseFunction.ReturnDate(dtDis.Rows[0]["cDefine4"]);
                    }
                    if (dtDis.Rows[0]["cDefine5"].ToString().Trim() != "")
                    {
                        model.cDefine5 = BaseFunction.ReturnLong(dtDis.Rows[0]["cDefine5"]);
                    }
                    if (dtDis.Rows[0]["cDefine6"].ToString().Trim() != "")
                    {
                        model.cDefine6 = BaseFunction.ReturnDate(dtDis.Rows[0]["cDefine6"]);
                    }
                    if (dtDis.Rows[0]["cDefine7"].ToString().Trim() != "")
                    {
                        model.cDefine7 = BaseFunction.ReturnDecimal(dtDis.Rows[0]["cDefine7"]);
                    }
                    model.cDefine8 = dtDis.Rows[0]["cDefine8"].ToString().Trim(); ;
                    model.cDefine9 = dtDis.Rows[0]["cDefine9"].ToString().Trim(); ;
                    model.cDefine10 = dtDis.Rows[0]["cDefine10"].ToString().Trim(); ;
                    model.cDefine11 = dtDis.Rows[0]["cDefine11"].ToString().Trim(); ;
                    model.cDefine12 = dtDis.Rows[0]["cDefine12"].ToString().Trim(); ;
                    model.cDefine13 = dtDis.Rows[0]["cDefine13"].ToString().Trim(); ;
                    model.cDefine14 = dtDis.Rows[0]["cDefine14"].ToString().Trim(); ;
                    if (dtDis.Rows[0]["cDefine15"].ToString().Trim() != "")
                    {
                        model.cDefine15 = BaseFunction.ReturnLong(dtDis.Rows[0]["cDefine15"]);
                    }
                    if (dtDis.Rows[0]["cDefine15"].ToString().Trim() != "")
                    {
                        model.cDefine16 = BaseFunction.ReturnDecimal(dtDis.Rows[0]["cDefine16"]);
                    }
                    #endregion

                    DAL.SaleBillVouch DalSaleBill = new DAL.SaleBillVouch();
                    sSQL = DalSaleBill.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
update salebillvouch set dverifydate = null,cVerifier = null,cAccounter = null,cChecker = null  
	,cInfoTypeCode = null ,dverifysystime = null,retail_id = null 
where SBVID = {0}
";
                    sSQL = string.Format(sSQL, model.SBVID);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    #endregion


                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        decimal dQty = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["SaleBillsQty"], 6);
                        if (dQty == 0)
                        {
                            continue;
                        }

                        sSQL = @"
select b.cCusInvCode,b.autoid,c.cDLCode,a.*
from dbo._DispatchLists_SaleBillVouchs a left join DispatchLists b on a.DLsID = b.iDLsID and isnull(a.Item,'') = isnull(b.cDefine29,'')
    left join DispatchList c on b.DLID = c.DLID
where a.[GUID] = '{0}' and a.cInvCode = '{1}'
";
                        sSQL = string.Format(sSQL,lGUID.Text.Trim(),dtGrid.Rows[i]["cInvCode"].ToString().Trim());

                        DataTable dtDis2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        Model.SaleBillVouchs models = new Model.SaleBillVouchs();

                        lIDDetails += 1;
                        models.AutoID = lIDDetails;
                        models.SBVID = model.SBVID;
                        models.cWhCode = dtGrid.Rows[i]["cWhCode"].ToString().Trim();
                        models.cInvCode = dtGrid.Rows[i]["cInvCode"].ToString().Trim();
                        models.iQuantity = dQty;
                        //models.iNum = dNum;
                        models.iQuotedPrice = 0;


                        int iGridCou = BaseFunction.ReturnInt(dtGrid.Rows[i]["iCou"]);

                        models.iSum = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iSum"]);
                        models.iMoney = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iMoney"]);
                        models.iTax = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iTax"]);

                        models.iNatSum = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iNatSum"]);
                        models.iNatMoney = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iNatMoney"]);
                        models.iNatTax = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iNatTax"]);

                        if (iGridCou == 1)
                        {
                            models.iUnitPrice = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iUnitPrice"]);
                            models.iTaxUnitPrice = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iTaxUnitPrice"]);

                            models.iNatUnitPrice = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iNatUnitPrice"]);
                        }
                        else
                        {
                            models.iUnitPrice = BaseFunction.ReturnDecimal(models.iMoney / dQty, 5);
                            models.iTaxUnitPrice = BaseFunction.ReturnDecimal(models.iSum / dQty, 5);

                            models.iNatUnitPrice = BaseFunction.ReturnDecimal(models.iNatMoney / dQty, 5);
                        }

                        models.iDisCount = 0;
                        models.iNatDisCount = 0;
                        models.iMoneySum = 0;
                        models.iExchSum = 0;

                        models.iBatch = 0;
                        //models.cBatch
                        models.bSettleAll = false;
                        models.iTB = 0;
                        models.TBQuantity = 0;
                        //models.iSOsID = 0;

                        models.iDLsID = BaseFunction.ReturnLong(dtDis2.Rows[0]["DLsID"]);            //发货单编号
                        
                        models.KL = 100;
                        models.KL2 = 100;
                        models.cInvName = dtGrid.Rows[i]["cInvName"].ToString().Trim();
                        models.iTaxRate = BaseFunction.ReturnDecimal(btntxtTaxRate.Text.Trim());

                        models.fOutQuantity = 0;
                        models.fOutNum = 0;
                        models.fSaleCost = 0;
                        models.fSalePrice = 0;
                        models.bgsp = false;
                        models.cMassUnit = 0;
                        models.bQANeedCheck = false;
                        models.bQAUrgency = false;
                        models.cCusInvCode = dtDis2.Rows[0]["cCusInvCode"].ToString().Trim();             //客户存货编码
                        models.bcosting = true;
                        models.fcusminprice = 0;
                        models.irowno = i + 1;
                        models.iExpiratDateCalcu = 0;

                        models.cbdlcode = dtDis2.Rows[0]["DLCode"].ToString().Trim();    //发货单号
                        models.bsaleprice = false;
                        models.bgift = false;
                        models.cbSysBarCode = "||SA72|" + model.cSBVCode + "|" + models.irowno.ToString();

                        #region cDefine
                        //models.cDefine22 = cDefine22;
                        //models.cDefine23 = cDefine23;
                        //models.cDefine24 = cDefine24;
                        //models.cDefine25 = cDefine25;
                        //models.cDefine26 = cDefine26;
                        //models.cDefine27 = cDefine27;
                        //models.cDefine28 = cDefine28;
                        models.cDefine29 =  dtGrid.Rows[i]["item"].ToString().Trim();
                        //models.cDefine30 = cDefine30;
                        //models.cDefine31 = cDefine31;
                        //models.cDefine32 = cDefine32;
                        //models.cDefine33 = cDefine33;
                        //models.cDefine34 = cDefine34;
                        //models.cDefine35 = cDefine35;
                        //if (cDefine36.ToString() != "1900/1/1 0:00:00")
                        //{
                        //    models.cDefine36 = cDefine36;
                        //}
                        //if (cDefine37.ToString() != "1900/1/1 0:00:00")
                        //{
                        //    models.cDefine37 = cDefine37;
                        //}
                        #endregion

                        DAL.SaleBillVouchs dals = new DAL.SaleBillVouchs();
                        sSQL = dals.Add(models);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = @"
update _DispatchLists_SaleBillVouchs set SaleBillsID = {0},SaleBillCode = '{1}',SaleBillID = {6}
where [GUID] = '{2}' and isnull([item],'') = '{3}' and cInvCode = '{4}' and cWhCode = '{5}'
";
                        sSQL = string.Format(sSQL, models.AutoID, model.cSBVCode, lGUID.Text.Trim(), models.cDefine29, models.cInvCode, models.cWhCode,model.SBVID);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    //修改单据时用回老的表头ID
                    if (txtStatus.Text.Trim().ToLower() == "edit" && lBillID > 0)
                    {
                        sSQL = @"
update salebillvouch set SBVID = {1}
where SBVID = {0}
";
                        sSQL = string.Format(sSQL, model.SBVID, lBillID);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
update salebillvouchs set SBVID = {1}
where SBVID = {0}
";
                        sSQL = string.Format(sSQL, model.SBVID, lBillID);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = @"
select *
from _DispatchLists_SaleBillVouchs
where [GUID] = '{0}'
";
                    sSQL = string.Format(sSQL, lGUID.Text.Trim());
                    DataTable dtUp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dtUp.Rows.Count; i++)
                    {
                        sSQL = @"
update DispatchLists  set iSettleQuantity  = isnull(iSettleQuantity ,0) + {0},iSettleNum = isnull(iSettleNum,0) + {1}
where iDLsID = {2}
";
                        sSQL = string.Format(sSQL, dtUp.Rows[i]["SaleBillsQty"], dtUp.Rows[i]["iSum"], dtUp.Rows[i]["DLsID"]);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("Sucess:\n" + model.cSBVCode);

                        txtStatus.Text = "Saved";
                        txtInvoice.Text = model.cSBVCode;

                        SetTxtEnable(false);
                        SetBtnEnable(true);
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private long sCode(long lCode)
        {
            string sCode = lCode.ToString().Trim();
            while (sCode.Length < 9)
            {
                sCode = "0" + sCode;
            }
            sCode = "1" + sCode;

            return BaseFunction.ReturnLong(sCode);
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColnowQty)
                {
                    decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColunQty));
                    decimal dQtyNow = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColnowQty));
                    if (dQty < dQtyNow)
                    {
                        throw new Exception("The qty is beyond");
                    }
                }

                if (e.Column == gridColiTaxUnitPrice)
                {
                    decimal dTaxRate = BaseFunction.ReturnDecimal(btntxtTaxRate.Text.Trim());
                    decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColnowQty));
                    decimal dTaxUnitPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiTaxUnitPrice));
                    decimal dUnitPrice;
                    decimal dMoney;
                    decimal dTax;
                    decimal dSum;
                    decimal iNatSum; 
                    decimal iNatMoney; 
                    decimal iNatUnitPrice; 
                    decimal iNatTax;

                    JSPrice(dTaxUnitPrice, dQty, dTaxRate
                        , out dUnitPrice, out dMoney, out dTax, out dSum
                        , out iNatSum, out iNatMoney, out iNatUnitPrice, out iNatTax);

                    gridView1.SetRowCellValue(e.RowHandle, gridColiUnitPrice, dUnitPrice);
                    gridView1.SetRowCellValue(e.RowHandle, gridColiSum, dSum);
                    gridView1.SetRowCellValue(e.RowHandle, gridColiMoney, dMoney);
                    gridView1.SetRowCellValue(e.RowHandle, gridColiTax, dTax);

                    gridView1.SetRowCellValue(e.RowHandle, gridColiNatSum, iNatSum);
                    gridView1.SetRowCellValue(e.RowHandle, gridColiNatMoney, iNatMoney);
                    gridView1.SetRowCellValue(e.RowHandle, gridColiNatUnitPrice, iNatUnitPrice);
                    gridView1.SetRowCellValue(e.RowHandle, gridColiNatTax, iNatTax);

                    int iFocRow = e.RowHandle;

                    if (radioSameItemPartNo.Checked)
                    {
                        DataTable dt = (DataTable)gridControl1.DataSource;

                        string sPartNo = gridView1.GetRowCellValue(iFocRow, gridColcinvcode).ToString().Trim();
                        string sItem = gridView1.GetRowCellValue(iFocRow, gridColitem).ToString().Trim();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sPartNo2 = dt.Rows[i]["cinvcode"].ToString().Trim();
                            string sItem2 = dt.Rows[i]["item"].ToString().Trim();
                            if (sPartNo == sPartNo2 && sItem == sItem2)
                            {
                                decimal dQty2 = BaseFunction.ReturnDecimal(dt.Rows[i]["nowQty"]);

                                JSPrice(dTaxUnitPrice, dQty2, dTaxRate
                       , out dUnitPrice, out dMoney, out dTax, out dSum
                       , out iNatSum, out iNatMoney, out iNatUnitPrice, out iNatTax);

                                dt.Rows[i]["iTaxUnitPrice"] = dTaxUnitPrice;
                                dt.Rows[i]["iUnitPrice"] = dUnitPrice;
                                dt.Rows[i]["iMoney"] = dMoney;
                                dt.Rows[i]["iTax"] = dTax;
                                dt.Rows[i]["iSum"] = dSum;
                                dt.Rows[i]["iNatSum"] = iNatSum;
                                dt.Rows[i]["iNatMoney"] = iNatMoney;
                                dt.Rows[i]["iNatUnitPrice"] = iNatUnitPrice;
                                dt.Rows[i]["iNatTax"] = iNatTax;

                            }
                        }
                        gridControl1.DataSource = dt;
                        gridView1.FocusedRowHandle = iFocRow;
                    }

                    if (radioSamePartNo.Checked)
                    {
                        DataTable dt = (DataTable)gridControl1.DataSource;

                        string sPartNo = gridView1.GetRowCellValue(iFocRow, gridColcinvcode).ToString().Trim();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sPartNo2 = dt.Rows[i]["cinvcode"].ToString().Trim();
                            if (sPartNo == sPartNo2)
                            {
                                decimal dQty2 = BaseFunction.ReturnDecimal(dt.Rows[i]["nowQty"]);

                                JSPrice(dTaxUnitPrice, dQty2, dTaxRate
                       , out dUnitPrice, out dMoney, out dTax, out dSum
                       , out iNatSum, out iNatMoney, out iNatUnitPrice, out iNatTax);

                                dt.Rows[i]["iTaxUnitPrice"] = dTaxUnitPrice;
                                dt.Rows[i]["iUnitPrice"] = dUnitPrice;
                                dt.Rows[i]["iMoney"] = dMoney;
                                dt.Rows[i]["iTax"] = dTax;
                                dt.Rows[i]["iSum"] = dSum;
                                dt.Rows[i]["iNatSum"] = iNatSum;
                                dt.Rows[i]["iNatMoney"] = iNatMoney;
                                dt.Rows[i]["iNatUnitPrice"] = iNatUnitPrice;
                                dt.Rows[i]["iNatTax"] = iNatTax;

                            }
                        }
                        gridControl1.DataSource = dt;
                        gridView1.FocusedRowHandle = iFocRow;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEditcCode1_EditValueChanged(object sender, EventArgs e)
        {
            btnSel_Click(null, null);
        }

        public void GetGridViewSet(DevExpress.XtraGrid.Views.Grid.GridView gridView1)
        {
            gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gridView1.OptionsCustomization.AllowSort = false;
            gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            gridView1.OptionsLayout.Columns.StoreAppearance = true;
            gridView1.OptionsLayout.StoreAllOptions = true;
            gridView1.OptionsLayout.StoreAppearance = true;
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsPrint.AutoWidth = false;

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
                f.Text = "Export excel err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
            lookUpEditcCusAbbName.EditValue = lookUpEditcCusCode.EditValue;
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;

                if (lookUpEditcCusName.EditValue != null && lookUpEditcCusName.EditValue.ToString().Trim() != "")
                {
                    string sCusCode = lookUpEditcCusName.EditValue.ToString().Trim();

                    string sSQL = @"
select distinct sale_DispToSaleVouch_T.cdlcode 
from sale_DispToSaleVouch_T WITH (NOLOCK) inner join sale_DispToSaleVouch_B WITH (NOLOCK) on sale_DispToSaleVouch_T.dlid=sale_DispToSaleVouch_B.dlid 
where 
	sale_DispToSaleVouch_T.ccuscode = '{0}'
	and (cVouchType=N'05' AND sale_DispToSaleVouch_B.bSettleAll=0 AND ISNULL(iSale,0)=0 AND IsNULL(cVerifier,N'')<>N'' 
	and (isnull(icorid,0)=0 or isnull(bneedbill,0)=1) 
	and (ISNULL(bsaleoutcreatebill ,0)=0 OR (ISNULL(bsaleoutcreatebill ,0)=1 and ISNULL(cwhcode,N'')=N''))) 
	and ( 
	1=1   
	and 
	(isnull(bneedsign,0)=0 or (isnull(bneedsign,0)=1 and isnull(bsignover,0)=1 and isnull(bneedloss,0)=0)  or (isnull(iflowid,0)=0 )) 
	and  (case when ISNULL(iquantity,0)=0 then cast(ISNULL(isum,0)-isnull(fretsum,0)-ISNULL(isettlenum,0) as decimal(26,6)) else cast(ISNULL(sale_DispToSaleVouch_B.iQuantity,0)-ISNULL(sale_DispToSaleVouch_B.iSettleQuantity,0)-ISNULL(fretqtywkp,0) as decimal(26,9)) end )>0)
order by sale_DispToSaleVouch_T.cdlcode

";
                    sSQL = string.Format(sSQL, sCusCode);
                    DataTable dtCus = DbHelperSQL.Query(sSQL);
                    lookUpEditcCode1.Properties.DataSource = dtCus;
                    lookUpEditcCode2.Properties.DataSource = dtCus;

                    sSQL = @"
select cCusExch_name 
from Customer 
where cCusCode = '{0}'
";
                    sSQL = string.Format(sSQL, sCusCode);
                    DataTable dt = DbHelperSQL.Query(sSQL);
                    lookUpEditCurrency.EditValue = dt.Rows[0]["cCusExch_name"].ToString().Trim();
                }
            }
            catch (Exception ee)
            { }
        }

        private void lookUpEditcCusAbbName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusAbbName.EditValue;

        }

        private void SetTxtEnable(bool b)
        {
            lookUpEditcCusCode.Enabled = b;
            lookUpEditcCusName.Enabled = b;
            lookUpEditcCusAbbName.Enabled = b;

            btntxtTaxRate.Enabled = b;

            lookUpEditcBusType.Enabled = b;

            lookUpEditcCode1.Enabled = b;
            lookUpEditcCode2.Enabled = b;

            dateEdit1.Enabled = b;
            dateEdit2.Enabled = b;

            txtInvoice.Enabled = false;

            gridView1.OptionsBehavior.Editable = b;

            chkAll.Enabled = b;

            lookUpEditSKXY.Enabled = b;
            lookUpEditCurrency.Enabled = b;

            txtRemark.Enabled = b;
        }

        private void SetBtnEnable(bool b)
        {
            btnQuery.Enabled = !b;
            btnEdit.Enabled = b;
            btnSave.Enabled = !b;
            btnDel.Enabled = b;

            btnExportExcel.Enabled = true;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"

select distinct *
from SaleBillVouch 
where cSBVCode in (
		select SaleBillCode 
		from dbo._DispatchLists_SaleBillVouchs 
		where [GUID] = '{0}'
    )
	
";
                sSQL = string.Format(sSQL, lGUID.Text.Trim());
                DataTable dtVouch = DbHelperSQL.Query(sSQL);
                if (dtVouch == null || dtVouch.Rows.Count == 0)
                {
                    throw new Exception("Failed to obtain document information");
                }

                if (dtVouch.Rows[0]["cVerifier"].ToString().Trim() != "" || dtVouch.Rows[0]["cChecker"].ToString().Trim() != "" || dtVouch.Rows[0]["cAccounter"].ToString().Trim() != "")
                {
                    throw new Exception("Status error of document");
                }

                SetTxtEnable(true);
                SetBtnEnable(false);

                

                txtStatus.Text = "Edit";
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int iCou = 0;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sGuid = lGUID.Text.Trim();

                    string sSQL = @"

select distinct *
from SaleBillVouch 
where cSBVCode in (
		select SaleBillCode 
		from dbo._DispatchLists_SaleBillVouchs 
		where [GUID] = '{0}'
    )
	
";
                    sSQL = string.Format(sSQL, sGuid);
                    DataTable dtVouch = DbHelperSQL.Query(sSQL);
                    if (dtVouch == null || dtVouch.Rows.Count == 0)
                    {
                        throw new Exception("Failed to obtain document information");
                    }

                    if (dtVouch.Rows[0]["cVerifier"].ToString().Trim() != "" || dtVouch.Rows[0]["cChecker"].ToString().Trim() != "" || dtVouch.Rows[0]["cAccounter"].ToString().Trim() != "")
                    {
                        throw new Exception("Status error of document");
                    }

                    string sBVCode = dtVouch.Rows[0]["cSBVCode"].ToString().Trim();
                    string sBVID = dtVouch.Rows[0]["SBVID"].ToString().Trim();
                    //删除发票体
                    sSQL = @"
delete SaleBillVouchs where SBVID = '{0}'
";
                    sSQL = string.Format(sSQL, sBVID);
                    iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //删除发票头
                    sSQL = @"
delete SaleBillVouch where SBVID = '{0}'
";
                    sSQL = string.Format(sSQL, sBVID);
                    iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //回写发货单
                    sSQL = @"
select *
from _DispatchLists_SaleBillVouchs
where [GUID] = '{0}'
";
                    sSQL = string.Format(sSQL, sGuid);
                    DataTable dtUp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dtUp.Rows.Count; i++)
                    {
                        sSQL = @"
update DispatchLists  set iSettleQuantity  = isnull(iSettleQuantity ,0) - {0},iSettleNum = isnull(iSettleNum,0) - {1}
where iDLsID = {2}
";

                        sSQL = string.Format(sSQL, dtUp.Rows[i]["SaleBillsQty"], dtUp.Rows[i]["iSum"], dtUp.Rows[i]["DLsID"]);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }

                    //删除中间表数据
                    sSQL = @"
delete  _DispatchLists_SaleBillVouchs 
where [GUID] = '{0}'
";
                    sSQL = string.Format(sSQL, lGUID.Text.Trim());

                    SetTxtEnable(false);
                    SetBtnEnable(true);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    txtStatus.Text = "Delete";

                    tran.Commit();

                    MessageBox.Show("OK");
                    this.Close();
                }
                catch (Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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

        private void btntxtTaxRate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                //gridview iCol = gridView1.FocusedColumn;
                DataTable dtGrid = (DataTable)gridControl1.DataSource;

                decimal dTaxRate = BaseFunction.ReturnDecimal(btntxtTaxRate.Text.Trim());

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    decimal dQty = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["unQty"]);
                    decimal dTaxUnitPrice = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["iTaxUnitPrice"]);
                    decimal dUnitPrice;
                    decimal dMoney;
                    decimal dTax;
                    decimal dSum;
                    decimal iNatSum;
                    decimal iNatMoney;
                    decimal iNatUnitPrice;
                    decimal iNatTax;


                    JSPrice(dTaxUnitPrice, dQty, dTaxRate
                        , out dUnitPrice, out dMoney, out dTax, out dSum
                        , out iNatSum, out iNatMoney, out iNatUnitPrice, out iNatTax);

                    dtGrid.Rows[i]["iUnitPrice"] = dUnitPrice;
                    dtGrid.Rows[i]["iMoney"] = dMoney;
                    dtGrid.Rows[i]["iTax"] = dTax;
                    dtGrid.Rows[i]["iSum"] = dSum;

                    dtGrid.Rows[i]["iNatSum"] = iNatSum;
                    dtGrid.Rows[i]["iNatMoney"] = iNatMoney;
                    dtGrid.Rows[i]["iNatUnitPrice"] = iNatUnitPrice;
                    dtGrid.Rows[i]["iNatTax"] = iNatTax;
                }
                gridControl1.DataSource = dtGrid;

                gridView1.FocusedRowHandle = iRow;

            }
            catch { }
        }


        private void JSPrice(decimal dTaxUnitPrice, decimal dQty, decimal dTaxRate
            , out decimal dUnitPrice, out decimal dMoney, out decimal dTax, out decimal dSum
            ,out decimal iNatSum,out decimal iNatMoney,out decimal iNatUnitPrice,out decimal iNatTax)
        {
            decimal iExchRate = BaseFunction.ReturnDecimal(lExchRate.Text.Trim());
            if(iExchRate == 0)
            {
            throw new Exception("Please set exchange rate");
            }

            dUnitPrice = BaseFunction.ReturnDecimal(dTaxUnitPrice / (1 + dTaxRate / 100), 5);
            dMoney = BaseFunction.ReturnDecimal(dUnitPrice * dQty, 2);
            dTax = BaseFunction.ReturnDecimal(dMoney * (dTaxRate / 100), 2);
            dSum = dMoney + dTax;

            iNatUnitPrice = BaseFunction.ReturnDecimal(dUnitPrice* iExchRate,2);
            iNatMoney =BaseFunction.ReturnDecimal( iNatUnitPrice* dQty,2);
            iNatTax = BaseFunction.ReturnDecimal(iNatMoney * (dTaxRate / 100), 2);

            iNatSum = iNatMoney + iNatTax;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                    return;

                string sDisCode = gridView1.GetRowCellValue(iRow, gridColcDLCode).ToString().Trim();
                bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(iRow, gridColSelected));

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (sDisCode == gridView1.GetRowCellValue(i, gridColcDLCode).ToString().Trim())
                    {
                        gridView1.SetRowCellValue(i, gridColSelected, !b);
                    }
                }

            }
            catch { 
            
            }
        }

    }
}