using System;

namespace HiQo.StaffManagement.BL.Domain.Entities
{
    public class JWT
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpiresIn { get; set; }
    }
}
