using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TH.BaseClass;

namespace ClsU8
{
    public class clsRdrecord10
    {

        public string sRdrecord10_Save(SqlTransaction tran, string sWOCode,string sZJCode, string sWhCode, string sRdCode, string sDepCode, string sCreater, DateTime dDate, string sInvCode,string sBatch, decimal dQty,string sAccID)
        {
            string sReturn = "";
            try
            {
                int iCou = 0;

                string sSQL = "select isnull(bflag_ST,0) as bflag from GL_mend where iYPeriod = '" + dDate.ToString("yyyyMM") + "'";
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得模块状态失败");
                }
                int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                if (i结账 > 0)
                {
                    throw new Exception(dDate.ToString("yyyy-MM") + " 已经结账");
                }

                sSQL = @"
select * from AccInformation  Where cSysId =N'ST' and  cName= N'bProductInCheck'
";
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                bool bRD10ChangeCurrentStock = BaseFunction.ReturnBool(dt.Rows[0]["cValue"]);


                //------------------------------------------------------
                sSQL = "select getdate()";
                DateTime d当前服务器时间 = Convert.ToDateTime(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                //1.   判断是否结账
                sSQL = "select * from gl_mend where iyear=year(getdate()) and iperiod=month(getdate())";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count < 1)
                {
                    throw new Exception("判断模块结账失败");
                }
                int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_ST"]);
                if (iR == 1)
                {
                    throw new Exception("当前月份已经结账");
                }

                bool bCheckToCurrQty = false;
                sSQL = " select ISNULL(cValue,0) as cValue from accinformation where cname=N'bProductInCheck'";
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp != null && BaseFunction.ReturnBool(dtTemp.Rows[0]["cValue"]))
                {
                    bCheckToCurrQty = true;
                }


                //2. 获得单据ID
                long lID = 1;
                long lIDDetail = 1;

                sSQL = @"
declare @p5 int
set @p5=0
declare @p6 int
set @p6=0
exec sp_GetId N'',N'888',N'rd',1,@p5 output,@p6 output,default
select @p5, @p6
";
                sSQL = sSQL.Replace("888", sAccID);
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                lID = BaseFunction.ReturnLong(dtTemp.Rows[0][0]);
                lIDDetail = BaseFunction.ReturnLong(dtTemp.Rows[0][1]);


                //3. 获得单据号
                long iCode = 0;
                sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='0411'";
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count < 1)
                {
                    iCode = 1;
                }
                else
                {
                    iCode = BaseFunction.ReturnLong(dtTemp.Rows[0]["cNumber"]) + 1;
                }
                sSQL = @"
update VoucherHistory set cNumber = {0}
where CardNumber='0411'
";
                sSQL = string.Format(sSQL, iCode);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                string sCode = iCode.ToString();
                while (sCode.Length < 5)
                {
                    sCode = "0" + sCode;
                }
                sCode = dDate.ToString("yyyyMM") + sCode;


                sSQL = @"
select * 
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
    inner join Inventory inv on b.InvCode = inv.cInvCode
where a.mocode = '{0}'
";
                sSQL = string.Format(sSQL, sWOCode);
                DataTable dtWO = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtWO == null || dtWO.Rows.Count < 1)
                {
                    throw new Exception("获得生产订单信息失败");
                }

                if (BaseFunction.ReturnInt(dtWO.Rows[0]["Status"]) != 3)
                {
                    throw new Exception("生产订单状态不正确，非审核状态");
                }
                if (dtWO.Rows[0]["InvCode"].ToString().Trim() != sInvCode)
                {
                    throw new Exception("生产订单与产品不匹配");
                }

                sSQL = @"
SELECT distinct a.*
FROM QMCHECKVOUCHER a inner join QMCHECKVOUCHERS  b on a.ID = b.ID
WHERE a.CVOUCHTYPE = 'QM04' and a.CCHECKCODE = '{0}'
";
                sSQL = string.Format(sSQL, sZJCode);
                DataTable dtZJ = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (sZJCode != "")
                {
                    if (BaseFunction.ReturnInt(dtZJ.Rows[0]["IVERIFYSTATE"]) != 1)
                    {
                        throw new Exception("检验单未审核");
                    }

                    decimal dBJQty = BaseFunction.ReturnDecimal(dtZJ.Rows[0]["FQUANTITY"]);
                    decimal dFsumQuantity = BaseFunction.ReturnDecimal(dtZJ.Rows[0]["FsumQuantity"]);

                    if (dBJQty < dFsumQuantity + dQty)
                    {
                        throw new Exception("入库数量超报检数量");
                    }

                    if (dtWO.Rows[0]["InvCode"].ToString().Trim() != dtZJ.Rows[0]["CINVCODE"].ToString().Trim())
                    {
                        throw new Exception("生产订单与检验单不匹配");
                    }
                }


                //组装表头
                string sMOID = dtWO.Rows[0]["MOID"].ToString().Trim();

                Model.rdrecord10 mod = new ClsU8.Model.rdrecord10();
                mod.ID = lID;
                mod.bRdFlag = 1;
                mod.cVouchType = "10";
                mod.cBusType = "成品入库";
                if (sZJCode != "")
                {
                    mod.cSource = "产品检验单";
                }
                else
                {
                    mod.cSource = "生产订单";
                }
                mod.cWhCode = sWhCode;
                mod.dDate = dDate;
                mod.cCode = sCode;

                //if (dtWO.Rows[0]["cInvDepCode "].ToString().Trim() != "")
                //{
                //    mod.cDepCode = dtWO.Rows[0]["cInvDepCode "].ToString().Trim();
                //}
                mod.cDepCode = sDepCode;
                mod.cProBatch = sBatch;


                mod.cRdCode = sRdCode;
                mod.bTransFlag = false;
                mod.cMaker = sCreater;
                mod.bpufirst = false;
                mod.biafirst = false;
                mod.iMQuantity = 0;
                mod.VT_ID = 63;
                mod.bIsSTQc = false;
                mod.cMPoCode = sWOCode;

                mod.iproorderid = 0;
                mod.bFromPreYear = false;
                mod.bIsComplement = 0;
                mod.iDiscountTaxType = 0;
                mod.ireturncount = 0;
                mod.iswfcontrolled = 0;
                mod.dnmaketime = DateTime.Now;
                mod.bredvouch = 0;
                mod.iPrintCount = 0;
                mod.csysbarcode = "||st10|" + mod.cCode;

                mod.iproorderid = BaseFunction.ReturnLong(dtWO.Rows[0]["moid"]);
                mod.dnmaketime = dDate;

                ////审核
                //mod.cHandler = sCreater;
                //mod.dVeriDate = dDate;
                //mod.dnverifytime = mod.dnmaketime;

                DAL.rdrecord10 dal = new ClsU8.DAL.rdrecord10();
                sSQL = dal.Add(mod);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                sSQL = @"
select * from Inventory where cInvCode = '{0}'
";
                sSQL = string.Format(sSQL, sInvCode);
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count == 0)
                {
                    throw new Exception("存货 " + sInvCode + " 不存在");
                }

                Model.rdrecords10 mods = new ClsU8.Model.rdrecords10();
                mods.AutoID = lIDDetail;
                mods.ID = lID;
                mods.cInvCode = sInvCode;
                //mods.iNum = 
                mods.iQuantity = dQty;
                if (sBatch != "")
                {
                    mods.cBatch = sBatch;
                }

                if (dtZJ == null || dtZJ.Rows.Count == 0)
                {
                    mods.iNQuantity = BaseFunction.ReturnDecimal(dtWO.Rows[0]["Qty"]);
                }
                else
                {
                    mods.iNQuantity = BaseFunction.ReturnDecimal(dtZJ.Rows[0]["FQUANTITY"]);

                    mods.iCheckIdBaks = BaseFunction.ReturnLong(dtZJ.Rows[0]["ID"]);
                    mods.cCheckPersonCode = dtZJ.Rows[0]["CCHECKPERSONCODE"].ToString().Trim();
                    mods.dbKeepDate = BaseFunction.ReturnDate(dtZJ.Rows[0]["DCOMPLETEDATE"]);
                }
                mods.iMPoIds = BaseFunction.ReturnLong(dtWO.Rows[0]["modid"]);

                if (sZJCode != "")
                {
                    mods.cCheckCode = sZJCode;
                }

                mods.iFlag = 0;
                mods.bRelated = false;
                mods.bLPUseFree = false;
                mods.iRSRowNO = 0;
                mods.iOriTrackID = 0;
                mods.bCosting = true;
                mods.bVMIUsed = false;
                mods.iExpiratDateCalcu = 0;
                mods.iordertype = 0;
                mods.isotype = 0;
                mods.irowno = 1;
                mods.cbsysbarcode = "||st10|" + mod.cCode + "|" + mods.irowno.ToString();
                mods.cMoLotCode = dtWO.Rows[0]["MoLotCode"].ToString().Trim();
                mods.cmocode = sWOCode;
                mods.imoseq = BaseFunction.ReturnInt(dtWO.Rows[0]["SortSeq"]);
                mods.imergecheckautoid = -1;


                DAL.rdrecords10 dals = new ClsU8.DAL.rdrecords10();
                sSQL = dals.Add(mods);
                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //回写质检
                if (sZJCode.Trim() != "")
                {
                    decimal dNum = BaseFunction.ReturnDecimal(mods.iNum);

                    sSQL = @"
update QMCHECKVOUCHER set FsumQuantity = isnull(FsumQuantity ,0) + {0},FsumNum = isnull(FsumNum ,0) + isnull({1},0)
WHERE CVOUCHTYPE = 'QM04' and CCHECKCODE = '{2}'
";
                    sSQL = string.Format(sSQL, mods.iQuantity, dNum, sZJCode);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                }

                //登记未记账
                sSQL = @"exec IA_SP_WriteUnAccountVouchForST aaaaaa,N'10'";
                sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //回写生产订单
                sSQL = @"
update mom_orderdetail set QualifiedInQty = isnull(QualifiedInQty,0) + {0}
where MoDid  = {1}
";
                sSQL = string.Format(sSQL, dQty, dtWO.Rows[0]["MODid"]);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //生产订单完成自动关闭
                sSQL = @"
select * 
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
where a.mocode = '{0}'
    and Qty > isnull(QualifiedInQty,0)
";
                sSQL = string.Format(sSQL, sWOCode);
                DataTable dtWOTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtWOTemp.Rows.Count == 0)
                {
                    sSQL = @"
update mom_orderdetail set Status =4 ，CloseUser = '{0}',CloseTime = getdate()
where MoDid  = {1}
";
                    sSQL = string.Format(sSQL, sCreater, dt.Rows[0]["MODid"]);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }


                //------------------------------------------------------

                //审核时修改现存量
                //if (!bRD10ChangeCurrentStock)
                //{
                //  exec ST_SaveForStock N'10',N'1000094394',0,0 ,1
                //  exec ST_SaveForTrackStock N'10',N'1000094394', 0 ,1
                //  exec Usp_MO_GetMoBFAllocate 1000028491,6.000000

                //保存时修改现存量
                if (!bCheckToCurrQty)
                {
                    sSQL = @"
if exists(select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' and 1=1)
  	update  CurrentStock set iQuantity = isnull(iQuantity,0) + @iQuantity  
    where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'  and 1=1
      
else 
    begin 
        declare @itemid varchar(20); 
        declare @iCount int;  
        select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode';
        if( @iCount > 0 )
	        select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode';
        else  
            select @itemid=max(itemid+1) from CurrentStock  
            insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid,iSoDid,cBatch)
            values('@cWhCode','@cInvCode', @iQuantity,isnull(@itemid,1),'',@cBatch) 
    end
";
                    sSQL = sSQL.Replace("@cInvCode", sInvCode);
                    sSQL = sSQL.Replace("@cWhCode", sWhCode);
                    sSQL = sSQL.Replace("@iQuantity", dQty.ToString());
                    if (sBatch != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and cBatch = '" + sBatch + "'");

                        sSQL = sSQL.Replace("@cBatch", "'" + sBatch + "'");
                    }
                    else
                    {
                        sSQL = sSQL.Replace("@cBatch", "NULL");
                    }
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                //}
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }

            return sReturn;
        }
    }
}
