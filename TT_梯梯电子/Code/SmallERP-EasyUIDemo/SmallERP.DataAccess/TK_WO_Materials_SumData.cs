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
    public class TK_WO_Materials_SumData
    {

        public TK_WO_Materials_SumData()
        { }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetListGroup(string sTKVersion, string qyPlanner, string qyGroup)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT sChild FROM TK_WO_Materials_Sum_History T left join TK_Trialkitting_Results R on T.sPartID=R.cInvCode ");
            strSql.Append(" WHERE 1=1 and R.cInvCode is not null");
            //if (!string.IsNullOrEmpty(sTKVersion))
            //{
            //    strSql.Replace("1=1", "1=1 and sVersion='" + sTKVersion + "'");
            //}
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            //if (!string.IsNullOrEmpty(qyGroup))
            //{
            //    strSql.Replace("1=1", "1=1 and ProdGroup='" + qyGroup + "'");
            //}
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT sPartID, sChild, Qty_Child FROM TK_WO_Materials_Sum_History T left join TK_Trialkitting_Results R on T.sPartID=R.cInvCode");
            strSql.Append(" WHERE 1=1 and R.cInvCode is not null");
            //if (!string.IsNullOrEmpty(sTKVersion))
            //{
            //    strSql.Replace("1=1", "1=1 and sVersion='" + sTKVersion + "'");
            //}
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            //if (!string.IsNullOrEmpty(qyGroup))
            //{
            //    strSql.Replace("1=1", "1=1 and ProdGroup='" + qyGroup + "'");
            //}
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

    }
}
