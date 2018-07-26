using System.Web.Mvc;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

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

        [HttpGet]
        public ActionResult GetProfile(int id)
        {
            var userDto = _userService.GetById(id);
            var user = Mapper.Map<UserDto, UserViewModel>(userDto);
            return View("UserProfile",user);
        }

        [HttpGet]
        public ActionResult UpdateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProfile(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                //var user = _userService.GetById(updatedUser.UserId);
                //user = updatedUser;
                //_userService.Update(user);
            }
            return View("UserProfile");
        }

    }
}