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
    public partial class ImportRdrecord01 : UserControl
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

                SetLookup();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public ImportRdrecord01()
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
                if(txtCurrency.Text.Trim() == "")
                {
                    throw new Exception("Please set currency");
                }

                decimal dExch = BaseFunction.ReturnDecimal(txtExchangeRate.Text.Trim());
                if(dExch ==0)
                {
                    throw new Exception("Please set the exchange rate");
                }

                if (lookUpEditWarehouse.EditValue == null || lookUpEditWarehouse.Text.Trim() == "")
                {
                    lookUpEditWarehouse.Focus();
                    throw new Exception("Please choose warehouse");
                }

                int iCou = gridViewPL.RowCount;
                if (iCou == 0)
                {
                    throw new Exception("no data");
                }
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    DateTime dLogDate = BaseFunction.ReturnDate(sLogDate);

                    string sWhCode = lookUpEditWarehouse.Text.Trim();
                    string sRdCode = "101";

                    string sSQL = @"
select * from _Code where VouchType = 'RdRecord01'
";
                    DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtCode != null && dtCode.Rows.Count > 0)
                    {
                        sRdCode = dtCode.Rows[0]["cRdCodeIn"].ToString().Trim();
                    }

                    //string sDate = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                    string sDate = sLogDate;
                    sSQL = @"
select bflag_ST from gl_mend where iyear = aaaaaa and iperiod = bbbbbb
";
                    sSQL = sSQL.Replace("aaaaaa", dLogDate.Year.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dLogDate.Month.ToString());
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (BaseFunction.ReturnBool(dtTemp.Rows[0]["bflag_ST"]))
                    {
                        throw new Exception("The current date has been checked out");
                    }

                    string sDateTime = dateEditQuery.DateTime.ToString("yyyy-MM-dd");

//                    sSQL = @"
//select * from exch where cdate = 'aaaaaa'
//";
//                    sSQL = sSQL.Replace("aaaaaa", dtmBL.DateTime.ToString("yyyy.MM.dd"));
//                    DataTable dtExch = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                    if (dtExch == null || dtExch.Rows.Count == 0)
//                    {
//                        throw new Exception("Please set exchange rate");
//                    }

                    long lID = 0;
                    long lIDs = 0;
                    sSQL = @"
declare @p5 int
set @p5=0
declare @p6 int
set @p6=0
exec sp_GetId N'',N'@AccID',N'rd',@iCou,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("@iCou", iCou.ToString());
                    sSQL = sSQL.Replace("@AccID", sAccID);
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    lID = BaseFunction.ReturnLong(dtTemp.Rows[0][0]);
                    lIDs = BaseFunction.ReturnLong(dtTemp.Rows[0][1]) - iCou;

                    sSQL = @"
select * From VoucherHistory  with (ROWLOCK)  Where  CardNumber='24' and cContent='日期' and cSeed='aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", dLogDate.ToString("yyyyMMdd"));
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long iCode = 0;
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        iCode = BaseFunction.ReturnLong(dtTemp.Rows[0]["cNumber"]) + 1;
                        sSQL = @"
update VoucherHistory set cNumber = aaaaaa where autoid = bbbbbb and CardNumber = '24'
";
                        sSQL = sSQL.Replace("aaaaaa", iCode.ToString());
                        sSQL = sSQL.Replace("bbbbbb", dtTemp.Rows[0]["AutoId"].ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        iCode = 1;
                        sSQL = @"
insert into VoucherHistory(CardNumber, cContent, cContentRule, cSeed, cNumber, bEmpty)
values('24','日期','日','aaaaaa',1,0)
";
                        sSQL = sSQL.Replace("aaaaaa", dLogDate.ToString("yyyyMMdd"));
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = @"
select * from PO_POMain where cPOID = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", gridViewPL.GetRowCellValue(0, gridColPONO).ToString().Trim());
                    DataTable dtPO = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    Model.RdRecord01 mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.RdRecord01();
                    mod.ID = lID;
                    mod.bRdFlag = 1;
                    mod.cVouchType = "01";
                    mod.cBusType = "普通采购";
                    mod.cSource = "采购订单";
                    //mod.cBusCode = 
                    mod.cWhCode = sWhCode;               //在途仓库
                    mod.dDate = dLogDate;

                    //DataRow[] drExch = dtExch.Select("cexch_name = '" + txtCurrency.Text.Trim() + "'");
                    //if (drExch.Length == 0)
                    //{
                    //    throw new Exception("Please set exchange rate");
                    //}
                    mod.iExchRate = dExch;

                    string sCode = iCode.ToString();
                    while (sCode.Length < 4)
                    {
                        sCode = "0" + sCode;
                    }
                    sCode = "RC" + dLogDate.ToString("yyyyMMdd") + sCode;
                    mod.cCode = sCode;
                    mod.cRdCode = sRdCode;
                    mod.cDepCode = "LOG";
                    mod.cPTCode = dtPO.Rows[0]["cPTCode"].ToString().Trim();
                    mod.cVenCode = dtPO.Rows[0]["cVenCode"].ToString().Trim();
                    //mod.cOrderCode = dtPO.Rows[0]["cPOID"].ToString().Trim();
                    mod.bTransFlag = false;
                    mod.cMaker = sUserName;
                    mod.cDefine10 = txtInvoiceNO.Text.Trim();
                    mod.bpufirst = false;
                    mod.biafirst = false;
                    mod.VT_ID = 131313;
                    mod.bIsSTQc = false;
                    mod.ipurorderid = BaseFunction.ReturnLong(dtPO.Rows[0]["POID"]);
                    mod.iTaxRate = BaseFunction.ReturnDecimal(dtPO.Rows[0]["iTaxRate"]);
                    mod.cExch_Name = dtPO.Rows[0]["cExch_Name"].ToString().Trim();
                    mod.bOMFirst = false;
                    mod.bFromPreYear = false;
                    mod.bIsComplement = 0;
                    mod.iDiscountTaxType = 0;
                    mod.ireturncount = 0;
                    mod.iverifystate = 0;
                    mod.iswfcontrolled = 0;
                    mod.dnmaketime = DateTime.Now;
                    mod.bredvouch = 0;
                    mod.bCredit = 0;
                    mod.iPrintCount = 0;
                    mod.csysbarcode = "||st01|" + mod.cCode;

                    mod.cDefine1 = txtBL.Text.Trim();
                    mod.cDefine10 = txtInvoiceNO.Text.Trim();

                    //导入单据审核
                    mod.dVeriDate = mod.dDate;
                    mod.dnverifytime = DateTime.Now;
                    mod.cHandler = mod.cMaker;

                    DAL.RdRecord01 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.RdRecord01();
                    sSQL = dal.Add(mod);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridViewPL.RowCount; i++)
                    {
                        if(!BaseFunction.ReturnBool(gridViewPL.GetRowCellValue(i,gridColSelected)))
                            continue;

                        //判断是否已经生成了采购入库单
                        long lRds01Autoid = BaseFunction.ReturnLong(gridViewPL.GetRowCellValue(i,gridColRds01ID));
                        if (lRds01Autoid > 0)
                        {
                            sSQL = @"
select autoid from Rdrecords01 where autoid = aaaaaaaa
";
                            sSQL = sSQL.Replace("aaaaaaaa", lRds01Autoid.ToString());
                            DataTable dtRds01 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            if (dtRds01 != null && dtRds01.Rows.Count > 0)
                            {
                                sErr = sErr + "Line " + (i + 1).ToString() + " is imported\n";
                                continue;
                            }
                        }

                        string sPONO = gridViewPL.GetRowCellValue(i, gridColPONO).ToString().Trim();
                        string sInvCode = gridViewPL.GetRowCellValue(i, gridColPARTNO).ToString().Trim();

                        //同一个订单相同子件只能有一个
                        sSQL = @"
select a.cPOID,a.POID,a.cexch_name ,a.cPTCode,a.cVenCode ,a.cBusType ,a.cDepCode 
    ,b.ID,b.cInvCode,b.iQuantity,isnull(b.freceivedqty ,0) as freceivedqty ,b.irowno ,b.ivouchrowno ,isnull(b.fPoArrQuantity ,0) as fPoArrQuantity 
    ,isnull(b.iReceivedQTY ,0) as iReceivedQTY ,isnull(b.iInvQTY ,0) as iInvQTY ,b.iPerTaxRate ,isnull(b.iArrQTY ,0) as iArrQTY 
    ,b.iPerTaxRate 

from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID
where a.cPOID = 'aaaaaa' and b.cInvCode = 'bbbbbb'
";
                        sSQL = sSQL.Replace("aaaaaa", sPONO);
                        sSQL = sSQL.Replace("bbbbbb", sInvCode);
                        DataTable dtPOs = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtPOs == null || dtPOs.Rows.Count == 0)
                        {
                            throw new Exception("Not found the corresponding purchase order");
                        }

                        Model.rdrecords01 mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords01();
                        lIDs += 1;
                        mods.AutoID = lIDs;
                        mods.ID = mod.ID;
                        mods.cInvCode = sInvCode;

                        decimal dQty = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColQUANTITY));
                        decimal dPOQty = BaseFunction.ReturnDecimal(dtPOs.Rows[0]["iQuantity"]);
                        decimal dArrQty = BaseFunction.ReturnDecimal(dtPOs.Rows[0]["iReceivedQTY"]);

                        mods.iTaxRate = BaseFunction.ReturnDecimal(dtPOs.Rows[0]["iPerTaxRate"]);
                        mods.iQuantity = dQty;
                        mods.iOriCost = BaseFunction.ReturnDecimal(gridViewPL.GetRowCellValue(i, gridColUnitPrice));    //原币无税单价 
                        mods.iOriTaxCost = BaseFunction.ReturnDecimal(mods.iOriCost * (1 + mods.iTaxRate / 100));       //原币含税单价                                            
                        mods.iOriMoney = BaseFunction.ReturnDecimal(mods.iOriCost * mods.iQuantity, 2);                //原币无税金额
                        mods.ioriSum = BaseFunction.ReturnDecimal(mods.iOriTaxCost * mods.iQuantity, 2);                //原币含税金额
                        mods.iOriTaxPrice = mods.ioriSum - mods.iOriMoney;                                              //税额

                        mods.iUnitCost = BaseFunction.ReturnDecimal(mods.iOriCost * mod.iExchRate);                     //单价
                        mods.iPrice = BaseFunction.ReturnDecimal(mods.iUnitCost * dQty, 2);                             //金额
                        mods.iSum = BaseFunction.ReturnDecimal(mods.ioriSum * mod.iExchRate, 2);                        //本币价税合计
                        mods.iTaxPrice = mods.iSum - mods.iPrice;                                                       //本币税额
                        mods.bTaxCost = true;

                        mods.fACost = mods.iUnitCost;                                                                   //暂估单价
                        mods.iAPrice = mods.iSum;                                                                       //暂估金额

                        mods.iMoney = 0;                                                                                //累计结算金额

                        mods.iFlag = 0;
                        mods.iSQuantity = 0;
                        mods.iSNum = 0;
                        mods.iPOsID = BaseFunction.ReturnLong(dtPOs.Rows[0]["ID"]);
                        mods.iNQuantity = dQty;
                        mods.chVencode = dtPOs.Rows[0]["cVenCode"].ToString().Trim();
                        mods.cPOID = dtPOs.Rows[0]["cPOID"].ToString().Trim();
                        mods.iMatSettleState = 0;
                        mods.iBillSettleCount = 0;
                        mods.bLPUseFree = false;
                        mods.iOriTrackID = 0;
                        mods.bCosting = true;
                        mods.iExpiratDateCalcu = 0;
                        mods.isotype = 0;
                        mods.irowno = i + 1;
                        mods.cbsysbarcode = "||st01|" + mod.cCode + "|" + mods.irowno.ToString();
                        mods.cDefine22 = gridViewPL.GetRowCellValue(i, gridColCONTAINERNO).ToString().Trim();
                        mods.cDefine23 = gridViewPL.GetRowCellValue(i, gridColBOXNO).ToString().Trim();
                        mods.cDefine24 = gridViewPL.GetRowCellValue(i, gridColCASENO).ToString().Trim();
                        mods.cDefine25 = gridViewPL.GetRowCellValue(i, gridColGWKGS).ToString().Trim();
                        mods.cDefine28 = gridViewPL.GetRowCellValue(i, gridColNWKGS).ToString().Trim();

                        DAL.rdrecords01 dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords01();
                        sSQL = dals.Add(mods);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
if exists
    (select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
        and isnull(cFree1,'') = @cFree1 
        and isnull(cFree2,'') = @cFree2
        and isnull(cFree3,'') = @cFree3
        and isnull(cFree4,'') = @cFree4
        and isnull(cFree5,'') = @cFree5
        and isnull(cFree6,'') = @cFree6
        and isnull(cFree7,'') = @cFree7
        and isnull(cFree8,'') = @cFree8
        and isnull(cFree9,'') = @cFree9
        and isnull(cFree10,'') = @cFree10
        and isnull(cBatch,'') = @cBatch 
    )
  	update  CurrentStock set iQuantity = isnull(iQuantity,0) + @iQuantity  
    where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' 
        and isnull(cFree1,'') = @cFree1 
        and isnull(cFree2,'') = @cFree2
        and isnull(cFree3,'') = @cFree3
        and isnull(cFree4,'') = @cFree4
        and isnull(cFree5,'') = @cFree5
        and isnull(cFree6,'') = @cFree6
        and isnull(cFree7,'') = @cFree7
        and isnull(cFree8,'') = @cFree8
        and isnull(cFree9,'') = @cFree9
        and isnull(cFree10,'') = @cFree10
        and isnull(cBatch,'') = @cBatch 
else 
    begin 
        declare @itemid varchar(20); 
        declare @iCount int;  
        select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode';
        if( @iCount > 0 )
	        select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode';
        else  
            select @itemid=max(itemid+1) from CurrentStock  
            insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid, cFree1, cFree2, cFree3, cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10,cBatch,iSoDid)
            values('@cWhCode','@cInvCode', @iQuantity,isnull(@itemid,1), @cFree1, @cFree2, @cFree3, @cFree4, @cFree5, @cFree6, @cFree7, @cFree8, @cFree9, @cFree10,@cBatch,'') 
    end
";
                        sSQL = sSQL.Replace("@cInvCode", mods.cInvCode);
                        sSQL = sSQL.Replace("@cWhCode", mod.cWhCode);
                        sSQL = sSQL.Replace("@iQuantity", mods.iQuantity.ToString());
                        sSQL = sSQL.Replace("@iNum", mods.iNum.ToString());
                        sSQL = sSQL.Replace("@cFree10", mods.cFree10 == null ? "''" : "'" + mods.cFree10 + "'");
                        sSQL = sSQL.Replace("@cFree1", mods.cFree1 == null ? "''" : "'" + mods.cFree1 + "'");
                        sSQL = sSQL.Replace("@cFree2", mods.cFree2 == null ? "''" : "'" + mods.cFree2 + "'");
                        sSQL = sSQL.Replace("@cFree3", mods.cFree3 == null ? "''" : "'" + mods.cFree3 + "'");
                        sSQL = sSQL.Replace("@cFree4", mods.cFree4 == null ? "''" : "'" + mods.cFree4 + "'");
                        sSQL = sSQL.Replace("@cFree5", mods.cFree5 == null ? "''" : "'" + mods.cFree5 + "'");
                        sSQL = sSQL.Replace("@cFree6", mods.cFree6 == null ? "''" : "'" + mods.cFree6 + "'");
                        sSQL = sSQL.Replace("@cFree7", mods.cFree7 == null ? "''" : "'" + mods.cFree7 + "'");
                        sSQL = sSQL.Replace("@cFree8", mods.cFree8 == null ? "''" : "'" + mods.cFree8 + "'");
                        sSQL = sSQL.Replace("@cFree9", mods.cFree9 == null ? "''" : "'" + mods.cFree9 + "'");
                        sSQL = sSQL.Replace("@cBatch", mods.cBatch == null ? "''" : "'" + mods.cBatch + "'");
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //回写导入中间表 Rdrecords10_Import
                        sSQL = @"
update RdRecords01_Import set Rds01ID = AAAAAA
WHERE AUTOID = BBBBBB
";
                        sSQL = sSQL.Replace("AAAAAA", mods.AutoID.ToString());
                        sSQL = sSQL.Replace("BBBBBB", gridViewPL.GetRowCellValue(i, gridColAutoID).ToString());
                        int iRet = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        if (iRet != 1)
                        {
                            sErr = sErr + "Row " + (i + 1) + " update dl err\n";
                        }

                        //回写采购订单
                        sSQL = @"
update PO_Podetails set iReceivedQTY = isnull(iReceivedQTY,0) + aaaaaa
where ID = bbbbbb
";
                        sSQL = sSQL.Replace("aaaaaa", mods.iQuantity.ToString());
                        sSQL = sSQL.Replace("bbbbbb", mods.iPOsID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = @"
exec ST_SaveForStock N'01',N'aaaaaa',1,0 ,1
";
                    sSQL = sSQL.Replace("aaaaaa", mod.ID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
exec ST_SaveForTrackStock N'01',N'aaaaaa', 0 ,1
";
                    sSQL = sSQL.Replace("aaaaaa", mod.ID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
exec IA_SP_WriteUnAccountVouchForST 'aaaaaa',N'01'
";
                    sSQL = sSQL.Replace("aaaaaa", mod.ID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("Success:" + mod.cCode);

                        SetTxtNull();
                    }
                    else
                    {
                        throw new Exception("Save failed,no data");
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
            //gridControlIN.DataSource = null;
            gridControlPL.DataSource = null;
            txtCompany.Text = "";
            txtInvoiceNO.Text = "";
            dateEdit1.Text = "";
            txtBL.Text = "";
            dtmBL.Text = "";
            lsContaineNO.Text = "";
            lookUpEditWarehouse.EditValue = DBNull.Value;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSEL_ImportRdrecord01 frm = new FrmSEL_ImportRdrecord01();
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                dateEditQuery.DateTime = frm.dtmReturn;
                string sInvoiceNO = frm.sInvoiceNO;
                string sContaineNO = frm.sContainerNO;
                lsContaineNO.Text = sContaineNO;

                GetGrid(sInvoiceNO, sContaineNO);
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();

                SetTxtNull();
            }
        }

        private void GetGrid(string sInvoiceNO, string sContaineNO)
        {

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
            }

            sSQL = @"
SELECT cast(0 as bit) as Selected, a.AutoID, ImportTime, InvoiceNo, Date, Companyname, PONO, CONTAINERNO, PARTNO
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
    ,a.Currency
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
where 1=1 and a.InvoiceNO = 'aaaaaa'
order by a.Autoid
";
            sSQL = sSQL.Replace("aaaaaa", sInvoiceNO);
            if (sContaineNO != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.ContainerNO like '%" + sContaineNO.Trim() + "%'");
            }
            if (radioUnCreated.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(c.Autoid,-1) = -1 ");
            }
            if (radioCreated.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(c.Autoid,-1) <> -1 ");
            }

            DataTable dtPL = DbHelperSQL.Query(sSQL);
            gridControlPL.DataSource = dtPL;
            if (dtPL != null && dtPL.Rows.Count > 0)
            {
                txtCurrency.Text = dtPL.Rows[0]["Currency"].ToString().Trim();
                txtBL.Text = dtPL.Rows[0]["BLNo"].ToString().Trim();
                dtmBL.DateTime = BaseFunction.ReturnDate(dtPL.Rows[0]["BLDate"]);
                gridViewPL.BestFitColumns();

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

            chkSelected.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                setNull();
            }
            catch (Exception ee)
            { 
                
            }
        }

        private void setNull()
        {
            txtInvoiceNO.Text = "";
            dateEdit1.Text = "";
            dtmBL.Text = "";
            txtBL.Text = "";
            txtCompany.Text = "";
            gridControlPL.DataSource = null;
            chkSelected.Checked = false;

        }

        private void SetLookup()
        {
            string sSQL = @"
select cWhCode ,cWhName from Warehouse where cWhcode in ('A00','B00')
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditWarehouse.Properties.DataSource = dt;
        }

        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridViewPL.RowCount; i++)
                {
                    gridViewPL.SetRowCellValue(i, gridColSelected, chkSelected.Checked);
                }
            }
            catch { }
        }

        private void gridViewPL_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8RDCode).ToString().Trim();
                    if (s1 != "")
                    {
                        e.Appearance.BackColor = Color.LightYellow;
                    }
                }
            }
            catch
            {

            }
        }

        private void gridViewPL_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColSelected && e.RowHandle >= 0)
                {
                    bool b = BaseFunction.ReturnBool(gridViewPL.GetRowCellValue(e.RowHandle, gridColSelected));
                    if (b)
                    {
                        string s2 = gridViewPL.GetRowCellValue(e.RowHandle, gridColU8RDCode).ToString().Trim();
                        if (s2 != "")
                        {
                            gridViewPL.SetRowCellValue(e.RowHandle, gridColSelected, false);
                        }
                    }
                }
            }
            catch { }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (txtInvoiceNO.Text.Trim() != "")
            {
                GetGrid(txtInvoiceNO.Text.Trim(), lsContaineNO.Text.Trim());
            }
        }
    }
}
