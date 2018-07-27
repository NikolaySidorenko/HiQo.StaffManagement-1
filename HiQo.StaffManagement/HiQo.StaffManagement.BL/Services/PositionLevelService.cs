using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly IPositionLevelRepository _positionLevelRepository;

        public PositionLevelService(IPositionLevelRepository positionLevelRepository, IRepository repository)
        {
            _positionLevelRepository = positionLevelRepository;
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

        public void Remove(PositionLevelDto entity)
        {
            _repository.Remove(Mapper.Map<PositionLevel>(entity));
        }

        public void Remove(int id)
        {
            var entity = _repository.GetById<PositionLevel>(id);
            _repository.Remove(entity);
        }

        public void Update(PositionLevelDto entity)
        {
            _repository.Update(Mapper.Map<PositionLevel>(entity));
        }

        public Dictionary<int, string> GetDictionary()
        {
            var listOfPositionLevels = _repository.GetAll<PositionLevel>();

            return listOfPositionLevels.ToDictionary(positionlevel => positionlevel.PositionLevelId,
                positionlevel => positionlevel.Name + " " + positionlevel.Level.ToString());

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