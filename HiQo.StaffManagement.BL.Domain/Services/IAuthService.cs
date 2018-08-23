using System.Threading.Tasks;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(UserDto user);

        Task<bool> LoginUserAsync(UserDto user);

        void LogOut();
    }
}
