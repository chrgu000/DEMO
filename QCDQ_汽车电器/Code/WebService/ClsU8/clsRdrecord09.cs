using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TH.BaseClass;

namespace ClsU8
{
    public class clsRdrecord09
    {

        public string sRdrecord09_Save(SqlTransaction tran, string sWhCode, string sRdCode, string sDepCode, string sCreater, DateTime dDate, string sInvCode, string sBatch, string sQty, string sAccID)
        {
            string sReturn = "";
            try
            {
                int iCou = 0;

                string[] sInvCodeList = sInvCode.Split('◆');
                string[] sQtyList = sQty.Split('◆');
                string[] sBatchList = sBatch.Split('◆');

                if (sInvCodeList.Length != sQtyList.Length)
                {
                    throw new Exception("存货与数量不一致");
                }


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
select * from AccInformation  Where cSysId =N'ST' and  cName= N'bOtherOutCheck'
                ";
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                bool bOtherOutCheck = BaseFunction.ReturnBool(dt.Rows[0]["cValue"]);


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


                //2. 获得单据ID
                long lID = 1;
                long lIDDetail = 1;

                sSQL = @"
declare @p5 int
set @p5=0
declare @p6 int
set @p6=0
exec sp_GetId N'',N'888',N'rd',{0},@p5 output,@p6 output,default
select @p5, @p6
";
                sSQL = sSQL.Replace("888", sAccID);
                sSQL = string.Format(sSQL, sInvCodeList.Length);
                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                lID = BaseFunction.ReturnLong(dtTemp.Rows[0][0]);
                lIDDetail = BaseFunction.ReturnLong(dtTemp.Rows[0][1]) - sInvCodeList.Length;


                //3. 获得单据号
                long iCode = 0;
                sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='0302'";
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
where CardNumber='0302'
";
                sSQL = string.Format(sSQL, iCode);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                string sCode = iCode.ToString();
                while (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                sCode = dDate.ToString("yyyyMM") + sCode;



                //组装表头

                Model.RdRecord09 mod = new ClsU8.Model.RdRecord09();
                mod.cCode = sCode;
                mod.ID = lID;
                mod.bRdFlag = 0;
                mod.cVouchType = "09";
                mod.cBusType = "其他出库";
                mod.cSource = "库存";
                mod.cWhCode = sWhCode;
                mod.dDate = dDate;
                mod.cRdCode = "22";
                mod.cDepCode = sDepCode;
                mod.cMaker = sCreater;
                mod.bpufirst = false;
                mod.biafirst = false;
                mod.VT_ID = 85;
                mod.bIsSTQc = false;
                mod.bFromPreYear = false;
                mod.bIsComplement = 0;
                mod.iDiscountTaxType = 0;
                mod.iBG_OverFlag = 0;
                mod.ControlResult = -1;
                mod.ireturncount = 0;
                mod.iverifystate = 0;
                mod.iswfcontrolled = 0;
                mod.dnmaketime = DateTime.Now;
                mod.bredvouch = 0;
                mod.iPrintCount = 0;
                mod.csysbarcode = "||st09|" + mod.cCode;

                //mod.cHandler = sCreater;
                //mod.dVeriDate = dDate;
                //mod.iverifystate = 2;
                //mod.dnverifytime = DateTime.Now;
                DAL.RdRecord09 dal = new ClsU8.DAL.RdRecord09();
                sSQL = dal.Add(mod);

                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                string sErr = "";
                for (int i = 0; i < sInvCodeList.Length; i++)
                {
                    sSQL = @"
select * from Inventory where cInvCode = '{0}'
";
                    sSQL = string.Format(sSQL, sInvCodeList[i].Trim());
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if(dtTemp == null || dtTemp.Rows.Count ==0)
                    {
                        sErr = sErr + "存货 " + sInvCodeList[i].Trim() + " 不存在\n";
                        continue;
                    }

                    bool bBatch = BaseFunction.ReturnBool(dtTemp.Rows[0]["bInvBatch"]);
                    if (bBatch && sBatchList[i].Trim() == "")
                    {
                        sErr = sErr + "存货 " + sInvCodeList[i].Trim() + " 需要批次\n";
                        continue;
                    }

                    sSQL = @"
select sum(iquantity) as iQty
from CurrentStock
where cInvCode = '{0}'  and cWhCode = '{1}' and 1=1
";
                    sSQL = string.Format(sSQL, sInvCodeList[i].Trim(), mod.cWhCode);
                    if(bBatch)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and cBatch = '" + sBatchList[i].Trim() + "'");
                    }
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count == 0 || BaseFunction.ReturnDecimal(dtTemp.Rows[0]["iQty"]) < BaseFunction.ReturnDecimal(sQtyList[i].Trim()))
                    {
                        sErr = sErr + "存货 " + sInvCodeList[i].Trim() + " 现存量不足\n";
                        continue;
                    }

                    Model.rdrecords09 mods = new ClsU8.Model.rdrecords09();
                    lIDDetail += 1;
                    mods.AutoID = lIDDetail;
                    mods.ID = lID;
                    mods.cInvCode = sInvCodeList[i].Trim();
                    mods.iQuantity = BaseFunction.ReturnDecimal(sQtyList[i].Trim());
                    mods.cBarCode = sBatchList[i].Trim();
                    mods.iFlag = 0;
                    mods.bLPUseFree = false;
                    mods.iRSRowNO = 0;
                    mods.iOriTrackID = 0;
                    mods.bCosting = true;
                    mods.bVMIUsed = false;
                    mods.iExpiratDateCalcu = 0;
                    mods.iordertype = 0;
                    mods.isotype = 0;
                    mods.irowno = i + 1;
                    mods.cBatch = sBatchList[i].Trim();
                    mods.cbsysbarcode = mod.csysbarcode + "|" + mods.irowno.ToString();

                    DAL.rdrecords09 dals = new ClsU8.DAL.rdrecords09();
                    sSQL = dals.Add(mods);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if(bOtherOutCheck)
                    sSQL = @"
if exists(select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' and 1=1)
  	update  CurrentStock set iQuantity = isnull(iQuantity,0) - @iQuantity  
    where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' and 1=1
      
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
                    sSQL = sSQL.Replace("@cInvCode", mods.cInvCode);
                    sSQL = sSQL.Replace("@cWhCode", mod.cWhCode);
                    sSQL = sSQL.Replace("@iQuantity", mods.iQuantity.ToString());

                    if (sBatchList[i].Trim() != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and cBatch = '" + sBatchList[i].Trim() + "'");

                        sSQL = sSQL.Replace("@cBatch", "'" + sBatchList[i].Trim() + "'");
                    }
                    else
                    {
                        sSQL = sSQL.Replace("@cBatch", "NULL");
                    }
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }

                if (sErr != "")
                {
                    sReturn = sReturn + sErr;
                }

                //登记未记账
                sSQL = @"exec IA_SP_WriteUnAccountVouchForST aaaaaa,N'09'";
                sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }

            return sReturn;
        }
    }
}
