using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallERP.Business;
using SmallERP.Common;
using SmallERP.DBUtility;
using SmallERP.Domain;
using SmallERP.Entity;

namespace SmallERP.Web.Controllers
{
    public class BusinessParmsController : BaseController
    {

        public t_business_parmsBusiness businessParmsBusiness = new t_business_parmsBusiness();

        //
        // GET: /BusinessParms/

        public ActionResult Index()
        {
            return View();
        }

        public class CurrentUserEntity
        {
            /// <summary>
            /// 当前用户ID
            /// </summary>
            public string CurrentUserID { get; set; }
        }

        /// <summary>
        /// BusinessParms管理
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 14:57:55
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessParmsManage()
        {
            BusinessParmsManageEntity businessParmsManageEntity = new BusinessParmsManageEntity();
            businessParmsManageEntity.CurrentUserID = CurrentUser.LoginId;
            businessParmsManageEntity.Module = Request.QueryString["module"];
            return View(businessParmsManageEntity);
        }

        public class BusinessParmsManageEntity
        {
            /// <summary>
            /// 当前用户ID
            /// </summary>
            public string CurrentUserID { get; set; }

            /// <summary>
            /// 模块（用于部分参数供不同模块管理自己维护）
            /// </summary>
            public string Module { get; set; }
        }

        /// <summary>
        /// Category下拉框数据获取
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCategoryForComboBox()
        {
            string sqlWhere = string.Empty;
            string category = Request["q"];
            List<string> list = businessParmsBusiness.GetCategoryList(category);
            var linq = from i in list
                       select new
                       {
                           category = i
                       };
            return Json(linq.ToList());
        }

        /// <summary>
        /// Item下拉框数据获取
        /// </summary>
        /// <returns></returns>
        public ActionResult GetItemForComboBox()
        {
            string sqlWhere = string.Empty;
            string category = Request["category"];
            string item = Request["q"];
            sqlWhere += " category='" + category + "' ";
            if (!string.IsNullOrEmpty(item))
            {
                sqlWhere += " and item LIKE '%" + item + "%' ";
            }
            List<t_business_parmsEntity> list = businessParmsBusiness.GetTopModelList(50, sqlWhere, " item ASC ");
            return Json(list);
        }

        /// <summary>
        /// 获取Business Parms列表
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 15:15:22
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBusinessParmsList()
        {
            PagingDomain param = new PagingDomain();
            UpdateModel<PagingDomain>(param);
            string module = Request["module"];
            string category = Request["category"];
            string item = Request["item"];
            string sqlWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(module))
            {
                sqlWhere += " and module='" + module + "' ";
            }
            if (!string.IsNullOrEmpty(category))
            {
                sqlWhere += " and category LIKE '%" + category + "%' ";
            }
            if (!string.IsNullOrEmpty(item))
            {
                sqlWhere += " and item LIKE '%" + item + "%' ";
            }
            int total = 0;
            List<t_business_parmsEntity> list = businessParmsBusiness.GetBusinessParmsListByPage(sqlWhere, " " + param.sort + " " + param.order + " ", param.RowStart(), param.RowEnd());
            total = businessParmsBusiness.GetRecordCount(sqlWhere);
            SuccessJsonResult obj = new SuccessJsonResult(list, total);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增Business Parms信息
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 15:20:52
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBusinessParms()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                bool err = false;
                if (string.IsNullOrEmpty(Request["category"]))
                {
                    err = true;
                    result = new FailureJsonResult("Category must not be null.");
                }
                if (string.IsNullOrEmpty(Request["item"]))
                {
                    err = true;
                    result = new FailureJsonResult("Item must not be null.");
                }
                if (!err)
                {
                    t_business_parmsEntity businessParmsEntity = new t_business_parmsEntity();
                    businessParmsEntity.category = Request["category"].ToString();
                    businessParmsEntity.item = Request["item"].ToString();
                    businessParmsEntity.defaultval = Request["defaultval"].ToString();
                    businessParmsEntity.value1 = Request["value1"].ToString();
                    businessParmsEntity.value2 = Request["value2"].ToString();
                    businessParmsEntity.value3 = Request["value3"].ToString();
                    businessParmsEntity.module = Request["module"].ToString();
                    businessParmsEntity.createddate = DateTime.Now;
                    businessParmsEntity.createdby = CurrentUser.LoginId;
                    businessParmsEntity.modifieddate = DateTime.Now;
                    businessParmsEntity.modifiedby = CurrentUser.LoginId;
                    bool addresult = businessParmsBusiness.Add(businessParmsEntity);
                    if (!addresult)
                    {
                        result = new FailureJsonResult("Add business parms failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
                LogHelper.WriteLog(LogEnum.Error, ex.Message);
            }
            return Json(result, "text/html");
        }

        /// <summary>
        /// 修改Business Parms信息
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 15:23:58
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateBusinessParms()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                bool err = false;
                if (string.IsNullOrEmpty(Request["category"]))
                {
                    err = true;
                    result = new FailureJsonResult("Category must not be null.");
                }
                if (string.IsNullOrEmpty(Request["item"]))
                {
                    err = true;
                    result = new FailureJsonResult("Item must not be null.");
                }
                if (!err)
                {
                    string id = Request["ID"].ToString();
                    t_business_parmsEntity businessParmsEntity = businessParmsBusiness.GetModel(Convert.ToInt32(id));
                    if (businessParmsEntity != null)
                    {
                        businessParmsEntity.category = Request["category"].ToString();
                        businessParmsEntity.item = Request["item"].ToString();
                        businessParmsEntity.defaultval = Request["defaultval"].ToString();
                        businessParmsEntity.value1 = Request["value1"].ToString();
                        businessParmsEntity.value2 = Request["value2"].ToString();
                        businessParmsEntity.value3 = Request["value3"].ToString();
                        businessParmsEntity.module = Request["module"].ToString();
                        businessParmsEntity.modifieddate = DateTime.Now;
                        businessParmsEntity.modifiedby = CurrentUser.LoginId;
                        bool updateresult = businessParmsBusiness.Update(businessParmsEntity);
                        if (!updateresult)
                        {
                            result = new FailureJsonResult("Update business parms failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
                LogHelper.WriteLog(LogEnum.Error, ex.Message);
            }
            return Json(result, "text/html");
        }

        /// <summary>
        /// 删除Business Parms信息
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 15:24:16
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteBusinessParms()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string id = Request["id"].ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    bool delresult = businessParmsBusiness.Delete(Convert.ToInt32(id));
                    if (!delresult)
                    {
                        result = new FailureJsonResult("Delete business parms failed.");
                    }
                    else
                    {
                        result = new SuccessJsonResult("Delete successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
                LogHelper.WriteLog(LogEnum.Error, ex.Message);
            }
            return Json(result, "text/html");
        }

        /// <summary>
        /// BusinessParmsItems下拉框数据获取
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBusinessParmsItemsForComboBox()
        {
            string category = Request["category"];
            string isShowAll = Request["isShowAll"];    //是否显示ALL选项
            string isShowBlank = Request["isShowBlank"];    //是否显示please select选项
            string isShowNA = Request["isShowNA"];    //是否显示NA选项
            var list = businessParmsBusiness.GetModelList(" category='" + category + "' ORDER BY item ASC ");
            if (!string.IsNullOrEmpty(isShowAll) && isShowAll == "1")
            {
                t_business_parmsEntity businessParmsEntity = new t_business_parmsEntity();
                businessParmsEntity.id = 0;
                businessParmsEntity.item = "ALL";
                list.Insert(0, businessParmsEntity);
            }
            if (!string.IsNullOrEmpty(isShowBlank) && isShowBlank == "1")
            {
                t_business_parmsEntity businessParmsEntity = new t_business_parmsEntity();
                businessParmsEntity.id = 0;
                businessParmsEntity.item = "Please select";
                list.Insert(0, businessParmsEntity);
            }
            if (!string.IsNullOrEmpty(isShowNA) && isShowNA == "1")
            {
                t_business_parmsEntity businessParmsEntity = new t_business_parmsEntity();
                businessParmsEntity.id = 0;
                businessParmsEntity.item = "NA";
                list.Insert(0, businessParmsEntity);
            }
            var query = from i in list
                        select new
                        {
                            Id = i.id,
                            Name = i.item
                        };
            return Json(query);
        }

        /// <summary>
        /// BusinessParmsItems下拉框数据获取(Value和Text都显示Item)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBusinessParmsDoubleItemsForComboBox()
        {
            string category = Request["category"];
            string isShowAll = Request["isShowAll"];    //是否显示ALL选项
            string isShowBlank = Request["isShowBlank"];    //是否显示please select选项
            var list = businessParmsBusiness.GetModelList(" category='" + category + "' ORDER BY item ASC ");
            if (!string.IsNullOrEmpty(isShowAll) && isShowAll == "1")
            {
                t_business_parmsEntity businessParmsEntity = new t_business_parmsEntity();
                businessParmsEntity.id = 0;
                businessParmsEntity.item = "ALL";
                list.Insert(0, businessParmsEntity);
            }
            if (!string.IsNullOrEmpty(isShowBlank) && isShowBlank == "1")
            {
                t_business_parmsEntity businessParmsEntity = new t_business_parmsEntity();
                businessParmsEntity.id = 0;
                businessParmsEntity.item = "Please select";
                list.Insert(0, businessParmsEntity);
            }
            var query = from i in list
                        select new
                        {
                            Id = i.item,
                            Name = i.item
                        };
            return Json(query);
        }

        /// <summary>
        /// BusinessParmsDefaultVal下拉框数据获取
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBusinessParmsDefaultValForComboBox()
        {
            string category = Request["category"];
            string isShowAll = Request["isShowAll"];    //是否显示ALL选项
            string isShowBlank = Request["isShowBlank"];    //是否显示please select选项
            var list = businessParmsBusiness.GetModelList(" category='" + category + "' ORDER BY item ASC ");
            if (!string.IsNullOrEmpty(isShowAll) && isShowAll == "1")
            {
                t_business_parmsEntity businessParmsEntity = new t_business_parmsEntity();
                businessParmsEntity.id = 0;
                businessParmsEntity.item = "ALL";
                list.Insert(0, businessParmsEntity);
            }
            if (!string.IsNullOrEmpty(isShowBlank) && isShowBlank == "1")
            {
                t_business_parmsEntity businessParmsEntity = new t_business_parmsEntity();
                businessParmsEntity.id = 0;
                businessParmsEntity.item = "Please select";
                list.Insert(0, businessParmsEntity);
            }
            var query = from i in list
                        select new
                        {
                            Id = i.id,
                            Name = i.item + " " + i.defaultval
                        };
            return Json(query);
        }
        //

    }
}
