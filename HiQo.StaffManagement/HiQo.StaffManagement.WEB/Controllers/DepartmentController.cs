using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            using (StaffManagementContext context = new StaffManagementContext())
            {
                IDepartmentRepository departmentRepository = new DepartmentRepository(context);
                IRepository baseRepository = new Repository(context);
                DepartmentService service = new DepartmentService(departmentRepository, baseRepository);
                var obj = service.GetAll();
                return View(obj);
            }
        }
    }
}