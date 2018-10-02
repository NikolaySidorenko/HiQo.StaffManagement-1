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
            var logEvent = CreateLogEvent(actionContext);
            _logger.Log(logEvent);
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

        private LogEventInfo CreateLogEvent(HttpActionContext actionContext)
        {

            var logEvent = new LogEventInfo(LogLevel.Info, "", "WebApi Info");
            logEvent.Properties["Parameters"] = GetParameters(actionContext.ActionArguments);
            logEvent.Properties["LogId"] = RequestIdProvider.GetRequestId();
            logEvent.Properties["Url"] = actionContext.Request.RequestUri;
            logEvent.Properties["Time"] = DateTime.UtcNow;
            return logEvent;
        }
    }
}