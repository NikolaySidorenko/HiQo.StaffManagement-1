using System;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class Jwt
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public double ExpiresIn { get; set; }
    }
}
