using System;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface ITokenService
    {
        string CreateRefreshToken(int id, DateTime expire, string secretKey);

        string CreateAccessToken(string role, string username, int id, DateTime expire, string secretKey);

        JWT CreateJwt(string role, string username, int id, string secretKey);

        bool IsValidTokenLifetime(string accessToken);

        JWT UpdateAccessAndRefreshToken(string token);

        void PassTokenToDb(string refreshToken, UserDto user);

        void Delete(int userId);
    }
}
