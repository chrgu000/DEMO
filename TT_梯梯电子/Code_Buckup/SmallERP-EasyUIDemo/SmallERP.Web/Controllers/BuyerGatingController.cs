using SmallERP.Business;
using SmallERP.Common;
using SmallERP.Domain;
using SmallERP.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallERP.Web.Controllers
{
    public class BuyerGatingController : Controller
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
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);
            AdminBusiness adminBll = new AdminBusiness();
            int total = 0;

            string queryVersion = Request["queryVersion"];
            string queryName = Request["queryName"];
            string queryPlanner = Request["queryPlanner"];

            string queryGroup = Request["queryGroup"];
            string sWhere = "";
            if (queryName != "")
            {
                sWhere = sWhere + " and iItemNO like N'%" + queryName + "%'";
            }
            if (queryPlanner != "")
            {
                sWhere = sWhere + " and sBuyer like N'%" + queryPlanner + "%'";
            }
            if (queryVersion != "")
            {
                sWhere = sWhere + " and sTKVersion='" + queryVersion + "'";
            }
            if (queryGroup != "")
            {
                string[] splitqueryGroup = queryGroup.Split(',');
                string listqueryGroup = "";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (listqueryGroup != "")
                    {
                        listqueryGroup = listqueryGroup + ",";
                    }
                    listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                }
                sWhere = sWhere + " and sProductGroup in (" + listqueryGroup + ")";
            }
            
            BuyerGatingBusiness Bll = new BuyerGatingBusiness();
            DataTable result = Bll.GetList(sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result);

            return Json(new SuccessJsonResult(obj, total));
        }

        #endregion

        /// <summary>
        /// 获取当前日期工作日历列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetQty()
        {
            PublicBusiness p = new PublicBusiness();
            object result = p.GetPeriod();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 版本
        /// </summary>
        /// <returns></returns>
        public ActionResult GetVersionList()
        {
            TK_TrialkittingBusiness Bll = new TK_TrialkittingBusiness();
            object result = Bll.GetTKTrialkitVersion();

            return Json(result);
        }

        /// <summary>
        /// 计划员
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPlanner()
        {
            PublicBusiness Bll = new PublicBusiness();
            object result = Bll.GetPlannerList();

            return Json(result);
        }

        /// <summary>
        /// 项目组
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProductGroupList()
        {
            PublicBusiness Bll = new PublicBusiness();
            object result = Bll.GetProductGroupList();

            return Json(result);
        }
    }
}
