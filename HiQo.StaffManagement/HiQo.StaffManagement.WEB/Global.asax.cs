using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HiQo.StaffManagement.Configuration.DependencyResolver;
using HiQo.StaffManagement.Configuration.Profiles;
using NLog;

namespace HiQo.StaffManagement.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Logger logger = LogManager.GetLogger(nameof(MvcApplication));

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes, Assembly.GetExecutingAssembly().GetName().Name);
            BundleConfigJs.RegisterBundles(BundleTable.Bundles);
            BundleConfigCss.RegisterBundles(BundleTable.Bundles);
            MapperConfig.ConfigureAutomapper();
            IocContainer.Setup(Assembly.GetExecutingAssembly().GetName().Name);
        }

        protected void Application_BeginRequest(object sender, EventArgs a)
        {
            var message = HttpContext.Current.Request.Headers["User-Agent"];
            var mes = HttpContext.Current.Request.UrlReferrer;
            logger.Info(mes);
        }
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var exception = Server.GetLastError();

        //    var errorHandler = DependencyResolver.Current.GetService<ApplicationErrorHandler>();

        //    errorHandler.Handle(Request, Response, exception);
        //}
    }
}