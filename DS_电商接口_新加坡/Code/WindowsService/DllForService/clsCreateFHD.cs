using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TH.BaseClass;
using System.Collections;
using System.Xml;

namespace DllForService
{
    public class clsCreateFHD
    {
        public void CreateFHD()
        {
            try
            {
                StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + @"【Start】-----------------------------------------------------------");

                string sUFDatabase = GetConfigValue("UFDatabase");
                string sServer = GetConfigValue("ServerInfo");
                string sSQLUid = GetConfigValue("SQLUID");
                string sSQLPwd = GetConfigValue("SQLPWD");

                string sConn = "server=" + sServer + ";uid=" + sSQLUid + " ;pwd=" + sSQLPwd + ";database=" + sUFDatabase + ";";

                string sAccID = sUFDatabase.Substring(7, 3);

                string sErr = "";

                int iCount = 0;

                //获得已审核，未关闭（含行关闭），累计发货数量为0 的订单
                //红字单据不考虑

                DbHelperSQL.connectionString = sConn;

                string sSQL = @"
SELECT     TOP (200) sType, StartTime, EndTime, Next_StartTime,GETDATE() AS dNowTime
FROM         _AutoService
where sType = 'DP'
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                DateTime dStartTime = Convert.ToDateTime(dt.Rows[0]["StartTime"]);
                DateTime dEndTime = Convert.ToDateTime(dt.Rows[0]["EndTime"]);
                DateTime dNext_StartTime = Convert.ToDateTime(dt.Rows[0]["Next_StartTime"]);
                DateTime dNowTime = Convert.ToDateTime(dt.Rows[0]["dNowTime"]);

                if (dNext_StartTime > dNowTime)
                {
                    StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  运行时间未到");
                    return;
                }

                StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  开始运行");

                sSQL = "update _AutoService set StartTime = getdate() where sType = 'DP'";
                DbHelperSQL.ExecuteSql(sSQL);

                sSQL = @"
select distinct a.*
from SO_SOMain a inner join SO_SODetails b on a.id = b.id 
	inner join [dbo].[_DSSaleBaseInfo] c on c.cSTCode = a.cSTCode
where isnull(c.[bDS],0) = 1  and isnull(a.cCloser,'') = '' and isnull(a.cVerifier ,'') <> '' 
    and a.ID not in 
    (
        select id 
        from  SO_SODetails
        where  isnull(iFHQuantity ,0) <> 0 or isnull(cSCloser ,'') <> ''
	)
";
                //测试用语句
//                sSQL = @"
//select distinct a.*
//from SO_SOMain a inner join SO_SODetails b on a.id = b.id 
//	inner join [dbo].[_DSSaleBaseInfo] c on c.cSTCode = a.cSTCode
//where isnull(c.[bDS],0) = 1  and isnull(a.cCloser,'') = '' and isnull(a.cVerifier ,'') <> '' 
//    and a.cSOCode = '20171016000822'
//";
                DataTable dtSO = DbHelperSQL.Query(sSQL);
                StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  加载需要发货的销售订单");

                if (dtSO == null || dtSO.Rows.Count == 0)
                {
                    try
                    {
                        string sSQL2 = @"
update _AutoService set  EndTime = getdate(), Next_StartTime = DATEADD(MINUTE,5,GetDate()) 
where sType = 'DP'
";
                        DbHelperSQL.ExecuteSql(sSQL2);
                    }
                    catch { }
                    return;
                }
                    StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  加载需要发货的销售订单，累计获得订单数量" + dtSO.Rows.Count);
                    for (int i = 0; i < dtSO.Rows.Count; i++)
                    {
                        sErr = "";

                        #region 发货单
                        SqlConnection conn = new SqlConnection(sConn);
                        conn.Open();
                        //启用事务
                        SqlTransaction tran = conn.BeginTransaction();


                        string sSOCode = dtSO.Rows[i]["cSOCode"].ToString().Trim();

                        try
                        {
                            sSQL = @"
select distinct a.*, a.cDefine12 as cWhCode,b.*,inv.cInvName,inv.cInvStd,isnull(inv.bInvBatch ,0) as bInvBatch,d.cRdCode
from SO_SOMain a inner join SO_SODetails b on a.id = b.id 
	inner join [dbo].[_DSSaleBaseInfo] c on c.cSTCode = a.cSTCode
    inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join SaleType d on d.cSTCode = a.cSTCode
where a.cSOCode = 'aaaaaaaa'
";
                            sSQL = sSQL.Replace("aaaaaaaa", sSOCode);
                            DataTable dtSOs = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            string sCusCode = dtSOs.Rows[0]["cCusCode"].ToString().Trim();
                            DateTime dtmSO = BaseFunction.ReturnDate(dtSOs.Rows[0]["dDate"]);

                            sSQL = "select isnull(bflag_SA,0) as bflag from GL_mend where iYPeriod = '" + dtmSO.ToString("yyyyMM") + "'";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt == null || dt.Rows.Count == 0)
                            {
                                StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  单据日期已经结账1");
                                throw new Exception(sSOCode + "当前单据日期已经结帐");
                            }
                            int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                            if (i结账 > 0)
                            {
                                StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  单据日期已经结账2");
                                throw new Exception(sSOCode + "当前单据日期已经结帐");
                            }

                            string sCode = "DP-" + sSOCode;

                            long lID = -1;
                            long lIDDetails = -1;
                            sSQL = @"
                                            declare @p5 int
                                            set @p5=aaaaaa
                                            declare @p6 int
                                            set @p6=bbbbbb
                                            exec sp_GetId N'00',N'dddddd',N'DISPATCH',eeeeee,@p5 output,@p6 output,default
                                            select @p5, @p6
                                            ";
                            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                            sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                            sSQL = sSQL.Replace("dddddd", sAccID);
                            sSQL = sSQL.Replace("eeeeee", dtSOs.Rows.Count.ToString());
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            lID = BaseFunction.ReturnLong(dt.Rows[0][0]);
                            lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - dtSOs.Rows.Count;


                            Model.DispatchList mod = new DllForService.Model.DispatchList();
                            mod.DLID = lID;


                            mod.cDLCode = sCode;
                            mod.cVouchType = "05";
                            mod.cRdCode = dtSOs.Rows[0]["cRdCode"].ToString().Trim();
                            mod.cSTCode = dtSOs.Rows[0]["cSTCode"].ToString().Trim();
                            mod.dDate = dtmSO;
                            mod.bneedbill = true;
                            mod.cDepCode = dtSO.Rows[0]["cDepCode"].ToString().Trim();
                            //mod.cPersonCode = lookUpEditcPersonCode.EditValue.ToString();
                            mod.SBVID = 0;
                            mod.cCusCode = sCusCode;
                            mod.cexch_name = dtSOs.Rows[0]["cexch_name"].ToString().Trim();
                            mod.iExchRate = BaseFunction.ReturnDecimal(dtSOs.Rows[0]["iExchRate"]);
                            mod.iTaxRate = BaseFunction.ReturnDecimal(dtSOs.Rows[0]["iTaxRate"]);
                            mod.bFirst = false;
                            mod.bReturnFlag = false;
                            mod.bSettleAll = false;
                            mod.cMemo = dtSOs.Rows[0]["cMemo"].ToString().Trim();
                            mod.cBusType = dtSOs.Rows[0]["cBusType"].ToString().Trim();
                            mod.cCusName = dtSOs.Rows[0]["cCusName"].ToString().Trim();

                            mod.cDefine1 = dtSOs.Rows[0]["cDefine1"].ToString().Trim();
                            mod.cDefine2 = dtSOs.Rows[0]["cDefine1"].ToString().Trim();
                            mod.cDefine3 = dtSOs.Rows[0]["cDefine3"].ToString().Trim();

                            if (dtSOs.Rows[0]["cDefine4"].ToString().Trim() != "" && BaseFunction.ReturnDate(dtSOs.Rows[0]["cDefine4"]) > BaseFunction.ReturnDate("1901-01-01"))
                            {
                                mod.cDefine4 = BaseFunction.ReturnDate(dtSOs.Rows[0]["cDefine4"]);
                            }
                            if (dtSOs.Rows[0]["cDefine5"].ToString().Trim() != "")
                            {
                                mod.cDefine5 = BaseFunction.ReturnLong(dtSOs.Rows[0]["cDefine5"]);
                            }
                            if (dtSOs.Rows[0]["cDefine6"].ToString().Trim() != "" && BaseFunction.ReturnDate(dtSOs.Rows[0]["cDefine6"]) > BaseFunction.ReturnDate("1901-01-01"))
                            {
                                mod.cDefine6 = BaseFunction.ReturnDate(dtSOs.Rows[0]["cDefine6"]);
                            }
                            if (dtSOs.Rows[0]["cDefine7"].ToString().Trim() != "")
                            {
                                mod.cDefine7 = BaseFunction.ReturnDecimal(dtSOs.Rows[0]["cDefine7"]);
                            }
                            mod.cDefine8 = dtSOs.Rows[0]["cDefine8"].ToString().Trim();
                            mod.cDefine9 = dtSOs.Rows[0]["cDefine9"].ToString().Trim();
                            mod.cDefine10 = dtSOs.Rows[0]["cDefine10"].ToString().Trim();
                            mod.cDefine11 = dtSOs.Rows[0]["cDefine11"].ToString().Trim();
                            mod.cDefine12 = dtSOs.Rows[0]["cDefine12"].ToString().Trim();
                            mod.cDefine13 = dtSOs.Rows[0]["cDefine13"].ToString().Trim();
                            mod.cDefine14 = dtSOs.Rows[0]["cDefine14"].ToString().Trim();
                            if (dtSOs.Rows[0]["cDefine15"].ToString().Trim() != "")
                            {
                                mod.cDefine15 = BaseFunction.ReturnLong(dtSOs.Rows[0]["cDefine15"]);
                            }
                            if (dtSOs.Rows[0]["cDefine16"].ToString().Trim() != "")
                            {
                                mod.cDefine16 = BaseFunction.ReturnDecimal(dtSOs.Rows[0]["cDefine16"]);
                            }

                            mod.iVTid = 71;
                            mod.cMaker = "demo";
                            mod.cMemo = dtSOs.Rows[0]["cMemo"].ToString().Trim();
                            mod.cVerifier = "demo";
                            mod.dverifydate = BaseFunction.ReturnDate(mod.dDate.ToString("yyyy-MM-dd"));
                            mod.dverifydate = mod.dDate;
                            mod.dverifysystime = mod.dDate;
                            mod.cSaleOut = sSOCode;
                            mod.cSysBarCode = "||SA01|" + mod.cDLCode;

                            DAL.DispatchList dal = new DllForService.DAL.DispatchList();

                            sSQL = dal.Add(mod);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  单据表头生成成功：单据第" + (i + 1).ToString() + "");
                            int iRow = 0;

                            for (int j = 0; j < dtSOs.Rows.Count; j++)
                            {
                                decimal dQty = BaseFunction.ReturnDecimal(dtSOs.Rows[j]["iQuantity"]);
                                if (dQty <= 0)
                                    continue;

                                string sInvCode = dtSOs.Rows[j]["cInvCode"].ToString().Trim();
                                string sWhCode = dtSOs.Rows[j]["cWhCode"].ToString().Trim();

                                sSQL = "select sum(iQuantity) as iQty from CurrentStock where cInvCode = 'aaaaaaaa' and cWhCode = 'bbbbbbbb' ";
                                sSQL = sSQL.Replace("aaaaaaaa", sInvCode);
                                sSQL = sSQL.Replace("bbbbbbbb", sWhCode);
                                DataTable dtCurr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtCurr == null || dtCurr.Rows.Count == 0)
                                {
                                    sErr = sErr + sCode + " There are not enough " + sInvCode + " in the warehouse " + sWhCode + "\n";
                                    continue;
                                }

                                decimal dCurrSum = BaseFunction.ReturnDecimal(dtCurr.Rows[0]["iQty"]);
                                if (dCurrSum < dQty)
                                {
                                    sErr = sErr + sCode + " There are not enough " + sInvCode + " in the warehouse " + sWhCode + "\n";
                                    continue;
                                }

                                sSQL = "select * from CurrentStock where isnull(iQuantity,0) > 0 and  cInvCode = 'aaaaaaaa' and cWhCode = 'bbbbbbbb' order by dVDate ";
                                sSQL = sSQL.Replace("aaaaaaaa", sInvCode);
                                sSQL = sSQL.Replace("bbbbbbbb", sWhCode);
                                dtCurr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                for (int k = 0; k < dtCurr.Rows.Count; k++)
                                {
                                    if (dQty <= 0)
                                        break;

                                    decimal dCurr = BaseFunction.ReturnDecimal(dtCurr.Rows[k]["iQuantity"]);

                                    if (dCurr <= 0)
                                        break;

                                    decimal dQtyNow = 0;
                                    if (dCurr <= dQty)
                                    {
                                        dQtyNow = dCurr;
                                        dQty = dQty - dCurr;
                                    }
                                    else
                                    {
                                        dQtyNow = dQty;
                                        dQty = 0;
                                    }

                                    if (dQtyNow <= 0)
                                        break;

                                    Model.DispatchLists mods = new DllForService.Model.DispatchLists();
                                    lIDDetails += 1;
                                    mods.AutoID = lIDDetails;
                                    mods.DLID = mod.DLID;
                                    mods.cWhCode = dtSOs.Rows[j]["cWhCode"].ToString().Trim();
                                    mods.cInvCode = sInvCode;
                                    mods.cInvName = dtSOs.Rows[j]["cInvName"].ToString().Trim();
                                    mods.iQuantity = dQtyNow;
                                    mods.iQuotedPrice = 0;
                                    mods.iUnitPrice = BaseFunction.ReturnDecimal(dtSOs.Rows[j]["iUnitPrice"]);
                                    mods.iTaxUnitPrice = BaseFunction.ReturnDecimal(dtSOs.Rows[j]["iTaxUnitPrice"]);
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
                                    mods.bcosting = true;
                                    mods.iSOsID = BaseFunction.ReturnLong(dtSOs.Rows[j]["iSOsID"]);
                                    mods.iTaxRate = BaseFunction.ReturnDecimal(dtSOs.Rows[j]["iTaxRate"]);
                                    iRow += 1;
                                    mods.irowno = iRow;
                                    if (BaseFunction.ReturnBool(dtSOs.Rows[j]["bInvBatch"]))
                                    {
                                        mods.cBatch = dtCurr.Rows[k]["cBatch"].ToString().Trim();
                                    }


                                    mods.cDefine22 = dtSOs.Rows[j]["cDefine22"].ToString().Trim();
                                    mods.cDefine23 = dtSOs.Rows[j]["cDefine23"].ToString().Trim();
                                    mods.cDefine24 = dtSOs.Rows[j]["cDefine24"].ToString().Trim();
                                    mods.cDefine25 = dtSOs.Rows[j]["cDefine25"].ToString().Trim();

                                    if (dtSOs.Rows[j]["cDefine26"].ToString().Trim() != "")
                                    {
                                        mods.cDefine26 = BaseFunction.ReturnDecimal(dtSOs.Rows[j]["cDefine26"]);
                                    }
                                    if (dtSOs.Rows[j]["cDefine27"].ToString().Trim() != "")
                                    {
                                        mods.cDefine27 = BaseFunction.ReturnDecimal(dtSOs.Rows[j]["cDefine27"]);
                                    }
                                    mods.cDefine28 = dtSOs.Rows[j]["cDefine28"].ToString().Trim();
                                    mods.cDefine29 = dtSOs.Rows[j]["cDefine29"].ToString().Trim();
                                    mods.cDefine30 = dtSOs.Rows[j]["cDefine30"].ToString().Trim();
                                    mods.cDefine31 = dtSOs.Rows[j]["cDefine31"].ToString().Trim();
                                    mods.cDefine32 = dtSOs.Rows[j]["cDefine32"].ToString().Trim();
                                    mods.cDefine33 = dtSOs.Rows[j]["cDefine33"].ToString().Trim();
                                    if (dtSOs.Rows[j]["cDefine34"].ToString().Trim() != "")
                                    {
                                        mods.cDefine34 = BaseFunction.ReturnLong(dtSOs.Rows[j]["cDefine34"]);
                                    }
                                    if (dtSOs.Rows[j]["cDefine35"].ToString().Trim() != "")
                                    {
                                        mods.cDefine35 = BaseFunction.ReturnLong(dtSOs.Rows[j]["cDefine35"]);
                                    }
                                    if (dtSOs.Rows[j]["cDefine36"].ToString().Trim() != "" && BaseFunction.ReturnDate(dtSOs.Rows[j]["cDefine36"]) > BaseFunction.ReturnDate("1901-01-01"))
                                    {
                                        mods.cDefine36 = BaseFunction.ReturnDate(dtSOs.Rows[j]["cDefine36"]);
                                    }
                                    if (dtSOs.Rows[j]["cDefine37"].ToString().Trim() != "" && BaseFunction.ReturnDate(dtSOs.Rows[j]["cDefine37"]) > BaseFunction.ReturnDate("1901-01-01"))
                                    {
                                        mods.cDefine37 = BaseFunction.ReturnDate(dtSOs.Rows[j]["cDefine37"]);
                                    }
                                    mods.bsaleprice = BaseFunction.ReturnBool(dtSOs.Rows[j]["bsaleprice"]); ;

                                    DAL.DispatchLists dals = new DllForService.DAL.DispatchLists();
                                    sSQL = dals.Add(mods);
                                    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = @"
if exists(select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode') 
	update  CurrentStock set fOutQuantity = isnull(fOutQuantity,0) + @dQty  where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'  and isnull(cBatch,'') = @cBatch 
else 
	begin 
		declare @itemid varchar(20); 
		declare @iCount int;  
		select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' and isnull(cBatch,'') = @cBatch 
		if( @iCount > 0 ) 
			select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' and isnull(cBatch,'') = @cBatch 
		else  
			select @itemid=max(itemid+1) from CurrentStock  
		
		insert into CurrentStock(cWhCode,cInvCode,fOutQuantity,itemid,cBatch)values('@cWhCode','@cInvCode', @dQty ,@itemid,@cBatch) 
	end
                        ";
                                    sSQL = sSQL.Replace("@cInvCode", mods.cInvCode);
                                    sSQL = sSQL.Replace("@cWhCode", mods.cWhCode);
                                    sSQL = sSQL.Replace("@dQty", mods.iQuantity.ToString());
                                    if (BaseFunction.ReturnBool(dtSOs.Rows[j]["bInvBatch"]))
                                    {
                                        sSQL = sSQL.Replace("@cBatch", "'" + mods.cBatch + "'");
                                    }
                                    else
                                    {
                                        sSQL = sSQL.Replace("@cBatch", "''");
                                    }
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "update SO_SODetails set iFHQuantity = isnull(iFHQuantity,0) + " + mods.iQuantity + ",iFHMoney = isnull(iFHMoney,0) + " + mods.iSum + " where iSOsID = " + mods.iSOsID;
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                                    StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  单据表头生成成功：单据第" + (i + 1).ToString() + "，行" + (j + 1).ToString());
                                }
                            }


                            int iTest = iRow - dtSOs.Rows.Count;
                            sSQL = @"
update  UFSystem..UA_Identity set iChildId = iChildId + {0} WHERE   (cAcc_Id = '001') AND (cVouchType = 'DISPATCH')
";
                            sSQL = string.Format(sSQL, iTest);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);



                            if (sErr != "")
                            {
                                throw new Exception(sErr);
                            }

                            #region 销售出库单


                            StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  生成销售出库单，开始");

                            //获得发货单有多少仓库，每个仓库有几行记录出库
                            sSQL = @"
select  b.cWhCode,count(1) as iCou
from DispatchList a  inner join DispatchLists b on a.DLID = b.DLID
	inner join [dbo].[_DSSaleBaseInfo] c on c.cSTCode = a.cSTCode
    inner join Inventory inv on b.cInvCode = inv.cInvCode
    inner join SaleType d on d.cSTCode = a.cSTCode
where a.cDLCode = 'aaaaaa'
group by b.cWhCode 
";
                            sSQL = sSQL.Replace("aaaaaa", mod.cDLCode);
                            DataTable dtWh = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            for (int iii = 0; iii < dtWh.Rows.Count; iii++)
                            {
                                string sRDCode = "";

                                sSQL = @"
select * 
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join SaleType c on c.cSTCode = a.cSTCode
    inner join Inventory inv on inv.cInvCode = b.cInvCode
where a.cDLCode = 'aaaaaa' and b.cWhCode = 'bbbbbb'
order by AutoID
";
                                sSQL = sSQL.Replace("aaaaaa", mod.cDLCode);
                                sSQL = sSQL.Replace("bbbbbb", dtWh.Rows[iii]["cWhCode"].ToString().Trim());
                                DataTable dtDispatchList = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtDispatchList == null || dtDispatchList.Rows.Count == 0)
                                {
                                    throw new Exception(sCode + " is not exists");
                                }

                                sSQL = "select isnull(bflag_ST,0) as bflag from GL_mend where iYPeriod = '" + mod.dDate.ToString("yyyyMM") + "'";
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt == null || dt.Rows.Count == 0)
                                {
                                    throw new Exception("Access module state failure");
                                }
                                i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                                if (i结账 > 0)
                                {
                                    throw new Exception(mod.dDate.ToString("yyyy-MM") + " have checked out");
                                }

                                lID = -1;
                                lIDDetails = -1;
                                sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',eeeeee,@p5 output,@p6 output,default
select @p5, @p6
                    ";
                                sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                                sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                                sSQL = sSQL.Replace("dddddd", sAccID);
                                sSQL = sSQL.Replace("eeeeee", dtWh.Rows[iii]["iCou"].ToString().Trim());
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                lID = BaseFunction.ReturnLong(dt.Rows[0][0]);
                                lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - BaseFunction.ReturnInt(dtWh.Rows[iii]["iCou"]);

                                if (dt == null || dt.Rows.Count == 0)
                                {
                                    throw new Exception(sCode + " is not exists");
                                }

                                Model.rdrecord32 modRD = new DllForService.Model.rdrecord32();
                                modRD.ID = lID;
                                modRD.bRdFlag = 0;
                                modRD.cVouchType = "32";
                                modRD.cBusType = mod.cBusType;
                                modRD.cSource = "发货单";
                                modRD.cBusCode = mod.cDLCode;
                                modRD.cWhCode = dtWh.Rows[iii]["cWhCode"].ToString().Trim();
                                modRD.dDate = mod.dDate;
                                modRD.cCode = "RD-" + modRD.cWhCode + "-" + sSOCode;


                                if (sRDCode == "")
                                {
                                    sRDCode = modRD.cCode;
                                }
                                else
                                {
                                    sRDCode = sRDCode + "，" + modRD.cCode;
                                }

                                modRD.cDepCode = mod.cDepCode;
                                modRD.cPersonCode = mod.cPersonCode;
                                modRD.cSTCode = mod.cSTCode;
                                modRD.cRdCode = dtDispatchList.Rows[0]["cRdCode"].ToString().Trim();
                                modRD.cCusCode = mod.cCusCode;
                                modRD.cDLCode = mod.DLID;
                                modRD.bTransFlag = false;
                                modRD.cMaker = "demo";
                                modRD.cDefine1 = mod.cDefine1;
                                modRD.cDefine2 = mod.cDefine2;
                                modRD.cDefine3 = mod.cDefine3;
                                modRD.cDefine4 = mod.cDefine4;
                                modRD.cDefine5 = mod.cDefine5;
                                modRD.cDefine6 = mod.cDefine6;
                                modRD.cDefine7 = mod.cDefine7;
                                modRD.cDefine8 = mod.cDefine8;
                                modRD.cDefine9 = mod.cDefine9;
                                modRD.cDefine10 = mod.cDefine10;
                                modRD.cDefine11 = mod.cDefine11;
                                modRD.cDefine12 = mod.cDefine12;
                                modRD.cDefine13 = mod.cDefine13;
                                modRD.cDefine14 = mod.cDefine14;
                                modRD.cDefine15 = mod.cDefine15;
                                modRD.cDefine16 = mod.cDefine16;
                                modRD.bpufirst = false;
                                modRD.biafirst = false;
                                modRD.VT_ID = 87;
                                modRD.bIsSTQc = false;
                                modRD.bFromPreYear = false;
                                modRD.bIsComplement = 0;
                                modRD.iDiscountTaxType = 0;
                                modRD.ireturncount = 0;
                                modRD.iverifystate = 0;
                                modRD.iswfcontrolled = 0;
                                modRD.dnmaketime = mod.dverifysystime;
                                modRD.bredvouch = 0;
                                modRD.iPrintCount = 0;
                                modRD.cinvoicecompany = modRD.cCusCode;
                                modRD.dnmaketime = mod.dDate;
                                modRD.csysbarcode = "||st32|" + modRD.cCode;
                                modRD.cHandler = "demo";
                                modRD.dnverifytime = mod.dverifysystime;
                                modRD.dVeriDate = mod.dverifydate;

                                DAL.rdrecord32 dalRD = new DllForService.DAL.rdrecord32();
                                sSQL = dalRD.Add(modRD);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                int iRDRow = 0;
                                for (int jj = 0; jj < dtDispatchList.Rows.Count; jj++)
                                {
                                    if (dtDispatchList.Rows[jj]["cWhCode"].ToString().Trim() != modRD.cWhCode)
                                        continue;

                                    decimal dOutSum = BaseFunction.ReturnDecimal(dtDispatchList.Rows[jj]["fOutQuantity"]);
                                    if (dOutSum > 0)
                                    {
                                        sErr = sErr + "Item No " + dtDispatchList.Rows[jj]["cInvCode"].ToString() + " No.Site list " + dtDispatchList.Rows[jj]["cDefine10"].ToString() + " is used\n";
                                        continue;
                                    }

                                    iRDRow += 1;
                                    Model.rdrecords32 modRDs = new DllForService.Model.rdrecords32();
                                    lIDDetails += 1;
                                    modRDs.AutoID = lIDDetails;
                                    modRDs.ID = modRD.ID;
                                    modRDs.cInvCode = dtDispatchList.Rows[jj]["cInvCode"].ToString().Trim();
                                    modRDs.iQuantity = BaseFunction.ReturnDecimal(dtDispatchList.Rows[jj]["iQuantity"]);
                                    modRDs.iNum = BaseFunction.ReturnDecimal(dtDispatchList.Rows[jj]["iNum"]);

                                    sSQL = "select sum(iQuantity) as iQty from CurrentStock where cWhCode = 'aaaaaa' and cInvCode = 'bbbbbb'";
                                    sSQL = sSQL.Replace("aaaaaa", modRD.cWhCode);
                                    sSQL = sSQL.Replace("bbbbbb", modRDs.cInvCode);
                                    DataTable dtCurr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    if (dtCurr == null || dtCurr.Rows.Count == 0)
                                    {
                                        sErr = sErr + "Item No " + dtDispatchList.Rows[jj]["cInvCode"].ToString() + " not enough\n";
                                        continue;
                                    }
                                    decimal dCurr = BaseFunction.ReturnDecimal(dtCurr.Rows[0]["iQty"]);
                                    if (dCurr < modRDs.iQuantity)
                                    {
                                        sErr = sErr + "Item No  " + dtDispatchList.Rows[jj]["cInvCode"].ToString() + " not enough\n";
                                        continue;
                                    }
                                    //modRDs.iUnitCost = BaseFunction.ReturnDecimal(dtDispatchList.Rows[jj]["iUnitPrice"]);
                                    //modRDs.iPrice = BaseFunction.ReturnDecimal(dtDispatchList.Rows[jj]["iMoney"]);
                                    modRDs.iFlag = 0;
                                    modRDs.iDLsID = BaseFunction.ReturnLong(dtDispatchList.Rows[jj]["iDLsID"]);
                                    modRDs.iNQuantity = modRDs.iQuantity;
                                    modRDs.iNNum = modRDs.iNum;
                                    modRDs.bLPUseFree = false;
                                    modRDs.iRSRowNO = 0;
                                    modRDs.iOriTrackID = 0;
                                    modRDs.bCosting = true;
                                    modRDs.bVMIUsed = false;
                                    modRDs.cbdlcode = sCode;
                                    modRDs.iExpiratDateCalcu = 0;
                                    modRDs.ccusinvcode = dtDispatchList.Rows[jj]["ccusinvcode"].ToString().Trim();
                                    modRDs.iordertype = 0;
                                    modRDs.ipesotype = 0;
                                    modRDs.isotype = 0;
                                    modRDs.irowno = iRDRow;
                                    modRDs.bIAcreatebill = false;
                                    modRDs.bsaleoutcreatebill = false;
                                    modRDs.bneedbill = true;
                                    modRDs.cBatch = dtDispatchList.Rows[jj]["cBatch"].ToString().Trim();


                                    modRDs.cDefine22 = dtDispatchList.Rows[jj]["cDefine22"].ToString().Trim();
                                    modRDs.cDefine23 = dtDispatchList.Rows[jj]["cDefine23"].ToString().Trim();
                                    modRDs.cDefine24 = dtDispatchList.Rows[jj]["cDefine24"].ToString().Trim();
                                    modRDs.cDefine25 = dtDispatchList.Rows[jj]["cDefine25"].ToString().Trim();
                                    if (dtDispatchList.Rows[jj]["cDefine26"].ToString().Trim() != "")
                                    {
                                        modRDs.cDefine26 = BaseFunction.ReturnDecimal(dtDispatchList.Rows[jj]["cDefine26"]);
                                    }
                                    if (dtDispatchList.Rows[jj]["cDefine27"].ToString().Trim() != "")
                                    {
                                        modRDs.cDefine27 = BaseFunction.ReturnDecimal(dtDispatchList.Rows[jj]["cDefine27"]);
                                    }
                                    modRDs.cDefine28 = dtDispatchList.Rows[jj]["cDefine28"].ToString().Trim();
                                    modRDs.cDefine29 = dtDispatchList.Rows[jj]["cDefine29"].ToString().Trim();
                                    modRDs.cDefine30 = dtDispatchList.Rows[jj]["cDefine30"].ToString().Trim();
                                    modRDs.cDefine31 = dtDispatchList.Rows[jj]["cDefine31"].ToString().Trim();
                                    modRDs.cDefine32 = dtDispatchList.Rows[jj]["cDefine32"].ToString().Trim();
                                    modRDs.cDefine33 = dtDispatchList.Rows[jj]["cDefine33"].ToString().Trim();
                                    if (dtDispatchList.Rows[jj]["cDefine34"].ToString().Trim() != "")
                                    {
                                        modRDs.cDefine34 = BaseFunction.ReturnInt(dtDispatchList.Rows[jj]["cDefine34"]);
                                    }
                                    if (dtDispatchList.Rows[jj]["cDefine35"].ToString().Trim() != "")
                                    {
                                        modRDs.cDefine35 = BaseFunction.ReturnInt(dtDispatchList.Rows[jj]["cDefine35"]);
                                    }
                                    if (dtDispatchList.Rows[jj]["cDefine36"].ToString().Trim() != "" && BaseFunction.ReturnDate(dtDispatchList.Rows[jj]["cDefine36"]) > BaseFunction.ReturnDate("1901-01-01"))
                                    {
                                        modRDs.cDefine36 = BaseFunction.ReturnDate(dtDispatchList.Rows[jj]["cDefine36"]);
                                    }
                                    if (dtDispatchList.Rows[jj]["cDefine37"].ToString().Trim() != "" && BaseFunction.ReturnDate(dtDispatchList.Rows[jj]["cDefine37"]) > BaseFunction.ReturnDate("1901-01-01"))
                                    {
                                        modRDs.cDefine37 = BaseFunction.ReturnDate(dtDispatchList.Rows[jj]["cDefine37"]);
                                    }


                                    DAL.rdrecords32 dals = new DllForService.DAL.rdrecords32();
                                    sSQL = dals.Add(modRDs);
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = @"
if exists(select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode') 
	update  CurrentStock set fOutQuantity = isnull(fOutQuantity,0) - @dQty ,iQuantity = isnull(iQuantity,0) - @dQty  where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'  and isnull(cBatch,'') = @cBatch 
else 
	begin 
		declare @itemid varchar(20); 
		declare @iCount int;  
		select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' and isnull(cBatch,'') = @cBatch 
		if( @iCount > 0 ) 
			select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' and isnull(cBatch,'') = @cBatch 
		else  
			select @itemid=max(itemid+1) from CurrentStock  
		
		insert into CurrentStock(cWhCode,cInvCode,fOutQuantity,iQuantity,itemid,cBatch)values('@cWhCode','@cInvCode', -1 * @dQty, -1 * @dQty ,@itemid,@cBatch) 
	end
";
                                    sSQL = sSQL.Replace("@cInvCode", modRDs.cInvCode);
                                    sSQL = sSQL.Replace("@cWhCode", modRD.cWhCode);
                                    sSQL = sSQL.Replace("@dQty", modRDs.iQuantity.ToString());
                                    if (BaseFunction.ReturnBool(dtDispatchList.Rows[jj]["bInvBatch"]))
                                    {
                                        sSQL = sSQL.Replace("@cBatch", "'" + modRDs.cBatch + "'");
                                    }
                                    else
                                    {
                                        sSQL = sSQL.Replace("@cBatch", "''");
                                    }
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "update DispatchLists set fOutQuantity = iQuantity where Autoid = " + dtDispatchList.Rows[jj]["Autoid"].ToString().Trim();
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = @"
insert into [IA_ST_UnAccountVouch32]( IDUN, IDSUN, cVouTypeUN, cBustypeUN)
values({0},{1},'32','普通销售')
";
                                    sSQL = string.Format(sSQL, modRD.ID, modRDs.AutoID);
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                }

                                CreateLog(sConn, sSOCode, mod.cDLCode, sRDCode, "Success", "");
                            }

                            StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  生成销售出库单，完成");

                            if (sErr != "")
                            {
                                throw new Exception(sErr);
                            }

                            #endregion

                            tran.Commit();
                        }
                        catch (Exception ee)
                        {
                            StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  " + ee.Message.ToString());
                            CreateLog(sConn, sSOCode, "", "", "Error", ee.Message);
                            tran.Rollback();
                        }

                        #endregion
                    }
            }
            catch (Exception ee)
            {
                StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + "  " + ee.Message.ToString());
                
                throw new Exception(ee.Message);
            }
            finally
            {

                StreamWriter(DateTime.Now.ToString("yyyyMMddHHmmss") + @"【End】-----------------------------------------------------------");
                StreamWriter("");
                StreamWriter("");
            }

        }

        private void CreateLog(string sConn, string cSoCode, string DisCode, string RdCode, string Status, string Remark)
        {
            try
            {
                SqlConnection conn = new SqlConnection(sConn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";

                try
                {
                    Model._CreateDisInfo mod = new DllForService.Model._CreateDisInfo();
                    mod.cSOCode = cSoCode;
                    mod.DisCode = DisCode;
                    mod.RdCode = RdCode;
                    mod.Status = Status;
                    mod.CreateDate = DateTime.Now;
                    mod.Remark = Remark;
                    DAL._CreateDisInfo dal = new DllForService.DAL._CreateDisInfo();

                    sSQL = dal.Exists(mod.cSOCode);
                    bool b = BaseFunction.ReturnBool(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (b)
                    {
                        sSQL = dal.Update(mod);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        sSQL = dal.Add(mod);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    Model._CreateDisInfo_Log mod_log = new DllForService.Model._CreateDisInfo_Log();
                    mod_log.cSOCode = cSoCode;
                    mod_log.DisCode = DisCode;
                    mod_log.RdCode = RdCode;
                    mod_log.Status = Status;
                    mod_log.CreateDate = DateTime.Now;
                    mod_log.Remark = Remark;
                    DAL._CreateDisInfo_Log dal_log = new DllForService.DAL._CreateDisInfo_Log();
                    sSQL = dal_log.Add(mod_log);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                }

            }
            catch (Exception ee)
            {

            }
        }

        public string GetConfigValue(string appKey)
        {

            string path = clsGetPath.GetWindowsServiceInstallPath("U8DS");                                        //服务器使用
            //string path = @"D:\WorkSpace\工作项目\DS_电商接口_新加坡_u8v12.5\Code\WindowsService\out\Config.xml";   //本机测试
            path = path.Replace("U8DS.exe", "Config.xml");
            path = path.Replace("\"", "");

            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception ee)
            {
                return "";
            }
        }

        private void StreamWriter(string p)
        {

            //string path = clsGetPath.GetWindowsServiceInstallPath("U8DS"); ;
            //path = path.Replace("U8DS.exe", "");
            //path = path.Replace("\"", "");

            //string s = path + @"log";
            //if (!System.IO.Directory.Exists(s))
            //{
            //    System.IO.Directory.CreateDirectory(s);
            //}

            //string sP = path + @"\log\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            //if (!System.IO.File.Exists(sP))
            //{
            //    System.IO.File.Create(sP);
            //}

            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sP, true))
            //{
            //    sw.WriteLine(p + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss "));
            //}
        }
    }
}
