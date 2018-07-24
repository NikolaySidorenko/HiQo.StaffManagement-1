using System.Collections.Generic;
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
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository, IRepository repository)
        {
            _positionRepository = positionRepository;
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

        public void Remove(PositionDto entity)
        {
            _repository.Remove(Mapper.Map<Position>(entity));
        }

        public void Remove(int id)
        {
            var entity = _repository.GetById<Position>(id);
            _repository.Remove(entity);
        }

        public void Update(PositionDto entity)
        {
            _repository.Update(Mapper.Map<Position>(entity));
        }

        //public IEnumerable<PositionLevelDto> Get(Expression<Func<PositionLevelDto, bool>> filter,
        //    Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy)
        //{
        //    var query =
        //        Mapper.Map<IQueryable<PositionLevel>, IQueryable<PositionLevelDto>>(
        //            _baseRepository.GetAll<PositionLevel>());

        //    if (filter != null) query = query.Where(filter);

        //    return orderBy != null ? orderBy(query).ToList() : query.ToList();
        //}
    }
}