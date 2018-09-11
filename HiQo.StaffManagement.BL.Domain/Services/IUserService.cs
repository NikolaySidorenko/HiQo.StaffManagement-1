using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IUserService
    {
        UserDto GetById(int id);

        IEnumerable<UserDto> GetAll();

        void Add(UserDto entity);

        void Remove(int id);

        void Update(UserDto entity);

        void Update(UserUpdateDto entity);

        IEnumerable<UserDto> GetListOfBirthdays();

        bool IsExists(int id);
    }
}
