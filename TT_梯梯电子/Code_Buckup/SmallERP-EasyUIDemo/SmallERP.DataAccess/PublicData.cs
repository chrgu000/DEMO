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
    public class PublicData
    {

        public PublicData()
        { }

        /// <summary>
        /// 计划员
        /// </summary>
        /// <returns></returns>
        public DataTable GetPlannerList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select distinct UserID as iID,UserID as iText From Admin order by UserID");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 工作组
        /// </summary>
        /// <returns></returns>
        public DataTable GetProductGroupList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("  Select distinct prodgroup as iID,prodgroup as iText From _Get_TK_ProdGroup order by prodgroup");
            //strSql.AppendFormat("  Select distinct ProdGroup as iID,ProdGroup as iText From TK_Trialkitting_Results ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 仓库
        /// </summary>
        /// <returns></returns>
        public DataTable GetWarehouseList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("  Select distinct warehouseid as iID,warehouseid as iText From t_trialkit_whclass order by warehouseid");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 版本
        /// </summary>
        /// <returns></returns>
        public DataTable GetVersionList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("  Select distinct sVersion as iID,sVersion as iText From TK_NetRequirement_History order by sVersion desc ");
            //strSql.AppendFormat("  Select distinct sTKVersion as iID,sTKVersion as iText From TK_Trialkitting_Result order by sTKVersion desc ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        public DataTable GetPeriod()
        {
            int iYear = DateTime.Now.Year;
            int iMonth = DateTime.Now.Month;
            int iDay = DateTime.Now.Day;

            string dDate = iYear + "-";
            if (iMonth.ToString().Length == 1)
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

            DateTime d = DateTime.Parse(iYear + "-" + iMonth + "-01");
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SET LANGUAGE us_english
select *,substring(convert(varchar(11),iDay,106),4,3) as EgMonth from (
Select top 7 a.iYear, a.iMonth,a.dtmStart,a.dtmEnd,convert(datetime,convert(nvarchar,a.iYear)+'-'+convert(nvarchar(2),right('0'+convert(nvarchar,a.iMonth),2))+'-01') as iDay
, b.iWeek1, b.iWeek2, b.iWeek3, b.iWeek4, b.iWeek5 
From TK_Base_CalendarPeriod a 
left join  TK_Base_CalendarPeriod b on a.iYear=b.iYear and a.iMonth=b.iMonth
where convert(nvarchar,a.iYear)+right('0'+convert(nvarchar,a.iMonth),2)>={0} order by a.iYear, a.iMonth
) a  order by iYear, iMonth", d.ToString("yyyyMM"));
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }
    }
}
