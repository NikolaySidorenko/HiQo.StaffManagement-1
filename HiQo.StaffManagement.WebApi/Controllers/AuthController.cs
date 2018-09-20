using System;
using System.Net;
using System.Net.Http;
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

            if (result.IsValid)
                try
                {
                    var isUserCredentialsValid = await _authService.LoginUserAsync(Mapper.Map<UserDto>(user));

                    return isUserCredentialsValid
                        ? Request.CreateResponse(HttpStatusCode.OK,
                            _authorizationServiceJwt.SingIn(Mapper.Map<UserAuthDto>(user)))
                        : new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                catch (Exception e)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("refresh-token")]
        [HttpPost]
        public HttpResponseMessage RefreshToken([FromBody] string token)
        {
            JWT jwt = null;

            try
            {
                jwt = _authorizationServiceJwt.UpdateToken(token);
            }
            catch (Exception e)
            {
                Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            if (jwt == null)
            {
                throw new ArgumentNullException();
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, jwt);
        }
    }
}