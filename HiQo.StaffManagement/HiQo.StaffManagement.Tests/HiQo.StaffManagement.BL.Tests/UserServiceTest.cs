using System;
using System.Runtime.CompilerServices;
using FakeItEasy;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.BL.Services;
using Xunit;
namespace HiQo.StaffManagement.BL.Tests
{
    public class UserServiceTest
    {
        private readonly IUserService _fakeUserService;

        public UserServiceTest()
        {
            _fakeUserService = A.Fake<IUserService>();
        }

        [Fact]
        public void Add_UserDto_ShouldReturnNewUser()
        {
            var user = new UserDto
            {
                FirstName = "user",
                LastName = "usero",
                BirthDate = new DateTime(1999, 5, 5),
                MainPhoneNumber = "+375291234577",
                Email = "user@gmail.com",
                RoleId = 1,
                PositionLevelId = 10,
                PositionId = 1,
                CategoryId = 1,
                DepartmentId = 1
            };

            A.CallTo(() => _fakeUserService.Add(user));

            Assert.True(_fakeUserService.IsExists(user.UserId));
        }

        [Fact]
        public void IsExist_UserDto_ShouldReturnTrue()
        {    

            var user = new UserDto
            {
                UserId = 1,
                FirstName = "Kirill",
                LastName = "Dudkov",
                BirthDate = new DateTime(1997, 10, 21),
                MainPhoneNumber = "+375445353430",
                Email = "kirilldudkov@gmail.com",
                RoleId = 1,
                PositionLevelId = 1,
                PositionId = 6,
                CategoryId = 3,
                DepartmentId = 2
            };


        }
    }
}
