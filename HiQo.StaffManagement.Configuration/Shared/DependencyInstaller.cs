﻿using System.Web;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Identity;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Identity;
using HiQo.StaffManagement.DAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace HiQo.StaffManagement.Configuration.Shared
{
    public class DependencyInstaller : IWindsorInstaller
    {       
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {           
            DependencyContextsResolver(container);
            DependencyRepositoriesResolver(container);
            DependencyServicesResolver(container);
        }

        private static void DependencyServicesResolver(IWindsorContainer container)
        {
            container.Register(Component.For<IPositionLevelService>().ImplementedBy<PositionLevelService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IUserService>().ImplementedBy<UserService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IDepartmentService>().ImplementedBy<DepartmentService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<ICategoryService>().ImplementedBy<CategoryService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IRoleService>().ImplementedBy<RoleService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IPositionService>().ImplementedBy<PositionService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IUpsertService>().ImplementedBy<UpsertService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IAuthService>().ImplementedBy<AuthService>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IAuthorizationServiceJWT>().ImplementedBy<AuthorizationServiceJWT>()
                .LifestylePerWebRequest());

            container.Register(Component.For<ITokenHandler>().ImplementedBy<TokenHandler>()
                .LifestylePerWebRequest());
        }

        private static void DependencyRepositoriesResolver(IWindsorContainer container)
        {
            container.Register(Component.For<IPositionLevelRepository>()
                .ImplementedBy<PositionLevelRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IUserRepository>()
                .ImplementedBy<UserRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IDepartmentRepository>()
                .ImplementedBy<DepartmentRepository>().LifestylePerWebRequest());

            container.Register(Component.For<ICategoryRepository>()
                .ImplementedBy<CategoryRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IPositionRepository>()
                .ImplementedBy<PositionRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IRoleRepository>()
                .ImplementedBy<RoleRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IRepository>().ImplementedBy<Repository>().LifestylePerWebRequest());

            container.Register(Component.For<IUserStore<User, int>>().ImplementedBy<UserStore>()
                .LifestylePerWebRequest());

        }

        private static void DependencyContextsResolver(IWindsorContainer container)
        {
            container.Register(Component.For<StaffManagementContext>().LifestylePerWebRequest());

            container.Register(Component.For<IAuthenticationManager>()
                .UsingFactoryMethod(GetAuthenticationManager, managedExternally: true)
                .LifestylePerWebRequest());

            container.Register(Component.For<IUserManager>().ImplementedBy<ApplicationUserManager>().LifestylePerWebRequest());
        }

        private static IAuthenticationManager GetAuthenticationManager(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            var owinContext = new HttpContextWrapper(HttpContext.Current).GetOwinContext();

            return owinContext.Authentication;
        }

    }

   
}
