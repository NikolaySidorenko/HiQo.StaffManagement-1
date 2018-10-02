using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class PositionLevelService : IPositionLevelService
    {
        private readonly IRepository _repository;

        public PositionLevelService(IRepository repository)
        {
            _repository = repository;
        }

        public PositionLevelDto GetById(int id)
        {
            return Mapper.Map<PositionLevel, PositionLevelDto>(_repository.GetById<PositionLevel>(id));
        }

        public IEnumerable<PositionLevelDto> GetAll()
        {
            return Mapper.Map<IEnumerable<PositionLevel>, IEnumerable<PositionLevelDto>>(
                _repository.GetAll<PositionLevel>());
        }

        public void Add(PositionLevelDto entity)
        {
            _repository.Add(Mapper.Map<PositionLevel>(entity));
        }

        public void Delete(PositionLevelDto entity)
        {
            _repository.Delete(Mapper.Map<PositionLevel>(entity));
        }

        public void Delete(int id)
        {
            var entity = _repository.GetById<PositionLevel>(id);
            _repository.Delete(entity);
        }

        public void Update(PositionLevelDto entity)
        {
            _repository.Update(Mapper.Map<PositionLevel>(entity));
        }

        public Dictionary<int, string> NameByIdDictionary()
        {
            var listOfPositionLevels = _repository.GetAll<PositionLevel>();

            return listOfPositionLevels.ToDictionary(positionlevel => positionlevel.PositionLevelId,
                positionlevel => positionlevel.Name + " " + positionlevel.Level.ToString());

        }
    }
}