using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class clsU8
    {
        //U8V11.1
        public int TransVouch_Audit_U8V111(SqlTransaction tran, string sCode, string sAccID, string sUserName)
        {
            string sErr = "";
            int iCount = 0;

            string sSQL = "select getdate()";
            DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
            DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

            sSQL = @"
SELECT * 
FROM dbo.TransVouch a INNER JOIN dbo.TransVouchs b ON a.ID = b.ID
WHERE a.cTVCode = 'aaaaaaaa'
";
            sSQL = sSQL.Replace("aaaaaaaa", sCode);
            DataTable dtTr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            if (dtTr == null || dtTr.Rows.Count == 0)
            {
                throw new Exception("Audit err");
            }

            int iCodeCou = dtTr.Rows.Count;

            DateTime dtmCode = BaseFunction.ReturnDate(dtTr.Rows[0]["dVerifyDate"]);

            //审核调拨单
            sSQL = @"UPDATE TransVouch SET cVerifyPerson = 'aaaaaa',dVerifyDate =dTVDate,dnverifytime = getdate() WHERE cTVCode = 'dddddd'";
            sSQL = sSQL.Replace("aaaaaa", sUserName);
            sSQL = sSQL.Replace("dddddd", sCode);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            long lID = -1;
            long lIDDetails = -1;
            sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
            sSQL = sSQL.Replace("cccccc", iCodeCou.ToString());
            sSQL = sSQL.Replace("dddddd", sAccID);
            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

            lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
            lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCodeCou;

            #region 其他入库单

            //获得单据号
            sSQL = "select cNumber from VoucherHistory with (ROWLOCK) WHERE (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = '日') AND (cSeed = 'aaaaaa') ORDER BY cNumber DESC";
            sSQL = sSQL.Replace("aaaaaa", dtmCode.ToString("yyyyMMdd"));
            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            long lRd08Code = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                lRd08Code = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
            }
            else
            {
                lRd08Code = 0;
            }
            lRd08Code += 1;

            string sRd08Code = lRd08Code.ToString();

            Model.RdRecord08 modRd08 = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.RdRecord08();

            lID += 1;
            modRd08.ID = lID;
            modRd08.bRdFlag = 1;
            modRd08.cVouchType = "08";
            modRd08.cBusType = "调拨入库";
            modRd08.cSource = "调拨";
            modRd08.cBusCode = sCode;
            if (dtTr.Rows[0]["cIWhCode"].ToString().Trim().ToString().Trim() == "")
            {
                throw new Exception("请设置转入仓库");
            }
            modRd08.cWhCode = dtTr.Rows[0]["cIWhCode"].ToString().Trim();
            modRd08.dDate = Convert.ToDateTime(dtTr.Rows[0]["dVerifyDate"]); ;

            string sCodeRD = lRd08Code.ToString();
            while (sCodeRD.Length < 4)
            {
                sCodeRD = "0" + sCodeRD;
            }
            modRd08.cCode = "IN" + dtmCode.ToString("yyyyMMdd") + sCodeRD;

            if (dtTr.Rows[0]["cIRdCode"].ToString().Trim() == "")
            {
                throw new Exception("请设置入库类别");
            }
            modRd08.cRdCode = dtTr.Rows[0]["cIRdCode"].ToString().Trim();
            if (dtTr.Rows[0]["cIDepCode"].ToString().Trim() != "")
            {
                modRd08.cDepCode = dtTr.Rows[0]["cIDepCode"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cPersonCode"].ToString().Trim() != "")
            {
                modRd08.cPersonCode = dtTr.Rows[0]["cPersonCode"].ToString().Trim();
            }
            modRd08.bTransFlag = false;
            modRd08.cMaker = dtTr.Rows[0]["cVerifyPerson"].ToString().Trim();
            modRd08.cHandler = dtTr.Rows[0]["cVerifyPerson"].ToString().Trim();
            modRd08.dVeriDate = Convert.ToDateTime(dtTr.Rows[0]["dVerifyDate"]);
            modRd08.bpufirst = false;
            modRd08.biafirst = false;
            modRd08.VT_ID = 67;
            modRd08.bIsSTQc = false;
            modRd08.bOMFirst = false;
            modRd08.bFromPreYear = false;
            modRd08.bIsComplement = 0;
            modRd08.iDiscountTaxType = 0;
            modRd08.ireturncount = 0;
            modRd08.iverifystate = 0;
            modRd08.iswfcontrolled = 0;
            modRd08.dnmaketime = dNow;
            modRd08.dnverifytime = dNow;
            modRd08.cSourceLs = "1";
            modRd08.iPrintCount = 0;
            modRd08.csysbarcode = "||st08||" + modRd08.cCode;

            if (dtTr.Rows[0]["cDefine1"].ToString().Trim() != "")
            {
                modRd08.cDefine1 = dtTr.Rows[0]["cDefine1"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine2"].ToString().Trim() != "")
            {
                modRd08.cDefine2 = dtTr.Rows[0]["cDefine2"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine3"].ToString().Trim() != "")
            {
                modRd08.cDefine3 = dtTr.Rows[0]["cDefine3"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine4"].ToString().Trim() != "")
            {
                modRd08.cDefine4 = BaseFunction.ReturnDate(dtTr.Rows[0]["cDefine4"]);
            }
            if (dtTr.Rows[0]["cDefine5"].ToString().Trim() != "")
            {
                modRd08.cDefine5 = BaseFunction.ReturnLong(dtTr.Rows[0]["cDefine5"]);
            }
            if (dtTr.Rows[0]["cDefine6"].ToString().Trim() != "")
            {
                modRd08.cDefine6 =BaseFunction.ReturnDate( dtTr.Rows[0]["cDefine6"]);
            }
            if (dtTr.Rows[0]["cDefine7"].ToString().Trim() != "")
            {
                modRd08.cDefine7 = BaseFunction.ReturnDecimal(dtTr.Rows[0]["cDefine7"]);
            }
            if (dtTr.Rows[0]["cDefine8"].ToString().Trim() != "")
            {
                modRd08.cDefine8 = dtTr.Rows[0]["cDefine8"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine9"].ToString().Trim() != "")
            {
                modRd08.cDefine9 = dtTr.Rows[0]["cDefine9"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine10"].ToString().Trim() != "")
            {
                modRd08.cDefine10 = dtTr.Rows[0]["cDefine10"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine11"].ToString().Trim() != "")
            {
                modRd08.cDefine11 = dtTr.Rows[0]["cDefine11"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine12"].ToString().Trim() != "")
            {
                modRd08.cDefine12 = dtTr.Rows[0]["cDefine12"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine13"].ToString().Trim() != "")
            {
                modRd08.cDefine13 = dtTr.Rows[0]["cDefine13"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine14"].ToString().Trim() != "")
            {
                modRd08.cDefine14 = dtTr.Rows[0]["cDefine14"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine15"].ToString().Trim() != "")
            {
                modRd08.cDefine15 = BaseFunction.ReturnLong(dtTr.Rows[0]["cDefine15"]);
            }
            if (dtTr.Rows[0]["cDefine16"].ToString().Trim() != "")
            {
                modRd08.cDefine16 = BaseFunction.ReturnDecimal(dtTr.Rows[0]["cDefine16"]);
            }

            DAL.RdRecord08 dalrd08 = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.RdRecord08();
            sSQL = dalrd08.Add(modRd08);
            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            for (int i = 0; i < dtTr.Rows.Count; i++)
            {
                lIDDetails += 1;
                Model.rdrecords08 modRds08 = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords08();
                modRds08.AutoID = lIDDetails;
                modRds08.ID = modRd08.ID;
                modRds08.cInvCode = dtTr.Rows[i]["cInvCode"].ToString().Trim();
                if (BaseFunction.ReturnDecimal(dtTr.Rows[i]["iTVNum"]) != 0)
                {
                    modRds08.iNum = BaseFunction.ReturnDecimal(dtTr.Rows[i]["iTVNum"]);
                }
                modRds08.iQuantity = BaseFunction.ReturnDecimal(dtTr.Rows[i]["iTVQuantity"]);
                modRds08.cBatch = dtTr.Rows[i]["cTVBatch"].ToString().Trim();
                modRds08.cVouchCode = 0;
                modRds08.iSOutNum = 0;
                modRds08.iSOutQuantity = 0;
                modRds08.iFlag = 0;
                modRds08.iTrIds = BaseFunction.ReturnLong(dtTr.Rows[i]["autoID"]);
                modRds08.iNQuantity = modRds08.iQuantity;
                modRds08.iNNum = modRds08.iNNum;
                modRds08.cMassUnit = 0;
                modRds08.bCosting = true;
                modRds08.bVMIUsed = false;
                modRds08.iordertype = 0;
                modRds08.irowno = BaseFunction.ReturnInt(dtTr.Rows[i]["irowno"]);
                modRds08.cbsysbarcode = "||st08||" + modRd08.cCode + "|" + modRds08.irowno.ToString();
                modRds08.cDefine22 = dtTr.Rows[i]["cDefine22"].ToString().Trim();
                modRds08.cDefine23 = dtTr.Rows[i]["cDefine23"].ToString().Trim();
                modRds08.cDefine24 = dtTr.Rows[i]["cDefine24"].ToString().Trim();
                modRds08.cDefine25 = dtTr.Rows[i]["cDefine25"].ToString().Trim();
                modRds08.cDefine28 = dtTr.Rows[i]["cDefine28"].ToString().Trim();

                DAL.rdrecords08 dalRDs08 = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords08();
                sSQL = dalRDs08.Add(modRds08);
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
                sSQL = sSQL.Replace("@cInvCode", modRds08.cInvCode);
                sSQL = sSQL.Replace("@cWhCode", modRd08.cWhCode);
                sSQL = sSQL.Replace("@iQuantity", modRds08.iQuantity.ToString());
                sSQL = sSQL.Replace("@iNum", modRds08.iNum.ToString());
                sSQL = sSQL.Replace("@cFree10", modRds08.cFree10 == null ? "''" : "'" + modRds08.cFree10 + "'");
                sSQL = sSQL.Replace("@cFree1", modRds08.cFree1 == null ? "''" : "'" + modRds08.cFree1 + "'");
                sSQL = sSQL.Replace("@cFree2", modRds08.cFree2 == null ? "''" : "'" + modRds08.cFree2 + "'");
                sSQL = sSQL.Replace("@cFree3", modRds08.cFree3 == null ? "''" : "'" + modRds08.cFree3 + "'");
                sSQL = sSQL.Replace("@cFree4", modRds08.cFree4 == null ? "''" : "'" + modRds08.cFree4 + "'");
                sSQL = sSQL.Replace("@cFree5", modRds08.cFree5 == null ? "''" : "'" + modRds08.cFree5 + "'");
                sSQL = sSQL.Replace("@cFree6", modRds08.cFree6 == null ? "''" : "'" + modRds08.cFree6 + "'");
                sSQL = sSQL.Replace("@cFree7", modRds08.cFree7 == null ? "''" : "'" + modRds08.cFree7 + "'");
                sSQL = sSQL.Replace("@cFree8", modRds08.cFree8 == null ? "''" : "'" + modRds08.cFree8 + "'");
                sSQL = sSQL.Replace("@cFree9", modRds08.cFree9 == null ? "''" : "'" + modRds08.cFree9 + "'");
                sSQL = sSQL.Replace("@cBatch", modRds08.cBatch == null ? "''" : "'" + modRds08.cBatch + "'");
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            }

            sSQL = @"
exec ST_SaveForStock N'08',N'aaaaaa',1,0 ,1
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            sSQL = @"
exec ST_SaveForTrackStock N'08',N'aaaaaa', 0 ,1
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            sSQL = @"
exec IA_SP_WriteUnAccountVouchForST 'aaaaaa',N'08'
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            sSQL = @"
if exists(select * from VoucherHistory where  (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = '日') AND (cSeed = 'bbbbbb'))
	update VoucherHistory set cNumber = aaaaaa  where  (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = '日') AND (cSeed = 'bbbbbb')
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('0301','日期','日','bbbbbb','1',0)
";
            sSQL = sSQL.Replace("aaaaaa", lRd08Code.ToString());
            sSQL = sSQL.Replace("bbbbbb", dtmCode.ToString("yyyyMMdd"));
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            #endregion

            #region 其他出库单


            lID = -1;
            lIDDetails = -1;
            sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
            sSQL = sSQL.Replace("cccccc", iCodeCou.ToString());
            sSQL = sSQL.Replace("dddddd", sAccID);
            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

            lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
            lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCodeCou;


            //获得单据号
            sSQL = "select cNumber from VoucherHistory with (ROWLOCK) WHERE (CardNumber = '0302') AND (cContent = '日期') AND (cContentRule = '日') AND (cSeed = 'aaaaaa') ORDER BY cNumber DESC";
            sSQL = sSQL.Replace("aaaaaa", dtmCode.ToString("yyyyMMdd"));
            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            long lRd09Code = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                lRd09Code = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
            }
            else
            {
                lRd09Code = 0;
            }
            lRd09Code += 1;

            string sRd09Code = lRd09Code.ToString();

            Model.RdRecord09 modRd09 = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.RdRecord09();

            lID += 1;
            modRd09.ID = lID;
            modRd09.bRdFlag = 0;
            modRd09.cVouchType = "09";
            modRd09.cBusType = "调拨出库";
            modRd09.cSource = "调拨";
            modRd09.cBusCode = sCode;
            if (dtTr.Rows[0]["cOWhCode"].ToString().Trim().ToString().Trim() == "")
            {
                throw new Exception("请设置转出仓库");
            }
            modRd09.cWhCode = dtTr.Rows[0]["cOWhCode"].ToString().Trim();
            modRd09.dDate = Convert.ToDateTime(dtTr.Rows[0]["dVerifyDate"]); ;

            string sCodeRD09 = lRd09Code.ToString();
            while (sCodeRD09.Length < 4)
            {
                sCodeRD09 = "0" + sCodeRD09;
            }
            modRd09.cCode = "OU" + dtmCode.ToString("yyyyMMdd") + sCodeRD09;

            if (dtTr.Rows[0]["cORdCode"].ToString().Trim() == "")
            {
                throw new Exception("请设置出库类别");
            }
            modRd09.cRdCode = dtTr.Rows[0]["cORdCode"].ToString().Trim();
            if (dtTr.Rows[0]["cODepCode"].ToString().Trim() != "")
            {
                modRd09.cDepCode = dtTr.Rows[0]["cODepCode"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cPersonCode"].ToString().Trim() != "")
            {
                modRd09.cPersonCode = dtTr.Rows[0]["cPersonCode"].ToString().Trim();
            }
            modRd09.bTransFlag = false;
            modRd09.cMaker = dtTr.Rows[0]["cVerifyPerson"].ToString().Trim();
            modRd09.cHandler = dtTr.Rows[0]["cVerifyPerson"].ToString().Trim();
            modRd09.dVeriDate = Convert.ToDateTime(dtTr.Rows[0]["dVerifyDate"]); ;
            modRd09.bpufirst = false;
            modRd09.biafirst = false;
            modRd09.VT_ID = 85;
            modRd09.bIsSTQc = false;
            modRd09.bOMFirst = false;
            modRd09.bFromPreYear = false;
            modRd09.bIsComplement = 0;
            modRd09.iDiscountTaxType = 0;
            modRd09.ireturncount = 0;
            modRd09.iverifystate = 0;
            modRd09.iswfcontrolled = 0;
            modRd09.dnmaketime = dNow;
            modRd09.dnverifytime = dNow;
            modRd09.cSourceLs = "1";
            modRd09.iPrintCount = 0;
            modRd09.csysbarcode = "||st09||" + modRd09.cCode;


            if (dtTr.Rows[0]["cDefine1"].ToString().Trim() != "")
            {
                modRd09.cDefine1 = dtTr.Rows[0]["cDefine1"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine2"].ToString().Trim() != "")
            {
                modRd09.cDefine2 = dtTr.Rows[0]["cDefine2"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine3"].ToString().Trim() != "")
            {
                modRd09.cDefine3 = dtTr.Rows[0]["cDefine3"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine4"].ToString().Trim() != "")
            {
                modRd09.cDefine4 = BaseFunction.ReturnDate(dtTr.Rows[0]["cDefine4"]);
            }
            if (dtTr.Rows[0]["cDefine5"].ToString().Trim() != "")
            {
                modRd09.cDefine5 = BaseFunction.ReturnLong(dtTr.Rows[0]["cDefine5"]);
            }
            if (dtTr.Rows[0]["cDefine6"].ToString().Trim() != "")
            {
                modRd09.cDefine6 = BaseFunction.ReturnDate(dtTr.Rows[0]["cDefine6"]);
            }
            if (dtTr.Rows[0]["cDefine7"].ToString().Trim() != "")
            {
                modRd09.cDefine7 = BaseFunction.ReturnDecimal(dtTr.Rows[0]["cDefine7"]);
            }
            if (dtTr.Rows[0]["cDefine8"].ToString().Trim() != "")
            {
                modRd09.cDefine8 = dtTr.Rows[0]["cDefine8"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine9"].ToString().Trim() != "")
            {
                modRd09.cDefine9 = dtTr.Rows[0]["cDefine9"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine10"].ToString().Trim() != "")
            {
                modRd09.cDefine10 = dtTr.Rows[0]["cDefine10"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine11"].ToString().Trim() != "")
            {
                modRd09.cDefine11 = dtTr.Rows[0]["cDefine11"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine12"].ToString().Trim() != "")
            {
                modRd09.cDefine12 = dtTr.Rows[0]["cDefine12"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine13"].ToString().Trim() != "")
            {
                modRd09.cDefine13 = dtTr.Rows[0]["cDefine13"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine14"].ToString().Trim() != "")
            {
                modRd09.cDefine14 = dtTr.Rows[0]["cDefine14"].ToString().Trim();
            }
            if (dtTr.Rows[0]["cDefine15"].ToString().Trim() != "")
            {
                modRd09.cDefine15 = BaseFunction.ReturnLong(dtTr.Rows[0]["cDefine15"]);
            }
            if (dtTr.Rows[0]["cDefine16"].ToString().Trim() != "")
            {
                modRd09.cDefine16 = BaseFunction.ReturnDecimal(dtTr.Rows[0]["cDefine16"]);
            }

            DAL.RdRecord09 dalrd09 = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.RdRecord09();
            sSQL = dalrd09.Add(modRd09);
            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            for (int i = 0; i < dtTr.Rows.Count; i++)
            {
                lIDDetails += 1;
                Model.rdrecords09 modRds09 = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords09();
                modRds09.AutoID = lIDDetails;
                modRds09.ID = modRd09.ID;
                modRds09.cInvCode = dtTr.Rows[i]["cInvCode"].ToString().Trim();
                if (BaseFunction.ReturnDecimal(dtTr.Rows[i]["iTVNum"]) != 0)
                {
                    modRds09.iNum = BaseFunction.ReturnDecimal(dtTr.Rows[i]["iTVNum"]);
                }
                modRds09.iQuantity = BaseFunction.ReturnDecimal(dtTr.Rows[i]["iTVQuantity"]);
                modRds09.cBatch = dtTr.Rows[i]["cTVBatch"].ToString().Trim();
                modRds09.cVouchCode = 0;
                modRds09.iSOutNum = 0;
                modRds09.iSOutQuantity = 0;
                modRds09.iFlag = 0;
                modRds09.iTrIds = BaseFunction.ReturnLong(dtTr.Rows[i]["autoID"]);
                modRds09.iNQuantity = modRds09.iQuantity;
                modRds09.iNNum = modRds09.iNNum;
                modRds09.cMassUnit = 0;
                modRds09.bCosting = true;
                modRds09.bVMIUsed = false;
                modRds09.iordertype = 0;
                modRds09.irowno = BaseFunction.ReturnInt(dtTr.Rows[i]["irowno"]);
                modRds09.cbsysbarcode = "||st09||" + modRd09.cCode + "|" + modRds09.irowno.ToString();

                modRds09.cDefine22 = dtTr.Rows[i]["cDefine22"].ToString().Trim();
                modRds09.cDefine23 = dtTr.Rows[i]["cDefine23"].ToString().Trim();
                modRds09.cDefine24 = dtTr.Rows[i]["cDefine24"].ToString().Trim();
                modRds09.cDefine25 = dtTr.Rows[i]["cDefine25"].ToString().Trim();
                modRds09.cDefine28 = dtTr.Rows[i]["cDefine28"].ToString().Trim();


                DAL.rdrecords09 dalRDs09 = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords09();
                sSQL = dalRDs09.Add(modRds09);
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
  	update  CurrentStock set iQuantity = isnull(iQuantity,0) - @iQuantity  
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
                sSQL = sSQL.Replace("@cInvCode", modRds09.cInvCode);
                sSQL = sSQL.Replace("@cWhCode", modRd09.cWhCode);
                sSQL = sSQL.Replace("@iQuantity", modRds09.iQuantity.ToString());
                sSQL = sSQL.Replace("@iNum", modRds09.iNum.ToString());
                sSQL = sSQL.Replace("@cFree10", modRds09.cFree10 == null ? "''" : "'" + modRds09.cFree10 + "'");
                sSQL = sSQL.Replace("@cFree1", modRds09.cFree1 == null ? "''" : "'" + modRds09.cFree1 + "'");
                sSQL = sSQL.Replace("@cFree2", modRds09.cFree2 == null ? "''" : "'" + modRds09.cFree2 + "'");
                sSQL = sSQL.Replace("@cFree3", modRds09.cFree3 == null ? "''" : "'" + modRds09.cFree3 + "'");
                sSQL = sSQL.Replace("@cFree4", modRds09.cFree4 == null ? "''" : "'" + modRds09.cFree4 + "'");
                sSQL = sSQL.Replace("@cFree5", modRds09.cFree5 == null ? "''" : "'" + modRds09.cFree5 + "'");
                sSQL = sSQL.Replace("@cFree6", modRds09.cFree6 == null ? "''" : "'" + modRds09.cFree6 + "'");
                sSQL = sSQL.Replace("@cFree7", modRds09.cFree7 == null ? "''" : "'" + modRds09.cFree7 + "'");
                sSQL = sSQL.Replace("@cFree8", modRds09.cFree8 == null ? "''" : "'" + modRds09.cFree8 + "'");
                sSQL = sSQL.Replace("@cFree9", modRds09.cFree9 == null ? "''" : "'" + modRds09.cFree9 + "'");
                sSQL = sSQL.Replace("@cBatch", modRds09.cBatch == null ? "''" : "'" + modRds09.cBatch + "'");
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                Model.rdrecords09sub mod09Sub = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords09sub();
                mod09Sub.AutoID = modRds09.AutoID;
                mod09Sub.ID = modRds09.ID;
                mod09Sub.iBG_Ctrl = false;
                mod09Sub.iBGSTSum = 0;
                DAL.rdrecords09sub dal09Sub = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords09sub();
                sSQL = dal09Sub.Add(mod09Sub);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            }

            sSQL = @"
exec ST_SaveForStock N'09',N'aaaaaa',1,0 ,1
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            sSQL = @"
exec ST_SaveForTrackStock N'09',N'aaaaaa', 0 ,1
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            sSQL = @"
exec IA_SP_WriteUnAccountVouchForST 'aaaaaa',N'09'
";
            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            //if (lID > 1000000000)
            //{
            //    lID = lID - 1000000000;
            //}
            //if (lIDDetails > 1000000000)
            //{
            //    lIDDetails = lIDDetails - 1000000000;
            //}
            //sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'rd'";
            //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


            sSQL = @"
if exists(select * from VoucherHistory where  (CardNumber = '0302') AND (cContent = '日期') AND (cContentRule = '日') AND (cSeed = 'bbbbbb'))
	update VoucherHistory set cNumber = aaaaaa  where  (CardNumber = '0302') AND (cContent = '日期') AND (cContentRule = '日') AND (cSeed = 'bbbbbb')
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('0302','日期','日','bbbbbb','1',0)
";
            sSQL = sSQL.Replace("aaaaaa", lRd09Code.ToString());
            sSQL = sSQL.Replace("bbbbbb", dtmCode.ToString("yyyyMMdd"));
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            #endregion


            return iCount;
        }
    }
}
