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
using SmallERP.Domain;

namespace SmallERP.DataAccess
{
    /// <summary>
    /// 数据访问类:t_common_attachment
    /// </summary>
    public partial class t_common_attachmentData
    {
        public t_common_attachmentData()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_common_attachment");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(t_common_attachmentEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_common_attachment(");
            strSql.Append("id,source_id,source_item,original_name,path,value1,value2,value3,createdby,createddate)");
            strSql.Append(" values (");
            strSql.Append("@id,@source_id,@source_item,@original_name,@path,@value1,@value2,@value3,@createdby,@createddate)");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50),
					new SqlParameter("@source_id", SqlDbType.VarChar,50),
					new SqlParameter("@source_item", SqlDbType.VarChar,50),
					new SqlParameter("@original_name", SqlDbType.NVarChar,200),
					new SqlParameter("@path", SqlDbType.NVarChar,500),
					new SqlParameter("@value1", SqlDbType.NVarChar,50),
					new SqlParameter("@value2", SqlDbType.NVarChar,50),
					new SqlParameter("@value3", SqlDbType.NVarChar,50),
					new SqlParameter("@createdby", SqlDbType.VarChar,30),
					new SqlParameter("@createddate", SqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.source_id;
            parameters[2].Value = model.source_item;
            parameters[3].Value = model.original_name;
            parameters[4].Value = model.path;
            parameters[5].Value = model.value1;
            parameters[6].Value = model.value2;
            parameters[7].Value = model.value3;
            parameters[8].Value = model.createdby;
            parameters[9].Value = model.createddate;

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
        public bool Update(t_common_attachmentEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_common_attachment set ");
            strSql.Append("id=@id,");
            strSql.Append("source_id=@source_id,");
            strSql.Append("source_item=@source_item,");
            strSql.Append("original_name=@original_name,");
            strSql.Append("path=@path,");
            strSql.Append("value1=@value1,");
            strSql.Append("value2=@value2,");
            strSql.Append("value3=@value3,");
            strSql.Append("createdby=@createdby,");
            strSql.Append("createddate=@createddate");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50),
					new SqlParameter("@source_id", SqlDbType.VarChar,50),
					new SqlParameter("@source_item", SqlDbType.VarChar,50),
					new SqlParameter("@original_name", SqlDbType.NVarChar,200),
					new SqlParameter("@path", SqlDbType.NVarChar,500),
					new SqlParameter("@value1", SqlDbType.NVarChar,50),
					new SqlParameter("@value2", SqlDbType.NVarChar,50),
					new SqlParameter("@value3", SqlDbType.NVarChar,50),
					new SqlParameter("@createdby", SqlDbType.VarChar,30),
					new SqlParameter("@createddate", SqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.source_id;
            parameters[2].Value = model.source_item;
            parameters[3].Value = model.original_name;
            parameters[4].Value = model.path;
            parameters[5].Value = model.value1;
            parameters[6].Value = model.value2;
            parameters[7].Value = model.value3;
            parameters[8].Value = model.createdby;
            parameters[9].Value = model.createddate;

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
        public bool Delete(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_common_attachment ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
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
            strSql.Append("delete from t_common_attachment ");
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
        public t_common_attachmentEntity GetModel(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,source_id,source_item,original_name,path,value1,value2,value3,createdby,createddate from t_common_attachment ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
            parameters[0].Value = id;

            t_common_attachmentEntity model = new t_common_attachmentEntity();
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
        public t_common_attachmentEntity DataRowToModel(DataRow row)
        {
            t_common_attachmentEntity model = new t_common_attachmentEntity();
            if (row != null)
            {
                if (row["id"] != null)
                {
                    model.id = row["id"].ToString();
                }
                if (row["source_id"] != null)
                {
                    model.source_id = row["source_id"].ToString();
                }
                if (row["source_item"] != null)
                {
                    model.source_item = row["source_item"].ToString();
                }
                if (row["original_name"] != null)
                {
                    model.original_name = row["original_name"].ToString();
                }
                if (row["path"] != null)
                {
                    model.path = row["path"].ToString();
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
                if (row["createdby"] != null)
                {
                    model.createdby = row["createdby"].ToString();
                }
                if (row["createddate"] != null && row["createddate"].ToString() != "")
                {
                    model.createddate = DateTime.Parse(row["createddate"].ToString());
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
            strSql.Append("select id,source_id,source_item,original_name,path,value1,value2,value3,createdby,createddate ");
            strSql.Append(" FROM t_common_attachment ");
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
            strSql.Append(" id,source_id,source_item,original_name,path,value1,value2,value3,createdby,createddate ");
            strSql.Append(" FROM t_common_attachment ");
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
            strSql.Append("select count(1) FROM t_common_attachment ");
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
            strSql.Append(")AS Row, T.*  from t_common_attachment T ");
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
            parameters[0].Value = "t_common_attachment";
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
        /// 根据source_id事务删除一条数据
        /// </summary>
        public CommandInfo TranDeleteBySourceID(string sourceID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_common_attachment ");
            strSql.Append(" where source_id=@source_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@source_id", SqlDbType.VarChar,50)			};
            parameters[0].Value = sourceID;

            return new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows);
        }

        /// <summary>
        /// 事务删除一条数据
        /// </summary>
        public CommandInfo TranDelete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_common_attachment ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.VarChar,50)			};
            parameters[0].Value = id;

            return new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows);
        }

        /// <summary>
        /// 分页获取数据列表
        /// 创建人：蒋俊
        /// 创建时间：2017-12-14 09:52:41
        /// </summary>
        public List<t_common_attachmentEntity> GetAttachmentListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            List<t_common_attachmentEntity> list = new List<t_common_attachmentEntity>();
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
            strSql.Append(")AS Row, T.*  from t_common_attachment T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ToList<t_common_attachmentEntity>();
                return list;
            }
            else
            {
                return new List<t_common_attachmentEntity>();
            }
        }
        

        #endregion  ExtensionMethod
    }
}

