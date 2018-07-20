using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public PositionLevelDTO GetById(int id)
        {
            return  _positionLevelRepository.GetById(id);
        }

        public IEnumerable<PositionLevelDTO> GetAll()
        {
            return _positionLevelRepository.GetAll();
        }

        //public IEnumerable<PositionLevelDTO> Get(Expression<Func<PositionLevelDTO, bool>> filter = null,
        //    Func<IQueryable<PositionLevelDTO>, IOrderedQueryable<PositionLevelDTO>> orderBy = null)
        //{
        //}

        public void Add(PositionLevelDTO entity)
        {
            _positionLevelRepository(entity);
        }

        public void Remove(PositionLevelDTO entity)
        {
            _positionLevelRepository.Remove(entity);
        }

        public void Remove(int id)
        {
            var entity = _positionLevelRepository.GetById(id);
            _positionLevelRepository.Remove(entity);
        }

        public void Update(PositionLevelDTO entity)
        {
           _positionLevelRepository.Update(entity);
        }
    }
}