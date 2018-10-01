using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface ICategoryService : IService
    {
        CategoryDto GetById(int id);

        IEnumerable<CategoryDto> GetAll();

        void Add(CategoryDto entity);

        void Remove(CategoryDto entity);

        void Remove(int id);

        void Update(CategoryDto entity);

        Dictionary<int, string> NameByIdDictionary();
    }
}
