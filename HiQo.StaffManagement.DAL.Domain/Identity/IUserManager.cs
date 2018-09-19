using System.Security.Claims;
using System.Threading.Tasks;
using HiQo.StaffManagement.DAL.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace HiQo.StaffManagement.DAL.Domain.Identity
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(User user, string password);

        Task<User> FindAsync(string userName, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);

        Task<User> FindByNameAsync(string userName);

        Task<bool> CheckPasswordAsync(User user, string pass);
    }
}