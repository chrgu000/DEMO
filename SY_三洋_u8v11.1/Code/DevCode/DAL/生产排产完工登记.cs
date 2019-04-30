using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections;

namespace TH.DAL
{
    public partial class 生产排产完工登记
    {
        DAL.GetBaseData BaseData = new GetBaseData();

        public DateTime Get最新计划生产日期(DateTime d完工日期)
        {
            string sSQL = @"
select max(排产日期) from dbo.生产日计划历史 where 计划生产日期 = '111111' and isnull(审核人,'') <> ''
";
            sSQL = sSQL.Replace("111111", d完工日期.ToString("yyyy-MM-dd"));
            DataTable dt = DbHelperSQL.Query(sSQL);
            return BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);
        }

        public DataTable GetWGDJ(DateTime d计划生产日期,string sLineNo)
        {
            string sSQL = @"
select a.GUID as 来源GUID,a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,a.存货编码,cast(b.数量 as decimal(16,0)) as 计划数量
    ,cast(case when isnull(c.完工数量,0) = 0 then b.数量 else c.完工数量 end as decimal(16,0)) as 完工数量
	,b.产线 as 产线编码,'111111' as 完工日期
    ,cast(case when isnull(c.完工数量,0) = 0 then 0 else 1 end as bit) as 是否报工
    ,c.制单人,c.制单日期,c.审核人,c.审核日期,b.iID as 生产日计划iID
from dbo.生产计划 a 
	inner join dbo.生产日计划 b on a.GUID = b.来源GUID
    left join 生产日计划完工登记 c on c.生产日计划iID = b.iID
	
where isnull(a.审核人,'') <> '' and isnull(a.关闭人,'') = '' 
	and b.计划生产日期 = '111111'
    and b.产线 = '222222'
order by b.产线,a.存货编码
";

            sSQL = sSQL.Replace("111111", d计划生产日期.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", sLineNo);
            DataTable dt = DbHelperSQL.Query(sSQL);

            return dt;
        }

        public int Audit(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                        continue;

                    TH.Model.生产排产完工登记 model = new TH.Model.生产排产完工登记();

                    string sSQL = "select * from dbo.生产日计划完工登记 where 生产日计划iID = '" + dt.Rows[i]["生产日计划iID"].ToString().Trim() + "' ";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        if (dtTemp.Rows[0]["审核人"].ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已审核\n";
                            continue;
                        }
                        sSQL = "update 生产日计划完工登记 set 审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',审核日期 = '" + BaseData.GetDatetimeSer() + "' where  生产日计划iID = '" + dt.Rows[i]["生产日计划iID"].ToString().Trim() + "'";
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "未保存不能审核\n";
                    }
                }

                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public int UnAudit(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                        continue;

                    TH.Model.生产排产完工登记 model = new TH.Model.生产排产完工登记();

                    string sSQL = "select * from dbo.生产日计划完工登记 where 生产日计划iID = '" + dt.Rows[i]["生产日计划iID"].ToString().Trim() + "' ";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        if (dtTemp.Rows[0]["审核人"].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "未审核\n";
                            continue;
                        }
                        sSQL = "update 生产日计划完工登记 set 审核人 = null,审核日期 = null where  生产日计划iID = '" + dt.Rows[i]["生产日计划iID"].ToString().Trim() + "' ";
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "未保存不能审核\n";
                    }
                }

                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public int DEL(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                        continue;

                    TH.Model.生产排产完工登记 model = new TH.Model.生产排产完工登记();
                    model.生产日计划iID = BaseFunction.BaseFunction.ReturnLong(dt.Rows[i]["生产日计划iID"]);
                    model.完工数量 = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["完工数量"], 0, 0);
                    model.制单人 = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    model.制单日期 = BaseData.GetDatetimeSer();

                    string sSQL = "select * from dbo.生产日计划完工登记 where 生产日计划iID = '" + model.生产日计划iID + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        if (dtTemp.Rows[0]["审核人"].ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已审核\n";
                            continue;
                        }

                        sSQL = Delete(model.生产日计划iID);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }
                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        public int Save(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                        continue;

                    TH.Model.生产排产完工登记 model = new TH.Model.生产排产完工登记();
                    model.生产日计划iID = BaseFunction.BaseFunction.ReturnLong(dt.Rows[i]["生产日计划iID"]);
                    model.完工数量 = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["完工数量"], 0, 0);
                    model.制单人 = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    model.制单日期 = BaseData.GetDatetimeSer();

                    string sSQL = "select * from dbo.生产日计划完工登记 where 生产日计划iID = '" + model.生产日计划iID + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count >0)
                    {
                        if (dtTemp.Rows[0]["审核人"].ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已审核\n";
                        }

                        sSQL = Update(model);
                    }
                    else
                    {
                        sSQL = Add(model);
                    }

                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.生产排产完工登记 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.生产日计划iID != null)
            {
                strSql1.Append("生产日计划iID,");
                strSql2.Append("" + model.生产日计划iID + ",");
            }
            if (model.完工数量 != null)
            {
                strSql1.Append("完工数量,");
                strSql2.Append("" + model.完工数量 + ",");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            strSql.Append("insert into 生产日计划完工登记(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.生产排产完工登记 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 生产日计划完工登记 set ");
            if (model.完工数量 != null)
            {
                strSql.Append("完工数量=" + model.完工数量 + ",");
            }
            else
            {
                strSql.Append("完工数量= null ,");
            }
            if (model.制单人 != null)
            {
                strSql.Append("制单人='" + model.制单人 + "',");
            }
            else
            {
                strSql.Append("制单人= null ,");
            }
            if (model.制单日期 != null)
            {
                strSql.Append("制单日期='" + model.制单日期 + "',");
            }
            else
            {
                strSql.Append("制单日期= null ,");
            }
            if (model.审核人 != null)
            {
                strSql.Append("审核人='" + model.审核人 + "',");
            }
            else
            {
                strSql.Append("审核人= null ,");
            }
            if (model.审核日期 != null)
            {
                strSql.Append("审核日期='" + model.审核日期 + "',");
            }
            else
            {
                strSql.Append("审核日期= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where 生产日计划iID=" + model.生产日计划iID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(long l生产日计划iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 生产日计划完工登记 ");
            strSql.Append(" where 生产日计划iID='" + l生产日计划iID + "' ");
            return strSql.ToString();
        }

        public DataTable GetDT完工(string sWhere)
        {
            string sSQL = @"
select a.单据类型,a.评审单据号,a.销售订单号,a.销售订单行号,b.计划生产日期
	,b.产线 as 产线编码,e.LineName as 产线,a.存货编码,d.cInvName as 存货名称,d.cInvStd as 规格型号
	,cast(a.数量 as decimal(16,0)) as 计划总量
	,cast(b.数量 as decimal(16,0)) as 日计划数量
	,cast(c.完工数量 as decimal(16,0)) as 日完工数量,convert(varchar(10),c.制单日期,120) as 完工日期
    ,c.制单人,c.制单日期,c.审核人,c.审核日期
    ,a.关闭人 as 计划关闭人,a.关闭日期 as 计划关闭日期
from dbo.生产计划 a 
	inner join dbo.生产日计划 b on a.GUID = b.来源GUID
    left join 生产日计划完工登记 c on c.生产日计划iID = b.iID
    left join @u8.Inventory d on d.cinvcode = a.存货编码
    left join dbo.ProductionLine e on e.[LineNo] = b.产线
where 1=1
order by a.iID,a.来源GUID,b.iID
            ";

            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }

            DataTable dt = DbHelperSQL.Query(sSQL);

            return dt;
        }
    }
}
