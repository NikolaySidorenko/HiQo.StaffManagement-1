using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using FluentValidation;
using FluentValidation.Mvc;
using HiQo.StaffManagement.Configuration.Shared;
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

            var def = configuration.Services.GetFilterProviders().Single(i => i is ActionDescriptorFilterProvider);
            configuration.Services.Remove(typeof(IFilterProvider), def);
            configuration.Services.Add(typeof(IFilterProvider),new WindsorFilterProvider(container));

            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = container.Resolve<IValidatorFactory>();
            });
        }
    }
}