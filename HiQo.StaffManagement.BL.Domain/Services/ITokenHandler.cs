using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface ITokenHandler
    {
        string CreateRefreshToken();

        string CreateAccessToken();

        JWT CreateJwt();
    }
}
