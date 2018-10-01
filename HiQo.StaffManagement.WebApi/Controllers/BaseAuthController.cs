using FluentValidation;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.Core.Filters;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [JwtAuthenticate]
    public class BaseAuthController : BaseController
    {
        public BaseAuthController(IServiceFactory serviceFactory, IValidatorFactory validatorFactory) 
            : base(serviceFactory, validatorFactory)
        {
        }
    }
}
