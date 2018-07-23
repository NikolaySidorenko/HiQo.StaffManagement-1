using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;

namespace HiQo.StaffManagement.Configuration.DependencyResolver
{
    public class BusinessLogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        { 
            container.Register(Component.For<IPositionLevelRepository>()
                .ImplementedBy<PositionLevelRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IRepository>().ImplementedBy<BaseRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IPositionLevelService>().ImplementedBy<PositionLevelService>()
                .LifestylePerWebRequest());
        }
    }
}