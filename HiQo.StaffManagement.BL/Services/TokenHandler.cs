using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.BL.Services
{
    public class TokenHandler : ITokenHandler
    {
        public TokenHandler()
        {
        }

        public string CreateRefreshToken()
        {
            throw new System.NotImplementedException();
        }

        public string CreateAccessToken()
        {
            throw new System.NotImplementedException();
        }

        public JWT CreateJwt()
        {
            throw new System.NotImplementedException();
        }
    }
}
