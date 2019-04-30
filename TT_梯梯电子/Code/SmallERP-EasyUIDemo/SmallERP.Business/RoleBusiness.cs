using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallERP.Common;
using SmallERP.DataAccess;
using SmallERP.Entity;
using SmallERP.Domain;
using System.Data;

namespace SmallERP.Business
{
    public class RoleBusiness
    {

        private readonly AdminData adminData = new AdminData();
        private readonly RoleData dal = new RoleData();
        private readonly PermissionData permissionData = new PermissionData();

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
        public bool Add(RoleEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(RoleEntity model)
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
        public RoleEntity GetModel(string ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public RoleEntity GetModelByCache(string ID)
        //{

        //    string CacheKey = "RoleModel-" + ID;
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
        //    return (RoleEntity)objModel;
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
        public List<RoleEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RoleEntity> DataTableToList(DataTable dt)
        {
            List<RoleEntity> modelList = new List<RoleEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RoleEntity model;
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

        #endregion  ExtensionMethod

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public bool AddRole(AddRoleDomain domain)
        {
            bool result = false;

            // 业务数据验证
            if (domain == null) throw new Exception("添加角色时，角色对象为空。");
            if (string.IsNullOrWhiteSpace(domain.Name)) throw new Exception("请填写角色名称。");
            if (domain.Name.Trim().Length > 50) throw new Exception("角色名称长度不能超过50。");
            if (domain.Description.Length > 100) throw new Exception("角色描述长度不能超过100。");

            // 实体映射
            RoleEntity entity = new RoleEntity();
            entity.ID = Guid.NewGuid().ToString();
            entity.Name = domain.Name.Trim();
            entity.Sort = domain.Sort;
            entity.Description = string.IsNullOrWhiteSpace(domain.Description) ? null : domain.Description;
            entity.CanDelete = 1;

            // 插入数据库
            result = dal.Add(entity);
            return result;
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public bool UpdateRole(UpdateRoleDomain domain)
        {
            bool result = false;

            // 业务数据验证
            if (domain == null) throw new Exception("编辑角色时，角色对象为空。");
            if (string.IsNullOrEmpty(domain.Id)) throw new Exception("编辑角色时，角色对象主键为空。");
            if (string.IsNullOrWhiteSpace(domain.Name)) throw new Exception("请填写角色名称。");
            if (domain.Name.Trim().Length > 50) throw new Exception("角色名称长度不能超过50。");
            if (domain.Description.Length > 100) throw new Exception("角色描述长度不能超过100。");

            // 实体映射
            RoleEntity entity = new RoleEntity();
            entity.ID = domain.Id;
            entity.Name = domain.Name.Trim();
            entity.Sort = domain.Sort;
            entity.Description = string.IsNullOrWhiteSpace(domain.Description) ? null : domain.Description;

            // 插入数据库
            result = dal.Update(entity);
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRole(string id)
        {
            // 验证该角色是否绑定了用户
            int adminCount = 0;
            adminCount = adminData.GetCountByRoleID(id);
            if (adminCount > 0) throw new Exception("该角色下含有账号，无法删除。");

            // 共享数据库上下文
            //permissionData.DbContext = roleData.DbContext;

            // 开启事务
            //permissionData.DbContext.BeginTransaction();

            RoleEntity entity = dal.GetModel(id);
            if (entity == null)
                throw new Exception("请先选择需要删除的角色");
            if (entity.CanDelete == 0)
                throw new Exception("系统保留角色，不可删除");

            // TODO: 级联删除相关权限


            // 删除角色
            dal.Delete(id);

            // 提交事务
            //permissionData.DbContext.CommitTransaction();
        }

        /// <summary>
        /// 获取单个角色
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public RoleEntity GetRole(string roleID)
        {
            RoleEntity result;
            result = dal.GetModel(roleID);
            return result;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public List<RoleEntity> GetRoleList()
        {
            List<RoleEntity> result;
            result = dal.GetList();
            return result;
        }
    }
}
