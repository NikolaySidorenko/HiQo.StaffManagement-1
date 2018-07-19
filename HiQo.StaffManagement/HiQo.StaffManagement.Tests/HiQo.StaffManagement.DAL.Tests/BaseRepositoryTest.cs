using System.Linq;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;
using Xunit;

namespace HiQo.StaffManagement.DAL.Tests
{
    public class BaseRepositoryTest
    {
        private readonly UserRepository _userRepository = new UserRepository(new StaffManagementContext());
        private readonly IRepository<Department> _departmnetRepository = new DepartmentRepository(new StaffManagementContext());

        [Fact]
        public void TestMethod()
        {
            var user = _userRepository.GetById(1).FirstName;

            Assert.Equal("Kirill", user);
        }

        [Fact]
        public void TestMethod2()
        {

            Assert.Equal(1,1);
        }
    }
}