using System.Reflection;
using System.Web.Http;
using HiQo.StaffManagement.Configuration.DependencyResolver;
using HiQo.StaffManagement.Configuration.Profiles;

namespace HiQo.StaffManagement.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MapperConfig.ConfigureAutomapper();
            IocContainer.Setup(Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
