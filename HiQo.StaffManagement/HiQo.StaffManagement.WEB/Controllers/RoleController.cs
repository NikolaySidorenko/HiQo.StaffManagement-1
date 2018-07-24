using System.Web.Mvc;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: Role
        public ActionResult Index()
        {
            var listOfRoles = _roleService.GetAll();

            return View(listOfRoles);
        }
    }
}