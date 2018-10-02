using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using FluentValidation;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.Providers;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : BaseController
    {
        private readonly ICookieProvider _provider;

        public AuthController(IValidatorFactory validatorFactory, IServiceFactory serviceFactory,
            ICookieProvider provider)
            : base(serviceFactory, validatorFactory)
        {
            _provider = provider;
        }

        [Route("login")]
        [HttpPost]
        public async Task<HttpResponseMessage> Login([FromBody] LoginViewModel user)
        {
            var validator = ValidatorFactory.GetValidator<LoginViewModel>();
            var result = validator.Validate(user);

            if (!result.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var authService = ServiceFactory.Create<IAuthService>();
            var jwtAuthService = ServiceFactory.Create<IAuthorizationServiceJWT>();

            var isUserCredentialsValid = await authService.LoginUserAsync(Mapper.Map<UserDto>(user));

            if (isUserCredentialsValid)
            {
                var token = jwtAuthService.SingIn(Mapper.Map<UserAuthDto>(user));

                var cookie = _provider.GetCookie(ActionContext, token.AccessToken);

                var response = Request.CreateResponse(HttpStatusCode.OK, token);
                response.Headers.AddCookies(new[] {cookie});
                return response;
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [Route("refresh-token")]
        [HttpPost]
        public HttpResponseMessage RefreshToken([FromBody] string token)
        {
            var jwtAuthService = ServiceFactory.Create<IAuthorizationServiceJWT>();
            var jwt = jwtAuthService.UpdateToken(token);
        
            var cookie = _provider.GetCookie(ActionContext, jwt.AccessToken);

            var response = Request.CreateResponse(HttpStatusCode.OK, jwt);
            Request.Headers.Remove("Set-Cookie");
            response.Headers.AddCookies(new[] {cookie});

            return response;
        }

        [Route("logout")]
        [HttpPost]
        public HttpResponseMessage Logout()
        {
            var jwtAuthService = ServiceFactory.Create<IAuthorizationServiceJWT>();
            var token = _provider.GetToken(ActionContext);
            jwtAuthService.Logout(token);
            //TODO Implement logout
            return null;
        }
    }
}