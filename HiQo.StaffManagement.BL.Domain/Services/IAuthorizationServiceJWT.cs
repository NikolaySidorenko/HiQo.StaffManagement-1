using System.Threading.Tasks;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IAuthorizationServiceJWT : IService
    {
        JWT SingIn(UserAuthDto user);

        bool ValidateRefreshToken(string token);

        JWT UpdateToken(string token);

        void Logout(string token);
    }
}
