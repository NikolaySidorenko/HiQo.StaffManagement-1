using System;
using Castle.MicroKernel;
using FluentValidation;

namespace HiQo.StaffManagement.Configuration.DependencyResolver.ValidatorResolver
{
    public class WindsorValidatorFactory: ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        public WindsorValidatorFactory(IKernel kernel)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            if (_kernel.HasComponent(validatorType))
            {
                return _kernel.Resolve(validatorType) as IValidator;
            }

            return null;
        }
    }
}
