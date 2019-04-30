using SmallERP.Business;
using SmallERP.Common;
using SmallERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SmallERP.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 后台用户登录认证
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Logon()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string userId = Request["UserId"];
                string password = Request["Password"];

                AdminBusiness service = new AdminBusiness();
                // 获取用户相关基本信息
                LoginUserDomain domain = service.Login(userId, password);

                // 创建票据
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, domain.UserId, DateTime.Now, DateTime.Now.AddHours(2), false, domain.Department, "/");
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(domain.UserId, false, 120);
                string encTicket = FormsAuthentication.Encrypt(ticket);


                //FormsAuthentication.SetAuthCookie(encTicket, false);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                CookieHelper.AddCookie(cookie);
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }
        public ActionResult Test()
        {
            return View("~/Views/ToolManage/ToolManage.cshtml");
        }

    }
}
