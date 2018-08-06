using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;
using HiQo.StaffManagement.Core.FluentValidator;

namespace HiQo.StaffManagement.Configuration.DependencyResolver.ValidatorResolver
{
    public class ValidatorsInstaller : IWindsorInstaller
    {
        public ValidatorsInstaller()
        {
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<UserValidator>()
                .ForEach(result =>
                {
                    container.Register(Component.For(result.InterfaceType)
                        .ImplementedBy(result.ValidatorType)
                        .LifeStyle.Singleton);
                });
        }
    }
}