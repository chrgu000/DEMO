using SmallERP.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SmallERP.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
            : base()
        {

        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    /*  StringBuilder errLog = new StringBuilder();
        //      base.OnException(filterContext);
        //      filterContext.ExceptionHandled = true;
        //      string content = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head>    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0; maximum-scale=1.0;\" /><meta http-equiv=\"Access-Control-Allow-Origin\" content=\"*\"><meta content=\"telephone=no\" name=\"format-detection\" />";
        //      content = (content + string.Format("<title>系统发生错误 TT  {0}{1}</title>", "4.0", "-2.0") +
        //          "<style>body{\tfont-family: 'Microsoft Yahei', Verdana, arial, sans-serif;\tfont-size:14px;width:100%;}a{text-decoration:none;color:#174B73;}a:hover{ text-decoration:none;color:#FF6600;}h2{\tborder-bottom:1px solid #DDD;\tpadding:8px 0;    font-size:25px;}.title{\tmargin:4px 0;\tcolor:#F60;\tfont-weight:bold;}.message,#trace{\tpadding:1em;\tborder:solid 1px #000;\tmargin:10px 0;\tbackground:#FFD;\tline-height:150%;}.message{\tbackground:#FFD;\tcolor:#2E2E2E;\t\tborder:1px solid #E0E0E0;}#trace{\tbackground:#E7F7FF;\tborder:1px solid #E0E0E0;\tcolor:#535353;\tword-wrap: break-word;}.notice{    padding:10px;\tmargin:5px;\tcolor:#666;\tbackground:#FCFCFC;\tborder:1px solid #E0E0E0;}.red{\tcolor:red;\tfont-weight:bold;}</style></head>") + "<body><div class=\"notice\"><h2>系统发生错误 </h2>" + "<div>您可以选择 [ <a href=\"javascript:location.reload();\" >重试</a> ] [ <a href=\"javascript:history.back()\">返回</a> ] 或者 [ <a target=\"_blank\" href=\"/\">进入首页</a> ]</div>";
        //      string Loginfo = string.Empty;
        //      string StackTrace = string.Empty;
        //      string Url = string.Empty;
        //      Exception e = filterContext.Exception;
        //      HttpContextBase httpContext = filterContext.HttpContext;
        //      httpContext.Response.Clear();
        //      StackTrace trace = new StackTrace(e, true);
        //      int fileLineNumber = trace.GetFrame(0).GetFileLineNumber();
        //      int fileColumnNumber = trace.GetFrame(0).GetFileColumnNumber();
        //      string fileName = trace.GetFrame(0).GetFileName();
        //      object obj2 = content;
        //      content = string.Concat(new object[] { obj2, "<p><strong>错误位置:</strong>　File: <span class=\"red\">", fileName, "</span>　Line: <span class=\"red\">", fileLineNumber, "</span> Column: <span class=\"red\">", fileColumnNumber, "</span></p>" }) + "<p class=\"title\">[ 错误信息 ]</p>";
        //      if (e is SqlException)
        //      {
        //          SqlException exception2 = (SqlException)e;
        //          if (exception2 != null)
        //          {
        //              string sqlExceptionMessage = exception2.Number.ToString();
        //              if (exception2.Number == 0x223)
        //              {
        //                  content = content + "<p class=\"message\">" + sqlExceptionMessage + "</p>";
        //              }
        //              else
        //              {
        //                  content = content + "<p class=\"message\">" + sqlExceptionMessage + "</p>";
        //                  Loginfo = sqlExceptionMessage;
        //                  StackTrace = e.ToString();
        //                  Url = httpContext.Request.Url.AbsoluteUri;
        //              }
        //          }
        //      }
        //      else
        //      {
        //          content = (((content + "<p class=\"message\">" + e.Message + "</p>") + "<p class=\"title\">[ StackTrace ]</p><p id=\"trace\">" + e.StackTrace + "</p></div>") + string.Format("<div align=\"center\" style=\"color:#FF3300;margin:5pt;font-family:Verdana\"> 一鸣 <sup style=\"color:gray;font-size:9pt\">{0}</sup>", "2.0")) + "<span style=\"color:silver\"> { Building &amp; OOP MVC 一鸣 Framework } -- [ WE CAN DO IT JUST HAPPY WORKING ]</span></div>" + "</body><style type=\"text/css\"></style></html>";

        //          Loginfo = e.Message;
        //          StackTrace = e.ToString();
        //          Url = httpContext.Request.Url.AbsoluteUri;

        //      }

        //      errLog.AppendFormat("\r\n Loginfo={0}\\r\n StackTrace={1} \r\n Url={2}", Loginfo, StackTrace, Url);
        //      if (!base.HttpContext.IsDebuggingEnabled && e.TargetSite.ToString().StartsWith("System.Web.Mvc.ViewEngineResult FindView"))
        //      {
        //          filterContext.Result = new HttpNotFoundResult();
        //          httpContext.Server.ClearError();
        //      }
        //      else
        //      {
        //          filterContext.Result = base.Content(content);
        //          httpContext.Server.ClearError();
        //      }
        //      LogHelper.WriteLog(LogEnum.Error, errLog);*/


        //    HttpContextBase httpContext = filterContext.HttpContext;
        //    httpContext.Response.Clear();
        //    string content = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head>    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0; maximum-scale=1.0;\" /><meta http-equiv=\"Access-Control-Allow-Origin\" content=\"*\"><meta content=\"telephone=no\" name=\"format-detection\" />";
        //    content += "<title>TT</title></head><body><div style=\"text-align:center;color:red;\"><p></p><img src=\"" + Utils.GetCurrentFullUrl() + "/Content/images/error_center.png\" /><p><a style=\"color:red;\" href=" + Utils.GetCurrentFullUrl() + ">稍后回来刷新看看吧</a></p></div></body></html>";
        //    filterContext.Result = base.Content(content);
        //    httpContext.Server.ClearError();
        //}

        protected virtual bool InitializeComponent(ActionExecutingContext filterContext)
        {
            return false;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        protected CurrentUserDomain CurrentUser
        {
            get
            {
                CurrentUserDomain result = null;
                FormsIdentity identity = ((FormsIdentity)User.Identity);
                if (identity == null)
                    return result;
                else
                {
                    if (!string.IsNullOrEmpty(identity.Ticket.Name))
                    {
                        result = new CurrentUserDomain();
                        result.LoginId = identity.Ticket.Name;
                        result.Name = identity.Ticket.UserData;

                    }
                    return result;
                }
            }
        }


        // 为了解决IE不能解析 ContentType为'application/json'的问题
        //protected new JsonResult Json(object data)
        //{
        //    string userAgent = base.Request.UserAgent.ToUpper();
        //    if (userAgent.Contains("MSIE") || userAgent.Contains("TRIDENT"))
        //        return base.Json(data, "text/plain; charset=UTF-8", Encoding.UTF8);
        //    else
        //        return base.Json(data);
        //}
        //protected new JsonResult Json(object data, JsonRequestBehavior behavior)
        //{
        //    string userAgent = base.Request.UserAgent.ToUpper();
        //    if (userAgent.Contains("MSIE") || userAgent.Contains("TRIDENT"))
        //        return base.Json(data, "text/plain; charset=UTF-8", Encoding.UTF8, behavior);
        //    else
        //        return base.Json(data, behavior);
        //}

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        protected List<UploadFileInfo> FilesUpload(HttpFileCollectionBase files)
        {
            int len = files.Count;
            if (len == 0) throw new Exception("Please select the files you need to upload.");

            DateTime dt = DateTime.Now;

            string basePath = Server.MapPath("~");
            string rootDir = "upload";
            string subDir = dt.ToString("yyyyMMdd");
            // 创建上传文件根目录
            DirectoryInfo dir = new DirectoryInfo(basePath + rootDir + "\\");
            if (!dir.Exists)
                dir.Create();
            // 创建以当前日期命名的子目录
            DirectoryInfo dir2 = new DirectoryInfo(dir.FullName + subDir + "\\");
            if (!dir2.Exists)
                dir2.Create();

            List<UploadFileInfo> filesInfo = new List<UploadFileInfo>();

            for (int i = 0; i < len; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                if (file.ContentLength == 0) throw new Exception("Please select the files you need to upload.");
                string fileName = file.FileName;

                string fName = "";
                string fExt = "";

                //if (fileName.Contains('.'))
                //{
                //    fName = fileName.Substring(0, fileName.LastIndexOf('.'));
                //    fExt = fileName.Substring(fileName.LastIndexOf('.') + 1);
                //}
                //else
                //{
                //    fName = fileName;
                //}

                if (fileName.Contains('.'))
                {
                    //C:\\Users\\Administrator\\Desktop\\TT项目\\s2.xlsx
                    fName = fileName.Substring(0, fileName.LastIndexOf('.'));
                    if (fName.IndexOf('\\') >= 0)
                    {
                        fName = fName.Substring(fName.LastIndexOf('\\') + 2);
                    }
                    fExt = fileName.Substring(fileName.LastIndexOf('.') + 1);
                }
                else
                {
                    fName = fileName;
                }

                // 文件新名称
                string fileReName = string.Format("{0}_{1}{2}", dt.ToString("HHmmssfff"), fName, fExt.Length == 0 ? "" : "." + fExt);

                // 文件上传
                file.SaveAs(dir2.FullName + fileReName);

                UploadFileInfo info = new UploadFileInfo();
                info.OriginalName = file.FileName;
                info.SavePath = subDir + "/" + fileReName;

                filesInfo.Add(info);
            }
            return filesInfo;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="files"></param>
        /// <param name="extensionName"></param>
        /// <returns></returns>
        protected List<UploadFileInfo> FilesUpload(HttpFileCollectionBase files, string[] extensionName)
        {
            int len = files.Count;
            if (len == 0) throw new Exception("Please select the files you need to upload.");

            DateTime dt = DateTime.Now;

            string basePath = Server.MapPath("~");
            string rootDir = "upload";
            string subDir = dt.ToString("yyyyMMdd");
            // 创建上传文件根目录
            DirectoryInfo dir = new DirectoryInfo(basePath + rootDir + "\\");
            if (!dir.Exists)
                dir.Create();
            // 创建以当前日期命名的子目录
            DirectoryInfo dir2 = new DirectoryInfo(dir.FullName + subDir + "\\");
            if (!dir2.Exists)
                dir2.Create();

            // 扩展名过滤
            for (int i = 0; i < len; i++)
            {
                string fn = Request.Files[i].FileName;
                string ext = fn.Substring(fn.LastIndexOf('.') + 1);
                if (!extensionName.Contains(ext.ToLower()))
                {
                    throw new Exception("file extension is not correct.");
                }
            }

            List<UploadFileInfo> filesInfo = new List<UploadFileInfo>();

            for (int i = 0; i < len; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                if (file.ContentLength == 0) throw new Exception("Please select the files you need to upload.");
                string fileName = file.FileName;

                string fName = "";
                string fExt = "";

                if (fileName.Contains('.'))
                {
                    //C:\\Users\\Administrator\\Desktop\\TT项目\\s2.xlsx
                    fName = fileName.Substring(0, fileName.LastIndexOf('.'));
                    if (fName.IndexOf('\\') >= 0)
                    {
                        fName = fName.Substring(fName.LastIndexOf('\\') + 2);
                    }
                    fExt = fileName.Substring(fileName.LastIndexOf('.') + 1);
                }
                else
                {
                    fName = fileName;
                }

                // 文件新名称
                string fileReName = string.Format("{0}_{1}{2}", dt.ToString("HHmmssfff"), fName, fExt.Length == 0 ? "" : "." + fExt);

                // 文件上传
                file.SaveAs(dir2.FullName + fileReName);

                UploadFileInfo info = new UploadFileInfo();
                info.OriginalName = file.FileName;
                info.SavePath = subDir + "/" + fileReName;

                filesInfo.Add(info);
            }
            return filesInfo;
        }



    }
}
