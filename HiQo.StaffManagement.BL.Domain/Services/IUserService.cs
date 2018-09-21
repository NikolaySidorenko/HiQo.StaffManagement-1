using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface IUserService:IService
    {
        UserDto GetById(int id);

        IEnumerable<UserDto> GetAll();

        void Add(UserDto entity);

        void Remove(int id);

        void Update(UserDto entity);

        IEnumerable<UserDto> GetListOfBirthdays();

        bool IsExists(int id);
    }
}
