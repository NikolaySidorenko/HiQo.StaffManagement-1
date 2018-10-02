using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.Settings;
using NLog;

namespace HiQo.StaffManagement.Core.Filters
{
    public class GlobalExceptionHandler : ExceptionFilterAttribute
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public IRequestIdProvider Provider { get; set; }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            object [] foo = {Provider.GetRequestId(), "dawd"};
            var logEvent = CreateLogEvent(actionExecutedContext);
            _logger.Log(logEvent);
            //const string errorMessage = "An unexpected error occuredfffcfafqaefdae";
            //var response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError,
            //    new
            //    {
            //        Message = errorMessage,
            //        asfa= "adfafaewf"
            //    });
            //response.Headers.Add("X-Error", errorMessage);
            //actionExecutedContext.Request.CreateResponse(response);
            return Task.CompletedTask;
        }

        private LogEventInfo CreateLogEvent(HttpActionExecutedContext actionExecutedContext)
        {
            var logEvent = new LogEventInfo(LogLevel.Error, "", "Error");
            logEvent.Properties["Message"] = actionExecutedContext.Exception.Message;
            logEvent.Properties["LogId"] = Provider.GetRequestId();
            logEvent.Properties["Url"] = actionExecutedContext.Request.RequestUri.ToString();
            logEvent.Properties["ExceptionClass"] = actionExecutedContext.Exception.TargetSite.DeclaringType.FullName;
            logEvent.Properties["Time"] = DateTime.UtcNow;
            return logEvent;
        }
    }
}