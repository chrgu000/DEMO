﻿using SmallERP.Business;
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
    public class BOMController : BaseController
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

            string queryVersion = Request["queryVersion"];
            //string queryPlanner = Request["queryPlanner"];
            string queryGroup = Request["queryGroup"];
            string filterName = Request["filterName"];
            string sWhere = "";
            if (queryVersion != "")
            {
                sWhere = sWhere + " and sDataVersion='" + queryVersion + "'";
            }
            //if (queryPlanner != "")
            //{
            //    sWhere = sWhere + " and sPlannerCode='" + queryPlanner + "'";
            //}
            if (queryGroup != "")
            {
                sWhere = sWhere + " and topprodgroup='" + queryGroup + "'";
            }
            if (filterName != "")
            {
                sWhere = sWhere + " and toplevel like N'%" + filterName + "%'";
            }
            TK_BOMBusiness Bll = new TK_BOMBusiness();
            List<TK_BOMEntity> result = Bll.GetList(sWhere, param, out total);

            SuccessJsonResult obj = new SuccessJsonResult(result, total);
            return Json(obj);
        }

        /// <summary>
        /// 版本
        /// </summary>
        /// <returns></returns>
        public ActionResult GetVersionList()
        {
            PublicBusiness Bll = new PublicBusiness();
            object result = Bll.GetVersionList();

            return Json(result);
        }

        ///// <summary>
        ///// 计划员
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult GetPlanner()
        //{
        //    PublicBusiness Bll = new PublicBusiness();
        //    object result = Bll.GetPlannerList();

        //    return Json(result);
        //}

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
