using System.Collections.Generic;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IUpsertService
    {
        Dictionary<int, string> getDictionaryNameByIdDepartment();

        Dictionary<int, string> getDictionaryNameByIdCategory();

        Dictionary<int, string> getDictionaryNameByIdPosition();

        Dictionary<int, string> getDictionaryNameByIdPositionLevel();

        Dictionary<int, string> getDictionaryNameByIdRole();
    }
}