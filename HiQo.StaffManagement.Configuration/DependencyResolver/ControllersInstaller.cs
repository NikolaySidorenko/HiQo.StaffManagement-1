using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace HiQo.StaffManagement.Configuration.DependencyResolver
{
    public class ControllersInstaller : IWindsorInstaller
    {
        private readonly string _assemblyProjectName;

        public ControllersInstaller(string assemblyName)
        {
            _assemblyProjectName = assemblyName;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(_assemblyProjectName)
                .BasedOn<IController>()
                .Configure(configurer => configurer.Named(configurer.Implementation.FullName))
                .LifestylePerWebRequest());
        }
    }
}