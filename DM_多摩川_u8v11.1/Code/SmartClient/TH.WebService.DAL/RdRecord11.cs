using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;

namespace TH.WebService.DAL
{
    /// <summary>
    /// 数据访问类:RdRecord11
    /// </summary>
    public partial class RdRecord11
    {
        public RdRecord11()
        { }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetRdrecord11(string sCode)
        {

            string sSQL = @"
select b.cInvCode as 存货编码,b.iQuantity as 数量,cast(isnull(b.cDefine29,0) as decimal(16,6)) as 已出库,cast(null as decimal(16,6)) as 当前扫描
    ,b.cDefine28 as 货位,b.cDefine30 as 批号,d.cDepName as 部门,e.cWhName as 仓库
    ,a.cCode as 单据号,b.irowno as 行,convert(varchar,a.dDate,111) as 单据日期,a.cDepCode  as 部门编码
    ,a.cWhCode as 仓库编码
	,a.id,a.cHandler as 审核人
	,b.autoid,b.cDefine27 as 包装批量,a.bredvouch as 红蓝字
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID
    left join Department d on d.cDepCode = a.cDepCode 
    left join WareHouse e on e.cWhCode = a.cWhCode
where a.cCode = '111111'
order by a.cCode,b.irowno,b.AutoID
";

            sSQL = sSQL.Replace("111111", sCode);
            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 保存材料出库单扫描数量
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iSaveRdrecord11ChkQty(string sCode, DataTable dtBarCode, string sUid)
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

                    string sSQL = "select a.cCode,b.iRowNo, b.cInvCode,b.iQuantity,b.cDefine29 as 已扫描数量,b.cDefine28 as 货位,b.cDefine30 as 批号,cast(null as decimal(16,6)) as 本次扫描数量,b.autoid from RdRecord11 a inner join rdrecords11 b on a.id = b.id where a.cCode = '" + sCode + "' order by b.cInvCode";
                    DataTable dtRdRecord11 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    bool bRed = false;
                    if (dtRdRecord11 != null && dtRdRecord11.Rows.Count > 0 && BaseClass.BaseFunction.ReturnDecimal (dtRdRecord11.Rows[0]["iQuantity"]) < 0)
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

                    #region 蓝字单据
                    
                    if (!bRed)
                    {
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
                                model_BarCodeRD.sType = "材料出库单";
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

                                string sUpdate = "";
                                if (drCode[j]["货位"].ToString().Trim() == "" && drCode[j]["批号"].ToString().Trim() == "")
                                {
                                    sUpdate = sUpdate + ",cDefine28 = '" + dtBarCode.Rows[i]["货位"].ToString().Trim() + "'";
                                    sUpdate = sUpdate + ",cDefine30 = '" + dtBarCode.Rows[i]["批号"].ToString().Trim() + "'";
                                }

                                sSQL = "update rdrecords11 set cDefine29 = cast(isnull(cDefine29,0) as decimal(16,6)) + " + model_BarCodeRD.Qty.ToString() + " 111111 where autoid = " + model_BarCodeRD.ExsID.ToString();
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
                                        sSQL = "update _BarCodeList set valid = 0 where BarCode = '" + model_BarCodeRD.BarCode + "'";
                                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    }
                                }
                            }
                        }
                    }

                    #endregion
                    #region 红字
                    
                    else
                    {
                        for (int i = 0; i < dtBarCode.Rows.Count; i++)
                        {
                            string sInvCode = dtBarCode.Rows[i]["存货编码"].ToString().Trim();
                            decimal dQtyBarCode = BaseFunction.ReturnDecimal(dtBarCode.Rows[i]["数量"]);


                            //条形码中仅存货编码与入库单对应
                            DataRow[] drCode = dtRdRecord11.Select("cInvCode = '" + sInvCode + "'");

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
                                model_BarCodeRD.sType = "材料出库单";
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
                                    if (d >= 0)
                                        continue;

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

                                sSQL = "update rdrecords11 set cDefine29 = cast(isnull(cDefine29,0) as decimal(16,6)) + " + model_BarCodeRD.Qty.ToString() + " 111111 where autoid = " + model_BarCodeRD.ExsID.ToString();
                                if (sUpdate == "")
                                    sSQL = sSQL.Replace("111111", "");
                                else
                                    sSQL = sSQL.Replace("111111", sUpdate);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "update _BarCodeList set valid = 1 where BarCode = '" + model_BarCodeRD.BarCode + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }
                    #endregion

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
from rdrecord11 a inner join rdrecords11 b on a.id = b.id 
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
                            sSQL = "update rdrecord11 set cHandler = '222222',dVeriDate  = '333333',dnverifytime = getdate() where cCode = '111111'";
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
    }
}

