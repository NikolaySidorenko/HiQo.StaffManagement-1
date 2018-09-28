using System.Web.Http;
using FluentValidation;
using FluentValidation.Results;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.Core.Filters;


namespace HiQo.StaffManagement.WebApi.Controllers
{
    [GlobalExceptionHandler]
    [ActionFilter]
    public class BaseController : ApiController 
    {
        protected readonly IServiceFactory ServiceFactory;
        protected readonly IValidatorFactory ValidatorFactory;

        public BaseController(IServiceFactory serviceFactory, IValidatorFactory validatorFactory)
        {
            ServiceFactory = serviceFactory;
            ValidatorFactory = validatorFactory;
        }

        protected void SetErrors(ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
