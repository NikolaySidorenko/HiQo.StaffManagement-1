using System.Collections.Generic;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.BL.Services
{
    public class UpsertService : IUpsertService
    {
        private readonly IServiceFactory _serviceFactory;

        public UpsertService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public List<KeyValuePair<int, string>> GetListNameByIdDepartment()
        {
            return _serviceFactory.Create<IDepartmentService>().GetListNameById();
        }

        public List<KeyValuePair<int, string>> GetListNameByIdCategory()
        {
            return _serviceFactory.Create<ICategoryService>().GetListNameById();
        }

        public List<KeyValuePair<int, string>> GetListNameByIdPosition()
        {
            return _serviceFactory.Create<IPositionService>().GetListNameById();
        }

        public List<KeyValuePair<int, string>> GetListNameByIdPositionLevel()
        {
            return _serviceFactory.Create<IPositionLevelService>().GetListNameById();
        }

        public List<KeyValuePair<int, string>> GetListNameByIdRole()
        {
            return _serviceFactory.Create<IRoleService>().GetListNameById();
        }

    }
}