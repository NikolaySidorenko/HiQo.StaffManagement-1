using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.XPath;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Identity;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
            var identityResult = await _userManager.CreateAsync(Mapper.Map<User>(user), user.PasswordHash);

            return identityResult.Succeeded;
        }

        public async Task<bool> LoginUserAsync(UserDto user)
        {
            var isUserCredentialsValid = await _userManager.FindAsync(user.Username, user.PasswordHash) != null;

            if (isUserCredentialsValid)
            {
                await IdentifyUserAsync(Mapper.Map<UserDto>(_userManager.FindByNameAsync(user.Username).Result));
                return true;
            }

            return false;
        }

        public void LogOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        private async Task IdentifyUserAsync(UserDto user)
        {
            var claim = await _userManager.CreateIdentityAsync(Mapper.Map<User>(user), DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignOut();

            if (user.Role != null)
                claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name, ClaimValueTypes.String));
            _authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
        }

        public async Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            return await _authenticationManager.GetExternalLoginInfoAsync();
        }

    }
}