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
        private readonly IRepository _Repository = new Repository(new StaffManagementContext());
        private readonly IRepository _fakeRepository;

        public UserRepositoryTest()
        {
            _fakeRepository = A.Fake<IRepository>();
        }

        [Theory]
        [InlineData(1)]
        public void GetById_Id_ObjFound(int id)
        {
            var objUser = _Repository.GetById<User>(id);

            //A.CallTo(fakeRepository)
            //    .Where(call => call.Method.Name == "GetById")
            //    .WithReturnType<User>()
            //    .Returns(fakeObjUser);

            A.CallTo(() => _fakeRepository.GetById<User>(id)).Returns(objUser);

            Assert.Equal(objUser, _fakeRepository.GetById<User>(id));
        }
    }
}