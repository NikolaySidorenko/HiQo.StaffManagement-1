using System;
using FakeItEasy;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;
using Xunit;

namespace HiQo.StaffManagement.DAL.Tests
{
    public class UserRepositoryTest
    {
        private readonly IUserRepository _userRepository = new UserRepository(new StaffManagementContext());
        private readonly IUserRepository _fakeRepository;

        public UserRepositoryTest()
        {
            _fakeRepository = A.Fake<IUserRepository>();
        }

        [Theory]
        [InlineData(1)]
        public void GetById_Id_ObjFound(int id)
        {
            var objUser = _userRepository.GetById(id);

            //A.CallTo(fakeRepository)
            //    .Where(call => call.Method.Name == "GetById")
            //    .WithReturnType<User>()
            //    .Returns(fakeObjUser);

            A.CallTo(() => _fakeRepository.GetById(id)).Returns(objUser);

            Assert.Equal(objUser, _fakeRepository.GetById(id));
        }
    }
}