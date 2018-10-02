using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IPositionService : IService
    {
        PositionDto GetById(int id);

        IEnumerable<PositionDto> GetAll();

        void Add(PositionDto entity);

        void Delete(PositionDto entity);

        void Delete(int id);

        void Update(PositionDto entity);

        Dictionary<int, string> NameByIdDictionary();
    }
}
