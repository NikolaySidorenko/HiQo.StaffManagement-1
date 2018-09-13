using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Identity;
using Microsoft.AspNet.Identity;

namespace HiQo.StaffManagement.DAL.Identity
{
    public class ApplicationUserManager : UserManager<User, int>, IUserManager
    {
        public ApplicationUserManager(IUserStore<User, int> store)
            : base(store)
        { 
        }
    }
}
