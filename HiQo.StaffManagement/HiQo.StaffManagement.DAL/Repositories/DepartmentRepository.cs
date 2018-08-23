using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public DepartmentRepository(StaffManagementContext context)
        {
        }
    }
}