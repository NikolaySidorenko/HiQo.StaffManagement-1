using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;

namespace HiQo.StaffManagement.Configuration.Shared.ServiceResolver
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IServiceFactory>().ImplementedBy<WindsorServiceFactory>());
        }
    }
}
