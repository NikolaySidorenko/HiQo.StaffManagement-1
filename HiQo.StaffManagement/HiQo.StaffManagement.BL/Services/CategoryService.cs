using System.Collections.Generic;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository _baseRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IRepository baseRepository)
        {
            _categoryRepository = categoryRepository;
            _baseRepository = baseRepository;
        }

        public CategoryDto GetById(int id)
        {
            return Mapper.Map<Category, CategoryDto>(_baseRepository.GetById<Category>(id));
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(
                _baseRepository.GetAll<Category>());
        }

        public void Add(CategoryDto entity)
        {
            _baseRepository.Add(Mapper.Map<Category>(entity));
        }

        public void Remove(CategoryDto entity)
        {
            _baseRepository.Remove(Mapper.Map<Category>(entity));
        }

        public void Remove(int id)
        {
            var entity = _baseRepository.GetById<Category>(id);
            _baseRepository.Remove(entity);
        }

        public void Update(CategoryDto entity)
        {
            _baseRepository.Update(Mapper.Map<Category>(entity));
        }

        //public IEnumerable<PositionLevelDto> Get(Expression<Func<PositionLevelDto, bool>> filter,
        //    Func<IQueryable<PositionLevelDto>, IOrderedQueryable<PositionLevelDto>> orderBy)
        //{
        //    var query =
        //        Mapper.Map<IQueryable<PositionLevel>, IQueryable<PositionLevelDto>>(
        //            _baseRepository.GetAll<PositionLevel>());

        //    if (filter != null) query = query.Where(filter);

        //    return orderBy != null ? orderBy(query).ToList() : query.ToList();
        //}
    }
}