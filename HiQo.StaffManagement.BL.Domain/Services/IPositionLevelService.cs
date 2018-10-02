using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IPositionLevelService : IService
    {
        PositionLevelDto GetById(int id);

        IEnumerable<PositionLevelDto> GetAll();

        void Add(PositionLevelDto entity);

        void Delete(PositionLevelDto entity);

        void Delete(int id);

        void Update(PositionLevelDto entity);

        List<KeyValuePair<int, string>> GetListNameById();
    }
}