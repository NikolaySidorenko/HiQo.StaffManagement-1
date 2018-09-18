using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HiQo.StaffManagement.WebApi.App_Start.Startup))]

namespace HiQo.StaffManagement.WebApi.App_Start

{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}