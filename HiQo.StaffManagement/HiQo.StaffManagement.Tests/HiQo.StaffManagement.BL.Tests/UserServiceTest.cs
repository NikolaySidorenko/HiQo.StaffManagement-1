using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using FakeItEasy;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.Configuration.Profiles;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using Xunit;

namespace HiQo.StaffManagement.BL.Tests
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        private readonly IRepository _repository;
        private readonly IUserRepository _userRepository;

        public UserServiceTest()
        {
            _repository = A.Fake<IRepository>();
            _userRepository = A.Fake<IUserRepository>();
            _userService = new UserService(_userRepository, _repository);
        }


        [Fact]
        public void GetAll_Nothing_CollectionOfUserDto()
        {
            MapperConfig.ConfigureAutomapper();
            IEnumerable<User> users = new[] {new User {UserId = 1},
                new User {UserId = 2}};
            var expectedIds = new[] {1, 2};

            A.CallTo(() => _repository.GetAll<User>()).Returns(users);

            var testUsers = _userService.GetAll() as List<UserDto>;

            Assert.Equal(expectedIds.Length, testUsers.Count);

            for (int i = 0; i < expectedIds.Length; i++)
            {
                Assert.Equal(expectedIds[i], testUsers[i].UserId);
            }
        }

        [Fact]
        public void GetById_UserId_ReturnsUserDto()
        {
            MapperConfig.ConfigureAutomapper();
            var id = 666;
            var user = new User
            {
                UserId = id
            };

            A.CallTo(() => _repository.GetById<User>(id)).Returns(user);

            Assert.Equal(user.UserId, _userService.GetById(id).UserId);
        }

        [Fact]
        public void IsExists_UserId_ReturnsFalse()
        {
            var id = 666;

            A.CallTo(() => _repository.GetById<User>(id)).Returns(null);

            Assert.False(_userService.IsExists(id));
        }

        [Fact]
        public void IsExists_UserId_ReturnsTrue()
        {
            var id = 666;
            var user = new User
            {
                UserId = id
            };

            A.CallTo(() => _repository.GetById<User>(id)).Returns(user);

            Assert.True(_userService.IsExists(id));
        }

        [Fact]
        public void Add_UserDto_MustHaveHappened()
        {
            MapperConfig.ConfigureAutomapper();
            var id = 666;

            var user = new User
            {
                UserId = id
            };

            _userService.Add(Mapper.Map<UserDto>(user));

            A.CallTo(() => _repository.Add<User>(user)).MustHaveHappenedOnceExactly();//Fake map?

            A.CallTo(_repository).Where(call => call.Method.Name == nameof(_repository.Add) && call.Method.IsGenericMethod)
                .WithVoidReturnType().MustHaveHappenedOnceExactly();
            A.CallTo(() => _repository.SaveChanges()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Update_UserDto_MustHaveHappened()
        {
            MapperConfig.ConfigureAutomapper();
            var id = 666;

            var user = new UserDto
            {
                UserId = id
            };

            _userService.Update(user);


            A.CallTo(_repository).Where(call => call.Method.Name == nameof(_repository.Update) && call.Method.IsGenericMethod)
                .WithVoidReturnType().MustHaveHappenedOnceExactly();
            A.CallTo(() => _repository.SaveChanges()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Remove_UserId_MustHaveHappened()
        {
            var id = 666;

            _userService.Remove(id);

            A.CallTo(_repository).Where(call => call.Method.Name == nameof(_repository.Remove) && call.Method.IsGenericMethod)
                .WithVoidReturnType().MustHaveHappenedOnceExactly();
            A.CallTo(() => _repository.SaveChanges()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void GetListOfBirthday_Nothing_ListDto()
        {
            MapperConfig.ConfigureAutomapper();
            IEnumerable<User> users = new[] {new User {UserId = 1, BirthDate = DateTime.Today}};
            var expectedIds = new[] { 1 };

            Expression<Func<User, bool>> filter = user => user.BirthDate.Date.Day == DateTime.Today.Day
                                                          && user.BirthDate.Date.Month == DateTime.Today.Month;


            A.CallTo(() => _repository.Get<User>(filter,null)).Returns(users);

            var lisOfUsers = _userService.GetListOfBirthdays() as List<UserDto>;

           
            Assert.Equal(expectedIds.Length, lisOfUsers.Count);

            for (int i = 0; i < expectedIds.Length; i++)
            {
                Assert.Equal(expectedIds[i],lisOfUsers[i].UserId);
            }
        }

    }
}