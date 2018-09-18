using System;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface ITokenHandler
    {
        string CreateRefreshToken(int id, DateTime expire);

        string CreateAccessToken(string role, string username, int id, DateTime expire);

        JWT CreateJwt(string role, string username, int id);
    }
}
