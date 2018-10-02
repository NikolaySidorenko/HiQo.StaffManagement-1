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
        private readonly IRepository _repository;

        public DepartmentService(IRepository repository)
        {
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

        public void Delete(DepartmentDto entity)
        {
            _repository.Delete(Mapper.Map<Department>(entity));
        }

        public void Delete(int id)
        {
            var entity = _repository.GetById<Department>(id);
            _repository.Delete(entity);
        }

        public void Update(DepartmentDto entity)
        {
            _repository.Update(Mapper.Map<Department>(entity));
        }

        public Dictionary<int, string> NameByIdDictionary()
        {
            var listOfDepartments = _repository.GetAll<Department>();

            return listOfDepartments.ToDictionary(department => department.DepartmentId, department => department.Name);
        }
    }
}