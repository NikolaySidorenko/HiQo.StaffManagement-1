using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var users = Mapper.Map<IEnumerable<UserDto>, IEnumerable<UserBirthdayViewModel>>(_userService.GetListOfBirthdays());
            return View(users);
        }
    }
}