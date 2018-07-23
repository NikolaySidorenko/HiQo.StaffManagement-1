using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.DAL.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        public PositionRepository(StaffManagementContext context)
        {
        }
    }
}