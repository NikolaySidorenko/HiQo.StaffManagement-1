using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class PositionLevelService : IPositionLevelService
    {
        private readonly IRepository _baseRepository;
        private readonly IPositionLevelRepository _positionLevelRepository;

        public PositionLevelService(IPositionLevelRepository positionLevelRepository, IRepository baseRepository)
        {
            _positionLevelRepository = positionLevelRepository;
            _baseRepository = baseRepository;
        }

        public PositionLevelDto GetById(int id)
        {
            return Mapper.Map<PositionLevel, PositionLevelDto>(_baseRepository.GetById<PositionLevel>(id));
        }

        public IEnumerable<PositionLevelDto> GetAll()
        {
            return Mapper.Map<IEnumerable<PositionLevel>, IEnumerable<PositionLevelDto>>(
                _baseRepository.GetAll<PositionLevel>());
        }

        public void Add(PositionLevelDto entity)
        {
            _baseRepository.Add(Mapper.Map<PositionLevel>(entity));
        }

        public void Remove(PositionLevelDto entity)
        {
            _baseRepository.Remove(Mapper.Map<PositionLevel>(entity));
        }

        public void Remove(int id)
        {
            var entity = _baseRepository.GetById<PositionLevel>(id);
            _baseRepository.Remove(entity);
        }

        public void Update(PositionLevelDto entity)
        {
            _baseRepository.Update(Mapper.Map<PositionLevel>(entity));
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