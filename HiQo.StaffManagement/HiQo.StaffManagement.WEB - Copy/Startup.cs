using AutoMapper;
using HiQo.StaffManagement.Configuration.DependencyResolver;
using HiQo.StaffManagement.Configuration.Mappings;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HiQo.StaffManagement.WEB.Startup))]
namespace HiQo.StaffManagement.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            MapperConfig.ConfigureAutomapper();
            CastleWinsdorDependencyResolver.Initialize();
        }


    }
}
