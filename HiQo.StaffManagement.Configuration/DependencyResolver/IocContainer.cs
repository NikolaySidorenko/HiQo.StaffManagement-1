using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using FluentValidation.Mvc;
using HiQo.StaffManagement.Configuration.Shared;
using HiQo.StaffManagement.Configuration.Shared.ValidatorResolver;

namespace HiQo.StaffManagement.Configuration.DependencyResolver
{
    public static class IocContainer
    {
        public static void Setup(string assemblyName)
        {
            var container = new WindsorContainer();

            var installer = new ControllersInstaller(assemblyName);
            installer.Install(container, null);

            container.Register(Component.For<IWindsorContainer>());

            var installerValidators = new ValidatorsInstaller();
            installerValidators.Install(container, null);

            var dependencyInstaller = new DependencyInstaller();
            dependencyInstaller.Install(container, null);

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = container.Resolve<IValidatorFactory>();
            });
        }
    }
}