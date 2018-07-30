using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IRepository repository)
        {
            _userRepository = userRepository;
            _repository = repository;
        }

        public UserDto GetById(int id)
        {
            return Mapper.Map<User, UserDto>(_repository.GetById<User>(id));
        }

        public IEnumerable<UserDto> GetAll()
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(
                _repository.GetAll<User>());
        }

        public void Add(UserDto entity)
        {
            _repository.Add(Mapper.Map<User>(entity));
            _repository.SaveChanges();
        }

        public void Remove(UserDto entity)
        {
            _repository.Remove(Mapper.Map<User>(entity));
            _repository.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _repository.GetById<User>(id);
            _repository.Remove(entity);
            _repository.SaveChanges();
        }

        public void Update(UserDto entity)
        {
            _repository.Update(Mapper.Map<User>(entity));
            _repository.SaveChanges();
        }

        public IEnumerable<UserDto> GetListOfBirthdays()
        {
            var users = _repository.GetAll<User>().Where(user =>
                user.BirthDate.Day == DateTime.Today.Day && user.BirthDate.Month == DateTime.Today.Month);

            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
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