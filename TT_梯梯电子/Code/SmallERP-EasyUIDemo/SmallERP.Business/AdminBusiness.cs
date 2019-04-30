using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using SmallERP.Entity;
using SmallERP.DataAccess;
using SmallERP.Domain;
using SmallERP.Common;
using SmallERP.Common.Enums;
using System.Data.SqlClient;


namespace SmallERP.Business
{
    public class AdminBusiness
    {
        private readonly AdminData dal = new AdminData();
        public RoleBusiness roleBusiness = new RoleBusiness();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AdminEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdminEntity GetModel(string ID)
        {

            return dal.GetModel(ID);
        }

        public List<AdminView> GetAllOwner()
        {
            return dal.GetAllOwner();
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdminEntity GetEmail(string UserID)
        {

            return dal.GetEmail(UserID);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public AdminEntity GetModelByCache(string ID)
        //{

        //    string CacheKey = "AdminModel-" + ID;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (AdminEntity)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AdminEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AdminEntity> DataTableToList(DataTable dt)
        {
            List<AdminEntity> modelList = new List<AdminEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AdminEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod



        /// <summary>
        /// 获得数据列表
        /// 创建人：蒋俊
        /// 创建时间：2017-08-23 16:14:07
        /// </summary>
        public List<AdminEntity> GetTopModelList(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 根据账号获取用户
        /// </summary>
        public AdminEntity GetModelByUserID(string userID)
        {
            return dal.GetModelByUserID(userID);
        }

        /// <summary>
        /// 添加账号
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public bool AddAdmin(AddAdminDomain domain)
        {
            bool result = false;

            // 业务数据验证
            if (domain == null) throw new Exception("exception.");
            if (string.IsNullOrEmpty(domain.UserId)) throw new Exception("account is required.");
            if (string.IsNullOrEmpty(domain.Name)) throw new Exception("name is required.");
            if (string.IsNullOrEmpty(domain.Password)) throw new Exception("password is required.");
            if (domain.Password.Length < 6) throw new Exception("password lengh must be over 6 numbers or letters.");
            if (string.IsNullOrEmpty(domain.RoleId)) throw new Exception("choose at least on role");
            if (domain.Name.Trim().Length > 20) throw new Exception("role name can not be longer than 20 characters.");

            // 实体映射
            AdminEntity entity = new AdminEntity();
            entity.ID = Guid.NewGuid().ToString();
            entity.UserID = domain.UserId.Trim();
            entity.Password = Utils.MD5Encrypt(domain.UserId.Trim() + domain.Password);

            entity.Name = domain.Name.Trim();
            entity.RoleID = domain.RoleId;
            entity.Sort = domain.Sort;
            entity.IsDisabled = 0;
            entity.Department = domain.Department;
            entity.Email = domain.Email;


            // 插入数据库
            int sameUserId = dal.GetCountByUserID(entity.UserID);
            if (sameUserId > 0) throw new Exception("Already have the same account, please replace other account.");
            result = dal.Add(entity);
            return result;
        }


        /// <summary>
        /// 筛选用户列表
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<AdminResultDomain> GetAdminList(SearchAdminDomain domain, out int total)
        {
            DataTable result = null;
            result = dal.GetListWithRole(domain.UserId, domain.Name, domain.RoleId, domain.RowStart(), domain.RowEnd(), out total);
            if (result != null && result.Rows.Count > 0)
            {
                //获取Role集合
                foreach (DataRow dr in result.Rows)
                {
                    string roleIDs = dr["RoleID"].ToString();
                    List<RoleEntity> roleEntityList = roleBusiness.GetModelList(" ID in ('" + roleIDs.Replace(",", "','") + "') ");
                    if (roleEntityList != null && roleEntityList.Count > 0)
                    {
                        dr["RoleName"] = string.Empty;
                        foreach (RoleEntity roleEntity in roleEntityList)
                        {
                            dr["RoleName"] += roleEntity.Name + ",";
                        }
                        dr["RoleName"] = dr["RoleName"].ToString().TrimEnd(',');
                    }
                }
            }
            return result.ToEntityList<AdminResultDomain>();
        }

        /// <summary>
        /// 根据角色获取账号列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<AdminEntity> GetListByRole(string roleId)
        {
            List<AdminEntity> result = new List<AdminEntity>();
            result = dal.GetAdminListByRoleId(roleId);
            return result;
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AdminRoleEnum? GetAdminRole(string id)
        {
            AdminRoleEnum? result = null;
            AdminEntity entity = new AdminEntity();
            entity = dal.GetModel(id);

            if (entity.RoleID == ConfigurationManager.AppSettings["SystemAdminRoleId"])
                result = AdminRoleEnum.SystemAdmin;
            return result;
        }



        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="LoginId">登录帐号</param>
        /// <returns></returns>
        public AdminRoleEnum? GetAdminRoleByLoginId(string LoginId)
        {
            AdminRoleEnum? result = null;
            AdminEntity entity = new AdminEntity();
            entity = dal.GetModelByUserID(LoginId);

            if (entity.RoleID == ConfigurationManager.AppSettings["SystemAdminRoleId"])
                result = AdminRoleEnum.SystemAdmin;
            return result;
        }


        /// <summary>
        /// 系统管理员
        /// </summary>
        /// <returns></returns>
        public List<AdminEntity> GetSystemAdmins()
        {
            return GetListByRole(ConfigurationManager.AppSettings["SystemAdminRoleId"]);
        }

        /// <summary>
        /// 获取所有有效的账号
        /// </summary>
        /// <returns></returns>
        public List<AdminEntity> GetEnabledList()
        {
            List<AdminEntity> result = new List<AdminEntity>();
            result = dal.GetEnabledList();
            return result;
        }

        /// <summary>
        /// 更新账号信息
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public bool UpdateAdmin(UpdateAdminDomain domain)
        {
            bool result = false;

            // 业务数据验证
            if (domain == null) throw new Exception("When the account is updated, the role object is empty.");
            if (string.IsNullOrEmpty(domain.Id)) throw new Exception("When the account is updated, the primary key is empty.");
            if (string.IsNullOrEmpty(domain.Name)) throw new Exception("Please fill in your name.");
            if (string.IsNullOrEmpty(domain.RoleId)) throw new Exception("Please bind a role for authorization.");
            if (domain.Name.Trim().Length > 20) throw new Exception("Role name length cannot exceed 20.");

            AdminEntity entity = new AdminEntity();
            entity.ID = domain.Id;
            entity.Name = domain.Name;
            entity.RoleID = domain.RoleId;
            entity.Sort = domain.Sort;
            entity.IsDisabled = domain.IsDisabled ? 1 : 0;
            entity.Department = domain.Department;
            entity.Email = domain.Email;

            result = dal.Update(entity);
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>LoginUserDomain
        /// <param name="id">账号Id</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool ChangePassword(string id, string password)
        {
            bool result = false;
            if (string.IsNullOrEmpty(id)) throw new Exception("Reset the password, the account primary key is empty.");
            if (string.IsNullOrEmpty(password)) throw new Exception("Reset password can not be empty.");
            result = dal.UpdatePassword(id, Utils.CreateMd5Hash(password));
            return result;
        }

        /// <summary>
        /// 用户自定义修改密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePasswordSelf(string userId, string oldPassword, string newPassword)
        {
            bool result = false;
            if (string.IsNullOrEmpty(userId)) throw new Exception("Login timeout, please re login.");
            if (string.IsNullOrEmpty(oldPassword)) throw new Exception("Please enter the original password.");
            if (string.IsNullOrEmpty(newPassword)) throw new Exception("Please enter a new password.");
            if (newPassword.Length < 6) throw new Exception("New password must be more than 6.");
            AdminEntity entity = dal.GetModelByUserID(userId);
            if (entity == null) throw new Exception("The current user does not exist or has been deleted.");
            if (entity.Password != Utils.CreateMd5Hash(oldPassword)) throw new Exception("The original password is not correct.");

            result = dal.UpdatePassword(entity.ID, Utils.CreateMd5Hash(newPassword));
            return result;
        }

        /// <summary>
        /// 重置密码  初始密码为 123456
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ResetPassword(string id)
        {
            return ChangePassword(id, "123456");
        }

        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAdmin(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new Exception("When you delete the account, the account key is empty.");
            AdminEntity entity = dal.GetModel(id);
            if (entity == null)
                throw new Exception("The account does not exist or has been deleted.");
            if (entity.UserID == "admin")
                throw new Exception("The account for the system to retain the account, can not be deleted.");

            // 删除账号
            dal.Delete(id);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LoginUserDomain Login(string userId, string password)
        {
            LoginUserDomain result = null;

            AdminEntity entity = null;
            entity = dal.GetModelByUserID(userId.Trim());

            if (entity == null || string.IsNullOrEmpty(entity.ID)) throw new Exception("The account you entered is incorrect.");
            // string Passwords = Utils.MD5Encrypt(userId + password);
            if (entity.Password != Utils.CreateMd5Hash(password))
                throw new Exception("The password you entered is incorrect.");
            if (entity.IsDisabled != null && entity.IsDisabled == 1)
                throw new Exception("Your account has been banned from logging in, please contact the administrator.");

            result = new LoginUserDomain();
            result.Id = entity.ID;
            result.Name = entity.Name;
            result.UserId = entity.UserID;
            result.Department = entity.Department;

            return result;
        }
        public List<UserDomain> GetUserbyDept(string filter)
        {
            return dal.GetUserbyDept(filter);
        }
        public List<UserDomain> GetMRBApproveUser(string filter)
        {
            return dal.GetMRBApproveUser(filter);
        }
        public List<AdminEntity> GetUserListAll()
        {
            return dal.GetUserListAll();
        }
        public string GetEmailStr(string UserID)
        {
            AdminEntity admin = dal.GetEmail(UserID);
            string emailstr = admin.Email;
            return emailstr;
        }
        #endregion  ExtensionMethod
    }
}
