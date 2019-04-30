using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;

namespace TH.WebService.DAL
{
    /// <summary>
    /// 数据访问类:TransVouch
    /// </summary>
    public partial class CheckVouch
    {
        public CheckVouch()
        { }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetCheckVouch(string sCode)
        {

            string sSQL = @"
select b.cInvCode as 存货编码,b.iCVQuantity as 数量,cast(isnull(b.cDefine29,0) as decimal(16,6)) as 已盘点,cast(null as decimal(16,6)) as 当前扫描
    ,d.cDepName as 部门
    ,f.cWhName as 仓库
    ,a.cCVCode  as 单据号,b.irowno as 行,convert(varchar,a.dCVDate ,111) as 单据日期,a.cDepCode  as 部门编码
    ,a.cWhCode as 仓库编码
	,a.id,a.cAccounter  as 审核人
from CheckVouch a inner join CheckVouchs b on a.ID = b.ID
	left join Department d on d.cDepCode = a.cDepCode  
    left join WareHouse f on f.cWhCode = a.cWhCode 
where a.cCVCode  = '111111'
order by a.cCVCode ,b.irowno,b.AutoID
";

            sSQL = sSQL.Replace("111111", sCode);
            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 保存盘点单扫描数量
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iSaveGetCheckVouchChkQty(string sCode, DataTable dtBarCode)
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
                    string sSQL = "select a.cCVCode as cCode,b.irowno,b.cInvCode ,b.cDefine29 as iQuantity,b.cDefine29 as 已扫描数量,cast(null as decimal(16,6)) as 本次扫描数量,b.autoid from CheckVouch a inner join CheckVouchs b on a.ID = b.ID  where a.cCVCode = '" + sCode + "' order by b.cInvCode";
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

                            sSQL = "select count(1) from _BarCodeRD where BarCode = '" + dtBarCode.Rows[i]["条形码"].ToString().Trim() + "' and ExCode = '" + sCode + "' and sType = '盘点单' ";
                            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            long iBarCou = BaseFunction.ReturnLong(dt.Rows[0][0]);
                            if (iBarCou > 0)
                                throw new Exception(dtBarCode.Rows[i]["条形码"].ToString().Trim() + "已经使用");

                            decimal diQuantity = BaseFunction.ReturnDecimal(drCode[j]["iQuantity"]);
                            decimal dQtyScaned = BaseFunction.ReturnDecimal(drCode[j]["已扫描数量"]);
                            decimal dQtyNow = BaseFunction.ReturnDecimal(drCode[j]["本次扫描数量"]);
                            decimal d = diQuantity - dQtyScaned - dQtyNow;


                            Model._BarCodeRD model_BarCodeRD = new TH.WebService.Model._BarCodeRD();
                            model_BarCodeRD.sCode = s_BarCodeRDCode;
                            model_BarCodeRD.BarCode = dtBarCode.Rows[i]["条形码"].ToString().Trim();
                            model_BarCodeRD.sType = "盘点单";
                            model_BarCodeRD.ExsID = BaseFunction.ReturnLong(drCode[j]["autoid"]);
                            model_BarCodeRD.ExCode = drCode[j]["cCode"].ToString().Trim();
                            model_BarCodeRD.ExRowNo = ClsBaseDataInfo.ReturnObjectToLong(drCode[j]["iRowNo"]);
                            model_BarCodeRD.cInvCode = drCode[j]["cInvCode"].ToString().Trim();
                            model_BarCodeRD.CreateUid = dtBarCode.Rows[i]["制单人"].ToString().Trim();
                            model_BarCodeRD.CreateDate = dtmNow;
                            model_BarCodeRD.XBarCode = dtBarCode.Rows[i]["箱码"].ToString().Trim();
                            model_BarCodeRD.RDType = 0;


                            model_BarCodeRD.Qty = dQtyBarCode;

                            drCode[j]["本次扫描数量"] = BaseFunction.ReturnDecimal(drCode[j]["本次扫描数量"]) + dQtyBarCode;
                            dQtyBarCode = 0;

                            sSQL = DAL_BarCodeRD.Add(model_BarCodeRD);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "update CheckVouchs set cDefine29 = cast(isnull(cDefine29,0) as decimal(16,6)) + " + model_BarCodeRD.Qty.ToString() + " where autoid = " + model_BarCodeRD.ExsID.ToString();
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (iCou == 0)
                    {
                        throw new Exception("没有语句执行");
                    }

                    sSQL = "update CheckVouchs set iCVCQuantity = cast(isnull(cDefine29,0) as decimal(16,6))  where cCVCode = '" + sCode + "'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

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

