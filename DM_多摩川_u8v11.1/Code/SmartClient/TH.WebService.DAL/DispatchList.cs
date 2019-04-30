using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;

namespace TH.WebService.DAL
{
    /// <summary>
    /// 数据访问类:DispatchList
    /// </summary>
    public partial class DispatchList
    {
        public DispatchList()
        { }

        string sAccID = "001";

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetDispatchList(string sCode)
        {

            string sSQL = @"
select b.cInvCode as 存货编码,b.iQuantity as 数量,cast(isnull(b.cDefine31,0) as decimal(16,6)) as 已发货,cast(null as decimal(16,6)) as 当前扫描
    ,b.cDefine28 as 货位,b.cDefine30 as 批号,d.cDepName as 部门,e.cWhName as 仓库
    ,a.cDLCode as 单据号,b.irowno as 行,convert(varchar,a.dDate,111) as 单据日期,a.cDepCode  as 部门编码
    ,b.cWhCode as 仓库编码
	,a.DLID as id,a.cVerifier as 审核人
	,b.autoid,a.bReturnFlag as 红蓝字
from DispatchList a inner join DispatchLists b on a.DLID  = b.DLID 
    left join Department d on d.cDepCode = a.cDepCode 
    left join WareHouse e on e.cWhCode = b.cWhCode
where a.cDLCode = '111111'
order by a.cDLCode,b.irowno,b.AutoID
";

            sSQL = sSQL.Replace("111111", sCode);
            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 保存发货单扫描数量
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iSaveDispatchListChkQty(string sCode, DataTable dtBarCode,string sUid)
        {
            int iCou = 0;
            try
            {
                string sDLCode = sCode;

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

                    string sSQL = "select a.cDLCode as cCode,b.iRowNo, b.cInvCode,b.iQuantity,b.cDefine31 as 已扫描数量,cast(null as decimal(16,6)) as 本次扫描数量,b.autoid,a.bReturnFlag as 红蓝字 from DispatchList a inner join DispatchLists b on a.DLID  = b.DLID where a.cDLCode = '" + sCode + "' order by b.cInvCode";
                    DataTable dtDispatchList = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                    bool bRed = false;
                    if (dtDispatchList != null && dtDispatchList.Rows.Count > 0 && BaseFunction.ReturnInt(dtDispatchList.Rows[0]["红蓝字"]) == 1)
                    {
                        bRed = true;
                    }

                    sSQL = "select getdate()";
                    DataTable dtTime = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dtmNow = BaseFunction.ReturnDate(dtTime.Rows[0][0]);
                    string s_BarCodeRDCode = BaseFunction.ReturnDate(dtTime.Rows[0][0]).ToString("yyMMddHHmmss");
                    dtTime = null;

                    _BarCodeRD DAL_BarCodeRD = new _BarCodeRD();
                    _BarCodeList DAL_BarCodeList = new _BarCodeList();

                    if (!bRed)
                    {
                        for (int i = 0; i < dtBarCode.Rows.Count; i++)
                        {
                            string sInvCode = dtBarCode.Rows[i]["存货编码"].ToString().Trim();
                            decimal dQtyBarCode = BaseFunction.ReturnDecimal(dtBarCode.Rows[i]["数量"]);


                            //条形码中仅存货编码与入库单对应
                            DataRow[] drCode = dtDispatchList.Select("cInvCode = '" + sInvCode + "'");

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
                                model_BarCodeRD.sType = "销售发货单";
                                model_BarCodeRD.ExsID = BaseFunction.ReturnLong(drCode[j]["autoid"]);
                                model_BarCodeRD.ExCode = drCode[j]["cCode"].ToString().Trim();
                                model_BarCodeRD.ExRowNo = ClsBaseDataInfo.ReturnObjectToLong(drCode[j]["iRowNo"]);
                                model_BarCodeRD.cInvCode = drCode[j]["cInvCode"].ToString().Trim();
                                model_BarCodeRD.CreateUid = dtBarCode.Rows[i]["制单人"].ToString().Trim();
                                model_BarCodeRD.CreateDate = dtmNow;
                                model_BarCodeRD.XBarCode = dtBarCode.Rows[i]["箱码"].ToString().Trim();
                                model_BarCodeRD.RDType = 2;

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

                                if (model_BarCodeRD.XBarCode != "")
                                {
                                    sSQL = @"select count(1) as iCou from _BarCodeRD where BarCode = '111111' and sType = '222222' and sCode = '333333'";
                                    sSQL = sSQL.Replace("111111", model_BarCodeRD.XBarCode);
                                    sSQL = sSQL.Replace("222222", model_BarCodeRD.sType);
                                    sSQL = sSQL.Replace("333333", model_BarCodeRD.sCode);
                                    DataTable dtCheckBox = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    int iCouBox = BaseFunction.ReturnInt(dtCheckBox.Rows[0][0]);
                                    if (iCouBox == 0)
                                    {
                                        model_BarCodeRD.BarCode = dtBarCode.Rows[i]["箱码"].ToString().Trim();
                                        sSQL = DAL_BarCodeRD.Add(model_BarCodeRD);
                                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                                        sSQL = "update _BarCodeList set valid = 0 where BarCode = '" + dtBarCode.Rows[i]["箱码"].ToString().Trim() + "'";
                                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    }
                                }

                                sSQL = "update DispatchLists set cDefine31 = cast(isnull(cDefine31,0) as decimal(16,6)) + " + model_BarCodeRD.Qty.ToString() + " where autoid = " + model_BarCodeRD.ExsID.ToString();
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "update _BarCodeList set Used = 1 where BarCode = '" + model_BarCodeRD.BarCode + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                //当可用量为0是，标记条形码失效
                                sSQL = DAL_BarCodeList.sBarCodeQty(model_BarCodeRD.BarCode);
                                DataTable dtQty = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtQty != null && dtQty.Rows.Count > 0)
                                {
                                    decimal dQtyUsed = BaseFunction.ReturnDecimal(dtQty.Rows[0][0]);
                                    if (dQtyUsed <= 0)
                                    {
                                        sSQL = "update _BarCodeList set valid = 0 where BarCode = '" + model_BarCodeRD.BarCode + "'";
                                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtBarCode.Rows.Count; i++)
                        {
                            string sInvCode = dtBarCode.Rows[i]["存货编码"].ToString().Trim();
                            decimal dQtyBarCode = BaseFunction.ReturnDecimal(dtBarCode.Rows[i]["数量"]);


                            //条形码中仅存货编码与入库单对应
                            DataRow[] drCode = dtDispatchList.Select("cInvCode = '" + sInvCode + "'");

                            for (int j = 0; j < drCode.Length; j++)
                            {
                                if (dQtyBarCode >= 0)
                                    break;

                                decimal diQuantity = BaseFunction.ReturnDecimal(drCode[j]["iQuantity"]);
                                decimal dQtyScaned = BaseFunction.ReturnDecimal(drCode[j]["已扫描数量"]);
                                decimal dQtyNow = BaseFunction.ReturnDecimal(drCode[j]["本次扫描数量"]);
                                decimal d = diQuantity - dQtyScaned - dQtyNow;


                                Model._BarCodeRD model_BarCodeRD = new TH.WebService.Model._BarCodeRD();
                                model_BarCodeRD.sCode = s_BarCodeRDCode;
                                model_BarCodeRD.BarCode = dtBarCode.Rows[i]["条形码"].ToString().Trim();
                                model_BarCodeRD.sType = "销售发货单";
                                model_BarCodeRD.ExsID = BaseFunction.ReturnLong(drCode[j]["autoid"]);
                                model_BarCodeRD.ExCode = drCode[j]["cCode"].ToString().Trim();
                                model_BarCodeRD.ExRowNo = ClsBaseDataInfo.ReturnObjectToLong(drCode[j]["iRowNo"]);
                                model_BarCodeRD.cInvCode = drCode[j]["cInvCode"].ToString().Trim();
                                model_BarCodeRD.CreateUid = dtBarCode.Rows[i]["制单人"].ToString().Trim();
                                model_BarCodeRD.CreateDate = dtmNow;
                                model_BarCodeRD.XBarCode = dtBarCode.Rows[i]["箱码"].ToString().Trim();
                                model_BarCodeRD.RDType = 2;

                                //条形码数量超出单据数量
                                if (dQtyBarCode <= d)
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

                                if (model_BarCodeRD.XBarCode != "")
                                {
                                    sSQL = @"select count(1) as iCou from _BarCodeRD where BarCode = '111111' and sType = '222222' and sCode = '333333'";
                                    sSQL = sSQL.Replace("111111", model_BarCodeRD.XBarCode);
                                    sSQL = sSQL.Replace("222222", model_BarCodeRD.sType);
                                    sSQL = sSQL.Replace("333333", model_BarCodeRD.sCode);
                                    DataTable dtCheckBox = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    int iCouBox = BaseFunction.ReturnInt(dtCheckBox.Rows[0][0]);
                                    if (iCouBox == 0)
                                    {
                                        model_BarCodeRD.BarCode = dtBarCode.Rows[i]["箱码"].ToString().Trim();
                                        sSQL = DAL_BarCodeRD.Add(model_BarCodeRD);
                                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                                        sSQL = "update _BarCodeList set valid = 0 where BarCode = '" + dtBarCode.Rows[i]["箱码"].ToString().Trim() + "'";
                                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    }
                                }

                                sSQL = "update DispatchLists set cDefine31 = cast(isnull(cDefine31,0) as decimal(16,6)) + " + model_BarCodeRD.Qty.ToString() + " where autoid = " + model_BarCodeRD.ExsID.ToString();
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "update _BarCodeList set Used = 1 where BarCode = '" + model_BarCodeRD.BarCode + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                //当可用量为0是，标记条形码失效
                                sSQL = DAL_BarCodeList.sBarCodeQty(model_BarCodeRD.BarCode);
                                DataTable dtQty = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtQty != null && dtQty.Rows.Count > 0)
                                {
                                    decimal dQtyUsed = BaseFunction.ReturnDecimal(dtQty.Rows[0][0]);
                                    if (dQtyUsed >= 0)
                                    {
                                        sSQL = "update _BarCodeList set valid = 1 where BarCode = '" + model_BarCodeRD.BarCode + "'";
                                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    }
                                }
                            }
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
select case when sum(cast(isnull(b.cDefine31,0) as decimal(16,6))) <> sum(b.iQuantity ) then 1 else 0 end as iCou
from DispatchList a inner join DispatchLists b on a.dlid = b.dlid
where a.cDLCode = '111111' 
group by a.cDLCode

";
                    //仓库不同，分多张出库单
                    sSQL = sSQL.Replace("111111", sCode);
                    DataTable dtTemp2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp2 != null && dtTemp2.Rows.Count == 1)
                    {
                        int iC = BaseFunction.ReturnInt(dtTemp2.Rows[0][0]);
                        if (iC == 0)
                        {
                            sSQL = @" 
Update DispatchList SET  cVerifier=N'222222',cChanger=null,dverifydate='333333' ,dverifysystime=getdate() 
WHERE DispatchList.cDLCode = '111111'
";
                            //sSQL = "update TransVouch set cVerifyPerson = '222222',dVerifyDate  = '333333',dnverifytime = getdate() where cTVCode = '111111'";
                            sSQL = sSQL.Replace("111111", sCode);
                            sSQL = sSQL.Replace("222222", sUid);
                            sSQL = sSQL.Replace("333333", dTimeNow.ToString("yyyy-MM-dd"));
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "select distinct b.cWhCode from  DispatchList a inner join DispatchLists b on a.dlid = b.dlid where a.cDLCode = '111111'";
                            sSQL = sSQL.Replace("111111", sCode);
                            DataTable dtcWhCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            for (int ii = 0; ii < dtcWhCode.Rows.Count; ii++)
                            {

                                sSQL = @"
select *
from DispatchList a inner join DispatchLists b on a.dlid = b.dlid
where a.cDLCode = '111111' and b.cWhCode = '222222'
order by cWhCode ,autoid
";
                                sSQL = sSQL.Replace("111111", sDLCode);
                                sSQL = sSQL.Replace("222222", dtcWhCode.Rows[ii]["cWhCode"].ToString().Trim());
                                DataTable dtTran = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                int iCouRow = dtTran.Rows.Count;

                                #region 生成销售出库单据
                                //获得单据号
                                sSQL = "select cNumber from VoucherHistory Where CardNumber='0303' and cSeed = '" + dTimeNow.ToString("yyyyMM") + "'";
                                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                                long lCode = 0;
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                                    lCode += 1;
                                    sSQL = "update  VoucherHistory set cNumber = '" + lCode.ToString() + "' Where CardNumber='0303'  and cSeed = '" + dTimeNow.ToString("yyyyMM") + "'";
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                                else
                                {
                                    lCode = 1;
                                    sSQL = "insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)" +
                                            "values('0303','日期','月','" + dTimeNow.ToString("yyyyMM") + "','1',0)";
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                                sCode = lCode.ToString();
                                while (sCode.Length < 5)
                                {
                                    sCode = "0" + sCode;
                                }

                                sCode = "XC" + dTimeNow.ToString("yyMM") + sCode;

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
                                Model.RdRecord32 modelr32 = new TH.WebService.Model.RdRecord32();
                                modelr32.ID = lID;
                                modelr32.bRdFlag = 1;
                                modelr32.cVouchType = "32";
                                modelr32.cBusType = "普通销售";
                                modelr32.cSource = "发货单";
                                modelr32.cBusCode = sDLCode;
                                modelr32.cWhCode = dtTran.Rows[0]["cWhCode"].ToString().Trim();
                                modelr32.dDate = BaseFunction.ReturnDate(dTimeNow.ToString("yyyy-MM-dd"));
                                modelr32.cCode = sCode;
                                modelr32.cRdCode = dtTran.Rows[0]["cRdCode"].ToString().Trim();
                                modelr32.cDepCode = dtTran.Rows[0]["cDepCode"].ToString().Trim();
                                modelr32.cCusCode = dtTran.Rows[0]["cCusCode"].ToString().Trim();
                                modelr32.cPersonCode = dtTran.Rows[0]["cPersonCode"].ToString().Trim();
                                modelr32.cSTCode = dtTran.Rows[0]["cSTCode"].ToString().Trim();
                                modelr32.cDLCode = TH.WebService.BaseClass.ClsBaseDataInfo.ReturnObjectToLong(dtTran.Rows[0]["DLID"]);


                                modelr32.bTransFlag = false;
                                modelr32.cMaker = sUid;
                                modelr32.bpufirst = false;
                                modelr32.biafirst = false;
                                modelr32.VT_ID = 327;
                                modelr32.bIsSTQc = false;
                                modelr32.bOMFirst = false;
                                modelr32.bFromPreYear = false;
                                modelr32.bIsComplement = 0;
                                modelr32.iDiscountTaxType = 0;
                                modelr32.ireturncount = 0;
                                modelr32.iverifystate = 0;
                                modelr32.iswfcontrolled = 0;
                                modelr32.dnmaketime = dTimeNow;
                                modelr32.bredvouch = 0;

                                DAL.rdrecord32 DALr32 = new rdrecord32();
                                sSQL = DALr32.Add(modelr32);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                for (int i = 0; i < dtTran.Rows.Count; i++)
                                {
                                    Model.RdRecords32 modelr32s = new TH.WebService.Model.RdRecords32();

                                    lIDDetails += 1;
                                    modelr32s.AutoID = lIDDetails;
                                    modelr32s.ID = lID;
                                    modelr32s.cInvCode = dtTran.Rows[i]["cInvCode"].ToString().Trim();
                                    modelr32s.iQuantity = BaseFunction.ReturnDecimal(dtTran.Rows[i]["iQuantity"]);
                                    modelr32s.iNum = BaseFunction.ReturnDecimal(dtTran.Rows[i]["iNum"]);
                                    modelr32s.irowno = BaseFunction.ReturnInt(dtTran.Rows[i]["irowno"]);
                                    modelr32s.iDLsID = BaseFunction.ReturnLong(dtTran.Rows[i]["iDLsID"]);

                                    DAL.rdrecords32 DALr32s = new rdrecords32();
                                    sSQL = DALr32s.Add(modelr32s);
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "insert into IA_ST_UnAccountVouch32(idun,idsun,cvoutypeun,cbustypeun)values " +
                                             "('" + lID + "','" + lIDDetails + "','32','调拨入库')";
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                                #endregion

                                //回写发货数量
                                sSQL = "update dispatchlists with (UPDLOCK) set fOutQuantity=iQuantity, fOutNum=iNum where DLID = " + dtTran.Rows[0]["DLID"].ToString().Trim();
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                //回写发货单表头
                                sSQL = " Update DispatchList SET cSaleOut=N'" + sCode + "' WHERE DispatchList.cDLCode ='" + sDLCode + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

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

