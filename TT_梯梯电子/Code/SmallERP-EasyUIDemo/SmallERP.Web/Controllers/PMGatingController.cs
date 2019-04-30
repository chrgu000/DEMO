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
    public class PMGatingController : Controller
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

            string queryName = Request["queryName"];
            string queryVersion = Request["queryVersion"];
            //string queryBuyer = Request["queryBuyer"];
            string queryPlanner = Request["queryPlanner"];
            string queryGroup = Request["queryGroup"];
            if (queryName == null)
            {
                queryName = "";
            }
            if (queryVersion == null)
            {
                queryVersion = "";
            }
            if (queryPlanner == null)
            {
                queryPlanner = "";
            }
            if (queryGroup == null)
            {
                queryGroup = "";
            }
            string sWhere = "";
            if (queryName != "")
            {
                sWhere = sWhere + " and PartID='" + queryName + "'";
            }
            if (queryPlanner != "")
            {
                sWhere = sWhere + " and PlanCode='" + queryPlanner + "'";
            }
            if (queryVersion != "")
            {
                sWhere = sWhere + " and sTKVersion='" + queryVersion + "'";
            }
            if (queryGroup != "")
            {
                string[] splitqueryGroup = queryGroup.Split(',');
                string listqueryGroup = " and (";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (i > 0)
                    {
                        listqueryGroup = listqueryGroup + " or ";
                    }
                    listqueryGroup = listqueryGroup + " ',' + ProGroup  + ',' like '%," + splitqueryGroup[i] + ",%'";
                }
                listqueryGroup = listqueryGroup + ")";
                sWhere = sWhere + listqueryGroup;
            }

            PMGatingBusiness Bll = new PMGatingBusiness();
            DataTable result = Bll.GetList(sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result);

            return Json(new SuccessJsonResult(obj, total));
        }

        public ActionResult GetDetails()
        {
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);
            AdminBusiness adminBll = new AdminBusiness();
            int total = 0;

            string queryiID = Request["queryiID"];
            string queryVersion = Request["queryVersion"];
            if (queryiID == null)
            {
                queryiID = "";
            }
            if (queryVersion == null)
            {
                queryVersion = "";
            }
            string sWhere = "";
            if (queryiID != "")
            {
                sWhere = sWhere + " and iID='" + queryiID + "'";
            }
            if (queryVersion != "")
            {
                sWhere = sWhere + " and sTKVersion='" + queryVersion + "'";
            }

            PMGatingBusiness Bll = new PMGatingBusiness();
            DataTable result = Bll.GetList(sWhere, param, out total);

            DataTable dt = new DataTable();
            dt.Columns.Add("PN");
            dt.Columns.Add("QtyETA");

            for (int i = 0; i < result.Rows.Count; i++)
            {
                if (result.Rows[i]["NonfullkitQty"].ToString() != "")
                {
                    string[] split = result.Rows[i]["NonfullkitQty"].ToString().Split('/');
                    for (int j = 0; j < split.Length; j++)
                    {
                        DataRow dw = dt.NewRow();
                        dw["PN"] = result.Rows[i]["PartID"].ToString();
                        dw["QtyETA"] = split[j];
                        dt.Rows.Add(dw);
                    }
                }
            }

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(dt);

            return Json(new SuccessJsonResult(obj, dt.Rows.Count));
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
        #endregion
    }
}
