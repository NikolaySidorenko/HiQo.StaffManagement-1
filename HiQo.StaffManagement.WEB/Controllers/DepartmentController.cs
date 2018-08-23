using System.Web.Mvc;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Department
        public ActionResult Index()
        {
            var listOfDepartments = _departmentService.GetAll();

            return View(listOfDepartments);
        }
    }
}