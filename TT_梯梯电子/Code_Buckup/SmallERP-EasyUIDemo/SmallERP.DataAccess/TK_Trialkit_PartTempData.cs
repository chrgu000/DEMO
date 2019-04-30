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
    public class TK_Trialkit_PartTempData
    {

        public TK_Trialkit_PartTempData()
        { }
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_Trialkit_PartTempEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersion,");
                strSql2.Append("'" + model.sTKVersion + "',");
            }
            if (model.sPartID != null)
            {
                strSql1.Append("sPartID,");
                strSql2.Append("'" + model.sPartID + "',");
            }
            if (model.CreaterUid != null)
            {
                strSql1.Append("CreaterUid,");
                strSql2.Append("'" + model.CreaterUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("'" + model.dtmCreate + "',");
            }
            strSql.Append("insert into TK_Trialkit_PartTemp(");
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
        public string Update(TK_Trialkit_PartTempEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Trialkit_PartTemp set ");
            if (model.sTKVersion != null)
            {
                strSql.Append("sTKVersion='" + model.sTKVersion + "',");
            }
            if (model.sPartID != null)
            {
                strSql.Append("sPartID='" + model.sPartID + "',");
            }
            if (model.CreaterUid != null)
            {
                strSql.Append("CreaterUid='" + model.CreaterUid + "',");
            }
            else
            {
                strSql.Append("CreaterUid= null ,");
            }
            if (model.dtmCreate != null)
            {
                strSql.Append("dtmCreate='" + model.dtmCreate + "',");
            }
            else
            {
                strSql.Append("dtmCreate= null ,");
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
            strSql.Append("delete from TK_Trialkit_PartTemp ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_Trialkit_PartTempEntity DataRowToModel(DataRow row)
        {
            TK_Trialkit_PartTempEntity model = new TK_Trialkit_PartTempEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["sTKVersion"] != null)
                {
                    model.sTKVersion = row["sTKVersion"].ToString();
                }
                if (row["sPartID"] != null)
                {
                    model.sPartID = row["sPartID"].ToString();
                }
                if (row["CreaterUid"] != null)
                {
                    model.CreaterUid = row["CreaterUid"].ToString();
                }
                if (row["dtmCreate"] != null && row["dtmCreate"].ToString() != "")
                {
                    model.dtmCreate = DateTime.Parse(row["dtmCreate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public List<TK_Trialkit_PartTempEntity> GetList(string sWhere)
        {

            List<TK_Trialkit_PartTempEntity> list = new List<TK_Trialkit_PartTempEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_Trialkit_PartTemp where 1=1 Order By iID ");
            strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TK_Trialkit_PartTempEntity sh = DataRowToModel(row);
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
            strCountSql.Append(" Select Count(1) From TK_Trialkit_PartTemp T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_Trialkit_PartTempEntity> list = new List<TK_Trialkit_PartTempEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_Trialkit_PartTemp T ");
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
