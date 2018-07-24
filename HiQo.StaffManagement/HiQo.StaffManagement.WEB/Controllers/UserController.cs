using System.Web.Mvc;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            var listOfUsers = _userService.GetAll();

            return View(listOfUsers);
        }
    }
}