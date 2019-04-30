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
        public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup, string queryName, string qyReorderpolicy, DataTable dtt, string userId, string name, string roleId, int rowStart, int rowEnd, out int total, bool b, bool b1)
        {
            if (b == true)
            {
                //获得记录总数
                StringBuilder strCountSql = new StringBuilder();
                strCountSql.Append(@" Select Count(1) From (");

                strCountSql.Append(@"SELECT cInvCode,b.sTKVersion,Planner,ProdGroup,Reorderpolicy,iCycle as DayWO,QtyCurr,max(NetQty) as NetQty,QtyWO ");

                //for (int i = 0; i < dtt.Columns.Count; i++)
                //{
                //    if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
                //    {
                //        string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
                //        strCountSql.Append(" ,SUM(CASE dtmQty WHEN '" + ddate + "' THEN Qty ELSE 0 END) AS '" + ddate + "' ");
                //    }
                //}

                strCountSql.Append(@" FROM (select max(sDataVersion) sDataVersion,sTKVersion from TK_Trialkitting_Result with (nolock) group by sTKVersion) a 
left join TK_Trialkitting_Results b with (nolock) on a.sTKVersion=b.sTKVersion 
left join (select sVersion,sItemNo,sum(dQty) dQty from TK_CurrentStock_History with (nolock) group by sVersion,sItemNo) c 
	on a.sDataVersion=c.sVersion and b.cInvCode=c.sItemNo 
left join (select sVersion,sPartID,sum(fOpenQTY) dQty from TK_WO_History with (nolock) group by sVersion,sPartID) d 
	on a.sDataVersion=d.sVersion and b.cInvCode=d.sPartID  
left join TK_Base_ItemNo_Cycle e with (nolock) on b.cInvCode=e.sItemNo
            where 1=1 --and isnull(b.Qty,0)<>0 
                GROUP BY cInvCode,b.sTKVersion,Planner,ProdGroup,Reorderpolicy,iCycle,QtyCurr,QtyCurr,QtyWO ");


                strCountSql.Append(@") T ");

                if (!string.IsNullOrEmpty(sTKVersion))
                {
                    strCountSql.Replace("1=1", "1=1 and b.sTKVersion='" + sTKVersion + "'");
                }
                if (!string.IsNullOrEmpty(qyPlanner))
                {
                    strCountSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
                }
                if (!string.IsNullOrEmpty(queryName))
                {
                    strCountSql.Replace("1=1", "1=1 and cInvCode='" + queryName + "'");
                }
                if (!string.IsNullOrEmpty(qyGroup))
                {
                    string[] splitqueryGroup = qyGroup.Split(',');
                    string listqueryGroup = "";
                    for (int i = 0; i < splitqueryGroup.Length; i++)
                    {
                        if (splitqueryGroup[i] != "")
                        {
                            if (listqueryGroup != "")
                            {
                                listqueryGroup = listqueryGroup + ",";
                            }
                            listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                        }
                    }
                    strCountSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
                }
                if (!string.IsNullOrEmpty(qyReorderpolicy))
                {
                    strCountSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
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
            strSql.Append(@"select max(sDataVersion) sDataVersion,sTKVersion into #a from TK_Trialkitting_Result with (nolock) where 2=2 group by sTKVersion
select sVersion,sItemNo,sum(dQty) dQty into #b from TK_CurrentStock_History a with (nolock) left join #a b on a.sVersion=b.sDataVersion where b.sDataVersion is not null group by sVersion,sItemNo
select sVersion,sPartID,sum(fOpenQTY) dQty into #c from TK_WO_History a with (nolock) left join #a b on a.sVersion=b.sDataVersion where b.sDataVersion is not null group by sVersion,sPartID
select child,max(orderid) AS orderid into #d from TK_BOM_Order with (nolock) group by child
select * into #e from TK_Base_ItemNo_Cycle with (nolock)
select * into #f from _Get_TK_PartMaster with (nolock)
select * into #g from TK_Trialkitting_Results with (nolock)
    SELECT ");
            if (b1 == true)
            {
                strSql.Append(@"cInvCode,Planner,CommidityCode,Reorderpolicy,ProdGroup,DayWO,NetQty,NCOUNT,NotNCOUNT,QtyCurr,QtyWO ");
            }
            else
            {
                strSql.Append(@"sTKVersion,cInvCode,Planner,CommidityCode,Reorderpolicy,ProdGroup,DayWO,NetQty,NCOUNT,NotNCOUNT,QtyCurr,QtyWO ");
            }
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
                {
                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
                    strSql.Append(" ,[" + ddate + "] ");
                }
            }
            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (b1 == true)
            {
                strSql.Append(" Order By ProdGroup,orderid ");
            }
            else
            {
                strSql.Append(" Order By orderid,sTKVersion,ProdGroup ");
            }
            strSql.Append(@")AS Row, T.* ");

            strSql.Append(@",case when (NetQty-isnull(QtyCurr,0)-isnull(QtyWO,0) ");
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
                {
                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
                    strSql.Append(@"-isnull([" + ddate + "],0)");
                }
            }
            strSql.Append(@")<0 then 0 else (NetQty-isnull(QtyCurr,0)-isnull(QtyWO,0) ");
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
                {
                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
                    strSql.Append(@"-isnull([" + ddate + "],0)");
                }
            }
            strSql.Append(@") end as NotNCOUNT ");

            strSql.Append(@",0 ");
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
                {
                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
                    strSql.Append(@"+isnull([" + ddate + "],0)");
                }
            }
            strSql.Append(@" as NCOUNT ");

            strSql.Append(@" from (");

            strSql.Append(@"SELECT a.sTKVersion,cInvCode,max(NetQty) as NetQty,max(g.ctlr) as Planner,max(commodity) as CommidityCode,max(b.Reorderpolicy) as Reorderpolicy
                ,max(b.ProdGroup) as ProdGroup,iCycle as DayWO,max(QtyCurr) as QtyCurr,max(QtyWO) as QtyWO,orderid ");//b.sTKVersion,cInvCode,Planner,ProdGroup,Reorderpolicy,iCycle as DayWO,QtyCurr,NetQty,QtyWO,orderid
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
                {
                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
                    strSql.Append(" ,SUM(CASE dtmQty WHEN '" + ddate + "' THEN Qty ELSE 0 END) AS '" + ddate + "' ");
                }
            }

            strSql.Append(@" FROM #a a 
left join #g b with (nolock) on a.sTKVersion=b.sTKVersion 
left join #b c 
	on a.sDataVersion=c.sVersion and b.cInvCode=c.sItemNo 
left join #c d 
	on a.sDataVersion=d.sVersion and b.cInvCode=d.sPartID  
left join #e e with (nolock) on b.cInvCode=e.sItemNo 
left join #d f on b.cInvCode=f.child 
left join #f g on b.cInvCode=g.partnum 
                where 1=1 --and isnull(b.Qty,0)<>0
                GROUP BY  a.sTKVersion,cInvCode,iCycle,orderid");//cInvCode,b.sTKVersion,Planner,ProdGroup,Reorderpolicy,iCycle,QtyCurr,NetQty,QtyWO,orderid

            strSql.Append(@") T ");

            if (!string.IsNullOrEmpty(sTKVersion))
            {
                if (sTKVersion.IndexOf(',') >= 0)
                {
                    strSql.Replace("1=1", "1=1 and b.sTKVersion  in ('" + sTKVersion.Replace(",", "','") + "')");
                    strSql.Replace("2=2", "2=2 and sTKVersion  in ('" + sTKVersion.Replace(",", "','") + "')");
                }
                else
                {
                    strSql.Replace("1=1", "1=1 and b.sTKVersion='" + sTKVersion + "'");
                    strSql.Replace("2=2", "2=2 and sTKVersion='" + sTKVersion + "'");
                }
            }
            if (!string.IsNullOrEmpty(queryName))
            {
                strSql.Replace("1=1", "1=1 and cInvCode='" + queryName + "'");
            }
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            if (!string.IsNullOrEmpty(qyGroup))
            {
                string[] splitqueryGroup = qyGroup.Split(',');
                string listqueryGroup = "";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (splitqueryGroup[i] != "")
                    {
                        if (listqueryGroup != "")
                        {
                            listqueryGroup = listqueryGroup + ",";
                        }
                        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                    }
                }
                strSql.Replace("1=1", "1=1 and b.ProdGroup in (" + listqueryGroup + ")");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
            }
            strSql.Append(" ) TT");
            if (b == true)
            {
                strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            }
            strSql.Append(" order by Row");
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

//        //<summary>
//        //获得数据列表-导出Excel
//        //</summary>
//        //<returns></returns>
//        public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, DataTable dtt)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append("SELECT cInvCode,NetQty,Planner,Reorderpolicy,ProdGroup,DayWO,NotNCOUNT,QtyCurr,QtyWO  ");
//            for (int i = 0; i < dtt.Columns.Count; i++)
//            {
//                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
//                {
//                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
//                    strSql.Append(" ,case when [" + ddate + "] <>0 then [" + ddate + "] end [" + ddate + "] ");
//                }
//            }
//            strSql.Append(" FROM ( ");
//            strSql.Append(" SELECT ROW_NUMBER() OVER (");
//            strSql.Append(" Order By ProdGroup,orderid ");
//            strSql.Append(@")AS Row, T.* ");

//            //strSql.Append(@",NetQty ");
//            //for (int i = 0; i < dtt.Columns.Count; i++)
//            //{
//            //    if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
//            //    {
//            //        string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
//            //        strSql.Append(@"-[" + ddate + "]");
//            //    }
//            //}
//            //strSql.Append(@" as NotNCOUNT ");
//            strSql.Append(@",case when (NetQty-isnull(QtyCurr,0)-isnull(QtyWO,0) ");
//            for (int i = 0; i < dtt.Columns.Count; i++)
//            {
//                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
//                {
//                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
//                    strSql.Append(@"-isnull([" + ddate + "],0)");
//                }
//            }
//            strSql.Append(@")<0 then 0 else (NetQty-isnull(QtyCurr,0)-isnull(QtyWO,0) ");
//            for (int i = 0; i < dtt.Columns.Count; i++)
//            {
//                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
//                {
//                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
//                    strSql.Append(@"-isnull([" + ddate + "],0)");
//                }
//            }
//            strSql.Append(@") end as NotNCOUNT ");

//            strSql.Append(@" from (");

//            strSql.Append(@"SELECT cInvCode,b.sTKVersion,Planner,ProdGroup,Reorderpolicy,iCycle as DayWO,QtyCurr,NetQty,QtyWO,orderid ");
//            for (int i = 0; i < dtt.Columns.Count; i++)
//            {
//                if (dtt.Columns[i].ColumnName.IndexOf("Period") > -1)
//                {
//                    string ddate = DateTime.Parse(dtt.Rows[0][i].ToString()).ToString("yyyy-MM-dd");
//                    strSql.Append(" ,SUM(CASE dtmQty WHEN '" + ddate + "' THEN Qty ELSE 0 END) AS '" + ddate + "' ");
//                }
//            }

//            strSql.Append(@" FROM (select max(sDataVersion) sDataVersion,sTKVersion from TK_Trialkitting_Result with (nolock) group by sTKVersion) a 
//left join TK_Trialkitting_Results b with (nolock) on a.sTKVersion=b.sTKVersion 
//left join (select sVersion,sItemNo,sum(dQty) dQty from TK_CurrentStock_History with (nolock) group by sVersion,sItemNo) c 
//	on a.sDataVersion=c.sVersion and b.cInvCode=c.sItemNo 
//left join (select sVersion,sPartID,sum(fOpenQTY) dQty from TK_WO_History with (nolock) group by sVersion,sPartID) d 
//	on a.sDataVersion=d.sVersion and b.cInvCode=d.sPartID    
//left join TK_Base_ItemNo_Cycle e with (nolock) on b.cInvCode=e.sItemNo
//left join (select child,max(orderid) AS orderid from TK_BOM_Order with (nolock) group by child) f on b.cInvCode=f.child 
//where 1=1 and isnull(b.Qty,0)<>0
//                GROUP BY cInvCode,b.sTKVersion,Planner,ProdGroup,Reorderpolicy,iCycle,QtyCurr,NetQty,QtyWO,orderid ");

//            strSql.Append(@") T ");

//            if (!string.IsNullOrEmpty(sTKVersion))
//            {
//                strSql.Replace("1=1", "1=1 and b.sTKVersion='" + sTKVersion + "'");
//            }
//            if (!string.IsNullOrEmpty(qyPlanner))
//            {
//                strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
//            }
//            if (!string.IsNullOrEmpty(qyGroup))
//            {
//                string[] splitqueryGroup = qyGroup.Split(',');
//                string listqueryGroup = "";
//                for (int i = 0; i < splitqueryGroup.Length; i++)
//                {
//                    if (splitqueryGroup[i] != "")
//                    {
//                        if (listqueryGroup != "")
//                        {
//                            listqueryGroup = listqueryGroup + ",";
//                        }
//                        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
//                    }
//                }
//                strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
//            }
//            if (!string.IsNullOrEmpty(qyReorderpolicy))
//            {
//                strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
//            }

//            strSql.Append(" ) TT");
//            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];

//            return result;
//        }

        ////<summary>
        ////获得数据列表-导出PAD Group
        ////</summary>
        ////<returns></returns>
        //public DataTable GetListPADGroup(string sTKVersion, string qyPlanner, string qyGroup)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT cInvCode FROM TK_Trialkitting_Results WHERE 1=1 GROUP BY cInvCode ");
        //    DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

        //    return dt;
        //}

        ////<summary>
        ////获得数据列表-导出PAD
        ////</summary>
        ////<returns></returns>
        //public DataTable GetListPAD(string sTKVersion, string qyPlanner, string qyGroup)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT cInvCode,dtmQty,sum(Qty) as Qty FROM TK_Trialkitting_Results WHERE 1=1 GROUP BY cInvCode,dtmQty ");
        //    DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

        //    return dt;
        //}

        //<summary>
        //得到查询结果列表
        //</summary>
        //<returns></returns>
        //public DataTable GetIsQuery(string sWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append(@"SELECT isnull(sTKVersion,'') FROM TK_Trialkitting_Results T");
        //    strSql.Append(" WHERE 1=1 ");
        //    if (!string.IsNullOrEmpty(sWhere))
        //        strSql.Replace("1=1", "1=1" + sWhere);
        //    DataSet ds = DbHelperSQL.Query(strSql.ToString());
        //    return ds.Tables[0];
        //}

    }
}
