﻿using System.Reflection;
using System.Web.Mvc;

namespace HiQo.StaffManagement.WEB.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name:"Admin_default",
                url:"Admin/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { Assembly.GetExecutingAssembly().GetName().Name + ".Areas.Admin.Controllers" }
            );
        }
    }
}
