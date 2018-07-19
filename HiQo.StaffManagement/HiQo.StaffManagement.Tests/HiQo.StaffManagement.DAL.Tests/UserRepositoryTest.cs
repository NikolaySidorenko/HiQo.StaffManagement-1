using System.Linq;
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
        private readonly IUserRepository fakeRepository;

        public UserRepositoryTest()
        {
            fakeRepository = A.Fake<IUserRepository>();
        }

        [Fact]
        public void TestMethod()
        {
            var fakeObjUser = _userRepository.GetById(1);

            A.CallTo(fakeRepository)
                .Where(call => call.Method.Name == "GetById")
                .WithReturnType<User>()
                .Returns(fakeObjUser);

            var response = fakeRepository.GetById(1);

            Assert.Equal(fakeObjUser, response);
        }
    }
}