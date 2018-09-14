using System.Threading.Tasks;
using System.Web.Http;
using FluentValidation;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IAuthService _authService;
        private readonly IValidatorFactory _validatorFactory;

        public AccountController(IAuthService authService, IValidatorFactory validatorFactory)
        {
            _authService = authService;
            _validatorFactory = validatorFactory;
        }

        [Route("login")]
        [HttpPost]
        public async Task<LoginViewModel> Login(LoginViewModel user)
        {


        }
       
    }
}
