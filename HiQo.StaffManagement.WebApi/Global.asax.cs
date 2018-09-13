﻿using System.Reflection;
using System.Web.Http;
using HiQo.StaffManagement.Configuration.ApiDependecyResolver;
using HiQo.StaffManagement.Configuration.Profiles;

namespace HiQo.StaffManagement.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MapperConfig.ConfigureAutomapper();
            ApiIocContainer.ConfigureWindsor(Assembly.GetExecutingAssembly().GetName().Name,GlobalConfiguration.Configuration);
        }
    }
}
