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
    public class CalendarPeriodController : BaseController
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
            string filterName = Request["filterName"];
            string sWhere= " and iYear='"+ filterName + "'";
            TK_Base_CalendarPeriodBusiness Bll = new TK_Base_CalendarPeriodBusiness();
            List<TK_Base_CalendarPeriodEntity> list = Bll.GetList(sWhere);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public ActionResult Update()
        {
            string sMsg = "";
            try
            {
                LoginUserDomain domain = new LoginUserDomain();

                string json = Request.Form[0].ToString();
                DataTable dt = ToDataTable(json);
                string sErr = "";
                
                ArrayList aList = new ArrayList();
                //更新年度期间
                TK_Base_CalendarPeriodBusiness bll = new TK_Base_CalendarPeriodBusiness();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //设置model
                    TK_Base_CalendarPeriodEntity model = new TK_Base_CalendarPeriodEntity();
                    if (dt.Rows[i]["iID"] != null && dt.Rows[i]["iID"].ToString() != "") model.iID = Int32.Parse(dt.Rows[i]["iID"].ToString());
                    if (dt.Rows[i]["iYear"] != null && dt.Rows[i]["iYear"].ToString() != "") model.iYear = Int32.Parse(dt.Rows[i]["iYear"].ToString());
                    if (dt.Rows[i]["iMonth"] != null && dt.Rows[i]["iMonth"].ToString() != "") model.iMonth = Int32.Parse(dt.Rows[i]["iMonth"].ToString());
                    if (dt.Rows[i]["dtmStart"] != null && dt.Rows[i]["dtmStart"].ToString() != "") model.dtmStart = DateTime.Parse(dt.Rows[i]["dtmStart"].ToString());
                    if (dt.Rows[i]["dtmEnd"] != null && dt.Rows[i]["dtmEnd"].ToString() != "") model.dtmEnd = DateTime.Parse(dt.Rows[i]["dtmEnd"].ToString());
                    if (dt.Rows[i]["iWeek1"] != null && dt.Rows[i]["iWeek1"].ToString() != "") model.iWeek1 = DateTime.Parse(dt.Rows[i]["iWeek1"].ToString());
                    if (dt.Rows[i]["iWeek2"] != null && dt.Rows[i]["iWeek2"].ToString() != "") model.iWeek2 = DateTime.Parse(dt.Rows[i]["iWeek2"].ToString());
                    if (dt.Rows[i]["iWeek3"] != null && dt.Rows[i]["iWeek3"].ToString() != "") model.iWeek3 = DateTime.Parse(dt.Rows[i]["iWeek3"].ToString());
                    if (dt.Rows[i]["iWeek4"] != null && dt.Rows[i]["iWeek4"].ToString() != "") model.iWeek4 = DateTime.Parse(dt.Rows[i]["iWeek4"].ToString());
                    if (dt.Rows[i]["iWeek5"] != null && dt.Rows[i]["iWeek5"].ToString() != "") model.iWeek5 = DateTime.Parse(dt.Rows[i]["iWeek5"].ToString());
                    model.dtmPreparedBy = DateTime.Now;
                    model.sPreparedBy = CurrentUser.LoginId;
                    
                    // 业务数据验证
                    if (model == null) sErr = sErr + "行" + (i + 1) + "对象为空。\n";

                    //获取SQL
                    aList.Add(bll.Update(model));
                }

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }

                bool updateResult = bll.Update(aList);
                if (!updateResult)
                {
                    //更新年度期间失败
                    return Json(new { Msg = "保存失败" + sErr, Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //更新年度期间成功后，同时更新TK_Period表
                    aList.Clear();
                    sErr = "";
                    //更新17个工作日历
                    TK_PeriodBusiness bllp = new TK_PeriodBusiness();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string iYear = dt.Rows[i]["iYear"].ToString();
                        string iMonth = dt.Rows[i]["iMonth"].ToString();
                        DataTable dts = bll.GetList(iYear, iMonth);
                        if (dts.Rows.Count != 17)
                        {
                            //return Json(new { Msg = "保存失败" + "，" + iYear + "年" + iMonth + "月未找到相应的工作日历", Result = "-1" }, JsonRequestBehavior.AllowGet);
                            sMsg = sMsg + "行" + (i + 1) + iYear + "年" + iMonth + "月未找到相应的工作日历。\n";
                            break;
                        }

                        TK_PeriodEntity model = new TK_PeriodEntity();
                        if (dt.Rows[i]["iYear"] != null && dt.Rows[i]["iYear"].ToString() != "") model.iYear = dt.Rows[i]["iYear"].ToString();
                        if (dt.Rows[i]["iMonth"] != null && dt.Rows[i]["iMonth"].ToString() != "") model.iMonth = dt.Rows[i]["iMonth"].ToString();
                        
                        for (int j = 0; j < dts.Rows.Count; j++)
                        {
                            #region 获取17个工作日历
                            switch (j)
                            {
                                case 0:
                                    model.Period01 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 1:
                                    model.Period02 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 2:
                                    model.Period03 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 3:
                                    model.Period04 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 4:
                                    model.Period05 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 5:
                                    model.Period06 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 6:
                                    model.Period07 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 7:
                                    model.Period08 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 8:
                                    model.Period09 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 9:
                                    model.Period10 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 10:
                                    model.Period11 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 11:
                                    model.Period12 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 12:
                                    model.Period13 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 13:
                                    model.Period14 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 14:
                                    model.Period15 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 15:
                                    model.Period16 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                case 16:
                                    model.Period17 = DateTime.Parse(dts.Rows[j]["iWeek"].ToString());
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                        }

                        if (model == null) sErr = sErr + "行" + (i + 1) + "对象为空。\n";

                        //获取SQL
                        aList.Add(bllp.Update(iYear, iMonth, model));
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    updateResult = bllp.Update(aList);
                    if (!updateResult)
                    {
                        return Json(new { Msg = "保存失败" + sErr, Result = "-1" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { Msg = "保存失败" + ex.Message, Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Msg = "保存成功" + sMsg, Result = "1" }, JsonRequestBehavior.AllowGet);
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
