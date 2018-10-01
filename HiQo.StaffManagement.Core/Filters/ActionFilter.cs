using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.Settings;
using Newtonsoft.Json;
using NLog;

namespace HiQo.StaffManagement.Core.Filters
{
    public class ActionFilter : ActionFilterAttribute
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public IRequestIdProvider RequestIdProvider { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            RequestIdProvider.GetRequestId();
            var theEvent = new LogEventInfo(LogLevel.Info, "", "WebApi Info");
            var parameters = GetParameters(actionContext.ActionArguments);
            theEvent.Properties["Parameters"] = parameters;
            theEvent.Properties["LogId"] = RequestIdProvider.GetRequestId();
            theEvent.Properties["Url"] = actionContext.Request.RequestUri;
            theEvent.Properties["Time"] = DateTime.UtcNow;
            _logger.Log(theEvent);
        }

        private string GetParameters(Dictionary<string, object> actionArguments)
        {
            var parameters = string.Empty;
            var enumerator = actionArguments.GetEnumerator();
            for (var i = 0; i < actionArguments.Count; i++)
            {
                enumerator.MoveNext();
                parameters += "|-|-|-|" + enumerator.Current.Key + "::" +
                              JsonConvert.SerializeObject(enumerator.Current.Value);
            }

            return parameters;
        }
    }
}