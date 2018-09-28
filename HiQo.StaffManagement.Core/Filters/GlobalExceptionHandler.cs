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
            var theEvent = new LogEventInfo(LogLevel.Error, "", "Error");
            theEvent.Properties["Message"] = actionExecutedContext.Exception.Message;
            theEvent.Properties["LogId"] = Provider.GetRequestId();
            theEvent.Properties["Url"] = actionExecutedContext.Request.RequestUri.ToString();
            theEvent.Properties["ExceptionClass"] = actionExecutedContext.Exception.TargetSite.DeclaringType.FullName;
            theEvent.Properties["Time"] = DateTime.UtcNow;
            _logger.Log(theEvent);
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
    }
}