using HiQo.StaffManagement.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace HiQo.StaffManagement.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}