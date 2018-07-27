﻿using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int id);

        IEnumerable<DepartmentDto> GetAll();

        //IEnumerable<PositionLevelDto> Get(
        //    Expression<Func<PositionLevelDto, bool>> filter = null,
        //    Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy = null);

        void Add(DepartmentDto entity);

        void Remove(DepartmentDto entity);

        void Remove(int id);

        void Update(DepartmentDto entity);

        Dictionary<int, string> GetDictionary();
    }
}
