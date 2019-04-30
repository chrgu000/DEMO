using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace TH.WebService.DAL
{
    /// <summary>
    /// 数据访问类:TransVouch
    /// </summary>
    public partial class TransVouch
    {
        public TransVouch()
        { }

        string sAccID = "001";

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetTransVouch(string sCode)
        {

            string sSQL = @"
select b.cInvCode as 存货编码,b.iTVQuantity as 数量,cast(isnull(b.cDefine29,0) as decimal(16,6)) as 已调拨,cast(null as decimal(16,6)) as 当前扫描
    ,d.cDepName as 转入部门,e.cDepName as 转出部门
    ,f.cWhName as 转入仓库,g.cWhName as 转出仓库
    ,a.cTVCode as 单据号,b.irowno as 行,convert(varchar,a.dTVDate ,111) as 单据日期,a.cIDepCode  as 转入部门编码,a.cODepCode  as 转出部门编码
    ,a.cIWhCode as 转入仓库编码,a.cOWhCode as 转出仓库编码
	,a.id,a.cVerifyPerson as 审核人
from TransVouch a inner join TransVouchs b on a.cTVCode = b.cTVCode 
	left join Department d on d.cDepCode = a.cIDepCode 
	left join Department e on e.cDepCode = a.cODepCode  
    left join WareHouse f on f.cWhCode = a.cIWhCode 
    left join WareHouse g on f.cWhCode = a.cOWhCode  
where a.cTVCode = '111111'
order by a.cTVCode,b.irowno,b.AutoID
";

            sSQL = sSQL.Replace("111111", sCode);
            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 保存调拨单扫描数量
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iSaveGetTransVouchChkQty(string sCode, DataTable dtBarCode,string sUid)
        {
            int iCou = 0;
            try
            {
                string sTrCode = sCode;

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    decimal dQtyScanSum = 0;        //  累计扫描数量
                    for (int i = 0; i < dtBarCode.Rows.Count; i++)
                    {
                        dQtyScanSum = dQtyScanSum + ClsBaseDataInfo.ReturnObjectToDecimal(dtBarCode.Rows[i]["数量"]);
                    }

                    string sSQL = "select a.cTVCode as cCode,b.irowno,b.cInvCode ,b.iTVQuantity as iQuantity,b.cDefine29 as 已扫描数量,cast(null as decimal(16,6)) as 本次扫描数量,b.autoid from TransVouch a inner join TransVouchs b on a.cTVCode = b.cTVCode  where a.cTVCode = '" + sCode + "' order by b.cInvCode";
                    DataTable dtRdRecord11 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = "select getdate()";
                    DataTable dtTime = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dtmNow = BaseFunction.ReturnDate(dtTime.Rows[0][0]);
                    string s_BarCodeRDCode = BaseFunction.ReturnDate(dtTime.Rows[0][0]).ToString("yyMMddHHmmss");
                    dtTime = null;

                    _BarCodeRD DAL_BarCodeRD = new _BarCodeRD();
                    _BarCodeList DAL_BarCodeList = new _BarCodeList();

                    for (int i = 0; i < dtBarCode.Rows.Count; i++)
                    {
                        string sInvCode = dtBarCode.Rows[i]["存货编码"].ToString().Trim();
                        decimal dQtyBarCode = BaseFunction.ReturnDecimal(dtBarCode.Rows[i]["数量"]);


                        //条形码中仅存货编码与入库单对应
                        DataRow[] drCode = dtRdRecord11.Select("cInvCode = '" + sInvCode + "'");

                        for (int j = 0; j < drCode.Length; j++)
                        {
                            if (dQtyBarCode <= 0)
                                break;

                            decimal diQuantity = BaseFunction.ReturnDecimal(drCode[j]["iQuantity"]);
                            decimal dQtyScaned = BaseFunction.ReturnDecimal(drCode[j]["已扫描数量"]);
                            decimal dQtyNow = BaseFunction.ReturnDecimal(drCode[j]["本次扫描数量"]);
                            decimal d = diQuantity - dQtyScaned - dQtyNow;


                            Model._BarCodeRD model_BarCodeRD = new TH.WebService.Model._BarCodeRD();
                            model_BarCodeRD.sCode = s_BarCodeRDCode;
                            model_BarCodeRD.BarCode = dtBarCode.Rows[i]["条形码"].ToString().Trim();
                            model_BarCodeRD.sType = "调拨单";
                            model_BarCodeRD.ExsID = BaseFunction.ReturnLong(drCode[j]["autoid"]);
                            model_BarCodeRD.ExCode = drCode[j]["cCode"].ToString().Trim();
                            model_BarCodeRD.ExRowNo = ClsBaseDataInfo.ReturnObjectToLong(drCode[j]["iRowNo"]);
                            model_BarCodeRD.cInvCode = drCode[j]["cInvCode"].ToString().Trim();
                            model_BarCodeRD.CreateUid = dtBarCode.Rows[i]["制单人"].ToString().Trim();
                            model_BarCodeRD.CreateDate = dtmNow;
                            model_BarCodeRD.XBarCode = dtBarCode.Rows[i]["箱码"].ToString().Trim();
                            model_BarCodeRD.RDType = 0;

                            //条形码数量超出单据数量
                            if (dQtyBarCode >= d)
                            {
                                model_BarCodeRD.Qty = d;
                                dQtyScanSum = dQtyScanSum - d;

                                drCode[j]["本次扫描数量"] = BaseFunction.ReturnDecimal(drCode[j]["本次扫描数量"]) + d;
                                dQtyBarCode = dQtyBarCode - d;
                            }
                            else
                            {
                                model_BarCodeRD.Qty = dQtyBarCode;
                                dQtyScanSum = dQtyScanSum - dQtyBarCode;

                                drCode[j]["本次扫描数量"] = BaseFunction.ReturnDecimal(drCode[j]["本次扫描数量"]) + dQtyBarCode;
                                dQtyBarCode = 0;
                            }

                            sSQL = DAL_BarCodeRD.Add(model_BarCodeRD);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "update TransVouchs set cDefine29 = cast(isnull(cDefine29,0) as decimal(16,6)) + " + model_BarCodeRD.Qty.ToString() + " where autoid = " + model_BarCodeRD.ExsID.ToString();
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (dQtyScanSum != 0)
                    {
                        throw new Exception("扫描数量未完全分配");
                    }
                    if (iCou == 0)
                    {
                        throw new Exception("没有语句执行");
                    }


                    #region 判断所有数量扫描后审核单据

                    sSQL = "select getdate()";
                    DataTable dTime = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dTimeNow = ClsBaseDataInfo.ReturnObjectToDatetime(dTime.Rows[0][0]);
                    sSQL = @"
select case when sum(cast(isnull(b.cDefine29,0) as decimal(16,6))) <> sum(b.iTVQuantity) then 1 else 0 end as iCou
from TransVouch a inner join TransVouchs b on a.cTVCode = b.cTVCode
where a.cTVCode = '111111' 
group by a.cTVCode 

";
                    sSQL = sSQL.Replace("111111", sCode);
                    DataTable dtTemp2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp2 != null && dtTemp2.Rows.Count == 1)
                    {
                        int iC = BaseFunction.ReturnInt(dtTemp2.Rows[0][0]);
                        if (iC == 0)
                        {
                            sSQL = "update TransVouch set cVerifyPerson = '222222',dVerifyDate  = '333333',dnverifytime = getdate() where cTVCode = '111111'";
                            sSQL = sSQL.Replace("111111", sCode);
                            sSQL = sSQL.Replace("222222", sUid);
                            sSQL = sSQL.Replace("333333", dTimeNow.ToString("yyyy-MM-dd"));
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                            sSQL = @"
select *
from TransVouch a inner join TransVouchs b on a.cTVCode = b.cTVCode
where a.cTVCode = '111111' 
order by autoid
";
                            sSQL = sSQL.Replace("111111", sCode);
                            DataTable dtTran = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            int iCouRow = dtTran.Rows.Count;

                            #region 生成其他入库单据
                            //获得单据号
                            sSQL = "select cNumber from VoucherHistory Where CardNumber='0301' and cSeed = '" + dTimeNow.ToString("yyyyMM") + "'";
                            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            long lCode = 0;
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                                lCode += 1;
                                sSQL = "update  VoucherHistory set cNumber = '" + lCode.ToString() + "' Where CardNumber='0301'  and cSeed = '" + dTimeNow.ToString("yyyyMM") + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {
                                lCode = 1;
                                sSQL = "insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)" +
                                        "values('0301','日期','月','" + dTimeNow.ToString("yyyyMM") + "','1',0)";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            sCode = lCode.ToString();
                            while (sCode.Length < 5)
                            {
                                sCode = "0" + sCode;
                            }

                            sCode = "QR" + dTimeNow.ToString("yyMM") + sCode;

                            long lID = 0;
                            long lIDDetails = 0;


                            sSQL = @"
declare @p5 int
set @p5=111111
declare @p6 int
set @p6=222222
exec sp_GetId N'',N'444444',N'rd',333333,@p5 output,@p6 output,default
select @p5, @p6
";
                            sSQL = sSQL.Replace("111111", lID.ToString());
                            sSQL = sSQL.Replace("222222", lIDDetails.ToString());
                            sSQL = sSQL.Replace("333333", iCouRow.ToString());
                            sSQL = sSQL.Replace("444444", sAccID); 
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            lID = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][0]) - 1;
                            lIDDetails = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][1]) - iCouRow;

                            lID += 1;
                            Model.RdRecord08 modelr8 = new TH.WebService.Model.RdRecord08();
                            modelr8.ID = lID;
                            modelr8.bRdFlag = 1;
                            modelr8.cVouchType = "08";
                            modelr8.cBusType = "调拨入库";
                            modelr8.cSource = "调拨";
                            modelr8.cBusCode = sTrCode;
                            modelr8.cWhCode = dtTran.Rows[0]["cIWhCode"].ToString().Trim();
                            modelr8.dDate = BaseFunction.ReturnDate(dTimeNow.ToString("yyyy-MM-dd"));
                            modelr8.cCode = sCode;
                            modelr8.cRdCode = dtTran.Rows[0]["cIRdCode"].ToString().Trim();
                            modelr8.cDepCode = dtTran.Rows[0]["cIDepCode"].ToString().Trim();
                            modelr8.bTransFlag = false;
                            modelr8.cMaker = sUid;
                            modelr8.bpufirst = false;
                            modelr8.biafirst = false;
                            modelr8.VT_ID = 67;
                            modelr8.bIsSTQc = false;
                            modelr8.bOMFirst = false;
                            modelr8.bFromPreYear = false;
                            modelr8.bIsComplement = 0;
                            modelr8.iDiscountTaxType = 0;
                            modelr8.ireturncount = 0;
                            modelr8.iverifystate = 0;
                            modelr8.iswfcontrolled = 0;
                            modelr8.dnmaketime = dTimeNow;
                            modelr8.bredvouch = 0;
                            modelr8.iPrintCount = 0;

                            DAL.RdRecord08 DALr8 = new RdRecord08();
                            sSQL = DALr8.Add(modelr8);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            for (int i = 0; i < dtTran.Rows.Count; i++)
                            {
                                Model.rdrecords08 modelr8s = new TH.WebService.Model.rdrecords08();

                                lIDDetails += 1;
                                modelr8s.AutoID = lIDDetails;
                                modelr8s.ID = lID;
                                modelr8s.cInvCode = dtTran.Rows[i]["cInvCode"].ToString().Trim();
                                modelr8s.iQuantity = BaseFunction.ReturnDecimal(dtTran.Rows[i]["iTVQuantity"]);
                                modelr8s.iNum = BaseFunction.ReturnDecimal(dtTran.Rows[i]["iTVNum"]);
                                modelr8s.iTrIds = BaseFunction.ReturnLong(dtTran.Rows[i]["autoID"]);
                                modelr8s.iNQuantity = BaseFunction.ReturnDecimal(dtTran.Rows[i]["iTVQuantity"]);
                                modelr8s.irowno = BaseFunction.ReturnInt(dtTran.Rows[i]["irowno"]);

                                DAL.rdrecords08 DALr8s = new rdrecords08();
                                sSQL = DALr8s.Add(modelr8s);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "insert into IA_ST_UnAccountVouch08(idun,idsun,cvoutypeun,cbustypeun)values " +
                                         "('" + lID + "','" + lIDDetails + "','08','调拨入库')";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            #endregion

                            #region 生成其他出库单据
                            //获得单据号
                            sSQL = "select cNumber from VoucherHistory Where CardNumber='0302' and cSeed = '" + dTimeNow.ToString("yyyyMM") + "'";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            lCode = 0;
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                                lCode += 1;
                                sSQL = "update  VoucherHistory set cNumber = '" + lCode.ToString() + "' Where CardNumber='0302'  and cSeed = '" + dTimeNow.ToString("yyyyMM") + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {
                                lCode = 1;
                                sSQL = "insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)" +
                                        "values('0302','日期','月','" + dTimeNow.ToString("yyyyMM") + "','1',0)";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            sCode = lCode.ToString();
                            while (sCode.Length < 5)
                            {
                                sCode = "0" + sCode;
                            }

                            sCode = "QC" + dTimeNow.ToString("yyMM") + sCode;

                            lID = 0;
                            lIDDetails = 0;


                            sSQL = @"
declare @p5 int
set @p5=111111
declare @p6 int
set @p6=222222
exec sp_GetId N'',N'444444',N'rd',333333,@p5 output,@p6 output,default
select @p5, @p6
";
                            sSQL = sSQL.Replace("111111", lID.ToString());
                            sSQL = sSQL.Replace("222222", lIDDetails.ToString());
                            sSQL = sSQL.Replace("333333", iCouRow.ToString());
                            sSQL = sSQL.Replace("444444", sAccID); 
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            lID = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][0]) - 1;
                            lIDDetails = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][1]) - iCouRow;

                            lID += 1;
                            Model.RdRecord09 modelr9 = new TH.WebService.Model.RdRecord09();
                            modelr9.ID = lID;
                            modelr9.bRdFlag = 0;
                            modelr9.cVouchType = "09";
                            modelr9.cBusType = "调拨出库";
                            modelr9.cSource = "调拨";
                            modelr9.cBusCode = sTrCode;
                            modelr9.cWhCode = dtTran.Rows[0]["cOWhCode"].ToString().Trim();
                            modelr9.dDate = BaseFunction.ReturnDate(dTimeNow.ToString("yyyy-MM-dd"));
                            modelr9.cCode = sCode;
                            modelr9.cRdCode = dtTran.Rows[0]["cORdCode"].ToString().Trim();
                            modelr9.cDepCode = dtTran.Rows[0]["cODepCode"].ToString().Trim();
                            modelr9.bTransFlag = false;
                            modelr9.cMaker = sUid;
                            modelr9.bpufirst = false;
                            modelr9.biafirst = false;
                            modelr9.VT_ID = 67;
                            modelr9.bIsSTQc = false;
                            modelr9.bOMFirst = false;
                            modelr9.bFromPreYear = false;
                            modelr9.bIsComplement = 0;
                            modelr9.iDiscountTaxType = 0;
                            modelr9.ireturncount = 0;
                            modelr9.iverifystate = 0;
                            modelr9.iswfcontrolled = 0;
                            modelr9.dnmaketime = dTimeNow;
                            modelr9.bredvouch = 0;
                            modelr9.iPrintCount = 0;

                            DAL.RdRecord09 DALr9 = new RdRecord09();
                            sSQL = DALr9.Add(modelr9);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            for (int i = 0; i < dtTran.Rows.Count; i++)
                            {
                                Model.rdrecords09 modelr9s = new TH.WebService.Model.rdrecords09();

                                lIDDetails += 1;
                                modelr9s.AutoID = lIDDetails;
                                modelr9s.ID = lID;
                                modelr9s.cInvCode = dtTran.Rows[i]["cInvCode"].ToString().Trim();
                                modelr9s.iQuantity = BaseFunction.ReturnDecimal(dtTran.Rows[i]["iTVQuantity"]);
                                modelr9s.iNum = BaseFunction.ReturnDecimal(dtTran.Rows[i]["iTVNum"]);
                                modelr9s.iTrIds = BaseFunction.ReturnLong(dtTran.Rows[i]["autoID"]);
                                modelr9s.iNQuantity = BaseFunction.ReturnDecimal(dtTran.Rows[i]["iTVQuantity"]);
                                modelr9s.irowno = BaseFunction.ReturnInt(dtTran.Rows[i]["irowno"]);

                                DAL.RdRecords09 DALr9s = new RdRecords09();
                                sSQL = DALr9s.Add(modelr9s);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "insert into IA_ST_UnAccountVouch09(idun,idsun,cvoutypeun,cbustypeun)values " +
                                         "('" + lID + "','" + lIDDetails + "','09','调拨出库')";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            #endregion
                        }


                        //sSQL = "exec SP_ClearCurrentStock_ST";
                        //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    #endregion



                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return iCou;
        }
    }


}

