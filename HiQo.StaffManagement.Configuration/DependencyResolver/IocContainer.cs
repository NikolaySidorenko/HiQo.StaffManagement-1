using System.Web;
using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using FluentValidation.Mvc;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.Configuration.DependencyResolver.ValidatorResolver;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Identity;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Identity;
using HiQo.StaffManagement.DAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace HiQo.StaffManagement.Configuration.DependencyResolver
{
    public static class IocContainer
    {
        private static IWindsorContainer _container;

        public static void Setup(string assemblyName)
        {
            _container = new WindsorContainer();

            ControllersInstaller installer = new ControllersInstaller(assemblyName);
            installer.Install(_container, null);
            
            ValidatorsInstaller installerValidators = new ValidatorsInstaller();
            installerValidators.Install(_container,null);

            DependencyServicesResolver();
            DependencyRepositoriesResolver();
            DependencyContextsResolver();

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            FluentValidationModelValidatorProvider.Configure(provider => {
                provider.ValidatorFactory = _container.Resolve<IValidatorFactory>();
            });
        }

        private static void DependencyServicesResolver()
        {
            _container.Register(Component.For<IPositionLevelService>().ImplementedBy<PositionLevelService>()
                .LifestylePerWebRequest());

            _container.Register(Component.For<IUserService>().ImplementedBy<UserService>()
                .LifestylePerWebRequest());

            _container.Register(Component.For<IDepartmentService>().ImplementedBy<DepartmentService>()
                .LifestylePerWebRequest());

            _container.Register(Component.For<ICategoryService>().ImplementedBy<CategoryService>()
                .LifestylePerWebRequest());

            _container.Register(Component.For<IRoleService>().ImplementedBy<RoleService>()
                .LifestylePerWebRequest());

            _container.Register(Component.For<IPositionService>().ImplementedBy<PositionService>()
                .LifestylePerWebRequest());

            _container.Register(Component.For<IUpsertService>().ImplementedBy<UpsertService>()
                .LifestylePerWebRequest());

            _container.Register(Component.For<IAuthService>().ImplementedBy<AuthService>()
                .LifestylePerWebRequest());

        }

        private static void DependencyRepositoriesResolver()
        {
            _container.Register(Component.For<IPositionLevelRepository>()
                .ImplementedBy<PositionLevelRepository>().LifestylePerWebRequest());

            _container.Register(Component.For<IUserRepository>()
                .ImplementedBy<UserRepository>().LifestylePerWebRequest());

            _container.Register(Component.For<IDepartmentRepository>()
                .ImplementedBy<DepartmentRepository>().LifestylePerWebRequest());

            _container.Register(Component.For<ICategoryRepository>()
                .ImplementedBy<CategoryRepository>().LifestylePerWebRequest());

            _container.Register(Component.For<IPositionRepository>()
                .ImplementedBy<PositionRepository>().LifestylePerWebRequest());

            _container.Register(Component.For<IRoleRepository>()
                .ImplementedBy<RoleRepository>().LifestylePerWebRequest());

            _container.Register(Component.For<IRepository>().ImplementedBy<Repository>().LifestylePerWebRequest());

            _container.Register(Component.For<IUserStore<User, int>>().ImplementedBy<UserStore>()
                .LifestylePerWebRequest());

        }

        private static void DependencyContextsResolver()
        {
            _container.Register(Component.For<StaffManagementContext>().LifeStyle.PerWebRequest);

            _container.Register(Component.For<IAuthenticationManager>()
                .UsingFactoryMethod(GetAuthenticationManager, managedExternally: true)
                .LifestyleTransient());

            _container.Register(Component.For<IUserManager>().ImplementedBy<ApplicationUserManager>().LifestylePerWebRequest());
        }

        private static IAuthenticationManager GetAuthenticationManager(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            var owinContext = new HttpContextWrapper(HttpContext.Current).GetOwinContext();

            return owinContext.Authentication;
        }

    }
}


