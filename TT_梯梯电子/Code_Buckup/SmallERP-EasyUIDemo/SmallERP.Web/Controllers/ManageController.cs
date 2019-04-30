using SmallERP.Business;
using SmallERP.Common;
using SmallERP.Domain;
using SmallERP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallERP.Web.Controllers
{
    public class ManageController : BaseController
    {

        public AdminBusiness adminBusiness = new AdminBusiness();

        [Authorize]
        public ActionResult Index()
        {

            string tabTitle = Request["tabTitle"];
            string tabUrl = Request["tabUrl"];
            string tabIcon = Request["tabIcon"];

            IndexEntity indexEntity = new IndexEntity();
            indexEntity.TabTitle = Utils.UrlDecode(tabTitle);
            indexEntity.TabUrl = Utils.UrlDecode(tabUrl);
            indexEntity.TabIcon = Utils.UrlDecode(tabIcon);

            //string userId = Request["UserId"];
            //if (!string.IsNullOrEmpty(userId))
            //{
            //    // 获取用户相关基本信息
            //    AdminEntity adminEntity = adminBusiness.GetModelByUserID(userId);

            //    // 创建票据
            //    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(2), false, adminEntity.Department, "/");
            //    //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(domain.UserId, false, 120);
            //    string encTicket = FormsAuthentication.Encrypt(ticket);

            //    //FormsAuthentication.SetAuthCookie(encTicket, false);
            //    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            //    CookieHelper.AddCookie(cookie);
            //}

            //if (User.Identity == null)
            //{
            //    string s = "";
            //}
            //(FormsIdentity)User.Identity
            return View(indexEntity);
        }

        public class IndexEntity
        {
            /// <summary>
            /// 需要打开的Tab页标题
            /// </summary>
            public string TabTitle { get; set; }

            /// <summary>
            /// 需要打开的Tab页URL
            /// </summary>
            public string TabUrl { get; set; }

            /// <summary>
            /// 需要打开的Tab页图标
            /// </summary>
            public string TabIcon { get; set; }
        }

        /// <summary>
        /// Tab首页（暂定使用gooflow做静态页面）
        /// 创建人：蒋俊
        /// 创建时间：2018-03-01 15:13:37
        /// </summary>
        /// <returns></returns>
        public ActionResult TabIndex()
        {
            return View();
        }

        #region 角色
        public ActionResult Role()
        {
            return View();
        }

        /// <summary>
        /// 获取一个角色对象
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRole()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string roleId = Request["Id"];
                RoleBusiness roleBll = new RoleBusiness();
                RoleEntity role = roleBll.GetRole(roleId);
                result = new SuccessJsonResult(role);
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleList()
        {
            string filterName = Request["filterName"];
            RoleBusiness roleBll = new RoleBusiness();
            List<RoleEntity> list = roleBll.GetRoleList();
            if (!string.IsNullOrEmpty(filterName))
                list = list.Where(p => p.Name.Contains(filterName)).ToList();
            return Json(list);
        }

        /// <summary>
        /// 获取所有角色，公共使用
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoles()
        {
            RoleBusiness roleBll = new RoleBusiness();
            List<RoleEntity> list = roleBll.GetRoleList();
            var query = from i in list
                        select new { id = i.ID, text = i.Name };
            return Json(query.ToList());
        }

        /// <summary>
        /// 添加一个角色
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRole()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                AddRoleDomain item = new AddRoleDomain();
                item.Name = Request["name"];
                item.Sort = int.Parse(Request["sort"]);
                item.Description = Request["description"];

                RoleBusiness roleBll = new RoleBusiness();
                bool addResult = roleBll.AddRole(item);
                if (!addResult)
                    result = new FailureJsonResult("Add role failed.");
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }

        /// <summary>
        /// 修改一个角色
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRole()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                UpdateRoleDomain item = new UpdateRoleDomain();
                item.Id = Request["Id"];
                item.Name = Request["name"];
                item.Sort = int.Parse(Request["sort"]);
                item.Description = Request["description"];

                RoleBusiness roleBll = new RoleBusiness();
                bool updateResult = roleBll.UpdateRole(item);
                if (!updateResult)
                    result = new FailureJsonResult("Modify role failed.");
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }

        public ActionResult DeleteRole()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string id = Request["Id"];
                RoleBusiness roleBll = new RoleBusiness();
                roleBll.DeleteRole(id);
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }
        #endregion

        #region 用户
        public ActionResult Admin()
        {
            return View();
        }

        /// <summary>
        /// 添加账号
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAdmin()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                AddAdminDomain domain = new AddAdminDomain();
                UpdateModel<AddAdminDomain>(domain);
                AdminBusiness adminBll = new AdminBusiness();
                domain.RoleId = Request["RoleId"];
                bool addResult = adminBll.AddAdmin(domain);
                if (!addResult)

                    result = new FailureJsonResult("Add account failed.");
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result, "text/html");
        }

        /// <summary>
        /// 修改账号
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateAdmin()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                UpdateAdminDomain domain = new UpdateAdminDomain();
                UpdateModel<UpdateAdminDomain>(domain);
                AdminBusiness adminBll = new AdminBusiness();
                domain.RoleId = Request["RoleId"];
                bool updateReslut = adminBll.UpdateAdmin(domain);
                if (!updateReslut)
                    result = new FailureJsonResult("Account modification failed.");
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result, "text/html");
        }

        /// <summary>
        /// 查询账号
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAdminList()
        {
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);

            AdminBusiness adminBll = new AdminBusiness();

            int total = 0;
            List<AdminResultDomain> result = adminBll.GetAdminList(param, out total);
            SuccessJsonResult obj = new SuccessJsonResult(result, total);
            return Json(obj);
        }

        /// <summary>
        /// 删除账号
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteAdmin()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string id = Request["Id"];
                AdminBusiness adminBll = new AdminBusiness();
                adminBll.DeleteAdmin(id);
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }

        /// <summary>
        /// 账号重置密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPassword()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string id = Request["Id"];
                AdminBusiness adminBll = new AdminBusiness();
                bool resetResult = adminBll.ResetPassword(id);
                if (!resetResult)
                    result = new FailureJsonResult("Reset password failed.");
                else
                    result.extraData = "Reset the password successfully, the initial password: 123456.";
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }

        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string oldPassword = Request["OldPassword"];
                string newPassword = Request["NewPassword"];
                AdminBusiness adminBll = new AdminBusiness();
                bool resetResult = adminBll.ChangePasswordSelf(CurrentUser.LoginId, oldPassword, newPassword);
                if (!resetResult)
                    result = new FailureJsonResult("Modify password failed.");
                else
                    result.extraData = "To change your password, please remember your new password.";
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }

        #endregion

        #region 菜单
        #endregion

        #region 权限
        public ActionResult Permission()
        {
            return View();
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllMenus()
        {
            PermissionBusiness service = new PermissionBusiness();
            List<PermissionNodeDomain> result = service.GetAllMenus();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存权限设置
        /// </summary>
        /// <returns></returns>
        public ActionResult SavePermission()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string roleId = Request["RoleID"];
                string nodeIds = Request["NodeIds[]"];
                List<string> nodeIdList = new List<string>();
                if (!string.IsNullOrEmpty(nodeIds))
                    nodeIdList = nodeIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

                PermissionBusiness service = new PermissionBusiness();
                bool setResult = service.SavePermission(roleId, nodeIdList);
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }

            return Json(result);
        }

        /// <summary>
        /// 获取权限 (授权时获取)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPermission()
        {
            string roleID = Request["RoleID"];
            PermissionBusiness service = new PermissionBusiness();
            List<string> result = service.GetMenuIdsByRoleId(roleID);
            return Json(result);
        }

        /// <summary>
        /// 获取角色菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenus()
        {
            PermissionBusiness service = new PermissionBusiness();
            List<PermissionNodeDomain> result = service.GetUserMenus(CurrentUser.LoginId);
            return Json(result);
        }
        #endregion
    }
}
