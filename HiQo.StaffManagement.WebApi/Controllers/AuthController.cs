using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using FluentValidation;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : BaseController
    {
        public AuthController(IValidatorFactory validatorFactory, IServiceFactory serviceFactory) : base(serviceFactory,
            validatorFactory)
        {
        }

        [Route("login")]
        [HttpPost]
        public async Task<HttpResponseMessage> Login([FromBody] LoginViewModel user)
        {
            var validator = ValidatorFactory.GetValidator<LoginViewModel>();
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var authService = ServiceFactory.Create<IAuthService>();
            var jwtAuthService = ServiceFactory.Create<IAuthorizationServiceJWT>();

            var isUserCredentialsValid = await authService.LoginUserAsync(Mapper.Map<UserDto>(user));

            if (isUserCredentialsValid)
            {
                var token = jwtAuthService.SingIn(Mapper.Map<UserAuthDto>(user));

                var cookie = new CookieHeaderValue("access_token", token.AccessToken)
                {
                    Expires = DateTimeOffset.Now.AddMinutes(15),
                    Domain = Request.RequestUri.Host,
                    Path = "/"
                };

                var response = Request.CreateResponse(HttpStatusCode.OK, token);
                response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
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

            if (jwt != null)
            {
                var cookie = new CookieHeaderValue("access_token", jwt.AccessToken)
                {
                    Expires = DateTimeOffset.Now.AddMinutes(15),
                    Domain = Request.RequestUri.Host,
                    Path = "/"
                };

                var response = Request.CreateResponse(HttpStatusCode.OK, jwt);
                Request.Headers.Remove("Set-Cookie");
                response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}