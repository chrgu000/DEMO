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
    public class TK_NetRequirementData
    {

        public TK_NetRequirementData()
        { }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetList(string sWhere, string userId, string name, string roleId, int rowStart, int rowEnd, out int total)
        {
            //获得记录总数
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(" Select Count(1) From TK_NetRequirement_History T Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_NetRequirementEntity> list = new List<TK_NetRequirementEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.sPartID,dtmRequirement ");
            strSql.Append(")AS Row, T.* from TK_NetRequirement_History T Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        /// <summary>
        /// 分页查询需求列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetListNet(string sWhere, string userId, string name, string roleId, int rowStart, int rowEnd, out int total)
        {
            StringBuilder strSqlMax = new StringBuilder();
            strSqlMax.Append("Select max(sVersion) as sVersion From TK_NetRequirement T");
            string sVersion = DbHelperSQL.Query(strSqlMax.ToString()).Tables[0].Rows[0][0].ToString();

            //获得记录总数
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(" Select Count(1) From TK_NetRequirement T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + " and sVersion='" + sVersion + "' " + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_NetRequirementEntity> list = new List<TK_NetRequirementEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_NetRequirement T ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + " and sVersion='" + sVersion + "' " + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        /// <summary>
        /// 得到新的版本号
        /// </summary>
        /// <returns></returns>
        public string GetNewVersion()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select max(sVersion) as sVersion From TK_NetRequirement");
            string s = DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0][0].ToString();
            return s;
        }
    }
}
