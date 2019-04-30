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
    public class ExcludeController : BaseController
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
            string sWhere = "";
            if (filterName != "")
            {
                sWhere = sWhere + " and sItemNo like N'%" + filterName + "%'";
            }

            TK_Base_ItemNo_ExcludeBusiness Bll = new TK_Base_ItemNo_ExcludeBusiness();
            DataTable result = Bll.GetList(sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result);

            return Json(new SuccessJsonResult(obj, total));
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

                string json = Request.Form[0].ToString();
                DataTable dt = ToDataTable(json);
                string sErr = "";
                ArrayList aList = new ArrayList();
                TK_Base_ItemNo_ExcludeBusiness roleBll = new TK_Base_ItemNo_ExcludeBusiness();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //设置model
                    TK_Base_ItemNo_ExcludeEntity model = new TK_Base_ItemNo_ExcludeEntity();
                    if (dt.Rows[i]["iID"] != null && dt.Rows[i]["iID"].ToString() != "") model.iID = Int32.Parse(dt.Rows[i]["iID"].ToString());
                    if (dt.Rows[i]["sItemNo"] != null && dt.Rows[i]["sItemNo"].ToString() != "") model.sItemNo = dt.Rows[i]["sItemNo"].ToString();

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

                string json = Request.Form[0].ToString();
                DataTable dt = ToDataTable(json);
                string sErr = "";
                ArrayList aList = new ArrayList();
                TK_Base_ItemNo_ExcludeBusiness roleBll = new TK_Base_ItemNo_ExcludeBusiness();
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

        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(string strJson)
        {
            ////取出表名  
            //Regex rg = new Regex(@"(?<={)[^:]+(?=:/[)", RegexOptions.IgnoreCase);
            //string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            ////去除表名  
            //strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            //strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据  
            Regex rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');

                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = "";
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');

                        dc.ColumnName = strCell[0].ToString().Replace("\"", "").Trim();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("/", "").Replace("\"", "").Trim();
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }
    }
}
