﻿using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IPositionLevelService
    {
        PositionLevelDto GetById(int id);

        IEnumerable<PositionLevelDto> GetAll();

        void Add(PositionLevelDto entity);

        void Remove(PositionLevelDto entity);

        void Remove(int id);

        void Update(PositionLevelDto entity);

        Dictionary<int, string> NameByIdDictionary();
    }
}