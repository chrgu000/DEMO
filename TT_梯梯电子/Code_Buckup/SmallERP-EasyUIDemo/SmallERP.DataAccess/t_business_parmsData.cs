using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SmallERP.DBUtility;
using SmallERP.Entity;
using SmallERP.Common;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace SmallERP.DataAccess
{
    /// <summary>
    /// 数据访问类:t_business_parms
    /// </summary>
    public partial class t_business_parmsData
    {
        public t_business_parmsData()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_business_parms");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(t_business_parmsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_business_parms(");
            strSql.Append("category,item,defaultval,value1,value2,value3,module,createddate,createdby,modifieddate,modifiedby)");
            strSql.Append(" values (");
            strSql.Append("@category,@item,@defaultval,@value1,@value2,@value3,@module,@createddate,@createdby,@modifieddate,@modifiedby)");
            SqlParameter[] parameters = {
					new SqlParameter("@category", SqlDbType.NVarChar,50),
					new SqlParameter("@item", SqlDbType.NVarChar,50),
					new SqlParameter("@defaultval", SqlDbType.NVarChar,50),
					new SqlParameter("@value1", SqlDbType.NVarChar,50),
					new SqlParameter("@value2", SqlDbType.NVarChar,50),
					new SqlParameter("@value3", SqlDbType.NVarChar,50),
					new SqlParameter("@module", SqlDbType.NVarChar,50),
					new SqlParameter("@createddate", SqlDbType.DateTime),
					new SqlParameter("@createdby", SqlDbType.VarChar,30),
					new SqlParameter("@modifieddate", SqlDbType.DateTime),
					new SqlParameter("@modifiedby", SqlDbType.VarChar,30)};
            parameters[0].Value = model.category;
            parameters[1].Value = model.item;
            parameters[2].Value = model.defaultval;
            parameters[3].Value = model.value1;
            parameters[4].Value = model.value2;
            parameters[5].Value = model.value3;
            parameters[6].Value = model.module;
            parameters[7].Value = model.createddate;
            parameters[8].Value = model.createdby;
            parameters[9].Value = model.modifieddate;
            parameters[10].Value = model.modifiedby;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(t_business_parmsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_business_parms set ");
            strSql.Append("category=@category,");
            strSql.Append("item=@item,");
            strSql.Append("defaultval=@defaultval,");
            strSql.Append("value1=@value1,");
            strSql.Append("value2=@value2,");
            strSql.Append("value3=@value3,");
            strSql.Append("module=@module,");
            strSql.Append("createddate=@createddate,");
            strSql.Append("createdby=@createdby,");
            strSql.Append("modifieddate=@modifieddate,");
            strSql.Append("modifiedby=@modifiedby");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@category", SqlDbType.NVarChar,50),
					new SqlParameter("@item", SqlDbType.NVarChar,50),
					new SqlParameter("@defaultval", SqlDbType.NVarChar,50),
					new SqlParameter("@value1", SqlDbType.NVarChar,50),
					new SqlParameter("@value2", SqlDbType.NVarChar,50),
					new SqlParameter("@value3", SqlDbType.NVarChar,50),
					new SqlParameter("@module", SqlDbType.NVarChar,50),
					new SqlParameter("@createddate", SqlDbType.DateTime),
					new SqlParameter("@createdby", SqlDbType.VarChar,30),
					new SqlParameter("@modifieddate", SqlDbType.DateTime),
					new SqlParameter("@modifiedby", SqlDbType.VarChar,30)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.category;
            parameters[2].Value = model.item;
            parameters[3].Value = model.defaultval;
            parameters[4].Value = model.value1;
            parameters[5].Value = model.value2;
            parameters[6].Value = model.value3;
            parameters[7].Value = model.module;
            parameters[8].Value = model.createddate;
            parameters[9].Value = model.createdby;
            parameters[10].Value = model.modifieddate;
            parameters[11].Value = model.modifiedby;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_business_parms ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_business_parms ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public t_business_parmsEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,category,item,defaultval,value1,value2,value3,module,createddate,createdby,modifieddate,modifiedby from t_business_parms ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            t_business_parmsEntity model = new t_business_parmsEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public t_business_parmsEntity DataRowToModel(DataRow row)
        {
            t_business_parmsEntity model = new t_business_parmsEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["category"] != null)
                {
                    model.category = row["category"].ToString();
                }
                if (row["item"] != null)
                {
                    model.item = row["item"].ToString();
                }
                if (row["defaultval"] != null)
                {
                    model.defaultval = row["defaultval"].ToString();
                }
                if (row["value1"] != null)
                {
                    model.value1 = row["value1"].ToString();
                }
                if (row["value2"] != null)
                {
                    model.value2 = row["value2"].ToString();
                }
                if (row["value3"] != null)
                {
                    model.value3 = row["value3"].ToString();
                }
                if (row["module"] != null)
                {
                    model.module = row["module"].ToString();
                }
                if (row["createddate"] != null && row["createddate"].ToString() != "")
                {
                    model.createddate = DateTime.Parse(row["createddate"].ToString());
                }
                if (row["createdby"] != null)
                {
                    model.createdby = row["createdby"].ToString();
                }
                if (row["modifieddate"] != null && row["modifieddate"].ToString() != "")
                {
                    model.modifieddate = DateTime.Parse(row["modifieddate"].ToString());
                }
                if (row["modifiedby"] != null)
                {
                    model.modifiedby = row["modifiedby"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,category,item,defaultval,value1,value2,value3,module,createddate,createdby,modifieddate,modifiedby ");
            strSql.Append(" FROM t_business_parms ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,category,item,defaultval,value1,value2,value3,module,createddate,createdby,modifieddate,modifiedby ");
            strSql.Append(" FROM t_business_parms ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_business_parms ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from t_business_parms T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "t_business_parms";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 根据category和item得到一个对象实体
        /// 创建人：蒋俊
        /// 创建时间：2017-09-13 10:34:20
        /// </summary>
        public t_business_parmsEntity GetModelByCategoryAndItem(string category, string item)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from t_business_parms ");
            strSql.Append(" where category=@category and item=@item ");
            SqlParameter[] parameters = {
					new SqlParameter("@category", SqlDbType.NVarChar,50),
					new SqlParameter("@item", SqlDbType.NVarChar,50)			};
            parameters[0].Value = category;
            parameters[1].Value = item;

            t_business_parmsEntity model = new t_business_parmsEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据id得到一个对象实体
        /// 
        /// 
        /// </summary>
        public t_business_parmsEntity GetModelByid(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from t_business_parms ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)		};
            parameters[0].Value = id;


            t_business_parmsEntity model = new t_business_parmsEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<string> GetCategoryList(string filter)
        {
            filter = filter ?? string.Empty;
            filter = filter.Replace("*", "%");
            string strSql = string.Format("select distinct top 50 category from t_business_parms where category like '{0}%' order by category asc ", filter);
            return DbHelperSQL.Query(strSql).Tables[0].ToStringList();
        }

        /// <summary>
        /// 分页获取数据列表
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 15:19:59
        /// </summary>
        public List<t_business_parmsEntity> GetBusinessParmsListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            List<t_business_parmsEntity> list = new List<t_business_parmsEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from t_business_parms T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ToList<t_business_parmsEntity>();
                return list;
            }
            else
            {
                return new List<t_business_parmsEntity>();
            }
        }


        #endregion  ExtensionMethod
    }
}

