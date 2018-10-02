using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.Providers;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.Core.Auth
{
    public class AuthorizationServiceJwt : IAuthorizationServiceJwt
    {
        private readonly ITokenProvider _tokenService;
        private readonly IServiceFactory _factory;

        public AuthorizationServiceJwt(IServiceFactory factory, ITokenProvider tokenService)
        {
            _factory = factory;
            _tokenService = tokenService;
        }

        public Jwt SingIn(string email)
        {
            return  _tokenService.CreateJwt(email);
        }

        public Jwt UpdateToken(string token)
        {
            return _tokenService.UpdateAccessAndRefreshToken(token);
        }

        public void Logout(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
    }
}