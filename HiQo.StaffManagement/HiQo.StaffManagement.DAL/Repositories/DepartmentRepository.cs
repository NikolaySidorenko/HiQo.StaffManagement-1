using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.DAL.Repositories
{
    public class DepartmentRepository:BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(StaffManagementContext context) : base(context)
        {

        }
    }
}
