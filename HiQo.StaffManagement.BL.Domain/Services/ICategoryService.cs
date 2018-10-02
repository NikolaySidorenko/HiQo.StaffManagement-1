using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface ICategoryService : IService
    {
        CategoryDto GetById(int id);

        IEnumerable<CategoryDto> GetAll();

        void Add(CategoryDto entity);

        void Delete(CategoryDto entity);

        void Delete(int id);

        void Update(CategoryDto entity);

        List<KeyValuePair<int, string>> GetListNameById();
    }
}
