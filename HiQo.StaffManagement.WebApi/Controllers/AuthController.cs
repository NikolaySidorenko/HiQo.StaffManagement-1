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
    [Authorize]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly IAuthService _authService;
        private readonly IAuthorizationServiceJWT _authorizationServiceJwt;

        public AuthController(IValidatorFactory validatorFactory, IAuthService authService,
            IAuthorizationServiceJWT authorizationServiceJwt)
        {
            _validatorFactory = validatorFactory;
            _authService = authService;
            _authorizationServiceJwt = authorizationServiceJwt;
        }

        [Route("login")]
        [HttpPost]
        public async Task<HttpResponseMessage> Login([FromBody] LoginViewModel user)
        {
            var validator = _validatorFactory.GetValidator<LoginViewModel>();
            var result = validator.Validate(user);

            if (result.IsValid)
            {
                try
                {
                    var isUserCredentialsValid = _authService.CheckPasswordAsync(Mapper.Map<UserDto>(user));

                    if (isUserCredentialsValid.Result)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, _authorizationServiceJwt.SingIn(Mapper.Map<UserAuthDto>(user)));
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.BadRequest);
                    }
                }
                catch (Exception e)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}