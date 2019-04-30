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
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ImportPurBillVouch : UserControl
    {        
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
                DbHelperSQL.connectionString = Conn;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public ImportPurBillVouch()
        {
            InitializeComponent();
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

        private void btnImprot_Click(object sender, EventArgs e)
        {
            try
            {
                gridViewPL.FocusedRowHandle -= 1;
                gridViewPL.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                if (txtCurrency.Text.Trim() == "")
                {
                    throw new Exception("Please set currency");
                }

                decimal dExch = BaseFunction.ReturnDecimal(txtExchangeRate.Text.Trim());
                if (dExch == 0)
                {
                    throw new Exception("Please set the exchange rate");
                }

                int iCou = gridViewPL.RowCount;
                if (iCou == 0)
                {
                    throw new Exception("no data");
                }

                int iCodeCou = gridViewPL.RowCount;
                string sErr = "";
                string sWarn = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    DateTime dLogDate = BaseFunction.ReturnDate(sLogDate);

                    //string sDate = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                    string sDate = sLogDate;
                    string sSQL = @"
select bflag_PU from gl_mend where iyear = aaaaaa and iperiod = bbbbbb
";
                    sSQL = sSQL.Replace("aaaaaa", dLogDate.Year.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dLogDate.Month.ToString());
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (BaseFunction.ReturnBool(dtTemp.Rows[0]["bflag_PU"]))
                    {
                        throw new Exception("The current date has been checked out");
                    }

                    string sDateTime = dateEditQuery.DateTime.ToString("yyyy-MM-dd");                   

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'tr',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("cccccc", iCou.ToString());
                    sSQL = sSQL.Replace("dddddd", sAccID);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCodeCou;

                    sSQL = @"
select a.EntryNO,b.*
from RdRecords01_Import a
    inner join ( 
		select a.cCode,a.cVouchType ,a.cDepCode,a.dDate,a.cBusType ,a.cPTCode ,a.cExch_Name,a.cVenCode ,a.cRdCode ,a.cWhCode ,a.bRdFlag ,a.cPersonCode ,a.cSource,a.iExchRate 
			,b.AutoID,b.cInvCode,b.iQuantity,b.irowno,b.iOriCost,b.iOriMoney,b.iOriTaxPrice,b.iOriSum,b.iMoney,b.iTaxPrice,b.iSum,b.iTaxRate,b.iPOsID ,b.iOriTaxCost
            ,a.cDefine1, a.cDefine2, a.cDefine3, a.cDefine4, a.cDefine5, a.cDefine6, a.cDefine7,  a.cDefine8, a.cDefine9, a.cDefine10,  a.cDefine11, a.cDefine12, a.cDefine13, a.cDefine14, a.cDefine15, a.cDefine16
            ,b.cDefine22, cDefine23, b.cDefine24, b.cDefine25, b.cDefine26, b.cDefine27, b.cDefine28, b.cDefine29, b.cDefine30, b.cDefine31, cDefine32, b.cDefine33, b.cDefine34, b.cDefine35, b.cDefine36, b.cDefine37
		from RdRecord01 a inner join Rdrecords01 b on a.id = b.id 
	)b on a.Rds01ID = b.Autoid
where a.InvoiceNo = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", txtInvoiceNO.Text.Trim());
                    DataTable dtRd01 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtRd01 == null || dtRd01.Rows.Count == 0)
                    {
                        throw new Exception("Purchase receipt warrant is not exists");
                    }

                    Model.PurBillVouch mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.PurBillVouch();
                    mod.PBVID = lID.ToString();
                    mod.cPBVBillType = "01";
                    mod.cPBVCode = txtInvoiceNO.Text.Trim();
                    mod.cPTCode = dtRd01.Rows[0]["cPTCode"].ToString().Trim();
                    mod.dPBVDate = dLogDate;
                    mod.cVenCode = dtRd01.Rows[0]["cVenCode"].ToString().Trim();
                    mod.cUnitCode = dtRd01.Rows[0]["cVenCode"].ToString().Trim();          //代垫单位代码
                    mod.cDepCode = dtRd01.Rows[0]["cDepCode"].ToString().Trim();
                    mod.cexch_name = txtCurrency.Text.Trim();
                    mod.cExchRate = dExch;
                    mod.iPBVTaxRate = BaseFunction.ReturnDecimal(dtRd01.Rows[0]["iTaxRate"]);
                    mod.cInCode = dtRd01.Rows[0]["cCode"].ToString().Trim();
                    mod.cBusType = dtRd01.Rows[0]["cBusType"].ToString().Trim();
                    mod.cPBVMaker = sUserName;
                    mod.bNegative = false;
                    mod.bOriginal = false;
                    mod.bFirst = false;
                    mod.iNetLock = 0;
                    mod.dVouDate = dLogDate;
                    mod.iVTid = 8163;
                    mod.cSource = "采购";
                    mod.iDiscountTaxType = 0;
                    //mod.cVenPUOMProtocol
                    mod.dCreditStart = dLogDate;
                    mod.iCreditPeriod = 0;
                    mod.dGatheringDate = dLogDate;
                    mod.bCredit = 1;
                    mod.iPrintCount = 0;
                    mod.IsWfControlled = false;
                    mod.csysbarcode = "||puzl|" + mod.cPBVCode;
                    mod.cmaketime = DateTime.Now;

                    mod.cCurrentAuditor = null;

                    mod.cDefine1 = dtRd01.Rows[0]["cDefine1"].ToString().Trim();
                    mod.cDefine10 = dtRd01.Rows[0]["cDefine10"].ToString().Trim();
                    //mod.cDefine11 = txtBL.Text.Trim();


                    DAL.PurBillVouch dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.PurBillVouch();
                    sSQL = dal.Add(mod);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    //回写采购入库单表头自定义项10 为发票号
                    sSQL = @"
Update Rdrecord01 set cDefine10 = 'aaaaaaaa' where ID in (select ID from Rdrecords01 where Autoid = bbbbbbbb)
";
                    sSQL = sSQL.Replace("aaaaaaaa", mod.cPBVCode);
                    sSQL = sSQL.Replace("bbbbbbbb", gridViewPL.GetRowCellValue(0, gridColRds01ID).ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    int iRow = 0;
                    for (int i = 0; i < gridViewPL.RowCount; i++)
                    {
                        //判断是否生成了调拨单
                        string sTrIDs = gridViewPL.GetRowCellValue(i, gridColU8TrsID).ToString().Trim();
                        if (sTrIDs != "")
                        {
                            sSQL = @"
select autoid from TransVouchs where autoid = aaaaaaaa
";
                            sSQL = sSQL.Replace("aaaaaaaa", sTrIDs);
                            DataTable dtTr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtTr == null || dtTr.Rows.Count == 0)
                            {
                                sWarn = sWarn + "Line " + (i + 1).ToString() + "  no transfer order\n";
                            }
                        }
                        else
                        {
                            sWarn = sWarn + "Line " + (i + 1).ToString() + "  no transfer order\n";
                        }

                        //判断是否生成了发票
                        string sPurIDs = gridViewPL.GetRowCellValue(i, gridColPurBillIDs).ToString().Trim();
                        if (sPurIDs != "")
                        {
                            sSQL = @"
select id from PurBillVouchs where ID = aaaaaaaa
";
                            sSQL = sSQL.Replace("aaaaaaaa", sPurIDs);
                            DataTable dtPur = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtPur != null && dtPur.Rows.Count > 0)
                            {
                                sErr = sErr + "Line " + (i + 1).ToString() + " imported invoice\n";
                                continue;
                            }
                        }

                        DataRow[] drs;
                        string sRds01ID = gridViewPL.GetRowCellValue(i,gridColRds01ID).ToString().Trim();
                        if (sRds01ID == "")
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " purchase receipt warrant is not exists\n";
                            continue;
                        }
                        else
                        {
                            drs = dtRd01.Select("Autoid = " + sRds01ID);
                            if (drs.Length == 0)
                            {
                                sErr = sErr + "Line " + (i + 1).ToString() + " purchase receipt warrant is not exists\n";
                                continue;
                            }
                        }

                        Model.PurBillVouchs mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.PurBillVouchs();

                        sSQL = @"
Select  b.iQuantity - isnull(b.iSumBillQuantity,0) as QtyUnRDIn
    ,b.*
from Rdrecord01 a inner join Rdrecords01 b on a.ID = b.ID
where AutoID = bbbbbb
";
                        sSQL = sSQL.Replace("bbbbbb", gridViewPL.GetRowCellValue(i, gridColRds01ID).ToString());
                        DataTable dtRds01 = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];
                        if (dtRds01 == null || dtRds01.Rows.Count == 0)
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " purchase entry form is not imported\n";
                            continue;
                        }

                        decimal dQtyUnRDIn = BaseFunction.ReturnDecimal(dtRds01.Rows[0]["QtyUnRDIn"]);

                        lIDDetails += 1;
                        mods.ID = lIDDetails;
                        mods.PBVID = mod.PBVID;
                        mods.cInvCode = gridViewPL.GetRowCellValue(i, gridColPARTNO).ToString().Trim();
                        mods.bExBill = false;
                        mods.iPBVQuantity = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColQUANTITY));
                        if (mods.iPBVQuantity > dQtyUnRDIn)
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " qty err\n";
                            continue;
                        }

                        mods.iTaxRate = BaseFunction.ReturnDecimal(drs[0]["iTaxRate"]);

                        mods.iOriCost = BaseFunction.ReturnDecimal(drs[0]["iOriCost"]);
                        mods.iOriMoney = BaseFunction.ReturnDecimal(drs[0]["iOriMoney"]);              //原币无税金额
                        mods.iOriSum = BaseFunction.ReturnDecimal(drs[0]["iOriSum"]);
                        mods.iOriTaxCost = BaseFunction.ReturnDecimal(drs[0]["iOriTaxCost"]);
                        mods.iOriTaxPrice = mods.iOriSum - mods.iOriMoney;

                        mods.iCost = BaseFunction.ReturnDecimal(mods.iOriCost * dExch);
                        mods.iMoney = BaseFunction.ReturnDecimal(mods.iOriMoney * dExch);
                        mods.iSum = BaseFunction.ReturnDecimal(mods.iOriSum * dExch);
                        mods.iOriTotal = 0;
                        mods.iTotal = 0;
                        mods.iTaxRate = BaseFunction.ReturnDecimal(drs[0]["iTaxRate"]);
                        mods.iTaxPrice = mods.iSum - mods.iMoney;

                        mods.cDefine22 = gridViewPL.GetRowCellValue(i, gridColCONTAINERNO).ToString().Trim();
                        mods.cDefine23 = gridViewPL.GetRowCellValue(i, gridColBOXNO).ToString().Trim();
                        mods.cDefine24 = gridViewPL.GetRowCellValue(i, gridColCASENO).ToString().Trim();
                        mods.cDefine25 = gridViewPL.GetRowCellValue(i, gridColGWKGS).ToString().Trim();
                        mods.cDefine28 = gridViewPL.GetRowCellValue(i, gridColNWKGS).ToString().Trim();

                        mods.iPOsID = BaseFunction.ReturnLong(drs[0]["iPOsID"]);

                        mods.RdsId = BaseFunction.ReturnLong(drs[0]["AutoID"]);
                        mods.UpSoType = "rd";
                        mods.bCosting = false;
                        mods.bTaxCost = true;
                        mods.iinvexchrate = 0;
                        mods.brettax = 0;
                        mods.ivouchrowno = i + 1;



                        mods.cbsysbarcode = "||puzl|" + mod.cPBVCode + "|" + mods.ivouchrowno.ToString();
                        DAL.PurBillVouchs dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.PurBillVouchs();
                        sSQL = dals.Add(mods);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //回写导入中间表 Rdrecords10_Import
                        sSQL = @"
update RdRecords01_Import set PurBillIDs = AAAAAA
WHERE AUTOID = BBBBBB
";
                        sSQL = sSQL.Replace("AAAAAA", mods.ID.ToString());
                        sSQL = sSQL.Replace("BBBBBB", gridViewPL.GetRowCellValue(i, gridColAutoID).ToString());
                        int iRet = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        if (iRet != 1)
                        {
                            sErr = sErr + "Row " + (i + 1) + " update dl err\n";
                        }

                        //回写采购入库单
                        sSQL = @"
update Rdrecords01 set iSumBillQuantity = isnull(iSumBillQuantity,0) + aaaaaa
where AutoID = bbbbbb
";
                        sSQL = sSQL.Replace("aaaaaa", gridViewPL.GetRowCellValue(i, gridColQUANTITY).ToString());
                        sSQL = sSQL.Replace("bbbbbb", gridViewPL.GetRowCellValue(i, gridColRds01ID).ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //回写采购订单
                        sSQL = @"
update PO_Podetails set iInvQTY  = isnull(iInvQTY ,0) + aaaaaa,iInvMoney = isnull(iInvMoney ,0) + cccccc,iNatInvMoney  = isnull(iNatInvMoney ,0) + dddddd
where ID = bbbbbb
";
                        sSQL = sSQL.Replace("aaaaaa", mods.iPBVQuantity.ToString());
                        sSQL = sSQL.Replace("bbbbbb", mods.iPOsID.ToString());
                        sSQL = sSQL.Replace("cccccc", mods.iOriMoney.ToString());
                        sSQL = sSQL.Replace("dddddd", mods.iMoney.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (sWarn != "")
                    {
                        if (MessageBox.Show(sWarn, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                        {
                            throw new Exception("User canceled ");
                        }
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("Success：" + mod.cPBVCode);

                        SetTxtNull();
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
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void SetTxtNull()
        {
            gridControlIN.DataSource = null;
            gridControlPL.DataSource = null;
            txtCompany.Text = "";
            txtInvoiceNO.Text = "";
            dateEdit1.Text = "";
            txtBL.Text = "";
            dtmBL.Text = "";
            txtCurrency.Text = "";
            txtExchangeRate.Text = "";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSEL_ImportPurBillVouch frm = new FrmSEL_ImportPurBillVouch();
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                dateEditQuery.DateTime = frm.dtmReturn;
                string sInvoiceNO = frm.sInvoiceNO;
                string sContaineNO = frm.sContainerNO;

                string sDateTime = dateEditQuery.DateTime.ToString("yyyy-MM-dd");
                string sSQL = @"
SELECT AutoID, ImportTime, InvoiceNo, Date, Companyname, PONO, PARTNO, DESCRIPTIONENGLISH
	, cast(QUANTITY as decimal(16,2)) as QUANTITY 
	, cast(NW as decimal(16,2)) as NW
	, cast(GW as decimal(16,2)) as GW
	, cast(PRICEPERUNIT as decimal(16,2)) as PRICEPERUNIT, UNIT
	, cast(TOTALPRICE as decimal(16,2)) as TOTALPRICE
FROM      PurBillVouchs_Import
where 1=1 and InvoiceNO = 'aaaaaa' 
order by Autoid
";
                sSQL = sSQL.Replace("aaaaaa", sInvoiceNO);
                DataTable dtIN = DbHelperSQL.Query(sSQL);
                if (dtIN != null && dtIN.Rows.Count > 0)
                {
                    txtCompany.Text = dtIN.Rows[0]["Companyname"].ToString().Trim();
                    txtInvoiceNO.Text = dtIN.Rows[0]["InvoiceNo"].ToString().Trim();
                    dateEdit1.DateTime = BaseFunction.ReturnDate(dtIN.Rows[0]["Date"]);
                    gridControlIN.DataSource = dtIN;
                    gridViewIN.BestFitColumns();
                }

                sSQL = @"
SELECT  a.AutoID, ImportTime, InvoiceNo, Date, Companyname, PONO, CONTAINERNO, PARTNO
	, DESCRIPTIONOFPRODUCTSEN, CASENO
	, BOXNO
	,cast( BOXQTY as int) as BOXQTY
	,cast( QUANTITY as decimal(16,2)) as QUANTITY, UNIT
	, cast(NWKGS as decimal(16,2)) as NWKGS
	,cast( GWKGS as decimal(16,2)) as GWKGS
    ,cast( UnitPrice as decimal(16,2)) as UnitPrice
	, BOXCBM, CONNO, POsID, Rds01ID, BLDate, BLNo
	,b.cPOID as U8PONO
	,c.cCode as U8RDCode
	, a.TrIDs ,d.cTVCode as U8TRCode
    ,a.Currency
    ,e.cPBVCode as PurBillCode,e.ID AS PurBillIDs
    ,d.autoid as U8TrsID
FROM      RdRecords01_Import a left join
(
	select distinct a.cPOID,b.ID,b.cInvCode
	from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID
)b on a.POsID = b.ID  and a.PARTNO = b.cInvCode
	LEFT JOIN
(
	select distinct a.cCode,b.autoid
	from Rdrecord01 a inner join rdrecords01 b on a.id = b.id
) c on a.Rds01ID = c.autoid 
	left join 
(
	select distinct a.cTVCode,b.autoid
	from TransVouch a inner join TransVouchs b on a.cTVCode = b.cTVCode 
) d on a.TrIDs = d.autoid
    left join
(
    select b.ID,a.cPBVCode,b.cInvCode
    from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID 
)e on e.ID = a.PurBillIDs
where 1=1 and a.InvoiceNO = 'aaaaaa' 
order by a.Autoid
";
                sSQL = sSQL.Replace("aaaaaa", sInvoiceNO);
                if (sContaineNO != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ContainerNO like '%" + sContaineNO.Trim() + "%'");
                }
                DataTable dtPL = DbHelperSQL.Query(sSQL);
                if (dtPL != null && dtPL.Rows.Count > 0)
                {
                    txtCurrency.Text = dtPL.Rows[0]["Currency"].ToString().Trim();
                    txtBL.Text = dtPL.Rows[0]["BLNo"].ToString().Trim();
                    dtmBL.DateTime = BaseFunction.ReturnDate(dtPL.Rows[0]["BLDate"]);
                    gridControlPL.DataSource = dtPL;
                    gridViewPL.BestFitColumns();
                }

                if (txtCurrency.Text.Trim().ToLower() == "thb")
                {
                    txtExchangeRate.Text = "1";
                }
                else
                {
                    sSQL = @"
select nflat from exch where cexch_name = 'bbbbbbbb' and cdate = 'aaaaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaaaa", dtmBL.DateTime.ToString("yyyy.MM.dd"));
                    sSQL = sSQL.Replace("bbbbbbbb", txtCurrency.Text.Trim());
                    DataTable dtExch = DbHelperSQL.Query(sSQL);
                    if (dtExch == null || dtExch.Rows.Count == 0)
                    {
                        throw new Exception("Please set the exchange rate");
                    }
                    else
                    {
                        txtExchangeRate.Text = dtExch.Rows[0]["nflat"].ToString().Trim();
                    }
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();

                SetTxtNull();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetTxtNull();
        }

        private void gridViewPL_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridViewPL.GetRowCellValue(e.RowHandle, gridColPurBillCode).ToString().Trim();
                    if (s1 != "")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }

                    string s2 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8TRCode).ToString().Trim();
                    if (s2 == "")
                    {
                        e.Appearance.BackColor = Color.LightYellow;
                    }

                    string s3 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8RDCode).ToString().Trim();
                    if(s3 == "")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }

                }
            }
            catch
            {

            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                gridViewPL.FocusedRowHandle -= 1;
                gridViewPL.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                string sErr = "";
                if (txtCurrency.Text.Trim() == "")
                {
                    sErr = sErr + "Please set currency\n";
                }

                decimal dExch = BaseFunction.ReturnDecimal(txtExchangeRate.Text.Trim());
                if (dExch == 0)
                {
                    sErr = sErr + "Please set the exchange rate\n";
                }

                int iCou = gridViewPL.RowCount;
                if (iCou == 0)
                {
                    sErr = sErr + "No data\n";
                }

                int iCodeCou = gridViewPL.RowCount;

                string sWarn = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    DateTime dLogDate = BaseFunction.ReturnDate(sLogDate);

                    //string sDate = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                    string sDate = sLogDate;
                    string sSQL = @"
select bflag_PU from gl_mend where iyear = aaaaaa and iperiod = bbbbbb
";
                    sSQL = sSQL.Replace("aaaaaa", dLogDate.Year.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dLogDate.Month.ToString());
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (BaseFunction.ReturnBool(dtTemp.Rows[0]["bflag_PU"]))
                    {
                        sErr = sErr + "The current date has been checked out\n";
                    }

                    for (int i = 0; i < gridViewPL.RowCount; i++)
                    {
                        string sCONTAINERNO = gridViewPL.GetRowCellValue(i, gridColCONTAINERNO).ToString().Trim();

                        sSQL = @"
select a.EntryNO,b.*
from RdRecords01_Import a
    inner join ( 
		select a.cCode,a.cVouchType ,a.cDepCode,a.dDate,a.cBusType ,a.cPTCode ,a.cExch_Name,a.cVenCode ,a.cRdCode ,a.cWhCode ,a.bRdFlag ,a.cPersonCode ,a.cSource,a.iExchRate 
			,b.AutoID,b.cInvCode,b.iQuantity,b.irowno,b.iOriCost,b.iOriMoney,b.iOriTaxPrice,b.iOriSum,b.iMoney,b.iTaxPrice,b.iSum,b.iTaxRate,b.iPOsID ,b.iOriTaxCost
		from RdRecord01 a inner join Rdrecords01 b on a.id = b.id 
	)b on a.Rds01ID = b.Autoid
where a.InvoiceNo = 'aaaaaa' and a.autoid = 'bbbbbb'
";
                        sSQL = sSQL.Replace("aaaaaa", txtInvoiceNO.Text.Trim());
                        sSQL = sSQL.Replace("bbbbbb", gridViewPL.GetRowCellValue(i,gridColAutoID).ToString().Trim());
                        DataTable dtRd01 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtRd01 == null || dtRd01.Rows.Count == 0)
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " purchase receipt warrant is not exists [" + sCONTAINERNO + "]\n";
                            continue;
                        }

                        //判断是否生成了调拨单
                        string sTrIDs = gridViewPL.GetRowCellValue(i, gridColU8TrsID).ToString().Trim();
                        if (sTrIDs == "")
                        {
                            sWarn = sWarn + "Line " + (i + 1).ToString() + "  no transfer order [" + sCONTAINERNO + "]\n";
                        }
                        else
                        {
                            sSQL = @"
select autoid from TransVouchs where autoid = aaaaaaaa
";
                            sSQL = sSQL.Replace("aaaaaaaa", sTrIDs);
                            DataTable dtTr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtTr == null || dtTr.Rows.Count == 0)
                            {
                                sWarn = sWarn + "Line " + (i + 1).ToString() + "  no transfer order [" + sCONTAINERNO + "]\n";
                            }
                        }

                        //判断是否生成了发票
                        string sPurIDs = gridViewPL.GetRowCellValue(i, gridColPurBillIDs).ToString().Trim();
                        if (sPurIDs != "")
                        {
                            sSQL = @"
select id from PurBillVouchs where ID = aaaaaaaa
";
                            sSQL = sSQL.Replace("aaaaaaaa", sPurIDs);
                            DataTable dtPur = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtPur != null && dtPur.Rows.Count > 0)
                            {
                                sErr = sErr + "Line " + (i + 1).ToString() + " imported invoice [" + sCONTAINERNO + "]\n";
                                continue;
                            }
                        }


                        DataRow[] drs = dtRd01.Select("Autoid = " + gridViewPL.GetRowCellValue(i, gridColRds01ID).ToString().Trim());
                        if (drs.Length == 0)
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " purchase receipt warrant is not exists [" + sCONTAINERNO + "]\n";
                            continue;
                        }

                        Model.PurBillVouchs mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.PurBillVouchs();

                        sSQL = @"
Select  b.iQuantity - isnull(b.iSumBillQuantity,0) as QtyUnRDIn
    ,b.*
from Rdrecord01 a inner join Rdrecords01 b on a.ID = b.ID
where AutoID = bbbbbb
";
                        sSQL = sSQL.Replace("bbbbbb", gridViewPL.GetRowCellValue(i, gridColRds01ID).ToString());
                        DataTable dtRds01 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtRds01 == null || dtRds01.Rows.Count == 0)
                        {
                            sErr = sErr + "Line " + (i + 1).ToString() + " purchase entry form is not imported [" + sCONTAINERNO + "]\n";
                            continue;
                        }

                        decimal dQtyUnRDIn = BaseFunction.ReturnDecimal(dtRds01.Rows[0]["QtyUnRDIn"]);

                        mods.iPBVQuantity = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColQUANTITY));
                        if (mods.iPBVQuantity > dQtyUnRDIn)
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " qty err [" + sCONTAINERNO + "]\n";
                            continue;
                        }
                    }
                    if (sErr != "")
                    {
                        string sInfo = "";
                        if (sWarn != "")
                        {
                            sInfo = "Warn:\n" + sWarn + "\n\n";
                        }
                        sInfo = sInfo + "Err:\n" + sErr;

                        throw new Exception(sInfo);
                    }

                    tran.Commit();

                    MessageBox.Show("CHECK OK");
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void btnExportIN_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = txtInvoiceNO.Text.Trim();
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridViewIN.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnExportPL_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = txtInvoiceNO.Text.Trim();
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridViewPL.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
