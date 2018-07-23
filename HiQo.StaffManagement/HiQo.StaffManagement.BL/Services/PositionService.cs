using System.Collections.Generic;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class PositionService : IPositionService
    {
        private readonly IRepository _baseRepository;
        private readonly IPositionService _positionService;

        public PositionService(IPositionService positionService, IRepository baseRepository)
        {
            _positionService = positionService;
            _baseRepository = baseRepository;
        }

        public PositionDto GetById(int id)
        {
            return Mapper.Map<Position, PositionDto>(_baseRepository.GetById<Position>(id));
        }

        public IEnumerable<PositionDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(
                _baseRepository.GetAll<Position>());
        }

        public void Add(PositionDto entity)
        {
            _baseRepository.Add(Mapper.Map<Position>(entity));
        }

        public void Remove(PositionDto entity)
        {
            _baseRepository.Remove(Mapper.Map<Position>(entity));
        }

        public void Remove(int id)
        {
            var entity = _baseRepository.GetById<Position>(id);
            _baseRepository.Remove(entity);
        }

        public void Update(PositionDto entity)
        {
            _baseRepository.Update(Mapper.Map<Position>(entity));
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