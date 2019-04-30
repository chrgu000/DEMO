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
    public class CalendarDayoffController : BaseController
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

            string filterName = Request["filterName"];
            string sWhere = " and iYear='" + filterName + "'";

            TK_Base_Calendar_DayoffBusiness Bll = new TK_Base_Calendar_DayoffBusiness();
            DataTable result = Bll.GetList(sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result);

            return Json(new SuccessJsonResult(obj, total));

            //TK_Base_Calendar_DayoffBusiness Bll = new TK_Base_Calendar_DayoffBusiness();
            //List<TK_Base_Calendar_DayoffEntity> list = Bll.GetList(sWhere);
            //return Json(list, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public ActionResult Update()
        {
            try
            {
                LoginUserDomain domain = new LoginUserDomain();
                PublicBusiness p = new PublicBusiness();

                string json = Request.Form[0].ToString();
                DataTable dt = p.ToDataTable(json);
                string sErr = "";
                ArrayList aList = new ArrayList();
                TK_Base_Calendar_DayoffBusiness roleBll = new TK_Base_Calendar_DayoffBusiness();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //设置model
                    TK_Base_Calendar_DayoffEntity model = new TK_Base_Calendar_DayoffEntity();
                    if (dt.Rows[i]["iID"] != null && dt.Rows[i]["iID"].ToString() != "") model.iID = Int32.Parse(dt.Rows[i]["iID"].ToString());
                    if (dt.Rows[i]["iYear"] != null && dt.Rows[i]["iYear"].ToString() != "") model.iYear = Int32.Parse(dt.Rows[i]["iYear"].ToString());
                    if (dt.Rows[i]["dayOffStart"] != null && dt.Rows[i]["dayOffStart"].ToString() != "") model.dayOffStart = DateTime.Parse(dt.Rows[i]["dayOffStart"].ToString());
                    if (dt.Rows[i]["dayOffEnd"] != null && dt.Rows[i]["dayOffEnd"].ToString() != "") model.dayOffEnd = DateTime.Parse(dt.Rows[i]["dayOffEnd"].ToString());
                    if (dt.Rows[i]["sRemark"] != null && dt.Rows[i]["sRemark"].ToString() != "") model.sRemark = dt.Rows[i]["sRemark"].ToString();
                    model.dtmPreparedBy = DateTime.Now;
                    model.sPreparedBy = CurrentUser.LoginId;
                    model.dtmUpdate = DateTime.Now;
                    model.sUpdateUid = CurrentUser.LoginId;

                    // 业务数据验证
                    if (model == null) sErr = sErr + "行" + (i + 1) + "对象为空。\n";

                    //获取SQL
                    aList.Add(roleBll.Update(model));
                }
                bool updateResult = roleBll.Update(aList);
                if (!updateResult)
                    return Json(new { Msg = "保存失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = "保存失败" + ex.Message, Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Msg = "保存成功", Result = "1" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            try
            {
                LoginUserDomain domain = new LoginUserDomain();

                PublicBusiness p = new PublicBusiness();

                string json = Request.Form[0].ToString();
                DataTable dt = p.ToDataTable(json);
                string sErr = "";
                ArrayList aList = new ArrayList();
                TK_Base_Calendar_DayoffBusiness roleBll = new TK_Base_Calendar_DayoffBusiness();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // 业务数据验证

                    aList.Add(roleBll.Delete(dt.Rows[i]["iID"].ToString()));
                }
                bool updateResult = roleBll.Update(aList);
                if (!updateResult)
                    return Json(new { Msg = "删除失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = "删除失败" + ex.Message, Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Msg = "删除成功", Result = "1" }, JsonRequestBehavior.AllowGet);
        }

    }
}
