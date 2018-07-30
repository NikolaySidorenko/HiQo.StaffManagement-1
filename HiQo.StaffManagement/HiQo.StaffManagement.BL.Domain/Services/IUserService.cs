using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IUserService
    {
        UserDto GetById(int id);

        IEnumerable<UserDto> GetAll();

        //IEnumerable<PositionLevelDto> Get(
        //    Expression<Func<PositionLevelDto, bool>> filter = null,
        //    Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy = null);

        void Add(UserDto entity);

        void Remove(UserDto entity);

        void Remove(int id);

        void Update(UserDto entity);

        IEnumerable<UserDto> GetListOfBirthdays();
    }
}
