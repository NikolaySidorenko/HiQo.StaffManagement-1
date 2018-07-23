using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HiQo.StaffManagement.BL.Domain.Models;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IPositionLevelService
    {
        PositionLevelDto GetById(int id);

        IEnumerable<PositionLevelDto> GetAll();

        //IEnumerable<PositionLevelDto> Get(
        //    Expression<Func<PositionLevelDto, bool>> filter = null,
        //    Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy = null);

        void Add(PositionLevelDto entity);

        void Remove(PositionLevelDto entity);

        void Remove(int id);

        void Update(PositionLevelDto entity);
    }
}