using System;
using System.Threading.Tasks;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Identity;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace HiQo.StaffManagement.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IUserManager _userManager;
        private readonly IUserRepository _userRepository;

        public AuthService(IUserManager userManager,
            IAuthenticationManager authenticationManager, IUserRepository userRepository)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _authenticationManager =
                authenticationManager ?? throw new ArgumentNullException(nameof(authenticationManager));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> RegisterUserAsync(UserDto user)
        {
            user.UserId = _userRepository.GetLastId();
            InitUserIds(user);

            var identityResult = await _userManager.CreateAsync(Mapper.Map<User>(user), user.PasswordHash);   

            if (!identityResult.Succeeded)
            { 
               throw new Exception();
            }
            //TODO:Error handling
            await IdentifyUserAsync(user);

            return true;
        }

        public async Task<bool> LoginUserAsync(UserDto user)
        {
            var isUserCredentialsValid = await _userManager.FindAsync(user.Username, user.PasswordHash) != null;

            if (isUserCredentialsValid)
            {
                await IdentifyUserAsync(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        private async Task IdentifyUserAsync(UserDto user)
        {
            var claim = await _userManager.CreateIdentityAsync(Mapper.Map<User>(user), DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignOut();
            _authenticationManager.SignIn(new AuthenticationProperties {IsPersistent = true}, claim);
        }

        private void InitUserIds(UserDto user)
        {
            user.DepartmentId = 1;
            user.CategoryId = 1;
            user.PositionId = 1;
            user.PositionLevelId = 1;
            user.RoleId = 1;
        }
    }
}