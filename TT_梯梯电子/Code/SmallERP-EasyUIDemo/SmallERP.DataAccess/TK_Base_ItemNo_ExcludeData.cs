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
    public class TK_Base_ItemNo_ExcludeData
    {

        public TK_Base_ItemNo_ExcludeData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_Base_ItemNo_ExcludeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sItemNo != null)
            {
                strSql1.Append("sItemNo,");
                strSql2.Append("N'" + model.sItemNo + "',");
            }
            strSql.Append("insert into TK_Base_ItemNo_Exclude(");
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
        public string Update(TK_Base_ItemNo_ExcludeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Base_ItemNo_Exclude set ");
            if (model.sItemNo != null)
            {
                strSql.Append("sItemNo=N'" + model.sItemNo + "',");
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
            strSql.Append("delete from TK_Base_ItemNo_Exclude ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_Base_ItemNo_ExcludeEntity DataRowToModel(DataRow row)
        {
            TK_Base_ItemNo_ExcludeEntity model = new TK_Base_ItemNo_ExcludeEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["sItemNo"] != null)
                {
                    model.sItemNo = row["sItemNo"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public List<TK_Base_ItemNo_ExcludeEntity> GetList(string sWhere)
        {
            List<TK_Base_ItemNo_ExcludeEntity> list = new List<TK_Base_ItemNo_ExcludeEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_Base_ItemNo_Exclude where 1=1 Order By iID ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TK_Base_ItemNo_ExcludeEntity sh = DataRowToModel(row);
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
            strCountSql.Append(" Select Count(1) From TK_Base_ItemNo_Exclude T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_Base_ItemNo_ExcludeEntity> list = new List<TK_Base_ItemNo_ExcludeEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_Base_ItemNo_Exclude T ");
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
