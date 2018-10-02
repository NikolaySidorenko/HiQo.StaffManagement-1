using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.Core.Providers
{
    public interface ITokenProvider
    {
        Jwt CreateJwt(string email);

        Jwt UpdateAccessAndRefreshToken(string token);

        void Delete(int userId);
    }
}
