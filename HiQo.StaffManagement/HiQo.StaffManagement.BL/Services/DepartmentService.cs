using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IRepository _repository;

        public DepartmentService(IDepartmentRepository departmentRepository, IRepository repository)
        {
            _departmentRepository = departmentRepository;
            _repository = repository;
        }

        public DepartmentDto GetById(int id)
        {
            return Mapper.Map<Department, DepartmentDto>(_repository.GetById<Department>(id));
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(
                _repository.GetAll<Department>());
        }

        public void Add(DepartmentDto entity)
        {
            _repository.Add(Mapper.Map<Department>(entity));
        }

        public void Remove(DepartmentDto entity)
        {
            _repository.Remove(Mapper.Map<Department>(entity));
        }

        public void Remove(int id)
        {
            var entity = _repository.GetById<Department>(id);
            _repository.Remove(entity);
        }

        public void Update(DepartmentDto entity)
        {
            _repository.Update(Mapper.Map<Department>(entity));
        }

        public Dictionary<int, string> GetDictionary()
        {
            var listOfDepartments = _repository.GetAll<Department>();

            return listOfDepartments.ToDictionary(department => department.DepartmentId, department => department.Name);
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