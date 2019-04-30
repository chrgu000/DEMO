using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using SmallERP.DBUtility;
using SmallERP.Entity;
using SmallERP.Common;
using SmallERP.Domain;

namespace SmallERP.DataAccess
{
    public class AdminData
    {

        public AdminData()
        { }

        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Admin");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AdminEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Admin(");
            strSql.Append("ID,UserID,Password,Name,IsDisabled,RoleID,Sort,Department,Email,Mobile,Wechat)");
            strSql.Append(" values (");
            strSql.Append("@ID,@UserID,@Password,@Name,@IsDisabled,@RoleID,@Sort,@Department,@Email,@Mobile,@Wechat)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@IsDisabled", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.VarChar,2000),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Department", SqlDbType.NVarChar,250),
					new SqlParameter("@Email", SqlDbType.NVarChar,250),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Wechat", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.IsDisabled;
            parameters[5].Value = model.RoleID;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.Department;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.Mobile;
            parameters[10].Value = model.Wechat;

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
        public bool Update(AdminEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set ");
            //strSql.Append("UserID=@UserID,");
            //strSql.Append("Password=@Password,");
            strSql.Append("Name=@Name,");
            strSql.Append("IsDisabled=@IsDisabled,");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Department=@Department,");
            strSql.Append("Email=@Email,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Wechat=@Wechat");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    //new SqlParameter("@UserID", SqlDbType.VarChar,50),
                    //new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@IsDisabled", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.VarChar,2000),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Department", SqlDbType.NVarChar,250),
					new SqlParameter("@Email", SqlDbType.NVarChar,250),
                    new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Wechat", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
            //parameters[0].Value = model.UserID;
            //parameters[1].Value = model.Password;
            parameters[0].Value = model.Name;
            parameters[1].Value = model.IsDisabled;
            parameters[2].Value = model.RoleID;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.Department;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Mobile;
            parameters[7].Value = model.Wechat;
            parameters[8].Value = model.ID;

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
            strSql.Append("delete from Admin ");
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
            strSql.Append("delete from Admin ");
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
        public AdminEntity GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Admin ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = ID;

            AdminEntity model = new AdminEntity();
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
        public List<AdminView> GetAllOwner()
        {

            List<AdminView> list = new List<AdminView>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from Admin");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                list = ds.Tables[0].ToList<AdminView>();
                return list;
            }
            else
            {
                return new List<AdminView>();
            }
        }

        public AdminEntity GetEmail(string UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Admin ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50)			};
            parameters[0].Value = UserID;

            AdminEntity model = new AdminEntity();
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
        public AdminEntity DataRowToModel(DataRow row)
        {
            AdminEntity model = new AdminEntity();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["UserID"] != null)
                {
                    model.UserID = row["UserID"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["IsDisabled"] != null && row["IsDisabled"].ToString() != "")
                {
                    model.IsDisabled = int.Parse(row["IsDisabled"].ToString());
                }
                if (row["RoleID"] != null)
                {
                    model.RoleID = row["RoleID"].ToString();
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["Department"] != null)
                {
                    model.Department = row["Department"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
                if (row["Wechat"] != null)
                {
                    model.Wechat = row["Wechat"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM Admin ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM Admin ");
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
            strSql.Append("select count(1) FROM Admin ");
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
            strSql.Append(")AS Row, T.*  from Admin T ");
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
            parameters[0].Value = "Admin";
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

        /// <summary>
        /// 根据账号获取用户
        /// </summary>
        public AdminEntity GetModelByUserID(string userID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Admin ");
            strSql.Append(" where UserID=@UserID  and IsDisabled='0'");
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.VarChar, 50) };
            parameters[0].Value = userID;

            AdminEntity model = new AdminEntity();
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
        /// 获取所有有效的账号
        /// </summary>
        /// <returns></returns>
        public List<AdminEntity> GetEnabledList()
        {
            List<AdminEntity> list = new List<AdminEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from Admin t where IsDisabled = 0 Order By Sort ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    AdminEntity sh = DataRowToModel(row);
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
        /// 获取角色下的账号列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<AdminEntity> GetAdminListByRoleId(string roleID)
        {
            List<AdminEntity> list = new List<AdminEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.* from Admin a ");
            strSql.Append(" left join Role r on r.ID = a.RoleID ");
            strSql.Append(" where r.ID= @RoleID ");
            strSql.Append(" and a.IsDisabled = 0 ");
            strSql.Append(" order by a.Sort ");
            var parameters = new SqlParameter("@RoleID", roleID);
            //SqlParameter[] parameters = {
            //        new SqlParameter("@RoleID", SqlDbType.VarChar,50)		};
            //parameters[0].Value = roleID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    AdminEntity sh = DataRowToModel(row);
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
        /// 根据账号名查询账号数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetCountByUserID(string userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) FROM Admin Where UserID = '{0}' ", userID);
            //strSql.Append("select count(1) FROM Admin Where UserID = @UserID ");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@UserID", SqlDbType.VarChar,50)		};
            //parameters[0].Value = userID;
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
        /// 获取所有用户列表
        /// </summary>
        /// <returns></returns>
        public List<AdminEntity> GetList()
        {
            List<AdminEntity> list = new List<AdminEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select * From Admin ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    AdminEntity sh = DataRowToModel(row);
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
        /// 获取该角色下的账号数量
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetCountByRoleID(string roleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Admin Where RoleID = @RoleID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleID", SqlDbType.VarChar,50)		};
            parameters[0].Value = roleID;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 分页查询用户列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetListWithRole(string userId, string name, string roleId, int rowStart, int rowEnd, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.Sort ");
            strSql.Append(")AS Row, T.*,r.Name RoleName  from Admin T Left Join Role r on T.RoleID = r.ID  ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(userId))
                strSql.AppendFormat(" And T.UserID Like '%{0}%' ", userId);
            if (!string.IsNullOrEmpty(name))
                strSql.AppendFormat(" And T.Name Like '%{0}%' ", name);
            if (!string.IsNullOrEmpty(roleId))
                strSql.AppendFormat(" And T.RoleID Like '%{0}%' ", roleId);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            //SqlParameter[] parameters = {
            //        new SqlParameter("@RoleId", SqlDbType.VarChar,50)	};
            //parameters[0].Value = roleId;
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(" Select Count(1) From Admin T Left Join Role r on T.RoleID = r.ID ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(userId))
                strCountSql.AppendFormat(" And T.UserID Like '%{0}%' ", userId);
            if (!string.IsNullOrEmpty(name))
                strCountSql.AppendFormat(" And T.Name Like '%{0}%' ", name);
            if (!string.IsNullOrEmpty(roleId))
                strCountSql.AppendFormat(" And T.RoleID Like '%{0}%' ", roleId);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));


            //var ctx = this.DbContext;
            //StringBuilder strDataSql = new StringBuilder();
            //strDataSql.Append(" Select pg.* From ");
            //strDataSql.Append(" ( ");
            //strDataSql.Append(" Select t.*, ROWNUM rn From ");
            //strDataSql.Append(" ( ");
            //strDataSql.Append(" Select a.*,r.Name RoleName From Admin a Left Join Role r on a.Roleid = r.Id ");
            //strDataSql.Append(" Where 1=1 ");
            //if (!string.IsNullOrEmpty(userId))
            //    strDataSql.AppendFormat(" And a.UserId Like '%{0}%' ", userId);
            //if (!string.IsNullOrEmpty(name))
            //    strDataSql.AppendFormat(" And a.Name Like '%{0}%' ", name);
            //if (!string.IsNullOrEmpty(roleId))
            //    strDataSql.Append(" And a.RoleId = :RoleId ");
            //strDataSql.Append(" Order By a.Sort ");
            //strDataSql.Append(" ) t ) pg ");
            //strDataSql.Append(" Where pg.rn Between :StartIndex And :EndIndex ");
            //ctx.CreateCommand(strDataSql.ToString());
            //if (!string.IsNullOrEmpty(roleId))
            //    ctx.AddParameter("RoleId", roleId);
            //ctx.AddParameter("StartIndex", rowStart);
            //ctx.AddParameter("EndIndex", rowEnd);
            //DataTable result = ctx.ExecuteDataTable();

            //StringBuilder strCountSql = new StringBuilder();
            //strCountSql.Append(" Select Count(1) From Admin a Left Join Role r on a.Roleid = r.Id ");
            //strCountSql.Append(" Where 1=1 ");
            //if (!string.IsNullOrEmpty(userId))
            //    strCountSql.AppendFormat(" And a.UserId Like '%{0}%' ", userId);
            //if (!string.IsNullOrEmpty(name))
            //    strCountSql.AppendFormat(" And a.Name Like '%{0}%' ", name);
            //if (!string.IsNullOrEmpty(roleId))
            //    strCountSql.Append(" And a.RoleId = :RoleId ");
            //ctx.CreateCommand(strCountSql.ToString());

            //if (!string.IsNullOrEmpty(roleId))
            //    ctx.AddParameter("RoleId", roleId);
            //total = ctx.ExecuteScalar<int>();
            return result;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UpdatePassword(string id, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Admin Set Password = @Password ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)		,	
                    new SqlParameter("@Password", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = id;
            parameters[1].Value = password;

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
        public List<UserDomain> GetUserbyDept(string deptid)
        {
            deptid = deptid ?? string.Empty;
            string strSql = "SELECT UserID,Email from Admin  ";
            if (deptid == "CE" || deptid == "SQE")
            {
                strSql += "where Department in ('CE','SQE')";
            }
            else
            {
                strSql += "where Department='" + deptid + "' ";
            }
            strSql += "ORDER BY UserID";
            return DbHelperSQL.Query(strSql).Tables[0].ToList<UserDomain>();
        }
        public List<UserDomain> GetMRBApproveUser(string filter)
        {
            string strSql = "select a.UserID,a.Email from Admin a INNER JOIN t_tt_mrb_approve b on a.Email=b.Mail ";
            if (filter.Trim() != "")
            {
                strSql += " where " + filter + "";
            }
            return DbHelperSQL.Query(strSql).Tables[0].ToList<UserDomain>();
        }
        public List<AdminEntity> GetUserListAll()
        {
            string strSql = "SELECT UserID,Email from Admin where IsDisabled=0 ORDER BY UserID ";
            return DbHelperSQL.Query(strSql).Tables[0].ToList<AdminEntity>();
        }
        #endregion  ExtensionMethod

    }
}
