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
    public class TK_PeriodData
    {

        public TK_PeriodData()
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
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_PeriodEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iYear != null)
            {
                strSql1.Append("iYear,");
                strSql2.Append("'" + model.iYear + "',");
            }
            if (model.iMonth != null)
            {
                strSql1.Append("iMonth,");
                strSql2.Append("'" + model.iMonth + "',");
            }
            if (model.Period01 != null)
            {
                strSql1.Append("Period01,");
                strSql2.Append("'" + model.Period01 + "',");
            }
            if (model.Period02 != null)
            {
                strSql1.Append("Period02,");
                strSql2.Append("'" + model.Period02 + "',");
            }
            if (model.Period03 != null)
            {
                strSql1.Append("Period03,");
                strSql2.Append("'" + model.Period03 + "',");
            }
            if (model.Period04 != null)
            {
                strSql1.Append("Period04,");
                strSql2.Append("'" + model.Period04 + "',");
            }
            if (model.Period05 != null)
            {
                strSql1.Append("Period05,");
                strSql2.Append("'" + model.Period05 + "',");
            }
            if (model.Period06 != null)
            {
                strSql1.Append("Period06,");
                strSql2.Append("'" + model.Period06 + "',");
            }
            if (model.Period07 != null)
            {
                strSql1.Append("Period07,");
                strSql2.Append("'" + model.Period07 + "',");
            }
            if (model.Period08 != null)
            {
                strSql1.Append("Period08,");
                strSql2.Append("'" + model.Period08 + "',");
            }
            if (model.Period09 != null)
            {
                strSql1.Append("Period09,");
                strSql2.Append("'" + model.Period09 + "',");
            }
            if (model.Period10 != null)
            {
                strSql1.Append("Period10,");
                strSql2.Append("'" + model.Period10 + "',");
            }
            if (model.Period11 != null)
            {
                strSql1.Append("Period11,");
                strSql2.Append("'" + model.Period11 + "',");
            }
            if (model.Period12 != null)
            {
                strSql1.Append("Period12,");
                strSql2.Append("'" + model.Period12 + "',");
            }
            if (model.Period13 != null)
            {
                strSql1.Append("Period13,");
                strSql2.Append("'" + model.Period13 + "',");
            }
            if (model.Period14 != null)
            {
                strSql1.Append("Period14,");
                strSql2.Append("'" + model.Period14 + "',");
            }
            if (model.Period15 != null)
            {
                strSql1.Append("Period15,");
                strSql2.Append("'" + model.Period15 + "',");
            }
            if (model.Period16 != null)
            {
                strSql1.Append("Period16,");
                strSql2.Append("'" + model.Period16 + "',");
            }
            if (model.Period17 != null)
            {
                strSql1.Append("Period17,");
                strSql2.Append("'" + model.Period17 + "',");
            }
            strSql.Append("insert into TK_Period(");
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
        public string Update(TK_PeriodEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Period set ");
            if (model.Period01 != null)
            {
                strSql.Append("Period01='" + model.Period01 + "',");
            }
            else
            {
                strSql.Append("Period01= null ,");
            }
            if (model.Period02 != null)
            {
                strSql.Append("Period02='" + model.Period02 + "',");
            }
            else
            {
                strSql.Append("Period02= null ,");
            }
            if (model.Period03 != null)
            {
                strSql.Append("Period03='" + model.Period03 + "',");
            }
            else
            {
                strSql.Append("Period03= null ,");
            }
            if (model.Period04 != null)
            {
                strSql.Append("Period04='" + model.Period04 + "',");
            }
            else
            {
                strSql.Append("Period04= null ,");
            }
            if (model.Period05 != null)
            {
                strSql.Append("Period05='" + model.Period05 + "',");
            }
            else
            {
                strSql.Append("Period05= null ,");
            }
            if (model.Period06 != null)
            {
                strSql.Append("Period06='" + model.Period06 + "',");
            }
            else
            {
                strSql.Append("Period06= null ,");
            }
            if (model.Period07 != null)
            {
                strSql.Append("Period07='" + model.Period07 + "',");
            }
            else
            {
                strSql.Append("Period07= null ,");
            }
            if (model.Period08 != null)
            {
                strSql.Append("Period08='" + model.Period08 + "',");
            }
            else
            {
                strSql.Append("Period08= null ,");
            }
            if (model.Period09 != null)
            {
                strSql.Append("Period09='" + model.Period09 + "',");
            }
            else
            {
                strSql.Append("Period09= null ,");
            }
            if (model.Period10 != null)
            {
                strSql.Append("Period10='" + model.Period10 + "',");
            }
            else
            {
                strSql.Append("Period10= null ,");
            }
            if (model.Period11 != null)
            {
                strSql.Append("Period11='" + model.Period11 + "',");
            }
            else
            {
                strSql.Append("Period11= null ,");
            }
            if (model.Period12 != null)
            {
                strSql.Append("Period12='" + model.Period12 + "',");
            }
            else
            {
                strSql.Append("Period12= null ,");
            }
            if (model.Period13 != null)
            {
                strSql.Append("Period13='" + model.Period13 + "',");
            }
            else
            {
                strSql.Append("Period13= null ,");
            }
            if (model.Period14 != null)
            {
                strSql.Append("Period14='" + model.Period14 + "',");
            }
            else
            {
                strSql.Append("Period14= null ,");
            }
            if (model.Period15 != null)
            {
                strSql.Append("Period15='" + model.Period15 + "',");
            }
            else
            {
                strSql.Append("Period15= null ,");
            }
            if (model.Period16 != null)
            {
                strSql.Append("Period16='" + model.Period16 + "',");
            }
            else
            {
                strSql.Append("Period16= null ,");
            }
            if (model.Period17 != null)
            {
                strSql.Append("Period17='" + model.Period17 + "',");
            }
            else
            {
                strSql.Append("Period17= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iYear=" + model.iYear + " and iMonth=" + model.iMonth + "");

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
        /// 删除一条数据
        /// </summary>
        /// <param name="iID">删除ID</param>
        /// <returns></returns>
        public string Delete(string iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TK_Period ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_PeriodEntity DataRowToModel(DataRow row)
        {
            TK_PeriodEntity model = new TK_PeriodEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["iYear"] != null)
                {
                    model.iYear = row["iYear"].ToString();
                }
                if (row["iMonth"] != null)
                {
                    model.iMonth = row["iMonth"].ToString();
                }
                if (row["Period01"] != null && row["Period01"].ToString() != "")
                {
                    model.Period01 = DateTime.Parse(row["Period01"].ToString());
                }
                if (row["Period02"] != null && row["Period02"].ToString() != "")
                {
                    model.Period02 = DateTime.Parse(row["Period02"].ToString());
                }
                if (row["Period03"] != null && row["Period03"].ToString() != "")
                {
                    model.Period03 = DateTime.Parse(row["Period03"].ToString());
                }
                if (row["Period04"] != null && row["Period04"].ToString() != "")
                {
                    model.Period04 = DateTime.Parse(row["Period04"].ToString());
                }
                if (row["Period05"] != null && row["Period05"].ToString() != "")
                {
                    model.Period05 = DateTime.Parse(row["Period05"].ToString());
                }
                if (row["Period06"] != null && row["Period06"].ToString() != "")
                {
                    model.Period06 = DateTime.Parse(row["Period06"].ToString());
                }
                if (row["Period07"] != null && row["Period07"].ToString() != "")
                {
                    model.Period07 = DateTime.Parse(row["Period07"].ToString());
                }
                if (row["Period08"] != null && row["Period08"].ToString() != "")
                {
                    model.Period08 = DateTime.Parse(row["Period08"].ToString());
                }
                if (row["Period09"] != null && row["Period09"].ToString() != "")
                {
                    model.Period09 = DateTime.Parse(row["Period09"].ToString());
                }
                if (row["Period10"] != null && row["Period10"].ToString() != "")
                {
                    model.Period10 = DateTime.Parse(row["Period10"].ToString());
                }
                if (row["Period11"] != null && row["Period11"].ToString() != "")
                {
                    model.Period11 = DateTime.Parse(row["Period11"].ToString());
                }
                if (row["Period12"] != null && row["Period12"].ToString() != "")
                {
                    model.Period12 = DateTime.Parse(row["Period12"].ToString());
                }
                if (row["Period13"] != null && row["Period13"].ToString() != "")
                {
                    model.Period13 = DateTime.Parse(row["Period13"].ToString());
                }
                if (row["Period14"] != null && row["Period14"].ToString() != "")
                {
                    model.Period14 = DateTime.Parse(row["Period14"].ToString());
                }
                if (row["Period15"] != null && row["Period15"].ToString() != "")
                {
                    model.Period15 = DateTime.Parse(row["Period15"].ToString());
                }
                if (row["Period16"] != null && row["Period16"].ToString() != "")
                {
                    model.Period16 = DateTime.Parse(row["Period16"].ToString());
                }
                if (row["Period17"] != null && row["Period17"].ToString() != "")
                {
                    model.Period17 = DateTime.Parse(row["Period17"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetList2(string sWhere)
        {

            List<TK_PeriodEntity> list = new List<TK_PeriodEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_Period where 1=1 Order By iID ");
            strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetList(string sTKVersionDate)
        {
            int iYear = int.Parse(sTKVersionDate.Split('-')[1].Substring(0, 4));
            int iMonth = int.Parse(sTKVersionDate.Split('-')[1].Substring(4, 2));
            int iDay = int.Parse(sTKVersionDate.Split('-')[1].Substring(6, 2));

            string dDate = iYear + "-";
            if(iMonth.ToString().Length==1)
            {
                dDate = dDate + "0";
            }
            dDate = dDate + iMonth + "-";
            if (iDay.ToString().Length == 1)
            {
                dDate = dDate + "0";
            }
            dDate = dDate + iDay;

            StringBuilder strSql1 = new StringBuilder();
            strSql1.AppendFormat(" Select * From TK_Base_CalendarPeriod where convert(nvarchar(10),dtmStart,120)<='" + dDate + "' and convert(nvarchar(10),dtmEnd,120)>='" + dDate + "' ");
            DataTable dtc = DbHelperSQL.Query(strSql1.ToString()).Tables[0];
            if (dtc.Rows.Count != 1)
            {
                return null;
            }
            iYear = int.Parse(dtc.Rows[0]["iYear"].ToString());
            iMonth = int.Parse(dtc.Rows[0]["iMonth"].ToString());
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_Period where 1=1 Order By iID ");
            strSql = strSql.Replace("1=1", "1=1 and iYear='" + iYear + "' and iMonth='" + iMonth + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            return ds.Tables[0];
        }
    }
}
