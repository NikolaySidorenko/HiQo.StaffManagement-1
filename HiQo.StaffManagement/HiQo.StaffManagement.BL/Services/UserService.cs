using System.Collections.Generic;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _baseRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IRepository baseRepository)
        {
            _userRepository = userRepository;
            _baseRepository = baseRepository;
        }

        public UserDto GetById(int id)
        {
            return Mapper.Map<User, UserDto>(_baseRepository.GetById<User>(id));
        }

        public IEnumerable<UserDto> GetAll()
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(
                _baseRepository.GetAll<User>());
        }

        public void Add(UserDto entity)
        {
            _baseRepository.Add(Mapper.Map<User>(entity));
        }

        public void Remove(UserDto entity)
        {
            _baseRepository.Remove(Mapper.Map<User>(entity));
        }

        public void Remove(int id)
        {
            var entity = _baseRepository.GetById<User>(id);
            _baseRepository.Remove(entity);
        }

        public void Update(UserDto entity)
        {
            _baseRepository.Update(Mapper.Map<User>(entity));
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