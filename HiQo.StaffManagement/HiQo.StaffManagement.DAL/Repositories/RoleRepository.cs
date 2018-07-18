using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.DAL.Repositories
{
    public class RoleRepository:BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(StaffManagementContext context) : base(context)
        {

        }
    }
}
