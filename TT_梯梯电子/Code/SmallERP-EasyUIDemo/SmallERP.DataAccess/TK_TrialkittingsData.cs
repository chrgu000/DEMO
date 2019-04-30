using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SmallERP.DBUtility;
using SmallERP.Entity;
using System.Collections;

namespace SmallERP.DataAccess
{
    public class TK_TrialkittingsData
    {

        public TK_TrialkittingsData()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iMonth">月</param>
        /// <returns></returns>
        public int Exists(string iYear, string iMonth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TK_Period");
            strSql.Append(" where iYear=" + iYear + " and iMonth=" + iMonth + " ");
            int i = int.Parse(DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0][0].ToString());
            return i;
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(TK_TrialkittingsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersion,");
                strSql2.Append("'" + model.sTKVersion + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.Planner != null)
            {
                strSql1.Append("Planner,");
                strSql2.Append("'" + model.Planner + "',");
            }
            if (model.ProdGroup != null)
            {
                strSql1.Append("ProdGroup,");
                strSql2.Append("'" + model.ProdGroup + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.NetQty != null)
            {
                strSql1.Append("NetQty,");
                strSql2.Append("" + model.NetQty + ",");
            }
            if (model.Reorderpolicy != null)
            {
                strSql1.Append("Reorderpolicy,");
                strSql2.Append("'" + model.Reorderpolicy + "',");
            }
            if (model.DayWO != null)
            {
                strSql1.Append("DayWO,");
                strSql2.Append("" + model.DayWO + ",");
            }
            if (model.QtyCurr != null)
            {
                strSql1.Append("QtyCurr,");
                strSql2.Append("" + model.QtyCurr + ",");
            }
            if (model.QtyWO != null)
            {
                strSql1.Append("QtyWO,");
                strSql2.Append("" + model.QtyWO + ",");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.dtmQty != null)
            {
                strSql1.Append("dtmQty,");
                strSql2.Append("'" + model.dtmQty + "',");
            }
            strSql.Append("insert into TK_Trialkitting_Results(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");

            return strSql.ToString();
            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TK_TrialkittingsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Trialkitting_Results set ");
            if (model.GUID != null)
            {
                strSql.Append("GUID='" + model.GUID + "',");
            }
            if (model.sTKVersion != null)
            {
                strSql.Append("sTKVersion='" + model.sTKVersion + "',");
            }
            if (model.dDate != null)
            {
                strSql.Append("dDate='" + model.dDate + "',");
            }
            else
            {
                strSql.Append("dDate= null ,");
            }
            if (model.Planner != null)
            {
                strSql.Append("Planner='" + model.Planner + "',");
            }
            else
            {
                strSql.Append("Planner= null ,");
            }
            if (model.ProdGroup != null)
            {
                strSql.Append("ProdGroup='" + model.ProdGroup + "',");
            }
            else
            {
                strSql.Append("ProdGroup= null ,");
            }
            if (model.cInvCode != null)
            {
                strSql.Append("cInvCode='" + model.cInvCode + "',");
            }
            else
            {
                strSql.Append("cInvCode= null ,");
            }
            if (model.NetQty != null)
            {
                strSql.Append("NetQty=" + model.NetQty + ",");
            }
            else
            {
                strSql.Append("NetQty= null ,");
            }
            if (model.Reorderpolicy != null)
            {
                strSql.Append("Reorderpolicy='" + model.Reorderpolicy + "',");
            }
            else
            {
                strSql.Append("Reorderpolicy= null ,");
            }
            if (model.DayWO != null)
            {
                strSql.Append("DayWO=" + model.DayWO + ",");
            }
            else
            {
                strSql.Append("DayWO= null ,");
            }
            if (model.QtyCurr != null)
            {
                strSql.Append("QtyCurr=" + model.QtyCurr + ",");
            }
            else
            {
                strSql.Append("QtyCurr= null ,");
            }
            if (model.QtyWO != null)
            {
                strSql.Append("QtyWO=" + model.QtyWO + ",");
            }
            else
            {
                strSql.Append("QtyWO= null ,");
            }
            if (model.Qty != null)
            {
                strSql.Append("Qty=" + model.Qty + ",");
            }
            else
            {
                strSql.Append("Qty= null ,");
            }
            if (model.dtmQty != null)
            {
                strSql.Append("dtmQty='" + model.dtmQty + "',");
            }
            else
            {
                strSql.Append("dtmQty= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return strSql.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ArrayList aList)
        {
            int rows = DbHelperSQL.ExecuteSqlTran(aList);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TK_TrialkittingsEntity DataRowToModel(DataRow row)
        {
            TK_TrialkittingsEntity model = new TK_TrialkittingsEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["GUID"] != null && row["GUID"].ToString() != "")
                {
                    model.GUID = new Guid(row["GUID"].ToString());
                }
                if (row["sTKVersion"] != null)
                {
                    model.sTKVersion = row["sTKVersion"].ToString();
                }
                if (row["dDate"] != null && row["dDate"].ToString() != "")
                {
                    model.dDate = DateTime.Parse(row["dDate"].ToString());
                }
                if (row["Planner"] != null)
                {
                    model.Planner = row["Planner"].ToString();
                }
                if (row["ProdGroup"] != null)
                {
                    model.ProdGroup = row["ProdGroup"].ToString();
                }
                if (row["cInvCode"] != null)
                {
                    model.cInvCode = row["cInvCode"].ToString();
                }
                if (row["NetQty"] != null && row["NetQty"].ToString() != "")
                {
                    model.NetQty = decimal.Parse(row["NetQty"].ToString());
                }
                if (row["Reorderpolicy"] != null)
                {
                    model.Reorderpolicy = row["Reorderpolicy"].ToString();
                }
                if (row["DayWO"] != null && row["DayWO"].ToString() != "")
                {
                    model.DayWO = int.Parse(row["DayWO"].ToString());
                }
                if (row["QtyCurr"] != null && row["QtyCurr"].ToString() != "")
                {
                    model.QtyCurr = decimal.Parse(row["QtyCurr"].ToString());
                }
                if (row["QtyWO"] != null && row["QtyWO"].ToString() != "")
                {
                    model.QtyWO = decimal.Parse(row["QtyWO"].ToString());
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(row["Qty"].ToString());
                }
                if (row["dtmQty"] != null && row["dtmQty"].ToString() != "")
                {
                    model.dtmQty = DateTime.Parse(row["dtmQty"].ToString());
                }
            }
            return model;
        }

        //<summary>
        //获得分页数据列表 导出Excel
        //</summary>
        //<returns></returns>
        public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string queryName, string qyReorderpolicy, DataTable dtt, string userId, string name, string roleId, int rowStart, int rowEnd, out int total, bool b, bool b1)
        {
            if (b == true)
            {
                //获得记录总数
                StringBuilder strCountSql = new StringBuilder();
                //strCountSql.Append(@"exec _Get_For_PAD '" + sTKVersion + "'");
                strCountSql.Append(@"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a')) drop table #a
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#b')) drop table #b
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#c')) drop table #c

select * into #a from TK_Trialkit_Net a with (nolock) where 2=2 
select distinct sTKVersion,PartID into #b from TK_Trialkit_Net a with (nolock) where 2=2 and 3=3

select sTKVersion,PartID,ProGroup = ( STUFF(( SELECT   distinct ',' + ProGroup
                          FROM     #a
                          WHERE     PartID = Test.PartID and sTKVersion=Test.sTKVersion
                        FOR
                          XML PATH('')
                        ), 1, 1, '') ) 
into #c 
from #a AS Test group by sTKVersion,PartID

select count(*) from (
    select a.sTKVersion, sDataVersion, a.PartID, PlanCode, CommidityCode, b.ProGroup, reorderpolicy, DayWO
    from #b c left join #c b on c.sTKVersion=b.sTKVersion and c.PartID=b.PartID left join #a a with (nolock) on b.sTKVersion=a.sTKVersion and b.PartID=a.PartID
    where 1=1 
    group by a.sTKVersion, sDataVersion, a.PartID, PlanCode, CommidityCode, b.ProGroup, reorderpolicy, DayWO
) t
");
                if (!string.IsNullOrEmpty(sTKVersion))
                {
                    if (sTKVersion.IndexOf(',') >= 0)
                    {
                        strCountSql.Replace("2=2", "2=2 and sTKVersion  in ('" + sTKVersion.Replace(",", "','") + "')");
                    }
                    else
                    {
                        strCountSql.Replace("2=2", "2=2 and sTKVersion='" + sTKVersion + "'");
                    }
                }
                if (!string.IsNullOrEmpty(queryName))
                {
                    strCountSql.Replace("1=1", "1=1 and a.PartID like '%" + queryName + "%'");
                }
                if (!string.IsNullOrEmpty(qyPlanner))
                {
                    strCountSql.Replace("1=1", "1=1 and default_plannerid='" + qyPlanner + "'");
                }
                if (!string.IsNullOrEmpty(qycategory))
                {
                    strCountSql.Replace("1=1", "1=1 and category='" + qycategory + "'");
                }
                if (!string.IsNullOrEmpty(qyGroup))
                {
                    if (qyGroup.IndexOf(',') >= 0)
                    {
                        strCountSql.Replace("3=3", "3=3 and ProGroup in ('" + qyGroup.Replace(",", "','") + "')");
                    }
                    else
                    {
                        strCountSql.Replace("3=3", "3=3 and ProGroup = '" + qyGroup + "'");
                    }
                }
                if (!string.IsNullOrEmpty(qyReorderpolicy))
                {
                    strCountSql.Replace("1=1", "1=1 and reorderpolicy='" + qyReorderpolicy + "'");
                }
                total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            }
            else
            {
                total = 0;
            }

            //获得记录
            List<TK_NetRequirementEntity> list = new List<TK_NetRequirementEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a')) drop table #a
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#b')) drop table #b
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#c')) drop table #c

select * into #a from TK_Trialkit_Net a with (nolock) where 2=2 
select distinct sTKVersion,PartID into #b from TK_Trialkit_Net a with (nolock) where 2=2 and 3=3

select sTKVersion,PartID,ProGroup = ( STUFF(( SELECT   distinct ',' + ProGroup
                          FROM     #a
                          WHERE     PartID = Test.PartID and sTKVersion=Test.sTKVersion
                        FOR
                          XML PATH('')
                        ), 1, 1, '') ) 
into #c 
from #a AS Test group by sTKVersion,PartID

select 1111111 from (
select ROW_NUMBER() OVER (Order By max(orderid),a.sTKVersion) AS Row, a.sTKVersion, sDataVersion, a.PartID as cInvCode, PlanCode as Planner, CommidityCode, b.ProGroup as ProdGroup,DayWO, reorderpolicy as Reorderpolicy
, sum(NetQty) as NetQty, max(WOQty) as  QtyWO, max(CurrQty) as QtyCurr, max(QTQty) as NCOUNT,max(orderid) as orderid
, sum(Week01) as Week01, sum(Week02) as Week02, sum(Week03) as Week03, sum(Week04) as Week04, sum(Week05) as Week05, sum(Week06) as Week06
, sum(Week07) as Week07, sum(Week08) as Week08, sum(Week09) as Week09, sum(Week10) as Week10, sum(Week11) as Week11, sum(Week12) as Week12, sum(Week13) as Week13
, sum(Month1) as Month1, sum(Month2) as Month2, sum(Month3) as Month3, sum(Month4) as Month4 
from #b c left join #c b on c.sTKVersion=b.sTKVersion and c.PartID=b.PartID left join #a a with (nolock) on b.sTKVersion=a.sTKVersion and b.PartID=a.PartID
where 1=1 
group by a.sTKVersion, sDataVersion, a.PartID, PlanCode, CommidityCode, b.ProGroup, reorderpolicy, DayWO
) t 
");
            if (b == true)
            {
                strSql.AppendFormat(" WHERE t.Row between {0} and {1}", rowStart, rowEnd);
            }
            strSql.Append(@" order by Row ");
            if (b1 == true)
            {
                //页面查询
                strSql.Replace("1111111", @"cInvCode, Planner, CommidityCode, Reorderpolicy, ProdGroup, DayWO, NetQty, QtyCurr ,NCOUNT 
,case when NetQty - isnull(QtyWO,0)- isnull(QtyCurr,0)- isnull(NCOUNT,0)>=0 then NetQty - isnull(QtyWO,0)- isnull(QtyCurr,0)- isnull(NCOUNT,0) end as NotNCOUNT, QtyWO
,Week01, Week02, Week03, Week04, Week05, Week06, Week07, Week08, Week09, Week10, Week11, Week12, Week13, Month1, Month2, Month3, Month4");
                }
            else
            {
                //导出excel
                strSql.Replace("1111111", @"cInvCode, sTKVersion, Planner, CommidityCode, Reorderpolicy, ProdGroup, DayWO, NetQty, QtyCurr ,NCOUNT 
,case when NetQty - isnull(QtyWO,0)- isnull(QtyCurr,0)- isnull(NCOUNT,0)>=0 then NetQty - isnull(QtyWO,0)- isnull(QtyCurr,0)- isnull(NCOUNT,0) end as NotNCOUNT, QtyWO
,Week01, Week02, Week03, Week04, Week05, Week06, Week07, Week08, Week09, Week10, Week11, Week12, Week13, Month1, Month2, Month3, Month4");
            }
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                if (sTKVersion.IndexOf(',') >= 0)
                {
                    strSql.Replace("2=2", "2=2 and sTKVersion  in ('" + sTKVersion.Replace(",", "','") + "')");
                }
                else
                {
                    strSql.Replace("2=2", "2=2 and sTKVersion='" + sTKVersion + "'");
                }
            }
            if (!string.IsNullOrEmpty(queryName))
            {
                strSql.Replace("1=1", "1=1 and a.PartID like '%" + queryName + "%'");
            }
            if (!string.IsNullOrEmpty(qyPlanner))
            {
                strSql.Replace("1=1", "1=1 and default_plannerid='" + qyPlanner + "'");
            }
            if (!string.IsNullOrEmpty(qycategory))
            {
                strSql.Replace("1=1", "1=1 and category='" + qycategory + "'");
            }
            if (!string.IsNullOrEmpty(qyGroup))
            {
                if (qyGroup.IndexOf(',') >= 0)
                {
                    strSql.Replace("3=3", "3=3 and ProGroup in ('" + qyGroup.Replace(",", "','") + "')");
                }
                else
                {
                    strSql.Replace("3=3", "3=3 and ProGroup = '" + qyGroup + "'");
                }
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and reorderpolicy='" + qyReorderpolicy + "'");
            }
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

    }
}
