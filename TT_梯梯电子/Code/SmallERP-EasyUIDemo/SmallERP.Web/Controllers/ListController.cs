using SmallERP.Business;
using SmallERP.Common;
using SmallERP.Domain;
using SmallERP.Entity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;

namespace SmallERP.Web.Controllers
{
    public class ListController : BaseController
    {
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <returns></returns>
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
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList()
        {
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);
            AdminBusiness adminBll = new AdminBusiness();
            int total = 0;
            string IsCreateUid = Request.UrlReferrer.Query.ToString();
            string queryDate1 = Request["queryDate1"];
            string queryDate2 = Request["queryDate2"];
            string sWhere = "";
            if (queryDate1 != "")
            {
                sWhere = sWhere + " and convert(nvarchar(10),dDate,120)>='" + queryDate1 + "'";
            }
            if (queryDate2 != "")
            {
                sWhere = sWhere + " and convert(nvarchar(10),dDate,120)<='" + queryDate2 + "'";
            }
            if (IsCreateUid.IndexOf("IsCreateUid=true") >= 0)
            {
                sWhere = sWhere + " and CreateUid='" + CurrentUser.LoginId + "'";
            }
            TK_ListBusiness Bll = new TK_ListBusiness();
            DataTable result = Bll.GetList(sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result,"yyyy-MM-dd HH:mm:dd");

            return Json(new SuccessJsonResult(obj, total));
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <returns></returns>
        public ActionResult Stop()
        {
            try
            {
                string iID = Request.Params["iID"].ToString();

                ArrayList aList = new ArrayList();

                TK_ListBusiness Bll_l = new TK_ListBusiness();

                DataTable dt = Bll_l.GetList(" and iID='" + iID + "'");

                if (dt.Rows.Count == 0)
                {
                    return Json(new { Msg = "停止失败,未找到相关单据", Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
                if (dt.Rows[0]["iState"].ToString()=="2")
                {
                    return Json(new { Msg = "停止失败,处理已完成", Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
                if (dt.Rows[0]["iState"].ToString() == "3")
                {
                    return Json(new { Msg = "停止失败,处理已完成失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
                if (dt.Rows[0]["iState"].ToString() == "4")
                {
                    return Json(new { Msg = "停止失败,已强制取消计算", Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
                aList.Add(Bll_l.Stop(iID));

                bool updateResult = Bll_l.Update(aList);
                if (!updateResult)
                    return Json(new { Msg = "停止失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = "停止失败" + ex.Message, Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Msg = "停止成功", Result = "1" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 作废
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            try
            {
                string iID = Request.Params["iID"].ToString();

                ArrayList aList = new ArrayList();

                TK_ListBusiness Bll_l = new TK_ListBusiness();

                DataTable dt = Bll_l.GetList(" and iID='" + iID + "'");

                if (dt.Rows.Count == 0)
                {
                    return Json(new { Msg = "作废失败,未找到相关单据", Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
                if (dt.Rows[0]["isdel"].ToString() == "1")
                {
                    return Json(new { Msg = "作废失败,已作废", Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
                aList.Add(Bll_l.Delete(iID));

                bool updateResult = Bll_l.Update(aList);
                if (!updateResult)
                    return Json(new { Msg = "作废失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = "作废失败" + ex.Message, Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Msg = "作废成功", Result = "1" }, JsonRequestBehavior.AllowGet);
        }
    }
}
