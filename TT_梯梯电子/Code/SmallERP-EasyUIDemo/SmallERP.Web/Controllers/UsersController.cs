using SmallERP.Business;
using SmallERP.Common;
using SmallERP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SmallERP.Web.Controllers
{
    public class UsersController : BaseController
    {
        public AdminBusiness adminBusiness = new AdminBusiness();

        public ActionResult Login()
        {
            LoginEntity loginEntity = new LoginEntity();
            string tabTitle = Request["tabTitle"];
            string tabUrl = Request["tabUrl"];
            string tabIcon = Request["tabIcon"];
            string userID = Request["userID"];
            loginEntity.TabTitle = tabTitle;
            loginEntity.TabUrl = tabUrl;
            loginEntity.TabIcon = tabIcon;
            if (!string.IsNullOrEmpty(tabTitle) && !string.IsNullOrEmpty(tabUrl))
            {
                if (string.IsNullOrEmpty(userID))
                {
                    userID = User.Identity.Name.Replace(".", "");
                }
                //string userId = User.Identity.Name.Replace(".", "");
                if (!string.IsNullOrEmpty(userID))
                {
                    // 获取用户相关基本信息
                    AdminEntity adminEntity = adminBusiness.GetModelByUserID(userID);
                    if (adminEntity != null)
                    {
                        // 创建票据
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userID, DateTime.Now, DateTime.Now.AddHours(2), false, adminEntity.Department, "/");
                        //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(domain.UserId, false, 120);
                        string encTicket = FormsAuthentication.Encrypt(ticket);

                        //FormsAuthentication.SetAuthCookie(encTicket, false);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                        CookieHelper.AddCookie(cookie);

                        return RedirectToAction("Index", "Manage", new { tabTitle = tabTitle, tabUrl = tabUrl, tabIcon = tabIcon });
                    }
                }
            }
            return View(loginEntity);
        }

        public class LoginEntity
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

        [AllowAnonymous]
        public ActionResult Regedit()
        {
            return View();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Json(new SuccessJsonResult());
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Default()
        {
            return View();
        }


    }
}
