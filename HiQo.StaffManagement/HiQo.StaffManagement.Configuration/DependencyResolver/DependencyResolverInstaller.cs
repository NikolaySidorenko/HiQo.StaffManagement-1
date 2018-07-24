using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;

namespace HiQo.StaffManagement.Configuration.DependencyResolver
{
    public class DependencyResolverInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        { 
            container.Register(Component.For<IPositionLevelRepository>()
                .ImplementedBy<PositionLevelRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IRepository>().ImplementedBy<Repository>().LifestylePerWebRequest());

            container.Register(Component.For<IPositionLevelService>().ImplementedBy<PositionLevelService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<StaffManagementContext>().LifeStyle.PerWebRequest);
        }
    }
}