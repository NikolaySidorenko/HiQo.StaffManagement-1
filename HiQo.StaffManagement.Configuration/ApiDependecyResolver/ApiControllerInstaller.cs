using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace HiQo.StaffManagement.Configuration.ApiDependecyResolver
{
    class ApiControllerInstaller : IWindsorInstaller
    {
        private readonly string _assemblyName;

        public ApiControllerInstaller(string assemblyName)
        {
            _assemblyName = assemblyName;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(_assemblyName).BasedOn<IHttpController>()
                .LifestylePerWebRequest());
        }
    }

}
