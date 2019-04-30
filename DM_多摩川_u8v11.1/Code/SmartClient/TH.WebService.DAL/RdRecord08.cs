using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;

namespace TH.WebService.DAL
{
    /// <summary>
    /// 数据访问类:RdRecord08
    /// </summary>
    public partial class RdRecord08
    {
        public RdRecord08()
        { }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetRdrecord08(string sCode)
        {

            string sSQL = @"
select b.cInvCode as 存货编码,b.iQuantity as 数量,cast(isnull(b.cDefine29,0) as decimal(16,6)) as 已入库,cast(null as decimal(16,6)) as 当前扫描
    ,b.cDefine28 as 货位,b.cDefine30 as 批号,d.cDepName as 部门,e.cWhName as 仓库
    ,a.cCode as 单据号,b.irowno as 行,convert(varchar,a.dDate,111) as 单据日期,a.cDepCode  as 部门编码
    ,a.cWhCode as 仓库编码
	,a.id,a.cHandler as 审核人
	,b.autoid,b.cDefine27 as 包装批量,a.bredvouch as 红蓝字
from RdRecord08 a inner join rdrecords08 b on a.ID = b.ID
    left join Department d on d.cDepCode = a.cDepCode 
    left join WareHouse e on e.cWhCode = a.cWhCode
where a.cCode = '111111'
order by a.cCode,b.irowno,b.AutoID
";

            sSQL = sSQL.Replace("111111", sCode);
            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 保存其他入库单扫描数量
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iSaveRdrecord08ChkQty(string sCode, DataTable dtBarCode, string sUid)
        {
            int iCou = 0;
            try
            {
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

                    string sSQL = "select a.cCode,b.iRowNo, b.cInvCode,b.iQuantity,b.cDefine29 as 已扫描数量,b.cDefine28 as 货位,b.cDefine30 as 批号,cast(null as decimal(16,6)) as 本次扫描数量,b.autoid from RdRecord08 a inner join rdrecords08 b on a.id = b.id where a.cCode = '" + sCode + "' order by b.cInvCode";
                    DataTable dtRdRecord08 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

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
                        DataRow[] drCode = dtRdRecord08.Select("cInvCode = '" + sInvCode + "'");

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
                            model_BarCodeRD.sType = "其他入库单";
                            model_BarCodeRD.ExsID = BaseFunction.ReturnLong(drCode[j]["autoid"]);
                            model_BarCodeRD.ExCode = drCode[j]["cCode"].ToString().Trim();
                            model_BarCodeRD.ExRowNo = ClsBaseDataInfo.ReturnObjectToLong(drCode[j]["iRowNo"]);
                            model_BarCodeRD.cInvCode = drCode[j]["cInvCode"].ToString().Trim();
                            model_BarCodeRD.CreateUid = dtBarCode.Rows[i]["制单人"].ToString().Trim();
                            model_BarCodeRD.CreateDate = dtmNow;
                            model_BarCodeRD.XBarCode = dtBarCode.Rows[i]["箱码"].ToString().Trim();
                            model_BarCodeRD.RDType = 1;

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

                            string sUpdate = "";
                            if (drCode[j]["货位"].ToString().Trim() == "" && drCode[j]["批号"].ToString().Trim() == "")
                            {
                                sUpdate = sUpdate + ",cDefine28 = '" + dtBarCode.Rows[i]["货位"].ToString().Trim() + "'";
                                sUpdate = sUpdate + ",cDefine30 = '" + dtBarCode.Rows[i]["批号"].ToString().Trim() + "'";
                            }
           
                            sSQL = "update rdrecords08 set cDefine29 = cast(isnull(cDefine29,0) as decimal(16,6)) + " + model_BarCodeRD.Qty.ToString() + " 111111 where autoid = " + model_BarCodeRD.ExsID.ToString();
                            if (sUpdate == "")
                                sSQL = sSQL.Replace("111111", "");
                            else
                                sSQL = sSQL.Replace("111111", sUpdate);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                          

                            //当可用量为0是，标记条形码失效
                            sSQL = DAL_BarCodeList.sBarCodeQty(model_BarCodeRD.BarCode);
                            DataTable dtQty = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtQty != null && dtQty.Rows.Count > 0)
                            {
                                decimal dQtyUsed = BaseFunction.ReturnDecimal(dtQty.Rows[0][0]);
                                if (dQtyUsed <= 0)
                                {
                                    sSQL = "update _BarCodeList set used = 1 where BarCode = '" + model_BarCodeRD.BarCode + "'";
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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
select case when sum(cast(isnull(b.cDefine29,0) as decimal(16,6))) <> sum(b.iQuantity) then 1 else 0 end as iCou
from rdrecord08 a inner join rdrecords08 b on a.id = b.id 
where a.cCode = '111111' 
group by a.cCode 
";
                    sSQL = sSQL.Replace("111111", sCode);
                    DataTable dtTemp2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp2 != null && dtTemp2.Rows.Count == 1)
                    {
                        int iC = BaseFunction.ReturnInt(dtTemp2.Rows[0][0]);
                        if (iC == 0)
                        {
                            sSQL = "update rdrecord08 set cHandler = '222222',dVeriDate  = '333333',dnverifytime = getdate() where cCode = '111111'";
                            sSQL = sSQL.Replace("111111", sCode);
                            sSQL = sSQL.Replace("222222", sUid);
                            sSQL = sSQL.Replace("333333", dTimeNow.ToString("yyyy-MM-dd"));
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            //修改现存量
                            //sSQL = "exec SP_ClearCurrentStock_ST";
                            //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
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

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.WebService.Model.RdRecord08 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.bRdFlag != null)
            {
                strSql1.Append("bRdFlag,");
                strSql2.Append("" + model.bRdFlag + ",");
            }
            if (model.cVouchType != null)
            {
                strSql1.Append("cVouchType,");
                strSql2.Append("'" + model.cVouchType + "',");
            }
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            if (model.cBusCode != null)
            {
                strSql1.Append("cBusCode,");
                strSql2.Append("'" + model.cBusCode + "',");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.cRdCode != null)
            {
                strSql1.Append("cRdCode,");
                strSql2.Append("'" + model.cRdCode + "',");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.cPersonCode != null)
            {
                strSql1.Append("cPersonCode,");
                strSql2.Append("'" + model.cPersonCode + "',");
            }
            if (model.cPTCode != null)
            {
                strSql1.Append("cPTCode,");
                strSql2.Append("'" + model.cPTCode + "',");
            }
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cOrderCode != null)
            {
                strSql1.Append("cOrderCode,");
                strSql2.Append("'" + model.cOrderCode + "',");
            }
            if (model.cARVCode != null)
            {
                strSql1.Append("cARVCode,");
                strSql2.Append("'" + model.cARVCode + "',");
            }
            if (model.cBillCode != null)
            {
                strSql1.Append("cBillCode,");
                strSql2.Append("" + model.cBillCode + ",");
            }
            if (model.cDLCode != null)
            {
                strSql1.Append("cDLCode,");
                strSql2.Append("" + model.cDLCode + ",");
            }
            if (model.cProBatch != null)
            {
                strSql1.Append("cProBatch,");
                strSql2.Append("'" + model.cProBatch + "',");
            }
            if (model.cHandler != null)
            {
                strSql1.Append("cHandler,");
                strSql2.Append("'" + model.cHandler + "',");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.bTransFlag != null)
            {
                strSql1.Append("bTransFlag,");
                strSql2.Append("" + (model.bTransFlag ? 1 : 0) + ",");
            }
            if (model.cAccounter != null)
            {
                strSql1.Append("cAccounter,");
                strSql2.Append("'" + model.cAccounter + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.cDefine1 != null)
            {
                strSql1.Append("cDefine1,");
                strSql2.Append("'" + model.cDefine1 + "',");
            }
            if (model.cDefine2 != null)
            {
                strSql1.Append("cDefine2,");
                strSql2.Append("'" + model.cDefine2 + "',");
            }
            if (model.cDefine3 != null)
            {
                strSql1.Append("cDefine3,");
                strSql2.Append("'" + model.cDefine3 + "',");
            }
            if (model.cDefine4 != null)
            {
                strSql1.Append("cDefine4,");
                strSql2.Append("'" + model.cDefine4 + "',");
            }
            if (model.cDefine5 != null)
            {
                strSql1.Append("cDefine5,");
                strSql2.Append("" + model.cDefine5 + ",");
            }
            if (model.cDefine6 != null)
            {
                strSql1.Append("cDefine6,");
                strSql2.Append("'" + model.cDefine6 + "',");
            }
            if (model.cDefine7 != null)
            {
                strSql1.Append("cDefine7,");
                strSql2.Append("" + model.cDefine7 + ",");
            }
            if (model.cDefine8 != null)
            {
                strSql1.Append("cDefine8,");
                strSql2.Append("'" + model.cDefine8 + "',");
            }
            if (model.cDefine9 != null)
            {
                strSql1.Append("cDefine9,");
                strSql2.Append("'" + model.cDefine9 + "',");
            }
            if (model.cDefine10 != null)
            {
                strSql1.Append("cDefine10,");
                strSql2.Append("'" + model.cDefine10 + "',");
            }
            if (model.dKeepDate != null)
            {
                strSql1.Append("dKeepDate,");
                strSql2.Append("'" + model.dKeepDate + "',");
            }
            if (model.dVeriDate != null)
            {
                strSql1.Append("dVeriDate,");
                strSql2.Append("'" + model.dVeriDate + "',");
            }
            if (model.bpufirst != null)
            {
                strSql1.Append("bpufirst,");
                strSql2.Append("" + (model.bpufirst ? 1 : 0) + ",");
            }
            if (model.biafirst != null)
            {
                strSql1.Append("biafirst,");
                strSql2.Append("" + (model.biafirst ? 1 : 0) + ",");
            }
            if (model.iMQuantity != null)
            {
                strSql1.Append("iMQuantity,");
                strSql2.Append("" + model.iMQuantity + ",");
            }
            if (model.dARVDate != null)
            {
                strSql1.Append("dARVDate,");
                strSql2.Append("'" + model.dARVDate + "',");
            }
            if (model.cChkCode != null)
            {
                strSql1.Append("cChkCode,");
                strSql2.Append("'" + model.cChkCode + "',");
            }
            if (model.dChkDate != null)
            {
                strSql1.Append("dChkDate,");
                strSql2.Append("'" + model.dChkDate + "',");
            }
            if (model.cChkPerson != null)
            {
                strSql1.Append("cChkPerson,");
                strSql2.Append("'" + model.cChkPerson + "',");
            }
            if (model.VT_ID != null)
            {
                strSql1.Append("VT_ID,");
                strSql2.Append("" + model.VT_ID + ",");
            }
            if (model.bIsSTQc != null)
            {
                strSql1.Append("bIsSTQc,");
                strSql2.Append("" + (model.bIsSTQc ? 1 : 0) + ",");
            }
            if (model.cDefine11 != null)
            {
                strSql1.Append("cDefine11,");
                strSql2.Append("'" + model.cDefine11 + "',");
            }
            if (model.cDefine12 != null)
            {
                strSql1.Append("cDefine12,");
                strSql2.Append("'" + model.cDefine12 + "',");
            }
            if (model.cDefine13 != null)
            {
                strSql1.Append("cDefine13,");
                strSql2.Append("'" + model.cDefine13 + "',");
            }
            if (model.cDefine14 != null)
            {
                strSql1.Append("cDefine14,");
                strSql2.Append("'" + model.cDefine14 + "',");
            }
            if (model.cDefine15 != null)
            {
                strSql1.Append("cDefine15,");
                strSql2.Append("" + model.cDefine15 + ",");
            }
            if (model.cDefine16 != null)
            {
                strSql1.Append("cDefine16,");
                strSql2.Append("" + model.cDefine16 + ",");
            }
            if (model.gspcheck != null)
            {
                strSql1.Append("gspcheck,");
                strSql2.Append("'" + model.gspcheck + "',");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
            }
            if (model.iExchRate != null)
            {
                strSql1.Append("iExchRate,");
                strSql2.Append("" + model.iExchRate + ",");
            }
            if (model.cExch_Name != null)
            {
                strSql1.Append("cExch_Name,");
                strSql2.Append("'" + model.cExch_Name + "',");
            }
            if (model.bOMFirst != null)
            {
                strSql1.Append("bOMFirst,");
                strSql2.Append("" + (model.bOMFirst ? 1 : 0) + ",");
            }
            if (model.bFromPreYear != null)
            {
                strSql1.Append("bFromPreYear,");
                strSql2.Append("" + (model.bFromPreYear ? 1 : 0) + ",");
            }
            if (model.bIsLsQuery != null)
            {
                strSql1.Append("bIsLsQuery,");
                strSql2.Append("" + (model.bIsLsQuery ? 1 : 0) + ",");
            }
            if (model.bIsComplement != null)
            {
                strSql1.Append("bIsComplement,");
                strSql2.Append("" + model.bIsComplement + ",");
            }
            if (model.iDiscountTaxType != null)
            {
                strSql1.Append("iDiscountTaxType,");
                strSql2.Append("" + model.iDiscountTaxType + ",");
            }
            if (model.ireturncount != null)
            {
                strSql1.Append("ireturncount,");
                strSql2.Append("" + model.ireturncount + ",");
            }
            if (model.iverifystate != null)
            {
                strSql1.Append("iverifystate,");
                strSql2.Append("" + model.iverifystate + ",");
            }
            if (model.iswfcontrolled != null)
            {
                strSql1.Append("iswfcontrolled,");
                strSql2.Append("" + model.iswfcontrolled + ",");
            }
            if (model.cModifyPerson != null)
            {
                strSql1.Append("cModifyPerson,");
                strSql2.Append("'" + model.cModifyPerson + "',");
            }
            if (model.dModifyDate != null)
            {
                strSql1.Append("dModifyDate,");
                strSql2.Append("'" + model.dModifyDate + "',");
            }
            if (model.dnmaketime != null)
            {
                strSql1.Append("dnmaketime,");
                strSql2.Append("'" + model.dnmaketime + "',");
            }
            if (model.dnmodifytime != null)
            {
                strSql1.Append("dnmodifytime,");
                strSql2.Append("'" + model.dnmodifytime + "',");
            }
            if (model.dnverifytime != null)
            {
                strSql1.Append("dnverifytime,");
                strSql2.Append("'" + model.dnverifytime + "',");
            }
            if (model.bredvouch != null)
            {
                strSql1.Append("bredvouch,");
                strSql2.Append("" + model.bredvouch + ",");
            }
            if (model.iFlowId != null)
            {
                strSql1.Append("iFlowId,");
                strSql2.Append("" + model.iFlowId + ",");
            }
            if (model.cPZID != null)
            {
                strSql1.Append("cPZID,");
                strSql2.Append("'" + model.cPZID + "',");
            }
            if (model.cSourceLs != null)
            {
                strSql1.Append("cSourceLs,");
                strSql2.Append("'" + model.cSourceLs + "',");
            }
            if (model.cSourceCodeLs != null)
            {
                strSql1.Append("cSourceCodeLs,");
                strSql2.Append("'" + model.cSourceCodeLs + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.ctransflag != null)
            {
                strSql1.Append("ctransflag,");
                strSql2.Append("'" + model.ctransflag + "',");
            }
            if (model.csysbarcode != null)
            {
                strSql1.Append("csysbarcode,");
                strSql2.Append("'" + model.csysbarcode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            strSql.Append("insert into RdRecord08(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
    }
}

