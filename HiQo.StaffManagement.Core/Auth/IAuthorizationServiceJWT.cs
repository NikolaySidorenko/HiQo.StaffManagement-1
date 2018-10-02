using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.Core.Auth
{
    public interface IAuthorizationServiceJwt : IService
    {
        Jwt SingIn(string email);

        Jwt UpdateToken(string refreshToken);

        void Logout(string token);
    }
}
