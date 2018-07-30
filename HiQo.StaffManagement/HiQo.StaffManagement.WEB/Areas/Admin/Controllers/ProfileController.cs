using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WEB.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionLevelService _positionLevelService;
        private readonly IPositionService _positionService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public ProfileController(ICategoryService categoryService, IDepartmentService departmentService,
            IPositionLevelService positionLevelService, IPositionService positionService, IRoleService roleService,
            IUserService userService)
        {
            _categoryService = categoryService;
            _departmentService = departmentService;
            _positionLevelService = positionLevelService;
            _positionService = positionService;
            _roleService = roleService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            var listOfUsers = _userService.GetAll();

            return View(Mapper.Map<IEnumerable<UserDto>, List<UserViewModel>>(listOfUsers));
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var userDto = _userService.GetById(id);
            var user = Mapper.Map<UserDto, UserViewModel>(userDto);

            InitializeDictionary(user);

            return View("Creation", user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = new UserViewModel();

            InitializeDictionary(user);

            return View("Creation", user);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _userService.Remove(id);
            return View("Index", Mapper.Map<IEnumerable<UserDto>, List<UserViewModel>>(_userService.GetAll()));
        }
        [HttpPost]
        public ActionResult Creation(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserId != 0)
                    _userService.Update(Mapper.Map<UserViewModel, UserDto>(user));
                else
                    _userService.Add(Mapper.Map<UserViewModel, UserDto>(user));
            }

            return View("Index", Mapper.Map<IEnumerable<UserDto>, List<UserViewModel>>(_userService.GetAll()));
        }

        private void InitializeDictionary(UserViewModel user)
        {
            user.DictionaryOfDepartments = _departmentService.GetDictionary();
            user.DictionaryOfCategories = _categoryService.GetDictionary();
            user.DictionaryOfPositions = _positionService.GetDictionary();
            user.DictionaryOfPositionLevels = _positionLevelService.GetDictionary();
            user.DictionaryOfRoles = _roleService.GetDictionary();
        }
    }
}