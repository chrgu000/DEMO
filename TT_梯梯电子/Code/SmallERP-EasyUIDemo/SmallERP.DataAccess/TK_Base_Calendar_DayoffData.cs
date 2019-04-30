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
    public class TK_Base_Calendar_DayoffData
    {

        public TK_Base_Calendar_DayoffData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_Base_Calendar_DayoffEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iYear != null)
            {
                strSql1.Append("iYear,");
                strSql2.Append("" + model.iYear + ",");
            }
            if (model.dayOffStart != null)
            {
                strSql1.Append("dayOffStart,");
                strSql2.Append("'" + model.dayOffStart + "',");
            }
            if (model.dayOffEnd != null)
            {
                strSql1.Append("dayOffEnd,");
                strSql2.Append("'" + model.dayOffEnd + "',");
            }
            if (model.sRemark != null)
            {
                strSql1.Append("sRemark,");
                strSql2.Append("N'" + model.sRemark + "',");
            }
            if (model.sPreparedBy != null)
            {
                strSql1.Append("sPreparedBy,");
                strSql2.Append("'" + model.sPreparedBy + "',");
            }
            if (model.dtmPreparedBy != null)
            {
                strSql1.Append("dtmPreparedBy,");
                strSql2.Append("'" + model.dtmPreparedBy + "',");
            }
            if (model.sUpdateUid != null)
            {
                strSql1.Append("sUpdateUid,");
                strSql2.Append("'" + model.sUpdateUid + "',");
            }
            if (model.dtmUpdate != null)
            {
                strSql1.Append("dtmUpdate,");
                strSql2.Append("'" + model.dtmUpdate + "',");
            }
            strSql.Append("insert into TK_Base_Calendar_Dayoff(");
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
        public string Update(TK_Base_Calendar_DayoffEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Base_Calendar_Dayoff set ");
            if (model.iYear != null)
            {
                strSql.Append("iYear=" + model.iYear + ",");
            }
            if (model.dayOffStart != null)
            {
                strSql.Append("dayOffStart='" + model.dayOffStart + "',");
            }
            if (model.dayOffEnd != null)
            {
                strSql.Append("dayOffEnd='" + model.dayOffEnd + "',");
            }
            else
            {
                strSql.Append("dayOffEnd= null ,");
            }
            if (model.sRemark != null)
            {
                strSql.Append("sRemark=N'" + model.sRemark + "',");
            }
            else
            {
                strSql.Append("sRemark= null ,");
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
            if (model.sUpdateUid != null)
            {
                strSql.Append("sUpdateUid='" + model.sUpdateUid + "',");
            }
            else
            {
                strSql.Append("sUpdateUid= null ,");
            }
            if (model.dtmUpdate != null)
            {
                strSql.Append("dtmUpdate='" + model.dtmUpdate + "',");
            }
            else
            {
                strSql.Append("dtmUpdate= null ,");
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
        /// 删除一条数据
        /// </summary>
        /// <param name="iID">删除ID</param>
        /// <returns></returns>
        public string Delete(string iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TK_Base_Calendar_Dayoff ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_Base_Calendar_DayoffEntity DataRowToModel(DataRow row)
        {
            TK_Base_Calendar_DayoffEntity model = new TK_Base_Calendar_DayoffEntity();
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
                if (row["dayOffStart"] != null && row["dayOffStart"].ToString() != "")
                {
                    model.dayOffStart = DateTime.Parse(row["dayOffStart"].ToString());
                }
                if (row["dayOffEnd"] != null && row["dayOffEnd"].ToString() != "")
                {
                    model.dayOffEnd = DateTime.Parse(row["dayOffEnd"].ToString());
                }
                if (row["sRemark"] != null)
                {
                    model.sRemark = row["sRemark"].ToString();
                }
                if (row["sPreparedBy"] != null)
                {
                    model.sPreparedBy = row["sPreparedBy"].ToString();
                }
                if (row["dtmPreparedBy"] != null && row["dtmPreparedBy"].ToString() != "")
                {
                    model.dtmPreparedBy = DateTime.Parse(row["dtmPreparedBy"].ToString());
                }
                if (row["sUpdateUid"] != null)
                {
                    model.sUpdateUid = row["sUpdateUid"].ToString();
                }
                if (row["dtmUpdate"] != null && row["dtmUpdate"].ToString() != "")
                {
                    model.dtmUpdate = DateTime.Parse(row["dtmUpdate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public List<TK_Base_Calendar_DayoffEntity> GetList(string sWhere)
        {

            List<TK_Base_Calendar_DayoffEntity> list = new List<TK_Base_Calendar_DayoffEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_Base_Calendar_Dayoff where 1=1 Order By iID ");
            strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TK_Base_Calendar_DayoffEntity sh = DataRowToModel(row);
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
        /// 分页查询用户列表
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
            strCountSql.Append(" Select Count(1) From TK_Base_Calendar_Dayoff T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_NetRequirementEntity> list = new List<TK_NetRequirementEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_Base_Calendar_Dayoff T ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }
    }
}
