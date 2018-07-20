using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HiQo.StaffManagement.BL.Domain.Models;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IPositionLevelService
    {
        PositionLevelDTO GetById(int id);

        IEnumerable<PositionLevelDTO> GetAll();

        IEnumerable<PositionLevelDTO> Get(
            Expression<Func<PositionLevelDTO, bool>> filter = null,
            Func<IQueryable<PositionLevelDTO>, IOrderedQueryable<PositionLevelDTO>> orderBy = null);

        void Add(PositionLevelDTO entity);

        void Remove(PositionLevelDTO entity);

        void Remove(int id);

        void Update(PositionLevelDTO entity);
    }
}