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
    /// 数据访问类:Cycle
    /// </summary>
    public partial class CycleData
    {
        public CycleData()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cycle");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CycleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TK_Trialkitting(");
            strSql.Append("Guid,sVersion,iPriority,sPartID,sPlannerCode,sReorderPolicy,sProductGroup,iProcessCycle,fUnFullKit,fCurrentStock,fWOQty,dtmPeriod,fQty,sPreparedBy,dtmPreparedBy,sUpdateUid,dtmUpdate,bDel)");
            strSql.Append(" values (");
            strSql.Append("@Guid,@sVersion,@iPriority,@sPartID,@sPlannerCode,@sReorderPolicy,@sProductGroup,@iProcessCycle,@fUnFullKit,@fCurrentStock,@fWOQty,@dtmPeriod,@fQty,@sPreparedBy,@dtmPreparedBy,@sUpdateUid,@dtmUpdate,@bDel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sVersion", SqlDbType.NVarChar,50),
					new SqlParameter("@iPriority", SqlDbType.Int,4),
					new SqlParameter("@sPartID", SqlDbType.NVarChar,50),
					new SqlParameter("@sPlannerCode", SqlDbType.NVarChar,50),
					new SqlParameter("@sReorderPolicy", SqlDbType.NVarChar,50),
					new SqlParameter("@sProductGroup", SqlDbType.NVarChar,50),
					new SqlParameter("@iProcessCycle", SqlDbType.Int,4),
					new SqlParameter("@fUnFullKit", SqlDbType.Float,8),
					new SqlParameter("@fCurrentStock", SqlDbType.Float,8),
					new SqlParameter("@fWOQty", SqlDbType.Float,8),
					new SqlParameter("@dtmPeriod", SqlDbType.DateTime),
					new SqlParameter("@fQty", SqlDbType.Float,8),
					new SqlParameter("@sPreparedBy", SqlDbType.NVarChar,50),
					new SqlParameter("@dtmPreparedBy", SqlDbType.DateTime),
					new SqlParameter("@sUpdateUid", SqlDbType.NVarChar,50),
					new SqlParameter("@dtmUpdate", SqlDbType.DateTime),
					new SqlParameter("@bDel", SqlDbType.Bit,1)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.sVersion;
            parameters[2].Value = model.iPriority;
            parameters[3].Value = model.sPartID;
            parameters[4].Value = model.sPlannerCode;
            parameters[5].Value = model.sReorderPolicy;
            parameters[6].Value = model.sProductGroup;
            parameters[7].Value = model.iProcessCycle;
            parameters[8].Value = model.fUnFullKit;
            parameters[9].Value = model.fCurrentStock;
            parameters[10].Value = model.fWOQty;
            parameters[11].Value = model.dtmPeriod;
            parameters[12].Value = model.fQty;
            parameters[13].Value = model.sPreparedBy;
            parameters[14].Value = model.dtmPreparedBy;
            parameters[15].Value = model.sUpdateUid;
            parameters[16].Value = model.dtmUpdate;
            parameters[17].Value = model.bDel;

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
        public bool Update(CycleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TK_Trialkitting set ");
            strSql.Append("Guid=@Guid,");
            strSql.Append("sVersion=@sVersion,");
            strSql.Append("iPriority=@iPriority,");
            strSql.Append("sPartID=@sPartID,");
            strSql.Append("sPlannerCode=@sPlannerCode,");
            strSql.Append("sReorderPolicy=@sReorderPolicy,");
            strSql.Append("sProductGroup=@sProductGroup,");
            strSql.Append("iProcessCycle=@iProcessCycle,");
            strSql.Append("fUnFullKit=@fUnFullKit,");
            strSql.Append("fCurrentStock=@fCurrentStock,");
            strSql.Append("fWOQty=@fWOQty,");
            strSql.Append("dtmPeriod=@dtmPeriod,");
            strSql.Append("fQty=@fQty,");
            strSql.Append("sPreparedBy=@sPreparedBy,");
            strSql.Append("dtmPreparedBy=@dtmPreparedBy,");
            strSql.Append("sUpdateUid=@sUpdateUid,");
            strSql.Append("dtmUpdate=@dtmUpdate,");
            strSql.Append("bDel=@bDel");
            strSql.Append(" where iID=@iID");
            SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sVersion", SqlDbType.NVarChar,50),
					new SqlParameter("@iPriority", SqlDbType.Int,4),
					new SqlParameter("@sPartID", SqlDbType.NVarChar,50),
					new SqlParameter("@sPlannerCode", SqlDbType.NVarChar,50),
					new SqlParameter("@sReorderPolicy", SqlDbType.NVarChar,50),
					new SqlParameter("@sProductGroup", SqlDbType.NVarChar,50),
					new SqlParameter("@iProcessCycle", SqlDbType.Int,4),
					new SqlParameter("@fUnFullKit", SqlDbType.Float,8),
					new SqlParameter("@fCurrentStock", SqlDbType.Float,8),
					new SqlParameter("@fWOQty", SqlDbType.Float,8),
					new SqlParameter("@dtmPeriod", SqlDbType.DateTime),
					new SqlParameter("@fQty", SqlDbType.Float,8),
					new SqlParameter("@sPreparedBy", SqlDbType.NVarChar,50),
					new SqlParameter("@dtmPreparedBy", SqlDbType.DateTime),
					new SqlParameter("@sUpdateUid", SqlDbType.NVarChar,50),
					new SqlParameter("@dtmUpdate", SqlDbType.DateTime),
					new SqlParameter("@bDel", SqlDbType.Bit,1),
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = model.Guid;
            parameters[1].Value = model.sVersion;
            parameters[2].Value = model.iPriority;
            parameters[3].Value = model.sPartID;
            parameters[4].Value = model.sPlannerCode;
            parameters[5].Value = model.sReorderPolicy;
            parameters[6].Value = model.sProductGroup;
            parameters[7].Value = model.iProcessCycle;
            parameters[8].Value = model.fUnFullKit;
            parameters[9].Value = model.fCurrentStock;
            parameters[10].Value = model.fWOQty;
            parameters[11].Value = model.dtmPeriod;
            parameters[12].Value = model.fQty;
            parameters[13].Value = model.sPreparedBy;
            parameters[14].Value = model.dtmPreparedBy;
            parameters[15].Value = model.sUpdateUid;
            parameters[16].Value = model.dtmUpdate;
            parameters[17].Value = model.bDel;
            parameters[18].Value = model.iID;

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
        public bool Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TK_Trialkitting ");
            strSql.Append(" where iID=@iID");
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)
			};
            parameters[0].Value = iID;

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
        public bool DeleteList(string iIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TK_Trialkitting ");
            strSql.Append(" where iID in (" + iIDlist + ")  ");
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
        public CycleEntity GetModel(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 iID,Guid,sVersion,iPriority,sPartID,sPlannerCode,sReorderPolicy,sProductGroup,iProcessCycle,fUnFullKit,fCurrentStock,fWOQty,dtmPeriod,fQty,sPreparedBy,dtmPreparedBy,sUpdateUid,dtmUpdate,bDel from TK_Trialkitting ");
            strSql.Append(" where iID=@iID");
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)
			};
            parameters[0].Value = iID;

            CycleEntity model = new CycleEntity();
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
        public CycleEntity DataRowToModel(DataRow row)
        {
            CycleEntity model = new CycleEntity();
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
                if (row["iPriority"] != null && row["iPriority"].ToString() != "")
                {
                    model.iPriority = int.Parse(row["iPriority"].ToString());
                }
                if (row["sPartID"] != null)
                {
                    model.sPartID = row["sPartID"].ToString();
                }
                if (row["sPlannerCode"] != null)
                {
                    model.sPlannerCode = row["sPlannerCode"].ToString();
                }
                if (row["sReorderPolicy"] != null)
                {
                    model.sReorderPolicy = row["sReorderPolicy"].ToString();
                }
                if (row["sProductGroup"] != null)
                {
                    model.sProductGroup = row["sProductGroup"].ToString();
                }
                if (row["iProcessCycle"] != null && row["iProcessCycle"].ToString() != "")
                {
                    model.iProcessCycle = int.Parse(row["iProcessCycle"].ToString());
                }
                if (row["fUnFullKit"] != null && row["fUnFullKit"].ToString() != "")
                {
                    model.fUnFullKit = decimal.Parse(row["fUnFullKit"].ToString());
                }
                if (row["fCurrentStock"] != null && row["fCurrentStock"].ToString() != "")
                {
                    model.fCurrentStock = decimal.Parse(row["fCurrentStock"].ToString());
                }
                if (row["fWOQty"] != null && row["fWOQty"].ToString() != "")
                {
                    model.fWOQty = decimal.Parse(row["fWOQty"].ToString());
                }
                if (row["dtmPeriod"] != null && row["dtmPeriod"].ToString() != "")
                {
                    model.dtmPeriod = DateTime.Parse(row["dtmPeriod"].ToString());
                }
                if (row["fQty"] != null && row["fQty"].ToString() != "")
                {
                    model.fQty = decimal.Parse(row["fQty"].ToString());
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
                if (row["bDel"] != null && row["bDel"].ToString() != "")
                {
                    if ((row["bDel"].ToString() == "1") || (row["bDel"].ToString().ToLower() == "true"))
                    {
                        model.bDel = true;
                    }
                    else
                    {
                        model.bDel = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select iID,Guid,sVersion,iPriority,sPartID,sPlannerCode,sReorderPolicy,sProductGroup,iProcessCycle,fUnFullKit,fCurrentStock,fWOQty,dtmPeriod,fQty,sPreparedBy,dtmPreparedBy,sUpdateUid,dtmUpdate,bDel ");
        //    strSql.Append(" FROM TK_Trialkitting ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select ");
        //    if (Top > 0)
        //    {
        //        strSql.Append(" top " + Top.ToString());
        //    }
        //    strSql.Append(" iID,Guid,sVersion,iPriority,sPartID,sPlannerCode,sReorderPolicy,sProductGroup,iProcessCycle,fUnFullKit,fCurrentStock,fWOQty,dtmPeriod,fQty,sPreparedBy,dtmPreparedBy,sUpdateUid,dtmUpdate,bDel ");
        //    strSql.Append(" FROM TK_Trialkitting ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TK_Trialkitting ");
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
                strSql.Append("order by T.iID desc");
            }
            strSql.Append(")AS Row, T.*  from TK_Trialkitting T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 根据category和item得到一个对象实体
        /// 创建人：蒋俊
        /// 创建时间：2017-09-13 10:34:20
        /// </summary>
        public CycleEntity GetModelByCategoryAndItem(string category, string item)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from TK_Trialkitting ");
            strSql.Append(" where category=@category and item=@item ");
            SqlParameter[] parameters = {
					new SqlParameter("@category", SqlDbType.NVarChar,50),
					new SqlParameter("@item", SqlDbType.NVarChar,50)			};
            parameters[0].Value = category;
            parameters[1].Value = item;

            CycleEntity model = new CycleEntity();
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
        public CycleEntity GetModelByid(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Cycle ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)		};
            parameters[0].Value = id;


            CycleEntity model = new CycleEntity();
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
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="filter"></param>
        ///// <returns></returns>
        //public List<string> GetCategoryList(string filter)
        //{
        //    filter = filter ?? string.Empty;
        //    filter = filter.Replace("*", "%");
        //    string strSql = string.Format("select distinct top 50 category from Cycle where category like '{0}%' order by category asc ", filter);
        //    return DbHelperSQL.Query(strSql).Tables[0].ToStringList();
        //}

        /// <summary>
        /// 分页获取数据列表
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 15:19:59
        /// </summary>
        public List<CycleEntity> GetCycleListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            List<CycleEntity> list = new List<CycleEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.iID desc");
            }
            strSql.Append(")AS Row, T.*  from TK_Trialkitting T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ToList<CycleEntity>();
                return list;
            }
            else
            {
                return new List<CycleEntity>();
            }
        }
        public List<CycleEntity> GetList(string strWhere)
        {

            List<CycleEntity> list = new List<CycleEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * From TK_Trialkitting where bDel=0  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" Order By iID ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    CycleEntity sh = DataRowToModel(row);
                    list.Add(sh);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        #endregion  ExtensionMethod
    }
}

