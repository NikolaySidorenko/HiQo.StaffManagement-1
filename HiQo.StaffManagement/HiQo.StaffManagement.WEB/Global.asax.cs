using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HiQo.StaffManagement.Configuration.DependencyResolver;
using HiQo.StaffManagement.Configuration.Profiles;

namespace HiQo.StaffManagement.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
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
    }
}