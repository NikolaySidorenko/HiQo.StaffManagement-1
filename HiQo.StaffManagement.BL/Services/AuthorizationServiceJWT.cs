using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class AuthorizationServiceJWT : IAuthorizationServiceJWT
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IRepository _repository;

        public AuthorizationServiceJWT(IUserService userService, ITokenHandler tokenHandler, IRepository repository)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
            _repository = repository;
        }

        public JWT SingIn(UserAuthDto user)
        {
            return GenerateJWT(user);
        }

        public bool ValidateRefreshToken(string token)
        {
            return _tokenHandler.IsValidTokenLifetime(token);
        }

        public JWT UpdateToken(string token)
        {
            return _tokenHandler.UpdateAccessAndRefreshToken(token);
        }

        private JWT GenerateJWT(UserAuthDto user)
        {
            var userModel = _userService.GetAll().First(dto => dto.Username == user.UserName);

            var jwt = _tokenHandler.CreateJwt(userModel.Role.Name, user.UserName, userModel.UserId,
                userModel.SecurityStamp);

            PassTokenToDb(jwt.RefreshToken, userModel);

            return jwt;
        }

        private void PassTokenToDb(string refreshToken, UserDto user)
        {
            try
            {
                var tokenDto = new TokenDto()
                {
                    UserId = user.UserId,
                    RefreshToken = refreshToken
                };

                user.Tokens.Add(tokenDto);
                _repository.Add(Mapper.Map<Token>(tokenDto));
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}