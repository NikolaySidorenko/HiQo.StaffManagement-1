using System;
using Castle.MicroKernel;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.Configuration.Shared.ServiceResolver
{
    public class WindsorServiceFactory : IServiceFactory
    {
        private readonly IKernel _kernel;

        public WindsorServiceFactory(IKernel kernel)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
        }

        public T Create<T>() where T: IService
        {
            return _kernel.Resolve<T>();
        }
    }
}
