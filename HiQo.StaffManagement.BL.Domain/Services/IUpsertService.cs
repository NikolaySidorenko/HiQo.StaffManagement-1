using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IUpsertService : IService
    {
        List<KeyValuePair<int, string>> GetListNameByIdDepartment();

        List<KeyValuePair<int, string>> GetListNameByIdCategory();

        List<KeyValuePair<int, string>> GetListNameByIdPosition();

        List<KeyValuePair<int, string>> GetListNameByIdPositionLevel();

        List<KeyValuePair<int, string>> GetListNameByIdRole();
    }
}