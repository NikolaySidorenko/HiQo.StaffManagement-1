using System.Security.Claims;
using System.Threading.Tasks;
using HiQo.StaffManagement.DAL.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace HiQo.StaffManagement.DAL.Domain.Repositories
{
    public interface IUserRepository
    {
        int GetLastId();
    }
}
