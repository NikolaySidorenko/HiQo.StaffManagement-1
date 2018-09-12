using System;
using System.Linq;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StaffManagementContext _context;

        public UserRepository(StaffManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int GetLastId()
        {
            return _context.Users.ToList().LastOrDefault().Id + 1;
        }
    }
}