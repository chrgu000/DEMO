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
    public class TK_BOMData
    {

        public TK_BOMData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_BOMEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            //if (model.Guid != null)
            //{
            //    strSql1.Append("Guid,");
            //    strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            //}
            //if (model.sVersion != null)
            //{
            //    strSql1.Append("sVersion,");
            //    strSql2.Append("'" + model.sVersion + "',");
            //}
            //if (model.SourceID != null)
            //{
            //    strSql1.Append("SourceID,");
            //    strSql2.Append("'" + model.SourceID + "',");
            //}
            //if (model.sNO != null)
            //{
            //    strSql1.Append("sNO,");
            //    strSql2.Append("'" + model.sNO + "',");
            //}
            //if (model.sPartID != null)
            //{
            //    strSql1.Append("sPartID,");
            //    strSql2.Append("'" + model.sPartID + "',");
            //}
            //if (model.fQTY != null)
            //{
            //    strSql1.Append("fQTY,");
            //    strSql2.Append("" + model.fQTY + ",");
            //}
            //if (model.fOpenQTY != null)
            //{
            //    strSql1.Append("fOpenQTY,");
            //    strSql2.Append("" + model.fOpenQTY + ",");
            //}
            //if (model.dtmDue != null)
            //{
            //    strSql1.Append("dtmDue,");
            //    strSql2.Append("'" + model.dtmDue + "',");
            //}
            //if (model.dtmRequirement != null)
            //{
            //    strSql1.Append("dtmRequirement,");
            //    strSql2.Append("'" + model.dtmRequirement + "',");
            //}
            //if (model.sPlannerCode != null)
            //{
            //    strSql1.Append("sPlannerCode,");
            //    strSql2.Append("'" + model.sPlannerCode + "',");
            //}
            //if (model.sSourceType != null)
            //{
            //    strSql1.Append("sSourceType,");
            //    strSql2.Append("'" + model.sSourceType + "',");
            //}
            //if (model.sProductGroup != null)
            //{
            //    strSql1.Append("sProductGroup,");
            //    strSql2.Append("'" + model.sProductGroup + "',");
            //}
            //if (model.sRemark != null)
            //{
            //    strSql1.Append("sRemark,");
            //    strSql2.Append("'" + model.sRemark + "',");
            //}
            //if (model.sPreparedBy != null)
            //{
            //    strSql1.Append("sPreparedBy,");
            //    strSql2.Append("'" + model.sPreparedBy + "',");
            //}
            //if (model.dtmPreparedBy != null)
            //{
            //    strSql1.Append("dtmPreparedBy,");
            //    strSql2.Append("'" + model.dtmPreparedBy + "',");
            //}
            strSql.Append("insert into TK_BOM(");
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
        public string Update(TK_BOMEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_BOM set ");
            //if (model.Guid != null)
            //{
            //    strSql.Append("Guid='" + model.Guid + "',");
            //}
            //if (model.sVersion != null)
            //{
            //    strSql.Append("sVersion='" + model.sVersion + "',");
            //}
            //if (model.SourceID != null)
            //{
            //    strSql.Append("SourceID='" + model.SourceID + "',");
            //}
            //else
            //{
            //    strSql.Append("SourceID= null ,");
            //}
            //if (model.sNO != null)
            //{
            //    strSql.Append("sNO='" + model.sNO + "',");
            //}
            //if (model.sPartID != null)
            //{
            //    strSql.Append("sPartID='" + model.sPartID + "',");
            //}
            //if (model.fQTY != null)
            //{
            //    strSql.Append("fQTY=" + model.fQTY + ",");
            //}
            //if (model.fOpenQTY != null)
            //{
            //    strSql.Append("fOpenQTY=" + model.fOpenQTY + ",");
            //}
            //if (model.dtmDue != null)
            //{
            //    strSql.Append("dtmDue='" + model.dtmDue + "',");
            //}
            //if (model.dtmRequirement != null)
            //{
            //    strSql.Append("dtmRequirement='" + model.dtmRequirement + "',");
            //}
            //if (model.sPlannerCode != null)
            //{
            //    strSql.Append("sPlannerCode='" + model.sPlannerCode + "',");
            //}
            //if (model.sSourceType != null)
            //{
            //    strSql.Append("sSourceType='" + model.sSourceType + "',");
            //}
            //if (model.sProductGroup != null)
            //{
            //    strSql.Append("sProductGroup='" + model.sProductGroup + "',");
            //}
            //if (model.sRemark != null)
            //{
            //    strSql.Append("sRemark='" + model.sRemark + "',");
            //}
            //else
            //{
            //    strSql.Append("sRemark= null ,");
            //}
            //if (model.sPreparedBy != null)
            //{
            //    strSql.Append("sPreparedBy='" + model.sPreparedBy + "',");
            //}
            //else
            //{
            //    strSql.Append("sPreparedBy= null ,");
            //}
            //if (model.dtmPreparedBy != null)
            //{
            //    strSql.Append("dtmPreparedBy='" + model.dtmPreparedBy + "',");
            //}
            //else
            //{
            //    strSql.Append("dtmPreparedBy= null ,");
            //}
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
            strSql.Append("delete from TK_BOM ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_BOMEntity DataRowToModel(DataRow row)
        {
            TK_BOMEntity model = new TK_BOMEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["depth"] != null)
                {
                    model.depth = row["depth"].ToString();
                }
                if (row["toplevel"] != null)
                {
                    model.toplevel = row["toplevel"].ToString();
                }
                if (row["parent"] != null)
                {
                    model.parent = row["parent"].ToString();
                }
                if (row["child"] != null)
                {
                    model.child = row["child"].ToString();
                }
                if (row["qty"] != null && row["qty"].ToString() != "")
                {
                    model.qty = decimal.Parse(row["qty"].ToString());
                }
                if (row["cumqty"] != null && row["cumqty"].ToString() != "")
                {
                    model.cumqty = decimal.Parse(row["cumqty"].ToString());
                }
                if (row["childsm"] != null)
                {
                    model.childsm = row["childsm"].ToString();
                }
                if (row["topprodgroup"] != null)
                {
                    model.topprodgroup = row["topprodgroup"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere">查询条件</param>
        /// <returns></returns>
        public List<TK_BOMEntity> GetList(string sWhere)
        {
            List<TK_BOMEntity> list = new List<TK_BOMEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_BOM where 1=1 Order By iID ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TK_BOMEntity sh = DataRowToModel(row);
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
        public List<TK_BOMEntity> GetList(string sWhere, string userId, string name, string roleId, int rowStart, int rowEnd, out int total)
        {
            //获得记录总数
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(" Select Count(1) From TK_BOM T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_BOMEntity> list = new List<TK_BOMEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_BOM T ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    TK_BOMEntity sh = DataRowToModel(row);
                    list.Add(sh);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

    }
}
