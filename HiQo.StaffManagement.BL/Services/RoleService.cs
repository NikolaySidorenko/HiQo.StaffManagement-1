using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository _repository;

        public RoleService(IRepository repository)
        {
            _repository = repository;
        }

        public RoleDto GetById(int id)
        {
            return Mapper.Map<Role, RoleDto>(_repository.GetById<Role>(id));
        }

        public IEnumerable<RoleDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(
                _repository.GetAll<Role>());
        }

        public void Add(RoleDto entity)
        {
            _repository.Add(Mapper.Map<Role>(entity));
        }

        public void Delete(RoleDto entity)
        {
            _repository.Delete(Mapper.Map<Role>(entity));
        }

        public void Delete(int id)
        {
            var entity = _repository.GetById<Role>(id);
            _repository.Delete(entity);
        }

        public void Update(RoleDto entity)
        {
            _repository.Update(Mapper.Map<Role>(entity));
        }

        public List<KeyValuePair<int, string>> GetListNameById()
        {
            var listOfRoles = _repository.GetAll<Role>();

            return listOfRoles.Select(role =>
                new KeyValuePair<int, string>(role.RoleId, role.Name)).ToList();
        }
    }
}