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
select *
from dbo.条形码信息 a inner join
	(
		select b.*
		from CheckVouch a inner join CheckVouchs b on a.id = b.id
		where a.cCVCode = '111111' 
	)b on a.存货编码 = b.cInvCode and isnull(a.长度,'') = isnull(b.cFree1,'') and isnull(a.批号,'') = ISNULL(b.cCVBatch ,'')
where a.条形码 = '222222'
";

                sSQL = sSQL.Replace("111111", sCode);
                sSQL = sSQL.Replace("333333", sBarCode);

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

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"]);
                        decimal d件数 = 0;

                        sSQL = "update CheckVouchs set iCVCQuantity  = " + d数量 + ",iCVCNum  = " + d件数 + " where autoid = " + dtData.Rows[i]["盘点单子表ID"];
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    tran.Commit();
                    s = "保存" + sCode + "盘点信息成功";
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
