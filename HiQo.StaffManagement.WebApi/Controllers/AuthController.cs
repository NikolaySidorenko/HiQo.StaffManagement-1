using System;
using System.Threading.Tasks;
using System.Web.Http;
using FluentValidation;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IValidatorFactory _validatorFactory;

        public AuthController(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        //[Route("login")]
        //[HttpPost]
        //public async Task<> Login(LoginViewModel user)
        //{
        //    var validator = _validatorFactory.GetValidator<LoginViewModel>();
        //    var result = validator.Validate(user);

        //    if (result.IsValid)
        //    {
        //        try
        //        {

        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //    }
        //    return await
        //}

    }
}
