using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;
using System.Data.SqlClient;
using System.IO;
using System.Collections;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmFHDEdit : Form
    {
        string sConnString;
        string sUid;
        string sUserName;
        string sAccID;
        DateTime dLogDate;
        int iType;              //1. 新增，2. 修改， 3. 浏览（保存后）,4. 审核
        string sDLCode;
        Color cChoose = Color.Green;
        Color cUnChoose = Color.Black;
        Color cUsed = Color.Tomato;

        public FrmFHDEdit(string sConn, string sUid, string sUserName, string sAccID, DateTime dLogDate, int iType, string sCode)
        {
            InitializeComponent();

            this.sConnString = sConn;
            this.sUid = sUid;
            this.sUserName = sUserName;
            this.sAccID = sAccID;
            this.dLogDate = dLogDate;
            this.iType = iType;
            this.sDLCode = sCode;
        }

        private void SetLookup()
        {
            string sSQL = "select cCusCode,cCusName,cCusAbbName from Customer order by cCusCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;
            lookUpEditcCusCode.EditValue = "01010002";

            sSQL = "select cPersonCode,cPersonName from Person order by cPersonCode";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditcPersonCode.Properties.DataSource = dt;
            lookUpEditcPersonName.Properties.DataSource = dt;

            sSQL = "select cWhCode,cWhName from Warehouse order by cWhCode";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditcWhCode.Properties.DataSource = dt;
            lookUpEditcWhName.Properties.DataSource = dt;


            sSQL = "select cDepCode,cDepName from Department order by cDepCode";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditDepCode.Properties.DataSource = dt;
            lookUpEditDepName.Properties.DataSource = dt;
            lookUpEditDepCode.EditValue = "0302";

            string sCusCode = lookUpEditcCusCode.EditValue.ToString();
            sSQL = @"
select inv.cInvCode,inv.cInvName,inv.cInvStd,inv.cComUnitCode,cUnit.cComUnitName ,inv.cInvAddCode
from Inventory inv inner join ComputationUnit cUnit on inv.cComUnitCode = cUnit.cComUnitCode
where isnull(bSale ,0) = 1
order by inv.cInvCode
";
            dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvCode.DataSource = dt;

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
        }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();


                if (iType == 1)
                {
                    SetTxtNull();

                    string sSQL = @"
select a.cDLCode,a.cDepCode,a.cCusCode,a.cDefine10 as ProName,a.cDefine11 as ContactInfo,a.cPersonCode
	,a.cDefine4 as dtmPickUp,a.cDefine2 as timePickUp,a.cDefine1 as SiteQty,b.cDefine22 as NoSite,b.cDefine23 as TypeSite,b.cDefine24 as SiteID,b.cDefine28 as Region,b.cDefine25 as ASP
	,b.cInvCode,Inv.cInvName ,Inv.cInvStd,Inv.cInvAddCode,b.cCusInvCode
	,b.cUnitID ,b.cWhCode,b.iQuantity,b.iUnitPrice,b.iMoney
    ,inv.cComUnitCode
    ,cast(null as decimal(16,2)) as Qty
    ,cast(null as decimal(16,2)) as Amount
    ,cast(null as decimal(16,2)) as Price
    ,a.cMemo,a.cDefine5 as WeekNo,a.cDefine12 as LotNo
    ,b.cDefine29 as Item
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory Inv on Inv.cInvCode = b.cInvCode
where 1=-1
order by b.AutoID
";
                    DataTable dt = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dt;

                    while (GridView1.RowCount < 100)
                    {
                        GridView1.AddNewRow();
                    }

                    GridView1.FocusedRowHandle = 0;

                    SetEnable(true);

                    dateEdit1.DateTime = DateTime.Today;

                    txtStatus.Text = "add";

                    SetBtnEnable(true);
                }
                if (iType == 2)
                {
                    SetTxtNull();
                    SetEnable(false);
                    //SetBtnEnable(true);
                    string sSQL = @"
select a.cDLCode,a.cDepCode,a.cCusCode,a.cDefine10 as ProName,a.cDefine11 as ContactInfo,a.cPersonCode
	,a.cDefine4 as dtmPickUp,a.cDefine2 as timePickUp,a.cDefine1 as SiteQty,b.cDefine22 as NoSite,b.cDefine23 as TypeSite,b.cDefine24 as SiteID,b.cDefine28 as Region,b.cDefine25 as ASP
	,b.cInvCode,Inv.cInvName ,Inv.cInvStd,Inv.cInvAddCode,b.cCusInvCode
	,b.cUnitID ,b.cWhCode,b.iQuantity,b.iUnitPrice,b.iMoney
    ,inv.cComUnitCode
    ,cast(null as decimal(16,2)) as Qty
    ,cast(null as decimal(16,2)) as Amount
    ,cast(null as decimal(16,2)) as Price
    ,a.cMemo,a.cDefine5 as WeekNo,a.cDefine12 as LotNo
    ,a.cBusType
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory Inv on Inv.cInvCode = b.cInvCode
where 1=-1
order by b.AutoID
";
                    DataTable dt = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dt;

                    sSQL = @"
select distinct cDefine22 ,cDefine23 ,cDefine24 ,cDefine25 ,cDefine28,cDefine34
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID 
where cDLCode = 'aaaaaa' 
order by cDefine34
";
                    sSQL = sSQL.Replace("aaaaaa", sDLCode);
                    DataTable dtBand = DbHelperSQL.Query(sSQL);
                    for (int i = 0; i < dtBand.Rows.Count; i++)
                    {
                        txtSiteNo.Text = dtBand.Rows[i]["cDefine22"].ToString().Trim();
                        txtType.Text = dtBand.Rows[i]["cDefine23"].ToString().Trim();
                        txtSiteID.Text = dtBand.Rows[i]["cDefine24"].ToString().Trim();
                        txtASP.Text = dtBand.Rows[i]["cDefine25"].ToString().Trim();
                        txtRegion.Text = dtBand.Rows[i]["cDefine28"].ToString().Trim();
                        btnAddCol_Click(null, null);
                    }

                    sSQL = @"
select distinct a.cDLCode,a.cDepCode,a.cCusCode,a.cDefine10 as ProName,a.cDefine11 as ContactInfo
	,a.cPersonCode,a.cDefine4 as dtmPickUp,a.cDefine2 as timePickUp,a.cDefine3 as SiteQty
	,b.cInvCode,Inv.cInvName ,Inv.cInvStd,Inv.cInvAddCode,a.cVerifier
	,b.cUnitID ,b.cWhCode,b.iUnitPrice as Price
	111111111111111111111111
    ,inv.cComUnitCode
    ,cast(null as decimal(16,2)) as Qty
    ,cast(null as decimal(16,2)) as Amount
    ,a.cMemo,a.cDefine5 as WeekNo,a.cDefine12 as LotNo
    ,b.cDefine29 as Item
    ,a.cBusType
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory Inv on Inv.cInvCode = b.cInvCode
where cDLCode = 'aaaaaa' 
";
                    sSQL = sSQL.Replace("aaaaaa", sDLCode);
                    for (int i = 0; i < dtBand.Rows.Count; i++)
                    {
                        sSQL = sSQL.Replace("111111111111111111111111", "111111111111111111111111,cast(null as decimal(16,2)) as Qty_SiteNo_" + dtBand.Rows[i]["cDefine22"].ToString().Trim());
                    }
                    sSQL = sSQL.Replace("111111111111111111111111", "");

                    DataTable dtGrid = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dtGrid;

                    sSQL = @"
select b.*
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory Inv on Inv.cInvCode = b.cInvCode
where cDLCode = 'aaaaaa' 
";
                    sSQL = sSQL.Replace("aaaaaa", sDLCode);
                    DataTable dtDispatchLists = DbHelperSQL.Query(sSQL);

                    for (int i = 0; i < GridView1.RowCount; i++)
                    {
                        string sItem = GridView1.GetRowCellValue(i, gridColItem).ToString().Trim();
                        for (int j = 0; j < dtBand.Rows.Count; j++)
                        {
                            string sSiteNo = dtBand.Rows[j]["cDefine22"].ToString().Trim();

                            DataRow[] dr = dtDispatchLists.Select("cDefine22 = '" + sSiteNo + "' and cInvCode = '" + GridView1.GetRowCellDisplayText(i, gridColcInvCode).ToString() + "' and isnull(cDefine29,'') = '" + sItem + "'");
                            if (dr != null && dr.Length > 0)
                            {
                                decimal dQty = BaseFunction.ReturnDecimal(dr[0]["iQuantity"]);
                                GridView1.SetRowCellValue(i, GridView1.Columns["Qty_SiteNo_" + sSiteNo], dQty);
                            }
                        }
                    }
                    txtCode.Text = dtGrid.Rows[0]["cDLCode"].ToString();
                    lookUpEditDepCode.EditValue = dtGrid.Rows[0]["cDepCode"].ToString();
                    lookUpEditcCusCode.EditValue = dtGrid.Rows[0]["cCusCode"].ToString();
                    txtProName.Text = dtGrid.Rows[0]["ProName"].ToString();
                    txtContact.Text = dtGrid.Rows[0]["ContactInfo"].ToString();
                    lookUpEditcPersonCode.EditValue = dtGrid.Rows[0]["cPersonCode"];
                    dateEdit1.Text = BaseFunction.ReturnDate(dtGrid.Rows[0]["dtmPickUp"]).ToString("yyyy-MM-dd");
                    timeEdit1.Text = dtGrid.Rows[0]["timePickUp"].ToString();
                    txtSite.Text = dtGrid.Rows[0]["SiteQty"].ToString();
                    lookUpEditcWhCode.EditValue = dtGrid.Rows[0]["cWhCode"].ToString();
                    txtLotNo.Text = dtGrid.Rows[0]["LotNo"].ToString();
                    txtMemo.Text = dtGrid.Rows[0]["cMemo"].ToString();
                    txtWeekNo.Text = dtGrid.Rows[0]["WeekNo"].ToString();
                    string scBusType = dtGrid.Rows[0]["cBusType"].ToString();
                    if (scBusType == "分期收款")
                    {
                        lookUpEditcBusType.EditValue = "Receiving by stages";
                    }
                    if (scBusType == "普通销售")
                    {
                        lookUpEditcBusType.EditValue = "General sales";
                    }

                    //if (dtGrid.Rows[0]["cVerifier"].ToString() != "")
                    //{
                    //    SetBtnEnable(false);
                    //}
                    //else
                    //{
                    //    SetBtnEnable(true); 
                    //}

                    string sCode = txtCode.Text.Trim();
                    sSQL = @"
select * from DispatchList where cDLCode = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    dt = DbHelperSQL.Query(sSQL);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        txtStatus.Text = "err";
                    }
                    if (BaseFunction.ReturnInt(dt.Rows[0]["cDefine15"]) != 1)
                    {
                        txtStatus.Text = "err";
                    }
                    GetVouchStatus(sCode);

                    SetBtnEnable(false);
                }

                gridBand5.Width = 80;
                gridBand1.Width = 320;
                gridBand7.Width = 120;
                gridBandNoSitelist.Width = 100;

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n" + ee.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    GridView1.FocusedRowHandle -= 1;
                    GridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                string sWarn = "";
                int iCount = 0;

                //DialogResult d = checkData();
                //if (d != DialogResult.OK)
                //    return;

                if (iType == 1 && txtCode.Text.Trim() != "")
                {
                    throw new Exception("Be saved");
                }

                if (lookUpEditcBusType.EditValue == null || lookUpEditcBusType.EditValue.ToString().Trim() == "")
                {
                    lookUpEditcBusType.Focus();
                    throw new Exception("Please set Business type");
                }

                for (int i = GridView1.RowCount - 1; i >= 0; i--)
                {
                    string s1 = GridView1.GetRowCellDisplayText(i, gridColcInvCode).ToString().Trim();
                    string s2 = GridView1.GetRowCellDisplayText(i, gridColcInvName).ToString().Trim();
                    if (s1 == "" && s2 == "")
                    {
                        GridView1.DeleteRow(i);
                    }

                }

                if (lookUpEditcPersonCode.Text.Trim() == "")
                {
                    lookUpEditcPersonCode.Focus();
                    throw new Exception("Please set salesman");
                }
                if (lookUpEditcWhCode.Text.Trim() == "")
                {
                    lookUpEditcWhCode.Focus();
                    throw new Exception("Please set warehouse no");
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {


                    string sCusCode = lookUpEditcCusCode.EditValue.ToString().Trim();
                    sSQL = @"
select inv.cInvCode,inv.cInvName,inv.cInvStd,inv.cComUnitCode,cUnit.cComUnitName ,inv.cInvAddCode
from Inventory inv inner join ComputationUnit cUnit on inv.cComUnitCode = cUnit.cComUnitCode
where isnull(bSale ,0) = 1
order by inv.cInvCode
";
                    DataTable dtInvCus = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < GridView1.RowCount; i++)
                    {
                        string sInvAddCode = GridView1.GetRowCellValue(i, gridColcInvAddCode).ToString().Trim();
                        if (sInvAddCode == "")
                            continue;
                        DataRow[] dr = dtInvCus.Select("cInvAddCode = '" + sInvAddCode + "'");
                        GridView1.SetRowCellValue(i, gridColcInvCode, dr[0]["cInvAddCode"].ToString());
                    }

                    sSQL = "select isnull(bflag_SA,0) as bflag from GL_mend where iYPeriod = '" + dateEdit1.DateTime.ToString("yyyyMM") + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Access module state failure");
                    }
                    int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                    if (i结账 > 0)
                    {
                        throw new Exception(dateEdit1.DateTime.ToString("yyyy-MM") + " have checked out");
                    }

                    string sCode = txtCode.Text.Trim();
                    long lCode = 0;
                    if (iType == 1)
                    {
                        //获得单据号
                        sSQL = "select max(cNumber) as cNumber from VoucherHistory with (ROWLOCK) where CardNumber = '01' and cSeed = '" + dateEdit1.DateTime.Year.ToString() + "'";
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                        }
                        else
                        {
                            lCode = 0;
                        }

                        lCode += 1;
                        sCode = lCode.ToString();
                        while (sCode.Length < 5)
                        {
                            sCode = "0" + sCode;
                        }
                        sCode = "DN-" + dateEdit1.DateTime.Year.ToString() + sCode;
                    }


                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
                    declare @p5 int
                    set @p5=aaaaaa
                    declare @p6 int
                    set @p6=bbbbbb
                    exec sp_GetId N'00',N'dddddd',N'DISPATCH',1,@p5 output,@p6 output,default
                    select @p5, @p6
                    ";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("dddddd", sAccID);
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]);
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                    sSQL = "select * from Warehouse ";
                    DataTable dtWh = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = "select * from Inventory where isnull(bSale ,0) = 1";
                    DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                    Model.DispatchList mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.DispatchList();

                    mod.cSOCode = txtSONO.Text.Trim();
                    if (mod.cSOCode == "")
                    {
                        if (DialogResult.Yes != MessageBox.Show("The sales order number is blank and whether to continue", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                        {
                            throw new Exception("User cancelled");
                        }
                    }

                    if (mod.cSOCode != "")
                    {

                        sSQL = @"
select cSOCode from so_somain where cSOCode = 'aaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaa", mod.cSOCode);
                        DataTable dtSO = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtSO == null || dtSO.Rows.Count == 0)
                        {
                            txtSONO.Focus();
                            throw new Exception("The sales order number is incorrect");
                        }
                    }


                    if (iType == 1)
                    {
                        mod.DLID = lID;
                    }
                    else
                    {
                        sSQL = "select * from DispatchList where cDLCode = '" + sCode + "'";
                        DataTable dtD = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        mod.DLID = BaseFunction.ReturnLong(dtD.Rows[0]["DLID"]);

                        if (dtD.Rows[0]["cVerifier"].ToString().Trim() != "")
                        {
                            throw new Exception("be audit err");
                        }
                    }

                    mod.cDLCode = sCode;
                    mod.cVouchType = "05";
                    mod.cSTCode = "10";
                    mod.dDate = dateEdit1.DateTime;
                    mod.bneedbill = true;

                    if (lookUpEditDepCode.EditValue == null || lookUpEditDepCode.EditValue.ToString().Trim() == "")
                    {
                        sErr = sErr + "Please set department\n";
                        lookUpEditDepCode.Focus();
                    }
                    mod.cDepCode = lookUpEditDepCode.EditValue.ToString();
                    if (lookUpEditcPersonCode.EditValue == null || lookUpEditcPersonCode.EditValue.ToString().Trim() == "")
                    {
                        sErr = sErr + "Please set salesman\n";
                        lookUpEditcPersonCode.Focus();
                    }
                    mod.cPersonCode = lookUpEditcPersonCode.EditValue.ToString();
                    mod.SBVID = 0;
                    mod.cCusCode = lookUpEditcCusCode.EditValue.ToString();

                    sSQL = "select * from Customer where cCuscode = '" + mod.cCusCode + "'";
                    DataTable dtCus = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    string scexchname = dtCus.Rows[0]["cCusExch_name"].ToString().Trim();
                    if (scexchname == "")
                    {
                        mod.cexch_name = "THB";
                    }
                    else
                    {
                        mod.cexch_name = scexchname;
                    }

                    //select * from exch 
                    mod.iExchRate = 1;
                    mod.iTaxRate = 0;
                    mod.bFirst = false;
                    mod.bReturnFlag = false;
                    mod.bSettleAll = false;
                    mod.cMemo = "";

                    string sBusType = lookUpEditcBusType.EditValue.ToString().Trim();
                    if (sBusType == "Receiving by stages")
                    {
                        sBusType = "分期收款";
                    }
                    if (sBusType == "General sales")
                    {
                        sBusType = "普通销售";
                    }
                    mod.cBusType = sBusType;

                    mod.cCusName = dtCus.Rows[0]["cCusName"].ToString().Trim();
                    if (txtProName.Text.Trim() == "")
                    {
                        sErr = sErr + "Please set project name\n";
                        txtProName.Focus();
                    }
                    //mod.cDefine1 = txtWeekNo.Text.Trim();
                    //mod.cDefine8 = txtLotNo.Text.Trim();
                    mod.cDefine10 = txtProName.Text.Trim();
                    mod.cDefine11 = txtContact.Text.Trim();
                    mod.cDefine4 = dateEdit1.DateTime;
                    mod.cDefine2 = timeEdit1.Time.ToString("HH:mm:ss");
                    mod.cDefine3 = txtSite.Text;
                    mod.iVTid = 131308;
                    mod.cMaker = sUserName;
                    mod.cDefine15 = 1;  //标识有开发工具产生
                    mod.cMemo = txtMemo.Text;
                    //if(txtWeekNo.Text.Trim() == "")
                    //{
                    //    txtWeekNo.Focus();
                    //    throw new Exception("Please set work no");
                    //}
                    if (txtWeekNo.Text.Trim() != "")
                    {
                        mod.cDefine5 = BaseFunction.ReturnLong(txtWeekNo.Text.Trim());
                    }
                    mod.cDefine12 = txtLotNo.Text.Trim();
                    

                    DAL.DispatchList dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.DispatchList();
                    if (iType == 1)
                    {
                        sSQL = dal.Add(mod);
                    }
                    if (iType == 2)
                    {
                        sSQL = dal.Update(mod);
                    }
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (lookUpEditcWhCode.EditValue == null || lookUpEditcWhCode.EditValue.ToString().Trim() == "")
                    {
                        sErr = sErr + "Please set warehouse\n";
                        lookUpEditcWhCode.Focus();
                    }

                    //修改时先修改现存量回去，然后当做新单据改变现存量
                    if (iType == 2)
                    {
                        for (int i = 0; i < GridView1.RowCount; i++)
                        {
                            string sInvCode = GridView1.GetRowCellValue(i, gridColcInvCode).ToString();
                            if (sInvCode == "")
                                continue;

                            sSQL = @"

if exists(select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode') 
	update  CurrentStock set fOutQuantity = isnull(fOutQuantity,0) + @dQty  where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' 
else 
	begin 
		declare @itemid varchar(20); 
		declare @iCount int;  
		select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
		if( @iCount > 0 ) 
			select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
		else  
			select @itemid=max(itemid+1) from CurrentStock  
		
		insert into CurrentStock(cWhCode,cInvCode,fOutQuantity,itemid)values('@cWhCode','@cInvCode', @dQty ,@itemid) 
	end
";
                            sSQL = sSQL.Replace("@cInvCode", sInvCode);
                            sSQL = sSQL.Replace("@cWhCode", lookUpEditcWhCode.EditValue.ToString());
                            sSQL = sSQL.Replace("@dQty", GridView1.GetRowCellValue(i, gridColQty).ToString());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    sSQL = @"
delete DispatchLists where DLID in (select DLID FROM DispatchList where cDLCode = 'aaaaaa' )
";
                    sSQL = sSQL.Replace("aaaaaa", mod.cDLCode);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    int iRow = 0;

                    ArrayList arrSiteID = new ArrayList();


                    for (int j = 0; j < GridView1.Columns.Count; j++)
                    {
                        for (int i = 0; i < GridView1.RowCount; i++)
                        {
                            if (GridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() == "")
                            {
                                continue;
                            }
                            if (!GridView1.Columns[j].Name.StartsWith("gridColQty_SiteNo_"))
                                continue;

                            Model.DispatchLists mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.DispatchLists();
                            lIDDetails += 1;
                            mods.AutoID = lIDDetails;
                            mods.DLID = mod.DLID;
                            mods.cWhCode = lookUpEditcWhCode.EditValue.ToString();
                            string sInvCode = GridView1.GetRowCellDisplayText(i, gridColcInvCode).ToString().Trim();
                            if (sInvCode == "")
                            {
                                sErr = sErr + "Row " + (i + 1).ToString() + " Cus Inv No is not exitst\n";
                                continue;
                            }
                            mods.cInvCode = sInvCode;
                            mods.cInvName = GridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                            mods.iQuantity = BaseFunction.ReturnDecimal(GridView1.GetRowCellValue(i, GridView1.Columns[j]));
                            if (mods.iQuantity <= 0)
                            {
                                continue;
                            }
                            mods.iQuotedPrice = 0;
                            mods.iUnitPrice = BaseFunction.ReturnDecimal(GridView1.GetRowCellValue(i, gridColPrice));
                            mods.iTaxUnitPrice = BaseFunction.ReturnDecimal(BaseFunction.ReturnDecimal(GridView1.GetRowCellValue(i, gridColPrice)) * (1 + mod.iTaxRate / 100), 6);
                            mods.iMoney = BaseFunction.ReturnDecimal(mods.iUnitPrice * mods.iQuantity, 2);
                            mods.iSum = BaseFunction.ReturnDecimal(mods.iTaxUnitPrice * mods.iQuantity, 2);
                            mods.iTax = mods.iSum - mods.iMoney;
                            mods.iDisCount = 0;
                            mods.iNatUnitPrice = BaseFunction.ReturnDecimal(mods.iUnitPrice * mod.iExchRate);
                            mods.iNatMoney = BaseFunction.ReturnDecimal(mods.iNatUnitPrice * mods.iQuantity, 2);
                            mods.iNatSum = BaseFunction.ReturnDecimal(mods.iNatMoney * (1 + mod.iTaxRate / 100), 2);
                            mods.iNatTax = mods.iNatSum - mods.iNatMoney;
                            mods.bSettleAll = false;
                            mods.iDLsID = lIDDetails;
                            //mods.cCusInvCode = GridView1.GetRowCellValue(i, gridColcInvAddCode).ToString().Trim();
                            //if (mods.cCusInvCode == "")
                            //{
                            //    sWarn = sWarn + "Row " + (i + 1).ToString() + " " + mods.cInvCode + " ProductCode is not exitst\n";
                            //}
                            mods.bcosting = true;
                            iRow += 1;
                            mods.irowno = iRow;

                            string sSiteNo = GridView1.Columns[j].Name.Replace("gridColQty_SiteNo_", "");
                            mods.cDefine22 = GridView1.Bands["gridBand_SiteNo_1" + sSiteNo].Caption;
                            mods.cDefine23 = GridView1.Bands["gridBand_SiteNo_1" + sSiteNo].Children[0].Caption;
                            mods.cDefine24 = GridView1.Bands["gridBand_SiteNo_1" + sSiteNo].Children[0].Children[0].Caption;
                            mods.cDefine25 = GridView1.Bands["gridBand_SiteNo_1" + sSiteNo].Children[0].Children[0].Children[0].Children[0].Caption;
                            mods.cDefine28 = GridView1.Bands["gridBand_SiteNo_1" + sSiteNo].Children[0].Children[0].Children[0].Caption; 
                            mods.cDefine29 = GridView1.GetRowCellValue(i, gridColItem).ToString().Trim();
                            mods.cDefine34 = j;


                            sSQL = @"
select SUM(isnull(iQuantity,0) - isnull(fOutQuantity,0)) as iQty from CurrentStock where cInvCode = 'AAAAAAAA' and cWhCode = 'BBBBBBBB'
";
                            sSQL = sSQL.Replace("AAAAAAAA", mods.cInvCode);
                            sSQL = sSQL.Replace("BBBBBBBB", mods.cWhCode);
                            DataTable dtQtyUse = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtQtyUse == null || dtQtyUse.Rows.Count == 0)
                            {
                                sWarn = sWarn + "Item No " + mods.cInvCode + " is not enough \n";
                            }
                            decimal dQtyUse = BaseFunction.ReturnDecimal(dtQtyUse.Rows[0]["iQty"]);
                            if (dQtyUse < mods.iQuantity)
                            {
                                sWarn = sWarn + "Item No " + mods.cInvCode + " is not enough \n";
                            }

                            DAL.DispatchLists dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.DispatchLists();
                            sSQL = dals.Add(mods);
                            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = @"

if exists(select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode') 
	update  CurrentStock set fOutQuantity = isnull(fOutQuantity,0) + @dQty  where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' 
else 
	begin 
		declare @itemid varchar(20); 
		declare @iCount int;  
		select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
		if( @iCount > 0 ) 
			select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
		else  
			select @itemid=max(itemid+1) from CurrentStock  
		
		insert into CurrentStock(cWhCode,cInvCode,fOutQuantity,itemid)values('@cWhCode','@cInvCode', @dQty ,@itemid) 
	end
";
                            sSQL = sSQL.Replace("@cInvCode", mods.cInvCode);
                            sSQL = sSQL.Replace("@cWhCode", mods.cWhCode);
                            sSQL = sSQL.Replace("@dQty", mods.iQuantity.ToString());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            //当销售订单存在时回写销售订单累计发货数量
                            if (mod.cSOCode != "")
                            {
                                sSQL = @"
select a.cSOCode ,b.cInvCode,b.AutoID 
from so_somain a inner join SO_SODetails b on a.ID = b.ID
where a.cSOCode = 'aaaaaa' and b.cInvCode = 'bbbbbb'
";
                                sSQL = sSQL.Replace("aaaaaa", mod.cSOCode);
                                sSQL = sSQL.Replace("bbbbbb", mods.cInvCode);
                                DataTable dtSOs = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtSOs == null || dtSOs.Rows.Count == 0)
                                {
                                    sErr = sErr + "Row " + (i + 1).ToString() + " sales orders do not have a specified product\n";
                                    continue;
                                }

                                long lSOsID = BaseFunction.ReturnLong(dtSOs.Rows[0]["AutoID"]);
                                sSQL = @"
update SO_SODetails set iFHQuantity = isnull(iFHQuantity,0) + aaaaaa
where autoid = bbbbbb 
";
                                sSQL = sSQL.Replace("aaaaaa", mods.iQuantity.ToString());
                                sSQL = sSQL.Replace("bbbbbb", lSOsID.ToString());
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

                        }
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (sWarn != "")
                    {
                        FrmMsgBox frm = new FrmMsgBox();
                        frm.richTextBox1.Text = sWarn;
                        DialogResult d = frm.ShowDialog();
                        if (d != DialogResult.OK)
                        {
                            tran.Rollback();
                            return;
                        }
                    }

                    if (lID > 1000000000)
                    {
                        lID = lID - 1000000000;
                    }
                    if (lIDDetails > 1000000000)
                    {
                        lIDDetails = lIDDetails - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'DISPATCH'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iType == 1)
                    {
                        //sSQL = "update VoucherHistory set cNumber = aaaaaa where CardNumber = '01' and cSeed = '" + dateEdit1.DateTime.Year.ToString() + "'";
                        sSQL = @"
if exists(select * from VoucherHistory with (ROWLOCK) where CardNumber = '01' and cSeed = 'bbbbbb')
	update VoucherHistory set cNumber = aaaaaa where CardNumber = '01' and cSeed = 'bbbbbb'
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('01','日期','年','bbbbbb',aaaaaa,0)
";

                        sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
                        sSQL = sSQL.Replace("bbbbbb", mod.dDate.Year.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        txtCode.Text = sCode;
                        sDLCode = sCode;
                        MessageBox.Show("OK\n" + mod.cDLCode);
                        SetEnable(false);
                        SetBtnEnable(false);

                        iType = 2;
                        txtStatus.Text = "Saved";
                    }
                    else
                    {
                        throw new Exception("Save failed");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }



                if (txtStatus.Text.ToLower() == "audit")
                {
                    chkAll.Enabled = true;
                    chkAll.Checked = true;
                }
                else
                {
                    chkAll.Enabled = false;
                    chkAll.Checked = false;
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msgbox = new FrmMsgBox();
                msgbox.richTextBox1.Text = ee.Message;
                msgbox.ShowDialog();
            }
        }

        private void btnAddCol_Click(object sender, EventArgs e)
        {
            try
            {
                string sSiteNo = txtSiteNo.Text.Trim();
                if (sSiteNo == "")
                {
                    txtSiteNo.Focus();
                    throw new Exception("Please set No.Site list");
                }
                //if (txtType.Text.Trim() == "")
                //{
                //    txtType.Focus();
                //    throw new Exception("Please set Type");
                //}
                if (txtSiteID.Text.Trim() == "")
                {
                    txtSiteID.Focus();
                    throw new Exception("Please set Site ID");
                }
                if (txtASP.Text.Trim() == "")
                {
                    txtASP.Focus();
                    throw new Exception("Please set Region");
                }
                if (txtRegion.Text.Trim() == "")
                {
                    txtRegion.Focus();
                    throw new Exception("Please set ASP");
                }


                for (int i = 0; i < GridView1.Bands.Count; i++)
                {
                    string sBandName = "gridBand_SiteNo_1" + sSiteNo;
                    if (GridView1.Bands[i].Name == sBandName)
                    {
                        throw new Exception("Site No is exists");
                    }
                }

                // 
                // gridColQty101
                // 
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColQty101;
                gridColQty101 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                gridColQty101.AppearanceHeader.Options.UseTextOptions = true;
                gridColQty101.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridColQty101.Caption = "Qty";
                gridColQty101.FieldName = "Qty_SiteNo_" + sSiteNo;
                gridColQty101.Name = "gridColQty_SiteNo_" + sSiteNo;
                gridColQty101.OptionsColumn.AllowEdit = true;
                gridColQty101.Visible = true;
                gridColQty101.Width = 80;
                gridColQty101.DisplayFormat.FormatString = "n2";
                gridColQty101.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //gridColQty101.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
                gridColQty101.ColumnEdit = this.ItemTextEditN2;
                gridColQty101.AppearanceCell.ForeColor = cUnChoose;

                if (gridControl1.DataSource != null)
                {
                    for (int i = 0; i < ((DataTable)gridControl1.DataSource).Columns.Count; i++)
                    {
                        if (((DataTable)gridControl1.DataSource).Columns[i].ColumnName == gridColQty101.FieldName)
                        {
                            ((DataTable)gridControl1.DataSource).Columns.RemoveAt(i);
                            break;
                        }
                    }
                }

                DataColumn dc = new DataColumn();
                dc.ColumnName = gridColQty101.FieldName;
                ((DataTable)gridControl1.DataSource).Columns.Add(dc);

                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand101;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand102;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand103;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand104;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand105;

                gridBand101 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand102 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand103 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand104 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand105 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();

                // 
                // gridBand101
                // 

                gridBand101.AppearanceHeader.Options.UseTextOptions = true;
                gridBand101.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand101.Caption = sSiteNo;
                gridBand101.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand102 });
                gridBand101.Name = "gridBand_SiteNo_1" + sSiteNo;
                gridBand101.Width = 80;
                gridBand101.AppearanceHeader.ForeColor = cUnChoose;

                GridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand101 });
                // 
                // gridBand102
                // 

                string sType = txtType.Text.Trim();
                gridBand102.AppearanceHeader.Options.UseTextOptions = true;
                gridBand102.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand102.Caption = sType;
                gridBand102.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand103 });
                gridBand102.Name = "gridBand_SiteNo_2" + sSiteNo;
                gridBand102.Width = 80;
                gridBand102.AppearanceHeader.ForeColor = cUnChoose;
                // 
                // gridBand103
                // 

                string sSiteID = txtSiteID.Text.Trim();
                gridBand103.AppearanceHeader.Options.UseTextOptions = true;
                gridBand103.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand103.Caption = sSiteID;
                gridBand103.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gridBand104});
                gridBand103.Name = "gridBand_SiteNo_3" + sSiteNo;
                gridBand103.Width = 80;
                gridBand103.AppearanceHeader.ForeColor = cUnChoose;
                // 
                // gridBand104
                // 

                string sASP = txtRegion.Text.Trim();
                gridBand104.AppearanceHeader.Options.UseTextOptions = true;
                gridBand104.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand104.Caption = sASP;
                gridBand104.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gridBand105});
                gridBand104.Name = "gridBand_SiteNo_4" + sSiteNo;
                gridBand104.Width = 80;
                gridBand104.AppearanceHeader.ForeColor = cUnChoose;
                // 
                // gridBand105
                // 
                string sRegion = txtASP.Text.Trim();
                gridBand105.AppearanceHeader.Options.UseTextOptions = true;
                gridBand105.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand105.Caption = sRegion;
                gridBand105.Columns.Add(gridColQty101);
                gridBand105.Name = "gridBand_SiteNo_5" + sSiteNo;
                gridBand105.Width = 80;
                gridBand105.AppearanceHeader.ForeColor = cUnChoose;

                txtSiteNo.Text = "";
                txtType.Text = "";
                txtSiteID.Text = "";
                txtASP.Text = "";
                txtRegion.Text = "";
                txtSiteNo.Focus();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnDelCol_Click(object sender, EventArgs e)
        {
            string sSiteNo = txtSiteNo.Text.Trim();
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                string sColName = GridView1.Columns[i].Name.ToLower();
                if (sColName == ("gridColQty_SiteNo_" + sSiteNo).ToLower())
                {
                    GridView1.Columns.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name.ToLower();
                if (sColName == ("gridBand_SiteNo_5" + sSiteNo).ToLower())
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name.ToLower();
                if (sColName == ("gridBand_SiteNo_4" + sSiteNo).ToLower())
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name.ToLower();
                if (sColName == ("gridBand_SiteNo_3" + sSiteNo).ToLower())
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name.ToLower();
                if (sColName == ("gridBand_SiteNo_2" + sSiteNo).ToLower())
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name.ToLower();
                if (sColName == ("gridBand_SiteNo_1" + sSiteNo).ToLower())
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
        }

        private void GridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void lookUpEditDepCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditDepName.EditValue = lookUpEditDepCode.EditValue;
        }

        private void lookUpEditDepName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditDepCode.EditValue = lookUpEditDepName.EditValue;
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;

            try
            {
                string sCusCode = lookUpEditcCusCode.EditValue.ToString();
                string sSQL = @"
select inv.cInvCode,inv.cInvName,inv.cInvStd,inv.cComUnitCode,cUnit.cComUnitName ,inv.cInvAddCode
from Inventory inv inner join ComputationUnit cUnit on inv.cComUnitCode = cUnit.cComUnitCode
where isnull(bSale ,0) = 1
order by inv.cInvCode
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                ItemLookUpEditcInvName.DataSource = dt;
            }
            catch { }
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
        }

        private void lookUpEditcWhCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcWhName.EditValue = lookUpEditcWhCode.EditValue;
        }

        private void lookUpEditcWhName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcWhCode.EditValue = lookUpEditcWhName.EditValue;
        }

        private void SetEnable(bool b)
        {
            txtSiteNo.Enabled = b;
            txtCode.Enabled = false;
            lookUpEditDepCode.Enabled = b;
            lookUpEditDepName.Enabled = b;
            txtSite.Enabled = b;
            lookUpEditcCusCode.Enabled = b;
            lookUpEditcCusName.Enabled = b;
            txtProName.Enabled = b;
            txtType.Enabled = b;
            txtContact.Enabled = b;
            lookUpEditcPersonCode.Enabled = b;
            lookUpEditcPersonName.Enabled = b;
            txtSiteID.Enabled = b;
            dateEdit1.Enabled = b;
            timeEdit1.Enabled = b;
            txtASP.Enabled = b;
            txtSite.Enabled = b;
            lookUpEditcWhCode.Enabled = b;
            lookUpEditcWhName.Enabled = b;
            txtRegion.Enabled = b;
            txtWeekNo.Enabled = b;
            txtMemo.Enabled = b;
            txtLotNo.Enabled = b;
            btnAddCol.Enabled = b;
            btnDelCol.Enabled = b;

            lookUpEditcBusType.Enabled = b;
            txtSONO.Enabled = b;


            GridView1.OptionsBehavior.Editable = b;
        }

        private void SetTxtNull()
        {
            txtSiteNo.Text = "";
            txtCode.Text = "";
            lookUpEditDepCode.EditValue = "0302";
            lookUpEditDepName.EditValue = "0302";
            txtSite.Text = "";
            lookUpEditcCusCode.EditValue = "01010002";
            lookUpEditcCusName.EditValue = "01010002";
            txtProName.Text = "";
            txtType.Text = "";
            txtContact.Text = "";
            lookUpEditcPersonCode.EditValue = DBNull.Value;
            lookUpEditcPersonName.EditValue = DBNull.Value;
            txtSiteID.Text = "";
            dateEdit1.DateTime = dLogDate;
            timeEdit1.Text = "";
            txtASP.Text = "";
            txtSite.Text = "";
            txtWeekNo.Text = "";
            txtMemo.Text = "";
            txtLotNo.Text = "";
            lookUpEditcWhCode.EditValue = null;
            lookUpEditcWhName.EditValue = null;
            txtRegion.Text = "";
        }

        string sFocCol;
        int iFocRow;
        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColcInvAddCode)
                {
                    string sInvAddCode = GridView1.GetRowCellValue(e.RowHandle, gridColcInvAddCode).ToString().Trim();
                    DataRow[] dr = ((DataTable)ItemLookUpEditcInvName.DataSource).Select("cInvAddCode = '" + sInvAddCode + "'");
                    if (dr.Length == 0 && sInvAddCode.Trim() != "")
                    {
                        MessageBox.Show("Row " + (e.RowHandle + 1) + " item no is not exists");
                        return;
                    }

                    GridView1.SetRowCellValue(e.RowHandle, gridColcInvCode, dr[0]["cInvAddCode"].ToString().Trim());

                    string s = dr[0]["cComUnitCode"].ToString().Trim();
                    if (s != GridView1.GetRowCellValue(e.RowHandle, gridColUnit).ToString().Trim())
                    {
                        GridView1.SetRowCellValue(e.RowHandle, gridColUnit, s);
                    }

                    //s = dr[0]["cInvAddCode"].ToString().Trim();
                    //if (s != GridView1.GetRowCellValue(e.RowHandle, gridColcInvAddCode).ToString().Trim())
                    //{
                    //    GridView1.SetRowCellValue(e.RowHandle, gridColcInvAddCode, dr[0]["cInvAddCode"]);
                    //}

                    if (lookUpEditcCusCode.EditValue != null)
                    {
                        string sSQL = @"
select iPrice,denddate ,dstartdate ,cexch_name ,cCusCode,cInvCode
from PriceJustify 
where cCusCode = 'aaaaaa' and cInvCode = 'bbbbbb'
	and isnull(denddate,'2099-12-31') > GETDATE()
order by dstartdate desc
                    ";
                        sSQL = sSQL.Replace("aaaaaa", lookUpEditcCusCode.EditValue.ToString());
                        sSQL = sSQL.Replace("bbbbbb", sInvAddCode);
                        DataTable dtPrice = DbHelperSQL.Query(sSQL);
                        if (dtPrice != null && dtPrice.Rows.Count > 0)
                        {
                            decimal dPrice = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iPrice"], 3);
                            GridView1.SetRowCellValue(e.RowHandle, gridColPrice, dPrice);
                        }
                    }
                }

                if (e.Column.Name.StartsWith("gridColQty_SiteNo_"))
                {
                    decimal dSite = BaseFunction.ReturnDecimal(GridView1.GetRowCellValue(e.RowHandle, e.Column), 2);
                    if (dSite <= 0 && GridView1.GetRowCellValue(e.RowHandle, e.Column).ToString().Trim() != "")
                    {
                        GridView1.SetRowCellValue(e.RowHandle, e.Column, DBNull.Value);
                    }

                    decimal dQty = 0;


                    for (int i = 0; i < GridView1.Columns.Count; i++)
                    {
                        if (GridView1.Columns[i].Name.StartsWith("gridColQty_SiteNo_"))
                        {
                            dQty = dQty + BaseFunction.ReturnDecimal(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns[i]));
                        }
                    }
                    GridView1.SetRowCellValue(e.RowHandle, gridColQty, dQty);

                    decimal dPrice = BaseFunction.ReturnDecimal(GridView1.GetRowCellValue(e.RowHandle, gridColPrice));
                    GridView1.SetRowCellValue(e.RowHandle, gridColAmount, BaseFunction.ReturnDecimal(dPrice * dQty));
                }
            }
            catch (Exception ee)
            {

            }
        }

        private string GetString()
        {
            string s = "";
            IDataObject iData = Clipboard.GetDataObject();
            // 将数据与指定的格式进行匹配，返回bool
            if (iData.GetDataPresent(DataFormats.Text))
            {
                // GetData检索数据并指定一个格式
                s = (string)iData.GetData(DataFormats.Text);
            }

            return s;
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.DeleteRow(GridView1.FocusedRowHandle);
            }
            catch { }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.AddNewRow();
            }
            catch { }
        }

        private void txtSiteNo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers.CompareTo(Keys.ControlKey) == 0 && e.KeyCode == Keys.V)
                {

                }
            }
            catch { }
        }

        private void lookUpEditcPersonCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcPersonName.EditValue = lookUpEditcPersonCode.EditValue;
        }

        private void lookUpEditcPersonName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcPersonCode.EditValue = lookUpEditcPersonName.EditValue;
        }

        private void SetBtnEnable(bool b)
        {
            btnAddCol.Enabled = b;
            btnDelCol.Enabled = b;

            btnAddRow.Enabled = b;
            btnDelRow.Enabled = b;

            btnCheck.Enabled = true;

            btnCopy.Enabled = !b;

            btnEdit.Enabled = !b;

            btnSave.Enabled = b;

            btnDel.Enabled = !b;

            btnAudit.Enabled = !b;
            btnUnAudit.Enabled = !b;

            btnCreateoutbound.Enabled = !b;

            btnPrint.Enabled = true;
            btnExport.Enabled = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Continue ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    GridView1.FocusedRowHandle -= 1;
                    GridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCount = 0;

                if (iType == 1 && txtCode.Text.Trim() != "")
                {
                    throw new Exception("Be saved");
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sCode = txtCode.Text.Trim();
                    if (sCode == "")
                    {
                        throw new Exception("Please choose data");
                    }

                    string sSQL = @"
select * from DispatchList where cDLCode = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception(sCode + " is not exists");
                    }

                    if (BaseFunction.ReturnInt(dt.Rows[0]["cDefine15"]) != 1)
                    {
                        throw new Exception(sCode + " is err");
                    }
                    if (dt.Rows[0]["cVerifier"].ToString().Trim() != "")
                    {
                        throw new Exception(sCode + " is audit");
                    }

                    sSQL = @"
delete DispatchLists where DLID in (select DLID from DispatchList where cDLCode = 'aaaaaa')          
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    sSQL = @"
delete DispatchList where cDLCode = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("Delete OK");

                        this.Close();
                    }
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

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    GridView1.FocusedRowHandle -= 1;
                    GridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCount = 0;

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sCode = txtCode.Text.Trim();
                    if (sCode == "")
                    {
                        throw new Exception("Please choose data");
                    }

                    string sSQL = @"
select * from DispatchList where cDLCode = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception(sCode + " is not exists");
                    }

                    if (BaseFunction.ReturnInt(dt.Rows[0]["cDefine15"]) != 1)
                    {
                        throw new Exception(sCode + " is err");
                    }
                    if (dt.Rows[0]["cVerifier"].ToString().Trim() != "")
                    {
                        throw new Exception(sCode + " is audit");
                    }

                    sSQL = @"
update DispatchList set cVerifier = 'cccccc',dVerifydate = 'bbbbbb',dverifysystime = getdate() where cDLCode = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("cccccc", sUserName);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("Audit OK");

                        iType = 4;

                        chkAll.Checked = true;
                        chkAll.Enabled = true;
                        SetBtnEnable(false);
                        txtStatus.Text = "Audit";
                    }
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

        private string CreateRd32(SqlTransaction tran, string sCode, string sUserName, DateTime dLotDate,out string sWarn)
        {
            int iCou = 0;
            sWarn = "";
            string sReturn = "";
            try
            {
                ArrayList aListGreen = new ArrayList();
                for (int i = 0; i < GridView1.Bands.Count; i++)
                {
                    if (!GridView1.Bands[i].Name.StartsWith("gridBand_SiteNo_1"))
                    {
                        continue;
                    }

                    if (GridView1.Bands[i].AppearanceHeader.ForeColor == cChoose)
                    {
                        string s = GridView1.Bands[i].Name.Replace("gridBand_SiteNo_1", "");
                        aListGreen.Add(s);
                    }
                }

                if (aListGreen.Count == 0)
                {
                    throw new Exception("Please choose data");
                }

                string sErr = "";

                string sSQL = @"
select * 
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
where a.cDLCode = 'aaaaaa'
order by AutoID
";
                sSQL = sSQL.Replace("aaaaaa", sCode);
                DataTable dtDispatchList = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtDispatchList == null || dtDispatchList.Rows.Count == 0)
                {
                    throw new Exception(sCode + " is not exists");
                }


                sSQL = "select isnull(bflag_ST,0) as bflag from GL_mend where iYPeriod = '" + dateEdit1.DateTime.ToString("yyyyMM") + "'";
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("Access module state failure");
                }
                int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                if (i结账 > 0)
                {
                    throw new Exception(dateEdit1.DateTime.ToString("yyyy-MM") + " have checked out");
                }

                long lCode = 0;

                //获得单据号
                sSQL = "select max(cNumber) as cNumber from VoucherHistory with (ROWLOCK) where CardNumber = '0303' and cSeed = '" + dateEdit1.DateTime.Year.ToString() + "'";
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                }
                else
                {
                    lCode = 0;
                }

                lCode += 1;
                string sRDCode = lCode.ToString();
                while (sRDCode.Length < 5)
                {
                    sRDCode = "0" + sRDCode;
                }
                sRDCode = "SU-" + dateEdit1.DateTime.Year.ToString() + sRDCode;

                long lID = -1;
                long lIDDetails = -1;
                sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',1,@p5 output,@p6 output,default
select @p5, @p6
                    ";
                sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                sSQL = sSQL.Replace("dddddd", sAccID);
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                lID = BaseFunction.ReturnLong(dt.Rows[0][0]);
                lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception(sCode + " is not exists");
                }

                Model.rdrecord32 mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecord32();
                mod.ID = lID;
                mod.bRdFlag = 0;
                mod.cVouchType = "32";
                mod.cBusType = "分期收款";
                mod.cSource = "发货单";
                mod.cBusCode = sCode;
                mod.cWhCode = dtDispatchList.Rows[0]["cWhCode"].ToString();
                mod.dDate = BaseFunction.ReturnDate(dtDispatchList.Rows[0]["dverifydate"]);
                mod.cCode = sRDCode;
                mod.cDepCode = dtDispatchList.Rows[0]["cDepCode"].ToString();
                mod.cPersonCode = dtDispatchList.Rows[0]["cPersonCode"].ToString();
                mod.cSTCode = "10";
                mod.cRdCode = "201";
                mod.cCusCode = dtDispatchList.Rows[0]["cCusCode"].ToString();
                mod.cDLCode = BaseFunction.ReturnLong(dtDispatchList.Rows[0]["DLID"]);
                mod.bTransFlag = false;
                mod.cMaker = sUserName;
                mod.cDefine1 = dtDispatchList.Rows[0]["cDefine1"].ToString();
                mod.cDefine2 = dtDispatchList.Rows[0]["cDefine2"].ToString();
                mod.cDefine3 = dtDispatchList.Rows[0]["cDefine3"].ToString();
                mod.cDefine4 = BaseFunction.ReturnDate(dtDispatchList.Rows[0]["cDefine4"]);
                mod.cDefine5 = BaseFunction.ReturnInt(dtDispatchList.Rows[0]["cDefine5"]);
                mod.cDefine6 = BaseFunction.ReturnDate(dtDispatchList.Rows[0]["cDefine6"]);
                mod.cDefine7 = BaseFunction.ReturnDecimal(dtDispatchList.Rows[0]["cDefine7"]);
                mod.cDefine8 = dtDispatchList.Rows[0]["cDefine8"].ToString();
                mod.cDefine9 = dtDispatchList.Rows[0]["cDefine9"].ToString();
                mod.cDefine10 = dtDispatchList.Rows[0]["cDefine10"].ToString();
                mod.bpufirst = false;
                mod.biafirst = false;
                mod.VT_ID = 87;
                mod.bIsSTQc = false;
                mod.cDefine11 = dtDispatchList.Rows[0]["cDefine11"].ToString();
                mod.cDefine12 = dtDispatchList.Rows[0]["cDefine12"].ToString();
                mod.cDefine13 = dtDispatchList.Rows[0]["cDefine13"].ToString();
                mod.cDefine14 = dtDispatchList.Rows[0]["cDefine14"].ToString();
                mod.cDefine15 = BaseFunction.ReturnInt(dtDispatchList.Rows[0]["cDefine15"]);
                mod.cDefine16 = BaseFunction.ReturnDecimal(dtDispatchList.Rows[0]["cDefine16"]);
                mod.bFromPreYear = false;
                mod.bIsComplement = 0;
                mod.iDiscountTaxType = 0;
                mod.ireturncount = 0;
                mod.iverifystate = 0;
                mod.iswfcontrolled = 0;
                mod.dnmaketime = DateTime.Now;
                mod.bredvouch = 0;
                mod.iPrintCount = 0;
                mod.cinvoicecompany = mod.cCusCode;

                DAL.rdrecord32 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecord32();
                sSQL = dal.Add(mod);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                for (int i = 0; i < dtDispatchList.Rows.Count; i++)
                {
                    bool bCreate = false;
                    for (int j = 0; j < aListGreen.Count; j++)
                    {
                        if (dtDispatchList.Rows[i]["cDefine22"].ToString().Trim().ToLower() == aListGreen[j].ToString().ToLower())
                        {
                            bCreate = true;
                            break;
                        }
                    }

                    if (!bCreate)
                        continue;

                    decimal dOutSum = BaseFunction.ReturnDecimal(dtDispatchList.Rows[i]["fOutQuantity"]);
                    if (dOutSum > 0)
                    {
                        sErr = sErr + "Item No " + dtDispatchList.Rows[i]["cInvCode"].ToString() + " No.Site list " + dtDispatchList.Rows[i]["cDefine10"].ToString() + " is used\n";
                        continue;
                    }

                    Model.rdrecords32 mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords32();
                    lIDDetails += 1;
                    mods.AutoID = lIDDetails;
                    mods.ID = mod.ID;
                    mods.cInvCode = dtDispatchList.Rows[i]["cInvCode"].ToString().Trim();
                    mods.iQuantity = BaseFunction.ReturnDecimal(dtDispatchList.Rows[i]["iQuantity"]);
                    mods.iNum = BaseFunction.ReturnDecimal(dtDispatchList.Rows[i]["iNum"]);

                    sSQL = "select sum(iQuantity) as iQty from CurrentStock where cWhCode = 'aaaaaa' and cInvCode = 'bbbbbb'";
                    sSQL = sSQL.Replace("aaaaaa", mod.cWhCode);
                    sSQL = sSQL.Replace("bbbbbb", mods.cInvCode);
                    DataTable dtCurr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCurr == null || dtCurr.Rows.Count == 0)
                    {
                        sErr = sErr + "Item No " + dtDispatchList.Rows[i]["cInvCode"].ToString() + " not enough\n";
                        continue;
                    }
                    decimal dCurr = BaseFunction.ReturnDecimal(dtCurr.Rows[0]["iQty"]);
                    if (dCurr < mods.iQuantity)
                    {
                        sErr = sErr + "Item No  " + dtDispatchList.Rows[i]["cInvCode"].ToString() + " not enough\n";
                        continue;
                    }
                    mods.iUnitCost = BaseFunction.ReturnDecimal(dtDispatchList.Rows[i]["iUnitPrice"]);
                    mods.iPrice = BaseFunction.ReturnDecimal(dtDispatchList.Rows[i]["iMoney"]);
                    mods.iFlag = 0;
                    mods.iDLsID = BaseFunction.ReturnLong(dtDispatchList.Rows[i]["iDLsID"]);
                    mods.iNQuantity = mods.iQuantity;
                    mods.iNNum = mods.iNum;
                    mods.bLPUseFree = false;
                    mods.iRSRowNO = 0;
                    mods.iOriTrackID = 0;
                    mods.bCosting = true;
                    mods.bVMIUsed = false;
                    mods.cbdlcode = sCode;
                    mods.iExpiratDateCalcu = 0;
                    mods.ccusinvcode = dtDispatchList.Rows[i]["ccusinvcode"].ToString().Trim();
                    mods.iordertype = 0;
                    mods.ipesotype = 0;
                    mods.isotype = 0;
                    mods.irowno = i + 1;
                    mods.bIAcreatebill = false;
                    mods.bsaleoutcreatebill = false;
                    mods.bneedbill = true;

                    mods.cDefine22 = dtDispatchList.Rows[i]["cDefine22"].ToString().Trim();
                    mods.cDefine23 = dtDispatchList.Rows[i]["cDefine23"].ToString().Trim();
                    mods.cDefine24 = dtDispatchList.Rows[i]["cDefine24"].ToString().Trim();
                    mods.cDefine25 = dtDispatchList.Rows[i]["cDefine25"].ToString().Trim();
                    mods.cDefine26 = BaseFunction.ReturnDecimal(dtDispatchList.Rows[i]["cDefine26"]);
                    mods.cDefine27 = BaseFunction.ReturnDecimal(dtDispatchList.Rows[i]["cDefine27"]);
                    mods.cDefine28 = dtDispatchList.Rows[i]["cDefine28"].ToString().Trim();
                    mods.cDefine29 = dtDispatchList.Rows[i]["cDefine29"].ToString().Trim();
                    mods.cDefine30 = dtDispatchList.Rows[i]["cDefine30"].ToString().Trim();
                    mods.cDefine31 = dtDispatchList.Rows[i]["cDefine31"].ToString().Trim();
                    mods.cDefine32 = dtDispatchList.Rows[i]["cDefine32"].ToString().Trim();
                    mods.cDefine33 = dtDispatchList.Rows[i]["cDefine33"].ToString().Trim();
                    mods.cDefine34 = BaseFunction.ReturnInt(dtDispatchList.Rows[i]["cDefine34"]);
                    mods.cDefine35 = BaseFunction.ReturnInt(dtDispatchList.Rows[i]["cDefine35"]);
                    mods.cDefine36 = BaseFunction.ReturnDate(dtDispatchList.Rows[i]["cDefine36"]);
                    mods.cDefine37 = BaseFunction.ReturnDate(dtDispatchList.Rows[i]["cDefine37"]);


                    DAL.rdrecords32 dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords32();
                    sSQL = dals.Add(mods);
                    iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode') 
	update  CurrentStock set fOutQuantity = isnull(fOutQuantity,0) - @dQty ,iQuantity = isnull(iQuantity,0) - @dQty  where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' 
else 
	begin 
		declare @itemid varchar(20); 
		declare @iCount int;  
		select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
		if( @iCount > 0 ) 
			select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
		else  
			select @itemid=max(itemid+1) from CurrentStock  
		
		insert into CurrentStock(cWhCode,cInvCode,fOutQuantity,iQuantity,itemid)values('@cWhCode','@cInvCode', -1 * @dQty, -1 * @dQty ,@itemid) 
	end
";
                    sSQL = sSQL.Replace("@cInvCode", mods.cInvCode);
                    sSQL = sSQL.Replace("@cWhCode", mod.cWhCode);
                    sSQL = sSQL.Replace("@dQty", mods.iQuantity.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    sSQL = "update DispatchList set cSaleOut = 'ST' where DLID = " + dtDispatchList.Rows[i]["DLID"].ToString();
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update DispatchLists set fOutQuantity = iQuantity where Autoid = " + dtDispatchList.Rows[i]["Autoid"].ToString().Trim();
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }

                if (lID > 1000000000)
                {
                    lID = lID - 1000000000;
                }
                if (lIDDetails > 1000000000)
                {
                    lIDDetails = lIDDetails - 1000000000;
                }
                sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'rd'";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                sSQL = @"
if exists(select * from VoucherHistory with (ROWLOCK) where CardNumber = '0303' and cSeed = 'bbbbbb')
	update VoucherHistory set cNumber = aaaaaa where CardNumber = '0303' and cSeed = 'bbbbbb'
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('0303','日期','年','bbbbbb',aaaaaa,0)
";

                sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
                sSQL = sSQL.Replace("bbbbbb", mod.dDate.Year.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (iCou > 0)
                {
                    sReturn = "OK\n" + mod.cCode;
                }
            }
            catch (Exception ee)
            {
                sReturn = "err:\n" + ee.Message;
            }

            return sReturn;
        }

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    GridView1.FocusedRowHandle -= 1;
                    GridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCount = 0;

                if (iType == 1 && txtCode.Text.Trim() != "")
                {
                    throw new Exception("Be saved");
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sCode = txtCode.Text.Trim();
                    if (sCode == "")
                    {
                        throw new Exception("Please choose data");
                    }

                    string sSQL = @"
select a.cDLCode,a.cDefine15,a.cVerifier,sum(fOutQuantity ) as fOutQty
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
where a.cDLCode = 'aaaaaa'
group by a.cDLCode,a.cDefine15,a.cVerifier
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception(sCode + " is not exists");
                    }

                    if (BaseFunction.ReturnInt(dt.Rows[0]["cDefine15"]) != 1)
                    {
                        throw new Exception(sCode + " is err");
                    }
                    if (dt.Rows[0]["cVerifier"].ToString().Trim() == "")
                    {
                        throw new Exception(sCode + " is not audit");
                    }

                    decimal dOutQty = BaseFunction.ReturnDecimal(dt.Rows[0]["fOutQty"]);
                    if (dOutQty > 0)
                    {
                        throw new Exception(sCode + " is outbound");
                    }

                    sSQL = @"
update DispatchList set cVerifier = null,dVerifydate = null,dverifysystime = null where cDLCode = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("cccccc", sUserName);
                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("UnAudit OK");

                        iType = 3;

                        chkAll.Enabled = false;
                        SetBtnEnable(false);
                        txtStatus.Text = "Saved";
                    }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sCode = txtCode.Text.Trim();
                string sSQL = @"
select a.cDLCode,a.cDefine15,a.cVerifier,sum(fOutQuantity ) as fOutQty
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
where a.cDLCode = 'aaaaaa'
group by a.cDLCode,a.cDefine15,a.cVerifier
";
                sSQL = sSQL.Replace("aaaaaa", sCode);
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception(sCode + " is not exists");
                }

                if (dt.Rows[0]["cVerifier"].ToString().Trim() != "")
                {
                    throw new Exception(sCode + " is audit");
                }
                SetBtnEnable(true);
                SetEnable(true);
                txtStatus.Text = "edit";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridControl1.DataSource == null || GridView1.RowCount == 0)
                {
                    throw new Exception("No data");
                }

                checkData();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private DialogResult checkData()
        {
            DialogResult d = DialogResult.Cancel;

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "WareHouse No";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "WareHouse";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Item No";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Description";
            dt.Columns.Add(dc);

            if (lookUpEditcWhCode.EditValue == null)
            {
                lookUpEditcWhCode.Focus();
                throw new Exception("Please choose warehouse");
            }

            string sWhCode = lookUpEditcWhCode.EditValue.ToString();
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                string sInvCode = GridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                if (sInvCode == "")
                {
                    continue;
                }

                decimal dQty = BaseFunction.ReturnDecimal(GridView1.GetRowCellValue(i, gridColQty));

                string sSQL = @"
select SUM(isnull(iQuantity,0) - isnull(fOutQuantity,0)) as iCurrQty
from CurrentStock 
where cWhCode = 'aaaaaa' and cInvCode = 'bbbbbb'
";
                sSQL = sSQL.Replace("aaaaaa", sWhCode);
                sSQL = sSQL.Replace("bbbbbb", sInvCode);
                DataTable dtCurr = DbHelperSQL.Query(sSQL);
                if (dtCurr == null || dtCurr.Rows.Count == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Item No"] = sInvCode;
                    dr["WareHouse No"] = lookUpEditcWhCode.EditValue.ToString();
                    dr["WareHouse"] = lookUpEditcWhName.Text.Trim();
                    dr["Description"] = GridView1.GetRowCellDisplayText(i, gridColcInvName).ToString().Trim();
                    dt.Rows.Add(dr);
                    continue;
                }
                decimal dCurrQty = BaseFunction.ReturnDecimal(dtCurr.Rows[0]["iCurrQty"]);
                if (dCurrQty < dQty)
                {
                    DataRow dr = dt.NewRow();
                    dr["Item No"] = sInvCode;
                    dr["WareHouse No"] = lookUpEditcWhCode.EditValue.ToString();
                    dr["WareHouse"] = lookUpEditcWhName.Text.Trim();
                    dr["Description"] = GridView1.GetRowCellDisplayText(i, gridColcInvName).ToString().Trim();
                    dt.Rows.Add(dr);
                    continue;
                }
            }

            if (dt.Rows.Count > 0)
            {
                FrmExportData frm = new FrmExportData(dt);
                frm.ShowDialog();

                d = frm.DialogResult;
            }
            else
            {
                MessageBox.Show("Item is enough");
            }

            return d;
        }

        private void btnCreateoutbound_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    GridView1.FocusedRowHandle -= 1;
                    GridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCount = 0;

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sCode = txtCode.Text.Trim();
                    if (sCode == "")
                    {
                        throw new Exception("Please choose data");
                    }

                    string sSQL = @"
select * from DispatchList where cDLCode = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", sCode);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception(sCode + " is not exists");
                    }

                    if (BaseFunction.ReturnInt(dt.Rows[0]["cDefine15"]) != 1)
                    {
                        throw new Exception(sCode + " is err");
                    }
                    if (dt.Rows[0]["cVerifier"].ToString().Trim() == "")
                    {
                        throw new Exception(sCode + " is not audit");
                    }

                    string sWarn = "";
                    string s = CreateRd32(tran, sCode, sUserName, dLogDate,out sWarn);
                    if (s.StartsWith("err"))
                    {
                        throw new Exception(s);
                    }
                    if (sWarn != "")
                    {
                        FrmMsgBox frm = new FrmMsgBox();
                        frm.richTextBox1.Text = sWarn;
                        DialogResult d = frm.ShowDialog();
                        if (d != DialogResult.OK)
                        {
                            tran.Rollback();
                            return;
                        }
                    }

                    if (s.StartsWith("OK"))
                    {
                        tran.Commit();
                        MessageBox.Show("Create Outbound is " + s);
                        SetBtnEnable(false);

                        GetVouchStatus(sCode);
                        chkAll.Checked = false;
                    }
                    else
                    {
                        tran.Rollback();
                    }
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

        private void GetVouchStatus(string sCode)
        {
            string sSQL = @"
select case when ISNULL(cVerifier,'') = '' then 'Saved' when b.iCou > 0 and ISNULL(cVerifier,'') <> '' then 'Audit' else 'Closed' end as [Status]
from DispatchList a inner join Customer cus on a.cCusCode = cus.cCusCode
	left join (select count(1) as iCou,DLID from DispatchLists where isnull(fOutQuantity ,0) < isnull(iquantity,0) group by DLID) b on a.DLID = b.DLID
where isnull(a.cDefine15,0) = 1
        and a.cDLCode = 'aaaaaa'
order by cDLCode desc
";
            sSQL = sSQL.Replace("aaaaaa", sCode);
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtStatus.Text = dt.Rows[0]["Status"].ToString().Trim();
                if (txtStatus.Text.ToLower() == "audit")
                {
                    chkAll.Enabled = true;
                    chkAll.Checked = true;
                }
                else
                {
                    chkAll.Enabled = false;
                    chkAll.Checked = false;
                }
            }

            sSQL = @"
select distinct cDefine22,cDefine34 
from DispatchList a inner join DispatchLists b  on a.DLID = b.DLID
where a.cDLCode = 'aaaaaa' and isnull(b.fOutQuantity ,0) > 0
";
            sSQL = sSQL.Replace("aaaaaa", sCode);
            dt = DbHelperSQL.Query(sSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sSite = dt.Rows[i]["cDefine22"].ToString().Trim();
                SetBandColor(sSite, cUsed);
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                txtCode.Text = "";
                SetEnable(true);
                iType = 1;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
                    GridView1.ExportToXls(sF.FileName);
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

        private void ItemButtonEditInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //GridView1.FocusedColumn = gridColcInvName;
                //GridView1.FocusedColumn = gridColcInvCode;
                string sItem = GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, gridColcInvCode).ToString().Trim();

                FrmInvInfo frm = new FrmInvInfo(sItem, false);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sReturn = frm.sInvCode;
                    if (sReturn != "")
                    {
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, gridColcInvCode, sReturn);
                    }
                }

            }
            catch { }
        }

        private void ItemButtonEditInvCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    ItemButtonEditInvCode_ButtonClick(null, null);
                }
            }
            catch { }
        }

        private void ItemButtonEditInvCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    int iFocRow = GridView1.FocusedRowHandle;
                    int iFoc = iFocRow;

                    string sList = GetString();
                    if (sList.Trim() != "")
                    {
                        string[] sCode = sList.Replace("\r\n", "◆").Split('◆');
                        for (int i = 0; i < sCode.Length; i++)
                        {
                            string s = sCode[i].Trim();
                            //if (s != "")
                            {
                                GridView1.SetRowCellValue(iFocRow, gridColcInvAddCode, s);

                                iFocRow += 1;

                                if (GridView1.RowCount <= iFocRow)
                                {
                                    GridView1.AddNewRow();
                                }
                                GridView1.FocusedRowHandle = iFocRow;
                            }
                        }
                    }
                    GridView1.FocusedRowHandle = iFoc;
                }
            }
            catch { }
        }

        private void ItemTextEditN2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    int iFocRow = GridView1.FocusedRowHandle;
                    int iFoc = iFocRow;

                    string sList = GetString();
                    if (sList.Trim() != "")
                    {
                        string[] sCode = sList.Replace("\r\n", "◆").Split('◆');
                        for (int i = 0; i < sCode.Length; i++)
                        {
                            string s = sCode[i].Trim();
                            //if (s != "")
                            {
                                decimal d = BaseFunction.ReturnDecimal(s, 2);
                                GridView1.SetRowCellValue(iFocRow, GridView1.FocusedColumn, d);

                                iFocRow += 1;

                                if (GridView1.RowCount <= iFocRow)
                                {
                                    GridView1.AddNewRow();
                                }
                                GridView1.FocusedRowHandle = iFocRow;
                            }
                        }
                    }

                    GridView1.FocusedRowHandle = iFoc;
                }
            }
            catch { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridControl1.DataSource == null || GridView1.RowCount <= 0)
                {
                    throw new Exception("No data");
                }

                string sCode = txtCode.Text.Trim();
                if (sCode == "")
                {
                    throw new Exception("Please choose FHD");
                }

                string sSQL = @"
select a.cDLCode,a.cDefine15,a.cVerifier,sum(fOutQuantity ) as fOutQty
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
where a.cDLCode = 'aaaaaa'
group by a.cDLCode,a.cDefine15,a.cVerifier
";
                sSQL = sSQL.Replace("aaaaaa", sCode);
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception(sCode + " is not exists");
                }

                if (BaseFunction.ReturnInt(dt.Rows[0]["cDefine15"]) != 1)
                {
                    throw new Exception(sCode + " is err");
                }
                if (dt.Rows[0]["cVerifier"].ToString().Trim() == "")
                {
                    throw new Exception(sCode + " is not audit");
                }

                this.printableComponentLink1.CreateDocument();
                this.printableComponentLink1.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridControl1.DataSource == null || GridView1.RowCount <= 0)
                {
                    return;
                }

                string sCode = txtCode.Text.Trim();
                if (sCode == "")
                {
                    return;
                }

                string sSQL = @"
select a.cDLCode,a.cDefine15,a.cVerifier,sum(fOutQuantity ) as fOutQty
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
where a.cDLCode = 'aaaaaa'
group by a.cDLCode,a.cDefine15,a.cVerifier
";
                sSQL = sSQL.Replace("aaaaaa", sCode);
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }

                if (BaseFunction.ReturnInt(dt.Rows[0]["cDefine15"]) != 1)
                {
                    return;
                }
                if (dt.Rows[0]["cVerifier"].ToString().Trim() == "")
                {
                    return;
                }

                string sCol = GridView1.FocusedColumn.Name;
                if (sCol.StartsWith("gridColQty_SiteNo_"))
                {
                    string sSiteNO = sCol.Replace("gridColQty_SiteNo_", "");

                    if (GridView1.Bands["gridBand_SiteNo_1" + sSiteNO].AppearanceHeader.ForeColor == cChoose)
                    {
                        SetBandColor(sSiteNO, cUnChoose);
                    }
                    else if (GridView1.Bands["gridBand_SiteNo_1" + sSiteNO].AppearanceHeader.ForeColor == cUnChoose)
                    {
                        SetBandColor(sSiteNO, cChoose);
                    }

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetBandColor(string sSiteNO, Color c)
        {
            GridView1.Bands["gridBand_SiteNo_1" + sSiteNO].AppearanceHeader.ForeColor = c;
            GridView1.Bands["gridBand_SiteNo_1" + sSiteNO].Children[0].AppearanceHeader.ForeColor = c;
            GridView1.Bands["gridBand_SiteNo_1" + sSiteNO].Children[0].Children[0].AppearanceHeader.ForeColor = c;
            GridView1.Bands["gridBand_SiteNo_1" + sSiteNO].Children[0].Children[0].Children[0].AppearanceHeader.ForeColor = c;
            GridView1.Bands["gridBand_SiteNo_1" + sSiteNO].Children[0].Children[0].Children[0].Children[0].AppearanceHeader.ForeColor = c;
            GridView1.Columns["Qty_SiteNo_" + sSiteNO].AppearanceHeader.ForeColor = c;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int j = 0; j < GridView1.Bands.Count; j++)
                {
                    string sBandName = GridView1.Bands[j].Name;
                    string sSiteNo = "";
                    if (sBandName.StartsWith("gridBand_SiteNo_1"))
                    {
                        if (GridView1.Bands[j].AppearanceHeader.ForeColor == cUsed)
                            continue;

                        sSiteNo = sBandName.Replace("gridBand_SiteNo_1", "");

                        if (chkAll.Checked)
                        {
                            SetBandColor(sSiteNo, cChoose);
                        }
                        else
                        {
                            SetBandColor(sSiteNo, cUnChoose);
                        }

                    }
                }
            }
            catch (Exception ee)
            {

            }
        }


        private void ItemTextEditItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    int iFocRow = GridView1.FocusedRowHandle;
                    int iFoc = iFocRow;

                    string sList = GetString();
                    if (sList.Trim() != "")
                    {
                        string[] sCode = sList.Replace("\r\n", "◆").Split('◆');
                        for (int i = 0; i < sCode.Length; i++)
                        {
                            string s = sCode[i].Trim();
                            //if (s != "")
                            {
                                //decimal d = BaseFunction.ReturnDecimal(s, 2);
                                GridView1.SetRowCellValue(iFocRow, GridView1.FocusedColumn, s);

                                iFocRow += 1;

                                if (GridView1.RowCount <= iFocRow)
                                {
                                    GridView1.AddNewRow();
                                }
                                GridView1.FocusedRowHandle = iFocRow;
                            }
                        }
                    }

                    GridView1.FocusedRowHandle = iFoc;
                }
            }
            catch { }
        }
    }
}