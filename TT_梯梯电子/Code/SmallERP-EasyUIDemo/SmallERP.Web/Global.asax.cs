using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmallERP.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new TTViewEngine());
        }
    }

    //public class TTViewEngine : RazorViewEngine
    //{
    //    public TTViewEngine()
    //    {
    //        ViewLocationFormats = new[]
    //        {
    //            "~/Views/{1}/{0}.cshtml",
    //            "~/Views/Shared/{0}.cshtml",
    //            "~/Views/Admin/{1}/{0}.cshtml"//后台View存放目录的规则
    //        };
    //    }
    //    public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
    //    {
    //        return base.FindView(controllerContext, viewName, masterName, useCache);
    //    }
    //}
}