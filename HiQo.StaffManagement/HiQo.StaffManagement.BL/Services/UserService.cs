using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
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
            var user = Mapper.Map<User>(entity);
            _repository.Add(user);
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
            var listOfUsers = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(_repository.Get<User>().Where(user =>
                user.BirthDate.Day == DateTime.Today.Day && user.BirthDate.Month == DateTime.Today.Month));

            return listOfUsers;
        }

        public bool IsExists(int id)
        {
            var user = _repository.GetById<User>(id);

            return user != null;
        }
    }
}