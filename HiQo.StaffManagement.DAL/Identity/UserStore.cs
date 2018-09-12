using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace HiQo.StaffManagement.DAL.Identity
{
    public class UserStore : IUserPasswordStore<User, int>
    {
        private readonly StaffManagementContext _context;

        public UserStore(StaffManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(User user)
        {
            _context.Entry<User>(user).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return _context.SaveChangesAsync();
        }

        public Task<User> FindByIdAsync(int userId)
        {
            return _context.Users.Where(user => user.Id == userId).FirstOrDefaultAsync();
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return _context.Users.Where(user => user.UserName == userName).FirstOrDefaultAsync();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }
    }
}
