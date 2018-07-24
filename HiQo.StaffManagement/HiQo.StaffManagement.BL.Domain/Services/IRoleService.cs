using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IRoleService
    {
        RoleDto GetById(int id);

        IEnumerable<RoleDto> GetAll();

        //IEnumerable<PositionLevelDto> Get(
        //    Expression<Func<PositionLevelDto, bool>> filter = null,
        //    Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy = null);

        void Add(RoleDto entity);

        void Remove(RoleDto entity);

        void Remove(int id);

        void Update(RoleDto entity);
    }
}
