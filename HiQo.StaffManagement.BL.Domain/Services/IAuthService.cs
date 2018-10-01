using System.Threading.Tasks;
using HiQo.StaffManagement.BL.Domain.Entities;
using Microsoft.AspNet.Identity.Owin;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IAuthService : IService
    {
        Task<bool> RegisterUserAsync(UserDto user);

        Task<bool> LoginUserAsync(UserDto user);

        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();

        void LogOut();
    }
}
