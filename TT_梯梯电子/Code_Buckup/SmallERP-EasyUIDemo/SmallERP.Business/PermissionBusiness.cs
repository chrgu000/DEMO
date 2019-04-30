using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallERP.DataAccess;
using SmallERP.Common;
using SmallERP.Entity;
using SmallERP.Domain;
using System.Dynamic;

namespace SmallERP.Business
{
    public class PermissionBusiness
    {

        private readonly AdminData adminData = new AdminData();
        private readonly MenuData menuData = new MenuData();
        private readonly RoleData roleData = new RoleData();
        private readonly PermissionData permissionData = new PermissionData();

        /// <summary>
        /// 结构化所有菜单节点
        /// </summary>
        /// <returns></returns>
        public List<PermissionNodeDomain> GetAllMenus()
        {
            // 获取所有菜单数据
            List<MenuEntity> menuList = new List<MenuEntity>();
            menuList = menuData.GetEnabledList();

            // 筛选出所有根节点并排序
            List<MenuEntity> roots = menuList.Where(p => string.IsNullOrEmpty(p.ParentID)).OrderBy(p => p.Sort).ToList<MenuEntity>();

            // 定义返回结果集
            List<PermissionNodeDomain> result = new List<PermissionNodeDomain>();

            foreach (MenuEntity root in roots)
            {
                PermissionNodeDomain node = MenuNodeMap(root);
                // 递归调用
                RecursiveMenuNode(node, menuList);
                result.Add(node);
            }

            return result;
        }

        /// <summary>
        /// 节点映射
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private PermissionNodeDomain MenuNodeMap(MenuEntity entity)
        {
            PermissionNodeDomain result = new PermissionNodeDomain();
            result.id = entity.ID;
            result.text = entity.Name;
            result.@checked = false;
            result.state = "open";
            result.iconCls = entity.Icon;
            result.attributes = new NodeAttributes();
            result.attributes.url = entity.Url;
            result.attributes.sort = entity.Sort.Value;
            result.children = new List<PermissionNodeDomain>();
            return result;
        }


        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="nodeIdList"></param>
        /// <returns></returns>
        public bool SavePermission(string roleId, List<string> nodeIdList)
        {
            if (string.IsNullOrEmpty(roleId))
                throw new Exception("请先选择角色。");
            // 开启事务
            //pData.DbContext.BeginTransaction();

            // 先删除该角色下原有所有权限
            permissionData.DeleteByRoleID(roleId);

            PermissionEntity entity;
            // 添加新权限
            foreach (string nodeId in nodeIdList)
            {
                entity = new PermissionEntity();
                entity.ID = Guid.NewGuid().ToString();
                entity.MenuID = nodeId;
                entity.RoleID = roleId;

                bool addResult = permissionData.Add(entity);
                if (!addResult)
                    throw new Exception("设置权限失败。");
            }

            // 提交事务
            //pData.DbContext.CommitTransaction();

            return true;
        }

        /// <summary>
        /// 根据角色获取获取权限列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<PermissionEntity> GetPermissionsByRoleId(string roleId)
        {
            List<PermissionEntity> result = new List<PermissionEntity>();
            result = permissionData.GetListByRoleId(roleId);
            return result;
        }

        /// <summary>
        /// 根据角色获取权限菜单节点Id列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<string> GetMenuIdsByRoleId(string roleID)
        {
            List<PermissionEntity> result = GetPermissionsByRoleId(roleID);
            var query = from i in result
                        select i.MenuID;
            return query.ToList<string>();
        }

        /// <summary>
        /// 递归出所有子节点
        /// </summary>
        /// <param name="parentNode">父节点</param>
        /// <param name="allNode">所有节点数据</param>
        private void RecursiveMenuNode(PermissionNodeDomain parentNode, List<MenuEntity> allNodes)
        {
            // 筛选出子节点
            List<MenuEntity> children = allNodes.Where(p => p.ParentID == parentNode.id).OrderBy(p => p.Sort).ToList<MenuEntity>();

            foreach (MenuEntity menuNode in children)
            {
                PermissionNodeDomain node = MenuNodeMap(menuNode);
                parentNode.children.Add(node);
                RecursiveMenuNode(node, allNodes);
            }
        }

        private List<MenuEntity> lineNodes;

        /// <summary>
        /// 递归出所有父节点
        /// </summary>
        /// <param name="leafNodes"></param>
        /// <param name="allNodes"></param>
        private void RecursiveMenuParentNode(MenuEntity leafNode, List<MenuEntity> allNodes)
        {
            MenuEntity parent = allNodes.SingleOrDefault(p => p.ID == leafNode.ParentID);
            if (parent != null)
            {
                lineNodes.Add(parent);
                RecursiveMenuParentNode(parent, allNodes);
            }
        }

        /// <summary>
        /// 根据角色Id获取菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<PermissionNodeDomain> GetRoleMenus(string roleId)
        {
            //if (string.IsNullOrEmpty(roleId)) throw new Exception("获取角色权限是，角色主键为空。");
            //List<MenuEntity> menuList = new List<MenuEntity>();
            //using (MenuData mData = new MenuData())
            //{
            //    menuList = mData.GetList1(roleId);
            //}

            //// 筛选出所有根节点并排序
            //List<MenuEntity> roots = menuList.Where(p => string.IsNullOrEmpty(p.ParentID)).OrderBy(p => p.Sort).ToList<MenuEntity>();

            //// 定义返回结果集
            //List<PermissionNodeDomain> result = new List<PermissionNodeDomain>();

            //foreach (MenuEntity root in roots)
            //{
            //    PermissionNodeDomain node = MenuNodeMap(root);
            //    // 递归调用
            //    RecursiveMenuNode(node, menuList);
            //    result.Add(node);
            //}

            //return result;


            if (string.IsNullOrEmpty(roleId)) throw new Exception("获取角色权限是，角色主键为空。");
            List<MenuEntity> menuList = new List<MenuEntity>();
            List<MenuEntity> allMenuList = new List<MenuEntity>();
            // 所有有权限的菜单叶节点
            menuList = menuData.GetList1(roleId);
            // 查询所有可用的菜单节点
            allMenuList = menuData.GetEnabledList();

            // 递归查询出所有父节点
            List<MenuEntity> treeNodes = new List<MenuEntity>();
            foreach (MenuEntity node in menuList)
            {
                lineNodes = new List<MenuEntity>();
                RecursiveMenuParentNode(node, allMenuList);
                treeNodes.Add(node);
                treeNodes.AddRange(lineNodes);
            }

            treeNodes = treeNodes.Distinct().ToList();


            // 筛选出所有根节点并排序
            List<MenuEntity> roots = treeNodes.Where(p => string.IsNullOrEmpty(p.ParentID)).OrderBy(p => p.Sort).ToList<MenuEntity>();

            // 定义返回结果集
            List<PermissionNodeDomain> result = new List<PermissionNodeDomain>();

            foreach (MenuEntity root in roots)
            {
                PermissionNodeDomain node = MenuNodeMap(root);
                // 递归调用
                RecursiveMenuNode(node, treeNodes);
                result.Add(node);
            }

            return result;

        }

        /// <summary>
        /// 根据账号获取菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<PermissionNodeDomain> GetUserMenus(string userId)
        {
            if (string.IsNullOrEmpty(userId)) throw new Exception("登录超时，请重新登录。");
            AdminEntity entity = null;
            entity = adminData.GetModelByUserID(userId);
            if (entity == null) throw new Exception("该用户不存在或已被删除。");
            return GetRoleMenus(entity.RoleID);
        }
    }
}
