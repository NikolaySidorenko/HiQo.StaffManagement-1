using System.Linq;
using System.Threading.Tasks;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.BL.Services
{
    public class AuthorizationServiceJWT : IAuthorizationServiceJWT
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthorizationServiceJWT(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public JWT SingIn(UserAuthDto user)
        {
            var jwt = GenerateJWT(user);

            return jwt;
        }

        private JWT GenerateJWT(UserAuthDto user)
        {
            var userModel = _userService.GetAll().First(dto => dto.Username == user.UserName);

            var jwt = _tokenHandler.CreateJwt(userModel.Role.Name, user.UserName, userModel.UserId);

            return jwt;
        }

        public bool ValidateRefreshToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public Task<JWT> UpdateTokenAsync(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
