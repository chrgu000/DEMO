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
    public class TK_Base_CalendarPeriodData
    {

        public TK_Base_CalendarPeriodData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_Base_CalendarPeriodEntity model)
        {
            StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.iYear != null)
			{
				strSql1.Append("iYear,");
				strSql2.Append(""+model.iYear+",");
			}
			if (model.iMonth != null)
			{
				strSql1.Append("iMonth,");
				strSql2.Append(""+model.iMonth+",");
			}
			if (model.dtmStart != null)
			{
				strSql1.Append("dtmStart,");
				strSql2.Append("'"+model.dtmStart+"',");
			}
			if (model.dtmEnd != null)
			{
				strSql1.Append("dtmEnd,");
				strSql2.Append("'"+model.dtmEnd+"',");
			}
			if (model.iWeek1 != null)
			{
				strSql1.Append("iWeek1,");
				strSql2.Append("'"+model.iWeek1+"',");
			}
			if (model.iWeek2 != null)
			{
				strSql1.Append("iWeek2,");
				strSql2.Append("'"+model.iWeek2+"',");
			}
			if (model.iWeek3 != null)
			{
				strSql1.Append("iWeek3,");
				strSql2.Append("'"+model.iWeek3+"',");
			}
			if (model.iWeek4 != null)
			{
				strSql1.Append("iWeek4,");
				strSql2.Append("'"+model.iWeek4+"',");
			}
			if (model.iWeek5 != null)
			{
				strSql1.Append("iWeek5,");
				strSql2.Append("'"+model.iWeek5+"',");
			}
			if (model.sPreparedBy != null)
			{
				strSql1.Append("sPreparedBy,");
				strSql2.Append("'"+model.sPreparedBy+"',");
			}
			if (model.dtmPreparedBy != null)
			{
				strSql1.Append("dtmPreparedBy,");
				strSql2.Append("'"+model.dtmPreparedBy+"',");
			}
			strSql.Append("insert into TK_Base_CalendarPeriod(");
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
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(TK_Base_CalendarPeriodEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Base_CalendarPeriod set ");
            if (model.iYear != null)
            {
                strSql.Append("iYear=" + model.iYear + ",");
            }
            if (model.iMonth != null)
            {
                strSql.Append("iMonth=" + model.iMonth + ",");
            }
            if (model.dtmStart != null)
            {
                strSql.Append("dtmStart='" + model.dtmStart + "',");
            }
            else
            {
                strSql.Append("dtmStart= null ,");
            }
            if (model.dtmEnd != null)
            {
                strSql.Append("dtmEnd='" + model.dtmEnd + "',");
            }
            else
            {
                strSql.Append("dtmEnd= null ,");
            }
            if (model.iWeek1 != null)
            {
                strSql.Append("iWeek1='" + model.iWeek1 + "',");
            }
            else
            {
                strSql.Append("iWeek1= null ,");
            }
            if (model.iWeek2 != null)
            {
                strSql.Append("iWeek2='" + model.iWeek2 + "',");
            }
            else
            {
                strSql.Append("iWeek2= null ,");
            }
            if (model.iWeek3 != null)
            {
                strSql.Append("iWeek3='" + model.iWeek3 + "',");
            }
            else
            {
                strSql.Append("iWeek3= null ,");
            }
            if (model.iWeek4 != null)
            {
                strSql.Append("iWeek4='" + model.iWeek4 + "',");
            }
            else
            {
                strSql.Append("iWeek4= null ,");
            }
            if (model.iWeek5 != null)
            {
                strSql.Append("iWeek5='" + model.iWeek5 + "',");
            }
            else
            {
                strSql.Append("iWeek5= null ,");
            }
            if (model.sPreparedBy != null)
            {
                strSql.Append("sPreparedBy='" + model.sPreparedBy + "',");
            }
            else
            {
                strSql.Append("sPreparedBy= null ,");
            }
            if (model.dtmPreparedBy != null)
            {
                strSql.Append("dtmPreparedBy='" + model.dtmPreparedBy + "',");
            }
            else
            {
                strSql.Append("dtmPreparedBy= null ,");
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
        /// 更新多数据行
        /// </summary>
        /// <param name="aList"></param>
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
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_Base_CalendarPeriodEntity DataRowToModel(DataRow row)
        {
            TK_Base_CalendarPeriodEntity model = new TK_Base_CalendarPeriodEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["iYear"] != null && row["iYear"].ToString() != "")
                {
                    model.iYear = int.Parse(row["iYear"].ToString());
                }
                if (row["iMonth"] != null && row["iMonth"].ToString() != "")
                {
                    model.iMonth = int.Parse(row["iMonth"].ToString());
                }
                if (row["dtmStart"] != null && row["dtmStart"].ToString() != "")
                {
                    model.dtmStart = DateTime.Parse(row["dtmStart"].ToString());
                }
                if (row["dtmEnd"] != null && row["dtmEnd"].ToString() != "")
                {
                    model.dtmEnd = DateTime.Parse(row["dtmEnd"].ToString());
                }
                if (row["iWeek1"] != null && row["iWeek1"].ToString() != "")
                {
                    model.iWeek1 = DateTime.Parse(row["iWeek1"].ToString());
                }
                if (row["iWeek2"] != null && row["iWeek2"].ToString() != "")
                {
                    model.iWeek2 = DateTime.Parse(row["iWeek2"].ToString());
                }
                if (row["iWeek3"] != null && row["iWeek3"].ToString() != "")
                {
                    model.iWeek3 = DateTime.Parse(row["iWeek3"].ToString());
                }
                if (row["iWeek4"] != null && row["iWeek4"].ToString() != "")
                {
                    model.iWeek4 = DateTime.Parse(row["iWeek4"].ToString());
                }
                if (row["iWeek5"] != null && row["iWeek5"].ToString() != "")
                {
                    model.iWeek5 = DateTime.Parse(row["iWeek5"].ToString());
                }
                if (row["sPreparedBy"] != null)
                {
                    model.sPreparedBy = row["sPreparedBy"].ToString();
                }
                if (row["dtmPreparedBy"] != null && row["dtmPreparedBy"].ToString() != "")
                {
                    model.dtmPreparedBy = DateTime.Parse(row["dtmPreparedBy"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public List<TK_Base_CalendarPeriodEntity> GetList(string sWhere)
        {
            List<TK_Base_CalendarPeriodEntity> list = new List<TK_Base_CalendarPeriodEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_Base_CalendarPeriod where 1=1 Order By  iYear, iMonth ");
            strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TK_Base_CalendarPeriodEntity sh = DataRowToModel(row);
                    list.Add(sh);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得17个工作日历数据
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iMonth">月</param>
        /// <returns></returns>
        public DataTable GetList(string iYear, string iMonth)
        {
            DateTime d = DateTime.Parse(iYear + "-" + iMonth + "-01");
            DateTime d1 = d.AddMonths(3);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select * from (
Select top 3 iYear, iMonth,iWeek1 as iWeek From TK_Base_CalendarPeriod where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={0} order by iYear, iMonth
union all
Select top 3 iYear, iMonth,iWeek2 From TK_Base_CalendarPeriod where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={0} order by iYear, iMonth
union all
Select top 3 iYear, iMonth,iWeek3 From TK_Base_CalendarPeriod where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={0} order by iYear, iMonth
union all
Select top 3 iYear, iMonth,iWeek4 From TK_Base_CalendarPeriod where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={0} order by iYear, iMonth
union all
Select top 3 iYear, iMonth,iWeek5 From TK_Base_CalendarPeriod where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={0} order by iYear, iMonth
union all
Select top 4 iYear, iMonth,iWeek1 From TK_Base_CalendarPeriod where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={1} order by iYear, iMonth
) a where isnull(iWeek,'')<>'' order by iYear, iMonth,iWeek", d.ToString("yyyyMM"), d1.ToString("yyyyMM"));
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

    }
}
