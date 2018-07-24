using System.Collections.Generic;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository _repository;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository, IRepository repository)
        {
            _roleRepository = roleRepository;
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

        public void Remove(RoleDto entity)
        {
            _repository.Remove(Mapper.Map<Role>(entity));
        }

        public void Remove(int id)
        {
            var entity = _repository.GetById<Role>(id);
            _repository.Remove(entity);
        }

        public void Update(RoleDto entity)
        {
            _repository.Update(Mapper.Map<Role>(entity));
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