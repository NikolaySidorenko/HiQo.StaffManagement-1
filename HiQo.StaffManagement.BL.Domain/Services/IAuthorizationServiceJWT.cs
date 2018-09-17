﻿using System.Threading.Tasks;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IAuthorizationServiceJWT
    {
        Task<JWT> SingInAsync(UserAuthDto user);

        bool ValidateRefreshToken(string token);

        Task<JWT> UpdateTokenAsync(string token);
    }
}
