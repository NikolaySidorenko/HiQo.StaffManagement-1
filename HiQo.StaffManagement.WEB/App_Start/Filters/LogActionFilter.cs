using System.Web.Mvc;
using System.Web.Routing;
using NLog;

namespace HiQo.StaffManagement.WEB.App_Start.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private readonly Logger _logger = LogManager.GetLogger(nameof(LogActionFilter));

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }


        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var parameter = routeData.Values["id"];
            var message = $"{methodName} Controller:{controllerName} Action:{actionName} Parameter:{parameter}";

            _logger.Info(message);
        }
    }
}