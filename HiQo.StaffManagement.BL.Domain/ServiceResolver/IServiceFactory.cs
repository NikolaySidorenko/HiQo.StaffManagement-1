using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.BL.Domain.ServiceResolver
{
    public interface IServiceFactory
    {
        T Create<T>() where T: IService;
    }
}
