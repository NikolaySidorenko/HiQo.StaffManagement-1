using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class PositionService : IPositionService
    {
        private readonly IRepository _repository;

        public PositionService(IRepository repository)
        {
            _repository = repository;
        }

        public PositionDto GetById(int id)
        {
            return Mapper.Map<Position, PositionDto>(_repository.GetById<Position>(id));
        }

        public IEnumerable<PositionDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(
                _repository.GetAll<Position>());
        }

        public void Add(PositionDto entity)
        {
            _repository.Add(Mapper.Map<Position>(entity));
        }

        public void Delete(PositionDto entity)
        {
            _repository.Delete(Mapper.Map<Position>(entity));
        }

        public void Delete(int id)
        {
            var entity = _repository.GetById<Position>(id);
            _repository.Delete(entity);
        }

        public void Update(PositionDto entity)
        {
            _repository.Update(Mapper.Map<Position>(entity));
        }

        public List<KeyValuePair<int, string>> GetListNameById()
        {
            var listOfPositions = _repository.GetAll<Position>();

            return listOfPositions.Select(position =>
                new KeyValuePair<int, string>(position.PositionId, position.Name)).ToList();
        }
    }
}