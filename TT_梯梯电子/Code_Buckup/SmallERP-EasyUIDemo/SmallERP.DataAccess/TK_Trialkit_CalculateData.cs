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
    public class TK_Trialkit_CalculateData
    {

        public TK_Trialkit_CalculateData()
        { }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM TK_Trialkit_Calculate T ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            if (!string.IsNullOrEmpty(qyPlanner))
            {
                strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            }
            if (!string.IsNullOrEmpty(qyGroup))
            {
                strSql.Replace("1=1", "1=1 and ProdGroup='" + qyGroup + "'");
            }
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

    }
}
