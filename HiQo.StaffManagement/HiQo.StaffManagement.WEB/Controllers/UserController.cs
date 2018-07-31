using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionLevelService _positionLevelService;
        private readonly IPositionService _positionService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IDepartmentService departmentService,
            ICategoryService categoryService, IPositionService positionService,
            IPositionLevelService positionLevelService, IRoleService roleService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionLevelService));
            _positionLevelService = positionLevelService ?? throw new ArgumentNullException(nameof(positionLevelService));
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

        public ActionResult Index()
        {
            var listOfUsersForView = Mapper.Map<IEnumerable<UserDto>, IEnumerable<UserViewModel>>(_userService.GetAll());

            return View(listOfUsersForView);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var userDto = _userService.GetById(id);
            var user = Mapper.Map<UserDto, UserViewModel>(userDto);

            InitializeDictionary(user);

            return View(user);
        }

        [HttpPost]
        public ActionResult Creation(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(Mapper.Map<UserViewModel, UserDto>(user));
            }

            var listOfUsersForView =
                Mapper.Map<IEnumerable<UserDto>, IEnumerable<UserViewModel>>(_userService.GetAll());

            return View("Index", listOfUsersForView);
        }

        [HttpGet]
        public ActionResult Profiles(int id)
        {
            var user = Mapper.Map<UserDto, UserViewModel>(_userService.GetById(id));
            InitializeDictionary(user);

            return View(user);
        }

        private void InitializeDictionary(UserViewModel user)
        {
            user.DictionaryOfDepartments = _departmentService.NameByIdDictionary();
            user.DictionaryOfCategories = _categoryService.NameByIdDictionary();
            user.DictionaryOfPositions = _positionService.NameByIdDictionary();
            user.DictionaryOfPositionLevels = _positionLevelService.NameByIdDictionary();
            user.DictionaryOfRoles = _roleService.NameByIdDictionary();
        }
    }
}