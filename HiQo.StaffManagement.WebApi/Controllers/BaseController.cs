using System.Web.Http;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    public class BaseController : ApiController 
    {
        private readonly IServiceFactory _serviceFactory;

        public BaseController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
    }
}
