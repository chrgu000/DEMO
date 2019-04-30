using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls盘点单
    {
        public string dt盘点单信息(string sCode)
        {
            string s = "";

            try
            {
                string sSQL = @"
select *
from CheckVouch a inner join CheckVouchs b on a.id = b.id
where a.cCVCode = '111111'";

                sSQL = sSQL.Replace("111111", sCode);
                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {

            }
            return s;
        }

        public string dt盘点条码信息(string sBarCode, string sCode)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.*,b.cInvName,b.cInvStd
	,b.bInvBatch,a.数量,a.毛重
    ,rd.批号,rd.炉号,rd.公差,rd.喷漆颜色
	,rd.包装规格,rd.倒角,rd.研磨,rd.机台, rd.生产客户,rd.公差2
	,rd.长度
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 
	INNER JOIN (
		SELECT rds.cBatch AS 批号,rds.cBatchProperty6 AS 炉号,rds.cDefine22 AS 公差,rds.cDefine23 AS 喷漆颜色
				,rds.cDefine25 AS 包装规格,rds.cDefine27 AS 倒角,rds.cDefine28 AS 研磨,rds.cDefine29 AS 机台, rds.cBatchProperty7 AS 生产客户,rds.cBatchProperty8 AS 公差2
				,rds.cFree1 AS 长度
				,Left(rds.cBatch,Len(rds.cBatch) - 3) as 批次号
				,rds.irowno,rd.id,rd.cCode
		FROM rdrecord10 rd INNER JOIN rdrecords10 rds ON rd.id = rds.id
		) rd ON a.产成品入库单行号 = rd.irowno AND a.产成品入库单号 = rd.cCode
WHERE a.条形码 = 'aaaaaa'

UNION ALL

 select a.*,b.cInvName,b.cInvStd
	,b.bInvBatch,rd.数量,a.毛重
    ,rd.批号,rd.炉号,rd.公差,rd.喷漆颜色
	,rd.包装规格,rd.倒角,rd.研磨,rd.机台, rd.生产客户,rd.公差2
	,rd.长度
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 
	INNER JOIN (
		SELECT	rds.iQuantity AS 数量, rds.cBatch AS 批号,rds.cBatchProperty6 AS 炉号,rds.cDefine22 AS 公差,rds.cDefine23 AS 喷漆颜色
				,rds.cDefine25 AS 包装规格,rds.cDefine27 AS 倒角,rds.cDefine28 AS 研磨,rds.cDefine29 AS 机台, rds.cBatchProperty7 AS 生产客户,rds.cBatchProperty8 AS 公差2
				,rds.cFree1 AS 长度
				,Left(rds.cBatch,Len(rds.cBatch) - 3) as 批次号
				,rds.irowno,rd.id,rd.cCode
		FROM rdrecord01 rd INNER JOIN rdrecords01 rds ON rd.id = rds.id
		) rd ON a.采购入库单号 = rd.irowno AND a.采购入库单行号 = rd.cCode

WHERE a.条形码 = 'aaaaaa'
";

                sSQL = sSQL.Replace("aaaaaa", sBarCode);

                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = "0" + ee.Message;
            }
            return s;
        }

        public string Save盘点数据(DataTable dtData,string sCode)
        {
            string s = "";
            try
            {
                string sErr = "";
                string sInfo = "";

                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime d当前服务器时间 = Convert.ToDateTime(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));

                    //1.  判断是否结账
                    sSQL = "select * from gl_mend where iyear=year(getdate()) and iperiod=month(getdate())";
                    DataTable dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("判断模块结账失败");
                    }
                    int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_ST"]);
                    if (iR == 1)
                    {
                        throw new Exception("当前月份已经结账");
                    }

                    //2.判断单据是否审核
                    sSQL = "select * from CheckVouch where cCVCode = '" + sCode + "' ";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("获取盘点单失败");
                    }
                    string scAccounter = dtTemp.Rows[0]["cAccounter"].ToString().Trim();
                    if (scAccounter != "")
                    {
                        throw new Exception("单据已经审核");
                    }

                    long lID = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["ID"]);

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                        string s长度 = dtData.Rows[i]["长度"].ToString().Trim();
                        string s批号 = dtData.Rows[i]["批号"].ToString().Trim();
                        string s条形码 =  dtData.Rows[i]["条形码"].ToString().Trim();

                        sSQL = @"
select b.*
from CheckVouch a inner join CheckVouchs b on a.id = b.id
where a.cCVCode = 'aaaaaa' AND b.cInvCode = 'bbbbbb' AND ISNULL(b.cCVBatch,'') = 'cccccc' AND ISNULL(b.cFree1,'') = 'dddddd'
";
                        sSQL = sSQL.Replace("aaaaaa", sCode);
                        sSQL = sSQL.Replace("bbbbbb", s存货编码);
                        sSQL = sSQL.Replace("cccccc", s批号);
                        sSQL = sSQL.Replace("dddddd", s长度);
                        DataTable dt盘点 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt盘点 == null)
                        {
                            sErr = sErr + "条形码 " + s条形码 + " 获得单据失败\n";
                            continue;
                        }
                        if (dt盘点.Rows.Count == 0)
                        {
                            sInfo = sInfo + "条形码 " + s条形码 + "\n";
                            continue;
                        }

                        decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"]);
                        decimal d件数 = 0;
                        long lIDs = ClsBaseDataInfo.ReturnObjectToLong(dt盘点.Rows[0]["autoid"]);

                        sSQL = "update CheckVouchs set iCVCQuantity  = " + d数量 + ",iCVCNum  = " + d件数 + " ,BarCode = '" + s条形码 + "' where autoid = " + lIDs.ToString();
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = "update CheckVouchs  set iCVCQuantity  = 0,iCVCNum  = 0 where isnull(BarCode,'') = '' and ID = " + lID.ToString();
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sErr.Length > 0)
                        throw new Exception(sErr);

                    tran.Commit();
                    s = "保存" + sCode + "盘点信息成功";
                    if (sInfo.Length > 0)
                    {
                        s = s + "\n 以下条形码在盘点单没有信息，请手工输入:\n" + sInfo;
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
                s = ee.Message;
            }
            return s;
        }
    }
}
