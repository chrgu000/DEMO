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
    public class TK_CurrentStockData
    {

        public TK_CurrentStockData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(TK_CurrentStockEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Guid != null)
            {
                strSql1.Append("Guid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.sVersion != null)
            {
                strSql1.Append("sVersion,");
                strSql2.Append("'" + model.sVersion + "',");
            }
            if (model.Warehouse != null)
            {
                strSql1.Append("Warehouse,");
                strSql2.Append("'" + model.Warehouse + "',");
            }
            if (model.LocationID != null)
            {
                strSql1.Append("LocationID,");
                strSql2.Append("'" + model.LocationID + "',");
            }
            if (model.sItemNo != null)
            {
                strSql1.Append("sItemNo,");
                strSql2.Append("'" + model.sItemNo + "',");
            }
            if (model.dQty != null)
            {
                strSql1.Append("dQty,");
                strSql2.Append("" + model.dQty + ",");
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
            strSql.Append("insert into TK_CurrentStock(");
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
        public string Update(TK_CurrentStockEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_CurrentStock set ");
            if (model.Guid != null)
            {
                strSql.Append("Guid='" + model.Guid + "',");
            }
            else
            {
                strSql.Append("Guid= null ,");
            }
            if (model.sVersion != null)
            {
                strSql.Append("sVersion='" + model.sVersion + "',");
            }
            else
            {
                strSql.Append("sVersion= null ,");
            }
            if (model.Warehouse != null)
            {
                strSql.Append("Warehouse='" + model.Warehouse + "',");
            }
            else
            {
                strSql.Append("Warehouse= null ,");
            }
            if (model.LocationID != null)
            {
                strSql.Append("LocationID='" + model.LocationID + "',");
            }
            else
            {
                strSql.Append("LocationID= null ,");
            }
            if (model.sItemNo != null)
            {
                strSql.Append("sItemNo='" + model.sItemNo + "',");
            }
            else
            {
                strSql.Append("sItemNo= null ,");
            }
            if (model.dQty != null)
            {
                strSql.Append("dQty=" + model.dQty + ",");
            }
            else
            {
                strSql.Append("dQty= null ,");
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
        /// 删除一条数据
        /// </summary>
        /// <param name="iID">删除ID</param>
        /// <returns></returns>
        public string Delete(string iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TK_CurrentStock ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TK_CurrentStockEntity DataRowToModel(DataRow row)
        {
            TK_CurrentStockEntity model = new TK_CurrentStockEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["Guid"] != null && row["Guid"].ToString() != "")
                {
                    model.Guid = new Guid(row["Guid"].ToString());
                }
                if (row["sVersion"] != null)
                {
                    model.sVersion = row["sVersion"].ToString();
                }
                if (row["Warehouse"] != null)
                {
                    model.Warehouse = row["Warehouse"].ToString();
                }
                if (row["LocationID"] != null)
                {
                    model.LocationID = row["LocationID"].ToString();
                }
                if (row["sItemNo"] != null)
                {
                    model.sItemNo = row["sItemNo"].ToString();
                }
                if (row["dQty"] != null && row["dQty"].ToString() != "")
                {
                    model.dQty = decimal.Parse(row["dQty"].ToString());
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
        public List<TK_CurrentStockEntity> GetList(string sWhere)
        {

            List<TK_CurrentStockEntity> list = new List<TK_CurrentStockEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" Select * From TK_CurrentStock where 1=1 Order By iID ");
            strSql = strSql.Replace("1=1", "1=1" + sWhere);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TK_CurrentStockEntity sh = DataRowToModel(row);
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
            strCountSql.Append(" Select Count(1) From TK_CurrentStock_History T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_CurrentStockEntity> list = new List<TK_CurrentStockEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_CurrentStock_History T ");
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
