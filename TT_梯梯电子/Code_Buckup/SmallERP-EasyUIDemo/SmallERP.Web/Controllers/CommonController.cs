using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallERP.Domain;
using SmallERP.Business;
using SmallERP.Common;
using System.Text;
using System.IO;
using SmallERP.Entity;
using System.Data;
using SmallERP.DBUtility;

namespace SmallERP.Web.Controllers
{
    public class CommonController : BaseController
    {
        public AdminBusiness adminBusiness = new AdminBusiness();
        public t_common_attachmentBusiness attachmentBusiness = new t_common_attachmentBusiness();

        /// <summary>
        /// Admin下拉框数据获取
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAdminForComboBox()
        {
            string sqlWhere = string.Empty;
            string userID = Request["q"];
            string department = Request["department"];
            if (!string.IsNullOrEmpty(userID))
            {
                sqlWhere += " UserID LIKE '%" + userID + "%' ";
            }
            if (!string.IsNullOrEmpty(department))
            {
                sqlWhere += " Department='" + department + "' ";
            }
            List<AdminEntity> list = adminBusiness.GetTopModelList(50, sqlWhere, " UserID ASC ");
            return Json(list);
        }

        /// <summary>
        /// 根据UserID获取Admin信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAdminByUserID()
        {
            MyJsonResult result = new SuccessJsonResult();
            string userID = Request["userID"];
            AdminEntity adminEntity = adminBusiness.GetModelByUserID(userID);
            if (adminEntity != null)
            {
                result = new SuccessJsonResult(adminEntity);
            }
            else
            {
                result = new FailureJsonResult("User information does not exist.");
            }
            return Json(result);
        }


        public ActionResult LazyGetUserList()
        {
            string departid = Request.QueryString["deptid"];
            string filter = Request["q"];
            List<UserDomain> list = new List<UserDomain>();
            AdminBusiness adm = new AdminBusiness();
            list = adm.GetUserbyDept(departid);
            if (filter != null)
                list = list.Where(i => i.UserID.Contains(filter)).ToList();
            return Json(list);
        }
        public ActionResult LazyGetUserListAll()
        {
            string filter = Request["q"];
            List<AdminEntity> list = new List<AdminEntity>();
            AdminBusiness adm = new AdminBusiness();
            list = adm.GetUserListAll();
            if (filter != null)
                list = list.Where(i => i.UserID.Contains(filter)).ToList();
            return Json(list);
        }

        #region Attachment  Created by Jacky 2017-12-13 17:20:04

        public class AttachmentManageEntity
        {
            /// <summary>
            /// 当前用户ID
            /// </summary>
            public string CurrentUserID { get; set; }

            /// <summary>
            /// SourceID
            /// </summary>
            public string SourceID { get; set; }

            /// <summary>
            /// SourceItem
            /// </summary>
            public string SourceItem { get; set; }

            /// <summary>
            /// Value1
            /// </summary>
            public string Value1 { get; set; }

            /// <summary>
            /// 回调函数
            /// </summary>
            public string CallBack { get; set; }
        }


        /// <summary>
        /// Common Attachment Manage
        /// 创建人：蒋俊
        /// 创建时间：2017-11-28 17:06:29
        /// </summary>
        /// <returns></returns>
        public ActionResult AttachmentManage()
        {
            AttachmentManageEntity attachmentManageEntity = new AttachmentManageEntity();
            attachmentManageEntity.CurrentUserID = CurrentUser.LoginId;
            attachmentManageEntity.SourceID = Request.QueryString["sourceID"];
            attachmentManageEntity.SourceItem = Request.QueryString["sourceItem"];
            attachmentManageEntity.Value1 = Request.QueryString["value1"];
            attachmentManageEntity.CallBack = Request.QueryString["callBack"];
            return View(attachmentManageEntity);
        }

        /// <summary>
        /// 获取Attachment列表
        /// 创建人：Jacky
        /// 创建时间：2017-12-14 09:30:00
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAttachmentList()
        {
            PagingDomain param = new PagingDomain();
            UpdateModel<PagingDomain>(param);
            string sourceID = Request["sourceID"];
            string sourceItem = Request["sourceItem"];
            string value1 = Request["value1"];
            string sqlWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(sourceID))
            {
                sqlWhere += " and source_id='" + sourceID + "' ";
            }
            if (!string.IsNullOrEmpty(sourceItem))
            {
                sqlWhere += " and source_item='" + sourceItem + "' ";
            }
            if (!string.IsNullOrEmpty(value1))
            {
                sqlWhere += " and value1='" + value1 + "' ";
            }
            int total = 0;
            List<t_common_attachmentEntity> list = attachmentBusiness.GetAttachmentListByPage(sqlWhere, " createddate DESC ", param.RowStart(), param.RowEnd());
            total = attachmentBusiness.GetRecordCount(sqlWhere);
            SuccessJsonResult obj = new SuccessJsonResult(list, total);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddAttachment()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string sourceID = Request["sourceID"];
                string sourceItem = Request["sourceItem"];
                string value1 = Request["value1"];

                int len = Request.Files.Count;
                if (len == 0) throw new Exception("Please select the files you need to upload.");

                List<UploadFileInfo> filesInfo = FilesUpload(Request.Files);

                if (filesInfo != null && filesInfo.Count > 0)
                {
                    //t_common_attachment表插入数据
                    t_common_attachmentEntity attachmentEntity = new t_common_attachmentEntity();
                    attachmentEntity.id = Guid.NewGuid().ToString();
                    attachmentEntity.source_id = sourceID;
                    attachmentEntity.source_item = sourceItem;
                    attachmentEntity.original_name = filesInfo[0].OriginalName;
                    attachmentEntity.path = filesInfo[0].SavePath;
                    attachmentEntity.value1 = value1;
                    attachmentEntity.createdby = CurrentUser.LoginId;
                    attachmentEntity.createddate = DateTime.Now;
                    attachmentBusiness.Add(attachmentEntity);
                }

                result = new SuccessJsonResult(filesInfo);
            }
            catch (Exception ex)
            {
                result = new FailureJsonResult(ex.Message);
            }
            return Json(result);
        }

        /// <summary>
        /// 删除Attachment信息
        /// 创建人：Jacky
        /// 创建时间：2017-12-14 09:42:13
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteAttachment()
        {
            MyJsonResult result = new SuccessJsonResult();
            try
            {
                string ids = Request["ids"].ToString();
                if (!string.IsNullOrEmpty(ids))
                {
                    List<CommandInfo> commandInfoList = new List<CommandInfo>();
                    List<string> idList = ids.Split(',').ToList();
                    int attachmentCount = idList.Count;
                    idList.ForEach(delegate(string id)
                    {
                        commandInfoList.Add(attachmentBusiness.TranDelete(id)); //删除ECN Attachment事务
                    });
                    int exeRows = DbHelperSQL.ExecuteSqlTran(commandInfoList);
                    if (exeRows <= 0)
                    {
                        result = new FailureJsonResult("Delete attachment failed.");
                    }
                    else
                    {
                        result = new SuccessJsonResult("Delete successfully, delete " + attachmentCount + " attachment information.");
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

        #endregion

        #region View Attachment  Created by Jacky 2018-04-26 10:15:13

        /// <summary>
        /// View Attachment
        /// 创建人：蒋俊
        /// 创建时间：2018-04-26 10:25:55
        /// </summary>
        /// <returns></returns>
        public ActionResult AttachmentView()
        {
            AttachmentViewEntity attachmentViewEntity = new AttachmentViewEntity();
            attachmentViewEntity.CurrentUserID = CurrentUser.LoginId;
            attachmentViewEntity.FileName = Request.QueryString["fileName"];
            attachmentViewEntity.FilePath = Request.QueryString["filePath"];
            string ext = Request.QueryString["filePath"].Substring(Request.QueryString["filePath"].LastIndexOf('.') + 1);
            attachmentViewEntity.ExtensionName = ext;
            return View(attachmentViewEntity);
        }

        public class AttachmentViewEntity
        {
            /// <summary>
            /// 当前用户ID
            /// </summary>
            public string CurrentUserID { get; set; }

            /// <summary>
            /// 文件名
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// 文件路径
            /// </summary>
            public string FilePath { get; set; }

            /// <summary>
            /// 文件扩展名
            /// </summary>
            public string ExtensionName { get; set; }

        }


        #endregion
    }
}
