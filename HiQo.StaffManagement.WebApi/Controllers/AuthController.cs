using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using FluentValidation;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IAuthorizationServiceJWT _authorizationServiceJwt;
        private readonly IAuthService _authService;
        private readonly IValidatorFactory _validatorFactory;

        public AuthController(IValidatorFactory validatorFactory, IAuthService authService,
            IAuthorizationServiceJWT authorizationServiceJwt)
        {
            _validatorFactory = validatorFactory ?? throw new ArgumentNullException(nameof(validatorFactory));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _authorizationServiceJwt = authorizationServiceJwt ?? throw new ArgumentNullException(nameof(authorizationServiceJwt));
        }

        [Route("login")]
        [HttpPost]
        public async Task<HttpResponseMessage> Login([FromBody] LoginViewModel user)
        {
            var validator = _validatorFactory.GetValidator<LoginViewModel>();
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var isUserCredentialsValid = await _authService.LoginUserAsync(Mapper.Map<UserDto>(user));

                if (isUserCredentialsValid)
                {
                    var token = _authorizationServiceJwt.SingIn(Mapper.Map<UserAuthDto>(user));

                    var cookie = new CookieHeaderValue("access_token", token.AccessToken);
                    cookie.Expires = DateTimeOffset.Now.AddMinutes(15);
                    cookie.Domain = Request.RequestUri.Host;
                    cookie.Path = "/";

                    var response = Request.CreateResponse(HttpStatusCode.OK, token);
                    response.Headers.AddCookies(new CookieHeaderValue[]{cookie});
                    return response;
                }
                    
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [Route("refresh-token")]
        [HttpPost]
        public HttpResponseMessage RefreshToken([FromBody] string token)
        {
            var jwt = _authorizationServiceJwt.UpdateToken(token);

            return jwt != null ? Request.CreateResponse(HttpStatusCode.OK, jwt) : Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}