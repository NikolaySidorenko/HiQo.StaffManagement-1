using System.Web.Mvc;
using System.Web.Routing;

namespace HiQo.StaffManagement.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes, string assemblyName)
        {
            routes.MapMvcAttributeRoutes();
            routes.LowercaseUrls = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GoogleApi",
                url: "Account/ExternalLoginCallback",
                namespaces: new[] {assemblyName+".Controllers"},
                defaults: new { controller = "Account", action = "ExternalLoginCallbackRedirect"});


            routes.MapRoute(
                name:"Default",
                url:"{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces: new[] {assemblyName +".Controllers"}
            );
        }
    }
}