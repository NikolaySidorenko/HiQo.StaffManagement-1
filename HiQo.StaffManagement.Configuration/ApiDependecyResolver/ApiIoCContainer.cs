using System.Web.Http;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using FluentValidation;
using FluentValidation.Mvc;
using HiQo.StaffManagement.Configuration.Shared;
using HiQo.StaffManagement.Configuration.Shared.ServiceResolver;
using HiQo.StaffManagement.Configuration.Shared.ValidatorResolver;

namespace HiQo.StaffManagement.Configuration.ApiDependecyResolver
{
    public class ApiIocContainer
    {
        public static void ConfigureWindsor(string assemblyName, HttpConfiguration configuration)
        {
            var container = new WindsorContainer();

            var dependencyInstaller = new DependencyInstaller();
            dependencyInstaller.Install(container, null);

            var apiInstaller = new ApiControllerInstaller(assemblyName);
            apiInstaller.Install(container, null);

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            var dependencyResolver = new ApiResolver(container);
            configuration.DependencyResolver = dependencyResolver;

            var installerValidators = new ValidatorsInstaller();
            installerValidators.Install(container, null);

            var servicesInstaller = new ServiceInstaller();
            servicesInstaller.Install(container, null);

            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = container.Resolve<IValidatorFactory>();
            });
        }
    }
}