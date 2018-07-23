using System.Collections.Generic;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IRepository _baseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IRepository baseRepository)
        {
            _departmentRepository = departmentRepository;
            _baseRepository = baseRepository;
        }

        public DepartmentDto GetById(int id)
        {
            return Mapper.Map<Department, DepartmentDto>(_baseRepository.GetById<Department>(id));
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(
                _baseRepository.GetAll<Department>());
        }

        public void Add(DepartmentDto entity)
        {
            _baseRepository.Add(Mapper.Map<Department>(entity));
        }

        public void Remove(DepartmentDto entity)
        {
            _baseRepository.Remove(Mapper.Map<Department>(entity));
        }

        public void Remove(int id)
        {
            var entity = _baseRepository.GetById<Department>(id);
            _baseRepository.Remove(entity);
        }

        public void Update(DepartmentDto entity)
        {
            _baseRepository.Update(Mapper.Map<Department>(entity));
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