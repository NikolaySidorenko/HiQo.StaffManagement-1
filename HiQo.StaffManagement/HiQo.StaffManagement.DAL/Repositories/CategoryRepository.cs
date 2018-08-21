using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository(StaffManagementContext context)
        {
        }
    }
}