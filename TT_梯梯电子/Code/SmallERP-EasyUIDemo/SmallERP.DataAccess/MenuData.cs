using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SmallERP.DBUtility;
using SmallERP.Entity;

namespace SmallERP.DataAccess
{
    public class MenuData
    {

        public MenuData()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Menu");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MenuEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Menu(");
            strSql.Append("ID,ParentID,Name,Icon,Url,IsDisabled,Sort)");
            strSql.Append(" values (");
            strSql.Append("@ID,@ParentID,@Name,@Icon,@Url,@IsDisabled,@Sort)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@ParentID", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,100),
					new SqlParameter("@Icon", SqlDbType.VarChar,100),
					new SqlParameter("@Url", SqlDbType.VarChar,300),
					new SqlParameter("@IsDisabled", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Icon;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.IsDisabled;
            parameters[6].Value = model.Sort;

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
        public bool Update(MenuEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Menu set ");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Name=@Name,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("Url=@Url,");
            strSql.Append("IsDisabled=@IsDisabled,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,100),
					new SqlParameter("@Icon", SqlDbType.VarChar,100),
					new SqlParameter("@Url", SqlDbType.VarChar,300),
					new SqlParameter("@IsDisabled", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Icon;
            parameters[3].Value = model.Url;
            parameters[4].Value = model.IsDisabled;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.ID;

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
        public bool Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Menu ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Menu ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public MenuEntity GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,Name,Icon,Url,IsDisabled,Sort from Menu ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;

            MenuEntity model = new MenuEntity();
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
        public MenuEntity DataRowToModel(DataRow row)
        {
            MenuEntity model = new MenuEntity();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["ParentID"] != null)
                {
                    model.ParentID = row["ParentID"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Icon"] != null)
                {
                    model.Icon = row["Icon"].ToString();
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
                }
                if (row["IsDisabled"] != null && row["IsDisabled"].ToString() != "")
                {
                    model.IsDisabled = int.Parse(row["IsDisabled"].ToString());
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
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
            strSql.Append("select ID,ParentID,Name,Icon,Url,IsDisabled,Sort ");
            strSql.Append(" FROM Menu ");
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
            strSql.Append(" ID,ParentID,Name,Icon,Url,IsDisabled,Sort ");
            strSql.Append(" FROM Menu ");
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
            strSql.Append("select count(1) FROM Menu ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Menu T ");
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
            parameters[0].Value = "Menu";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        /// <summary>
        /// 获取所有菜单节点列表
        /// </summary>
        /// <returns></returns>
        public List<MenuEntity> GetList()
        {
            List<MenuEntity> list = new List<MenuEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * From Menu ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    MenuEntity sh = DataRowToModel(row);
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
        /// 根据角色获取菜单所有节点（包含父节点）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns> 
        public List<MenuEntity> GetList1(string roleID)
        {
            List<MenuEntity> list = new List<MenuEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT DISTINCT ");
            strSql.Append(" m.* ");
            strSql.Append(" FROM ");
            strSql.Append(" Permission p ");
            strSql.Append(" LEFT JOIN Menu m ON p.MenuID = m.ID ");
            //strSql.Append(" WHERE m.IsDisabled = 0 and p.RoleID = @RoleID ");
            strSql.Append(" WHERE m.IsDisabled = 0 and p.RoleID in ('" + roleID.Replace(",", "','") + "') ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@RoleID", SqlDbType.VarChar,2000)		};
            ////parameters[0].Value = roleID;
            //parameters[0].Value = roleID.Replace(",", "','");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    MenuEntity sh = DataRowToModel(row);
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
        /// 获取所有可用的菜单节点列表
        /// </summary>
        /// <returns></returns>
        public List<MenuEntity> GetEnabledList()
        {
            List<MenuEntity> list = new List<MenuEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * From Menu Where IsDisabled = 0 ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    MenuEntity sh = DataRowToModel(row);
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
        /// 查询子节点数量
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public int GetSubMenuNodeCount(string parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select Count(1) From Menu Where ParentID = @ParentID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ParentID", SqlDbType.VarChar,50)		};
            parameters[0].Value = parentId;
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



    }
}
