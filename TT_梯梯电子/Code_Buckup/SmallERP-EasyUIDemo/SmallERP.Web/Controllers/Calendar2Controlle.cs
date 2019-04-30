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
    public class Calendar2Controller : Controller
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
        /// 创建人：俞霞
        /// 创建时间：2018-07-05
        /// </summary>
        /// <returns></returns>
        public ActionResult TabIndex()
        {
            return View();
        }

        #region 列表
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList()
        {
            string filterName = Request["filterName"];
            NetRequirementBusiness Bll = new NetRequirementBusiness();
            List<NetRequirementEntity> list = Bll.GetList();
            if (!string.IsNullOrEmpty(filterName))
                list = list.Where(p => p.sVersion.Contains(filterName)).ToList();
            return Json(list);
        }

        #endregion
    }
}
