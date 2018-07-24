using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.Entities;

namespace HiQo.StaffManagement.BL.Domain.Services
{
    public interface ICategoryService
    {
        CategoryDto GetById(int id);

        IEnumerable<CategoryDto> GetAll();

        //IEnumerable<PositionLevelDto> Get(
        //    Expression<Func<PositionLevelDto, bool>> filter = null,
        //    Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy = null);

        void Add(CategoryDto entity);

        void Remove(CategoryDto entity);

        void Remove(int id);

        void Update(CategoryDto entity);
    }
}
