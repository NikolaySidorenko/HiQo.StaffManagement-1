using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IUpsertService : IService
    {
        Dictionary<int, string> GetDictionaryNameByIdDepartment();

        Dictionary<int, string> GetDictionaryNameByIdCategory();

        Dictionary<int, string> GetDictionaryNameByIdPosition();

        Dictionary<int, string> GetDictionaryNameByIdPositionLevel();

        Dictionary<int, string> GetDictionaryNameByIdRole();
    }
}