﻿using SmallERP.Business;
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
    public class CurrentStockController : Controller
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
            string queryWarehouse = Request["queryWarehouse"];
            string queryName = Request["queryName"];
            string sWhere = "";
            if (queryVersion != "")
            {
                sWhere = sWhere + " and sVersion='" + queryVersion + "'";
            }
            if (queryWarehouse != "")
            {
                sWhere = sWhere + " and Warehouse='" + queryWarehouse + "'";
            }
            if (queryName != "")
            {
                sWhere = sWhere + " and sItemNo like '%" + queryName + "%'";
            }

            TK_CurrentStockBusiness Bll = new TK_CurrentStockBusiness();
            DataTable result = Bll.GetList(sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result);

            return Json(new SuccessJsonResult(obj, total));
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

        /// <summary>
        /// 仓库
        /// </summary>
        /// <returns></returns>
        public ActionResult GetWarehouse()
        {
            PublicBusiness Bll = new PublicBusiness();
            object result = Bll.GetWarehouseList();

            return Json(result);
        }
    }
}
