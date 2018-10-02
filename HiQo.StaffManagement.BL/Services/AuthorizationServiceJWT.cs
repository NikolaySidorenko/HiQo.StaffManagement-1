using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.BL.Services
{
    public class AuthorizationServiceJWT : IAuthorizationServiceJWT
    {

        private readonly ITokenHandler _tokenHandler;
        private readonly IServiceFactory _factory;

        public AuthorizationServiceJWT(IServiceFactory factory, ITokenHandler tokenHandler)
        {
            _factory = factory;
            _tokenHandler = tokenHandler;
        }

        public JWT SingIn(UserAuthDto user)
        {
            return GenerateJWT(user);
        }

        public bool ValidateRefreshToken(string token)
        {
            return _tokenService.IsValidTokenLifetime(token);
        }

        public JWT UpdateToken(string token)
        {
            return _tokenService.UpdateAccessAndRefreshToken(token);
        }

        public void Logout(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        private JWT GenerateJWT(UserAuthDto user)
        {
            var userModel = _factory.Create<IUserService>().GetAll().First(dto => dto.Username == user.UserName);

            var jwt = _tokenService.CreateJwt(userModel.Role.Name, user.UserName, userModel.UserId,
                userModel.SecurityStamp);

            _tokenService.PassTokenToDb(jwt.RefreshToken, userModel);

            return jwt;
        }
    }
}