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
using System.IO;
using System.Web;
using System.Text;
using SmallERP.DBUtility;

namespace SmallERP.Web.Controllers
{
    public class PlannerController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList()
        {
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);
            AdminBusiness adminBll = new AdminBusiness();
            int total = 0;

            string qyVersion = Request["qyVersion"];
            string qyPlanner = Request["qyPlanner"];
            string qyGroup = Request["qyGroup"];
            string qyReorderpolicy = Request["qyReorderpolicy"];
            if (qyVersion != "")
            {
                TK_TrialkittingsBusiness Bll = new TK_TrialkittingsBusiness();
                DataTable result = Bll.GetList(qyVersion, qyPlanner, qyGroup,"", qyReorderpolicy, param, out total, true,true);

                PublicBusiness p = new PublicBusiness();
                object obj = p.ToObject(result);

                return Json(new SuccessJsonResult(obj, total));
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 得到错误列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetErrList()
        {
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);
            AdminBusiness adminBll = new AdminBusiness();
            int total = 0;

            string filterName = Request["filterName"];
            string sWhere = "";
            if (filterName != "")
            {
                sWhere = sWhere + " and sTKVersion='" + filterName + "'";
            }
            TK_Trialkitting_ErrorInfoBusiness Bll = new TK_Trialkitting_ErrorInfoBusiness();
            DataTable result = Bll.GetList(sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result);

            return Json(new SuccessJsonResult(obj, total));
        }

        /// <summary>
        /// 得到查询结果列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetQueryList()
        {
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);
            AdminBusiness adminBll = new AdminBusiness();
            int total = 0;

            string queryPlanner = Request["queryPlanner"];
            string queryGroup = Request["queryGroup"];
            string queryVersion = Request["queryVersion"];
            string queryDate1 = Request["queryDate1"];
            string queryDate2 = Request["queryDate2"];

            if (queryPlanner == null)
            {
                queryPlanner = "";
            }

            if (queryGroup == null)
            {
                queryGroup = "";
            }

            string sWhere = "";
            //if (queryPlanner != "")
            //{
            //    sWhere = sWhere + " and Planner='" + queryPlanner + "'";
            //}
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
                sWhere = sWhere + " and ProdGroup in (" + listqueryGroup + ")";
            }
            if (queryVersion != "")
            {
                sWhere = sWhere + " and a.sTKVersion='" + queryVersion + "'";
            }
            if (queryDate1 != "")
            {
                sWhere = sWhere + " and convert(nvarchar(10),dtmCreate,120)>='" + queryDate1 + "'";
            }
            if (queryDate2 != "")
            {
                sWhere = sWhere + " and convert(nvarchar(10),dtmCreate,120)<='" + queryDate2 + "'";
            }
            TK_TrialkittingBusiness Bll = new TK_TrialkittingBusiness();
            DataTable result = Bll.GetQueryList(sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result);

            return Json(new SuccessJsonResult(obj, total));
        }

        /// <summary>
        /// 点击NetQty列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNetQtyList()
        {
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);
            AdminBusiness adminBll = new AdminBusiness();
            int total = 0;

            string filterName = Request["filterName"];
            string queryPlanner = Request["queryPlanner"];
            string queryGroup = Request["queryGroup"];
            string queryVersion = Request["queryVersion"];
            if (queryPlanner == null)
            {
                queryPlanner = "";
            }
            if (queryGroup == null)
            {
                queryGroup = "";
            }
            if (queryVersion == null)
            {
                queryVersion = "";
            }
            string sWhere = "";
            if (filterName != "")
            {
                sWhere = sWhere + " and sPartID='" + filterName + "'";
            }
            //if (queryPlanner != "")
            //{
            //    sWhere = sWhere + " and sPlannerCode='" + queryPlanner + "'";
            //}
            if (queryGroup != "")
            {
                sWhere = sWhere + " and sProductGroup='" + queryGroup + "'";
            }
            if (queryVersion != "")
            {
                sWhere = sWhere + " and R.sTKVersion='" + queryVersion + "'";
            }
            TK_TrialkittingBusiness Bll = new TK_TrialkittingBusiness();
            DataTable result = Bll.GetNetQtyList(queryVersion, filterName, sWhere, param, out total);

            PublicBusiness p = new PublicBusiness();
            object obj = p.ToObject(result);

            return Json(new SuccessJsonResult(obj, total));
        }

        /// <summary>
        /// 获取当前日期工作日历列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetQty()
        {
            string qyVersion = Request["qyVersion"];
            if (qyVersion != "")
            {
                //string sWhere = " and iYear='" + iYear + "' and iMonth='" + iMonth + "'";
                TK_PeriodBusiness Bll = new TK_PeriodBusiness();
                PublicBusiness p = new PublicBusiness();
                object result = p.ToObject(Bll.GetList(qyVersion));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
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

                string Remark = Request.Form[1].ToString();

                string sErr = "";
                ArrayList aList = new ArrayList();

                string sWhere = " and iYear='" + DateTime.Now.Year + "' and iMonth='" + DateTime.Now.Month + "'";
                TK_PeriodBusiness Bllp = new TK_PeriodBusiness();
                DataTable dtp = Bllp.GetList2(sWhere);

                TK_NetRequirementBusiness blln = new TK_NetRequirementBusiness();
                string sVerData = blln.GetNewVersion();

                TK_Trialkit_Trial_UploadBusiness Bll = new TK_Trialkit_Trial_UploadBusiness();
                string sTKVersion = Bll.GetNewVersion(CurrentUser.LoginId);
                string sDataVersion = Bll.GetMaxVersion();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 10; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j].ToString() != "" && dt.Rows[i][j].ToString() != "0")
                        {
                            DateTime s1 = DateTime.Parse(dtp.Rows[0][dt.Columns[j].ColumnName].ToString());
                            DateTime s2 = s1;


                            //for (int s = 3; s < dtp.Columns.Count; s++)
                            //{
                            //    s2 = DateTime.Parse(dtp.Columns[s].ColumnName);
                            //    if (DateTime.Compare(s1, s2)<=0)
                            //    {
                            //        continue;
                            //    }
                            //}

                            TK_Trialkit_Trial_UploadEntity model = new TK_Trialkit_Trial_UploadEntity();

                            model.sTKVersion = sTKVersion;
                            model.sDataVersion = sDataVersion;
                            model.Partid = dt.Rows[i]["cInvCode"].ToString();
                            model.dDate = s1;
                            model.dtmPeriod = s2;
                            model.Qty = decimal.Parse(dt.Rows[i][j].ToString());

                            model.iUpload_Type = 0;
                            model.iTK_Type = 0;

                            model.dtmCreate = DateTime.Now;
                            model.CreateUid = CurrentUser.LoginId;
                            model.Remark = Remark;

                            aList.Add(Bll.Update(model));
                        }
                    }
                }
                TK_ListEntity model_l = new TK_ListEntity();
                model_l.sType = "Trialkitting";
                model_l.dDate = DateTime.Now;
                model_l.sVerData = sVerData;
                model_l.sVerTrialkitting = sTKVersion;
                model_l.ProdGroup = "";
                model_l.Planner = "";
                model_l.iState = 0;
                model_l.Remark = Remark;

                model_l.CreateUid = CurrentUser.LoginId;
                model_l.dtmCreate = DateTime.Now;

                TK_ListBusiness Bll_l = new TK_ListBusiness();
                aList.Add(Bll_l.Update(model_l));

                bool updateResult = Bll.Update(aList);
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
        /// 同步
        /// </summary>
        /// <returns></returns>
        public ActionResult Synchronize()
        {
            try
            {
                PublicBusiness p = new PublicBusiness();

                ArrayList aList = new ArrayList();

                TK_ListBusiness listBll = new TK_ListBusiness();
                int count = listBll.GetIsRun(" and sType='BaseData' and iState in ('0','1') and CreateUid='" + CurrentUser.LoginId + "'");

                if (count == 0)
                {
                    TK_Trialkit_Trial_UploadBusiness Bll = new TK_Trialkit_Trial_UploadBusiness();

                    TK_ListEntity model_l = new TK_ListEntity();
                    model_l.sType = "BaseData";
                    model_l.dDate = DateTime.Now;
                    model_l.iState = 0;
                    model_l.sVerData = DateTime.Now.ToString("yyyyMMddhhmmss");

                    model_l.CreateUid = CurrentUser.LoginId;
                    model_l.dtmCreate = DateTime.Now;

                    TK_ListBusiness Bll_l = new TK_ListBusiness();
                    aList.Add(Bll_l.Update(model_l));

                    bool updateResult = Bll.Update(aList);
                    if (!updateResult)
                        return Json(new { Msg = "同步失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Msg = "同步失败，已有未执行完成的同步", Result = "-1" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Msg = "同步失败" + ex.Message, Result = "-1" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Msg = "下达同步指令成功同步成功", Result = "1" }, JsonRequestBehavior.AllowGet);
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
        /// 版本Result表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetVersionResultList()
        {
            TK_TrialkittingBusiness Bll = new TK_TrialkittingBusiness();
            object result = Bll.GetTKTrialkitVersionResult();

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

        /// <summary>
        /// 类别
        /// </summary>
        /// <returns></returns>
        public ActionResult GetchktypeList()
        {
            PublicBusiness Bll = new PublicBusiness();
            DataTable dt = new DataTable();
            dt.Columns.Add("iID");
            dt.Columns.Add("iText");
            DataRow dw3 = dt.NewRow();
            dw3[0] = "3";
            dw3[1] = "展开一层计算";
            dt.Rows.Add(dw3);
            DataRow dw = dt.NewRow();
            dw[0] = "0";
            dw[1] = "按页面调整计算";
            dt.Rows.Add(dw);
            DataRow dw1 = dt.NewRow();
            dw1[0] = "1";
            dw1[1] = "上传数据完整计算";
            dt.Rows.Add(dw1);
            DataRow dw2 = dt.NewRow();
            dw2[0] = "2";
            dw2[1] = "上传数据余量计算";
            dt.Rows.Add(dw2);
            

            object result = Bll.ToObject(dt);

            return Json(result);
        }

        /// <summary>
        /// 加载查询属性
        /// </summary>
        /// <returns></returns>
        public ActionResult GetReorderpolicy()
        {
            PublicBusiness Bll = new PublicBusiness();
            DataTable dt = new DataTable();
            dt.Columns.Add("iID");
            dt.Columns.Add("iText");
            DataRow dw3 = dt.NewRow();
            dw3[0] = "";
            dw3[1] = "全部";
            dt.Rows.Add(dw3);
            DataRow dw = dt.NewRow();
            dw[0] = "MPS";
            dw[1] = "MPS";
            dt.Rows.Add(dw);
            DataRow dw1 = dt.NewRow();
            dw1[0] = "MRP";
            dw1[1] = "MRP";
            dt.Rows.Add(dw1);

            object result = Bll.ToObject(dt);

            return Json(result);
        }

        #region 上传和下载
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="funName"></param>
        /// <returns></returns>
        public ActionResult ImportData()
        {
            try
            {
                int iUpload_Type = int.Parse(Request.Params["iUpload_Type"]);
                string sTKVersion_Contrast = Request.Params["sTKVersion_Contrast"];
                string sTKVersion_Old = Request.Params["sTKVersion"];
                int iTK_Type = int.Parse(Request.Params["iTK_Type"]);
                string uploadtype = Request.Params["uploadtype"];
                string remark = Request.Params["remark"];

                string sErr = "";
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                
                if (files != null && files.Count > 0 && files[0].ContentLength > 0 && !string.IsNullOrEmpty(files[0].FileName))
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + @"Upload\temp\";
                    DirectoryInfo dir = new DirectoryInfo(path);
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    string filename = Path.GetFileName(files[0].FileName);
                    if (!string.IsNullOrEmpty(filename))
                    {

                        var keyValue = Guid.NewGuid().ToString();
                        string FileEextension = Path.GetExtension(files[0].FileName);
                        filename = keyValue + FileEextension;
                        string Fullfilename = Path.Combine(path, filename);
                        files[0].SaveAs(Fullfilename); //保存服务器

                        //保存数据库
                        NPOIHelper npoi = new NPOIHelper();
                        DataTable dt = npoi.Import(Fullfilename, "ImportDemand");
                        ArrayList aList = new ArrayList();

                        if (uploadtype == "0")
                        {
                            #region 上传计算模板
                            TK_Trialkit_Trial_UploadBusiness Bll = new TK_Trialkit_Trial_UploadBusiness();
                            string sTKVersion = Bll.GetNewVersion(CurrentUser.LoginId);
                            string sDataVersion = Bll.GetMaxVersion();
                            TK_PeriodBusiness Bllp = new TK_PeriodBusiness();
                            DataTable dtp = Bllp.GetList(sTKVersion);
                            if (dtp.Rows.Count == 0)
                            {
                                return Json(new { Msg = "保存失败，工作日历未设置", Result = "-1" }, JsonRequestBehavior.AllowGet);
                            }

                            for (int i = 1; i < dt.Rows.Count; i++)
                            {
                                string Partid = "";
                                if (dt.Rows[i]["制造件编码"] == null || dt.Rows[i]["制造件编码"].ToString() == "")
                                {
                                    sErr = sErr + "行" + (i + 1) + "制造件编码不可为空。\n";
                                }
                                else
                                {
                                    Partid = dt.Rows[i]["制造件编码"].ToString();
                                }
                                for (int j = 1; j < dt.Columns.Count; j++)
                                {
                                    string colName = dt.Columns[j].ColumnName;
                                    if (colName.IndexOf("Week") >= 0 || colName.IndexOf("Month") >= 0)
                                    {
                                        decimal quantity = 0;
                                        if (dt.Rows[i][colName] == null || dt.Rows[i][colName].ToString() == "")
                                        {
                                            sErr = sErr + "行" + (i + 1) + "数量不可为空。\n";
                                        }
                                        else
                                        {
                                            quantity = decimal.Parse(dt.Rows[i][colName].ToString());
                                        }
                                        if (quantity != 0)
                                        {
                                            DateTime commitdate = DateTime.Parse(dt.Rows[0][j].ToString());

                                            TK_Trialkit_Trial_UploadEntity model = new TK_Trialkit_Trial_UploadEntity();
                                            model.sDataVersion = sDataVersion;
                                            model.sTKVersion = sTKVersion;
                                            model.Partid = Partid;
                                            model.dDate = commitdate;
                                            model.dtmPeriod = commitdate;
                                            model.Qty = quantity;

                                            model.iUpload_Type = iUpload_Type;
                                            model.sTKVersion_Contrast = sTKVersion_Contrast;
                                            model.iTK_Type = iTK_Type;
                                            model.Remark = remark;

                                            model.dtmCreate = DateTime.Now;
                                            model.CreateUid = CurrentUser.LoginId;

                                            // 业务数据验证
                                            if (model == null) sErr = sErr + "行" + (i + 1) + "对象为空。\n";

                                            aList.Add(Bll.Update(model));
                                        }
                                    }
                                }
                            }

                            TK_NetRequirementBusiness blln = new TK_NetRequirementBusiness();
                            string sVerData = blln.GetNewVersion();

                            TK_ListEntity model_l = new TK_ListEntity();
                            model_l.sType = "Trialkitting";
                            model_l.dDate = DateTime.Now;
                            model_l.sVerData = sVerData;
                            model_l.sVerTrialkitting = sTKVersion;
                            model_l.ProdGroup = "";
                            model_l.Planner = "";
                            model_l.iState = 0;
                            model_l.Remark = remark;

                            model_l.CreateUid = CurrentUser.LoginId;
                            model_l.dtmCreate = DateTime.Now;

                            TK_ListBusiness Bll_l = new TK_ListBusiness();
                            aList.Add(Bll_l.Update(model_l));

                            bool updateResult = Bll.Update(aList);
                            if (!updateResult)
                                return Json(new { Msg = "保存失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
                            #endregion
                        }
                        else
                        {
                            #region 上传临时不计算物料
                            TK_Trialkit_PartTempBusiness Bll = new TK_Trialkit_PartTempBusiness();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string Partid = dt.Rows[i]["Partid"].ToString();
                                if (dt.Rows[i]["Partid"] == null || dt.Rows[i]["Partid"].ToString() == "")
                                {
                                    sErr = sErr + "行" + (i + 1) + "制造件编码不可为空。\n";
                                }
                                else
                                {
                                    Partid = dt.Rows[i]["Partid"].ToString();
                                }

                                TK_Trialkit_PartTempEntity model = new TK_Trialkit_PartTempEntity();

                                model.sTKVersion = sTKVersion_Old;
                                model.sPartID = Partid;

                                model.dtmCreate = DateTime.Now;
                                model.CreaterUid = CurrentUser.LoginId;
                                // 业务数据验证
                                if (model == null) sErr = sErr + "行" + (i + 1) + "对象为空。\n";

                                aList.Add(Bll.Update(model));
                            }

                            bool updateResult = Bll.Update(aList);
                            if (!updateResult)
                                return Json(new { Msg = "保存数据失败", Result = "-1" }, JsonRequestBehavior.AllowGet);

                            #endregion
                        }

                        //用完即删
                        if (System.IO.File.Exists(Fullfilename))
                        {
                            //如果存在则删除
                            System.IO.File.Delete(Fullfilename);
                        }

                        //return new ReponseModel { status = true, msg = result.Msg };
                        return Json(new { Msg = "保存成功", Result = "1" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { Msg = "保存失败," + "没有发现您上传的文件名", Result = "-1" }, JsonRequestBehavior.AllowGet);
                        //return Error("没有发现您上传的文件名,可能是浏览器兼容问题,请您换个浏览器试试! 详情: files[0].FileName  filename为null");
                    }

                }
                else
                {
                    return HttpNotFound("没有发现您要上传的文件!");
                }

            }
            catch (Exception ex)
            {
                return Json(new { Msg = "保存失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
                //return Error("导入excel到报价中出现了异常 详情:" + ex.Message);
            }
            return Json(new { Msg = "保存失败", Result = "-1" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ActionResult Download()
        {
            int uploadtype = int.Parse(Request.Params["uploadtype"]);

            string fileName = "";
            string outputFileName = "";
            if (uploadtype == 0)
            {
                fileName = AppDomain.CurrentDomain.BaseDirectory + @"Upload\model\上传计算模板.xlsx";
                outputFileName = "上传计划模板.xlsx";
            }
            else if (uploadtype == 1)
            {
                fileName = AppDomain.CurrentDomain.BaseDirectory + @"Upload\model\上传临时不计算物料.xlsx";
                outputFileName = "上传临时不计算物料.xlsx";
            }

            if (System.IO.File.Exists(fileName)==false)
            {
                return Json(new { Msg = "下载失败，文件不存在", Result = "-1" }, JsonRequestBehavior.AllowGet);
            }

            Encoding encoding;

            string browser = Request.UserAgent.ToUpper();
            if (browser.Contains("MS") == true && browser.Contains("IE") == true)
            {
                encoding = Encoding.Default;
            }
            else if (browser.Contains("FIREFOX") == true)
            {
                encoding = Encoding.GetEncoding("GB2312");
            }
            else
            {
                encoding = Encoding.Default;
            }
            FileStream fs = new FileStream(fileName, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.Charset = "UTF-8";
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = encoding;
            Response.AddHeader("Content-Disposition", "attachment; filename=" + outputFileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            return new EmptyResult();
        }

        /// <summary>
        /// 导出PAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ActionResult DownloadPAD()
        {
            string qyVersion = Request["qyVersion"];
            string qyPlanner = Request["qyPlanner"];
            string qyGroup = Request["qyGroup"];
            string qyReorderpolicy = Request["qyReorderpolicy"];
            bool isNetQty = bool.Parse(Request["isNetQty"]);

            if (qyVersion != "")
            {
                NPOIHelper npoi = new NPOIHelper();
                npoi.ExportByWebPAD(qyVersion, qyPlanner, qyGroup, qyReorderpolicy, "Sheet1", "PAD-" + qyVersion + ".xlsx", isNetQty);

            }

            return Json(new { Msg = "下载成功", Result = "1" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ActionResult DownloadExcel()
        {
            SearchAdminDomain param = new SearchAdminDomain();
            UpdateModel<SearchAdminDomain>(param);

            string qyVersion = Request["qyVersion"];
            string qyPlanner = Request["qyPlanner"];
            string qyGroup = Request["qyGroup"];
            string qyReorderpolicy = Request["qyReorderpolicy"];

            int total = 0;

            if (qyVersion != "")
            {
                TK_TrialkittingsBusiness Bll = new TK_TrialkittingsBusiness();
                DataTable result = Bll.GetList(qyVersion, qyPlanner, qyGroup,"", qyReorderpolicy, param, out total, false,true);

                TK_PeriodBusiness Bllp = new TK_PeriodBusiness();
                DataTable dtp = Bllp.GetList(qyVersion);

                NPOIHelper npoi = new NPOIHelper();
                npoi.ExportByWeb(result, dtp, "Sheet1", "计算-" + qyVersion + ".xlsx");

            }

            return Json(new { Msg = "下载成功", Result = "1" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
