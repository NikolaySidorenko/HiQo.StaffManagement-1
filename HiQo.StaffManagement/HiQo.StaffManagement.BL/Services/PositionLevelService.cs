using System;
using System.Collections;
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
    public class PositionLevelService : /*BaseService*/ IPositionLevelService
    {
        private readonly IPositionLevelRepository _positionLevelRepository;

        public PositionLevelService(IPositionLevelRepository positionLevelRepository /*TODO:ILogService */) //TODO:base(UoW)
        {
            _positionLevelRepository = positionLevelRepository;
        }

        public PositionLevelDto GetById(int id)
        {
            return Mapper.Map<PositionLevelDto>(_positionLevelRepository.GetById(id));
        }

        public IEnumerable<PositionLevelDto> GetAll()
        {
            return Mapper.Map<IEnumerable<PositionLevelDto>>(_positionLevelRepository.GetAll());
        }

        public void Add(PositionLevelDto entity)
        {
            _positionLevelRepository.Add(Mapper.Map<PositionLevel>(entity));
        }

        public void Remove(PositionLevelDto entity)
        {
            _positionLevelRepository.Remove(Mapper.Map<PositionLevel>(entity));
        }

        public void Remove(int id)
        {
            var entity = _positionLevelRepository.GetById(id);
            _positionLevelRepository.Remove(entity);
        }

        public void Update(PositionLevelDto entity)
        {
            _positionLevelRepository.Update(Mapper.Map<PositionLevel>(entity));
        }

        public IEnumerable<PositionLevelDto> Get(Expression<Func<PositionLevelDto, bool>> filter = null, Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy = null)
        {
            IQueryable<PositionLevelDto> query =
                Mapper.Map<IQueryable<PositionLevelDto>>(_positionLevelRepository.GetAll());

            if (filter != null) query = query.Where(filter);

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }
    }
}