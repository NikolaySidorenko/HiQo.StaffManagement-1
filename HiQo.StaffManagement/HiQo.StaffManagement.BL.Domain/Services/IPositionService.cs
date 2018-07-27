﻿using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IPositionService
    {
        PositionDto GetById(int id);

        IEnumerable<PositionDto> GetAll();

        //IEnumerable<PositionLevelDto> Get(
        //    Expression<Func<PositionLevelDto, bool>> filter = null,
        //    Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy = null);

        void Add(PositionDto entity);

        void Remove(PositionDto entity);

        void Remove(int id);

        void Update(PositionDto entity);

        Dictionary<int, string> GetDictionary();
    }
}
