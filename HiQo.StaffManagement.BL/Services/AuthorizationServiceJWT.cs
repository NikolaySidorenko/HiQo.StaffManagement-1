using System.Threading.Tasks;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.BL.Services
{
    public class AuthorizationServiceJWT : IAuthorizationService
    {
        public AuthorizationServiceJWT()
        {
        }

        public Task<JWT> SingInAsync(UserAuthDto user)
        {


            throw new System.NotImplementedException();
        }

        public bool ValidateRefreshToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public Task<JWT> UpdateTokenAsync(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
