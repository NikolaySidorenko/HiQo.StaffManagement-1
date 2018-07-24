using HiQo.StaffManagement.DAL.Context;
using System.Web.Mvc;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (StaffManagementContext context = new StaffManagementContext())
            {
                IUserRepository userRepository = new UserRepository(context);
                IRepository baseRepository = new Repository(context);
                UserService service = new UserService(userRepository, baseRepository);
                var obj = service.GetAll();
                return View(obj);
            }
        }
    }
}