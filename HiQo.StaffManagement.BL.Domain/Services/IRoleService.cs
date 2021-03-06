﻿using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IRoleService
    {
        RoleDto GetById(int id);

        IEnumerable<RoleDto> GetAll();

        void Add(RoleDto entity);

        void Remove(RoleDto entity);

        void Remove(int id);

        void Update(RoleDto entity);

        Dictionary<int, string> NameByIdDictionary();
    }
}
