﻿using System;
using System.Web;
using System.Web.Mvc;
using HiQo.StaffManagement.WEB.App_Start.Filters;

namespace HiQo.StaffManagement.WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleAllErrorAttribute());
            filters.Add(new LogActionFilter());
        }
    }

}