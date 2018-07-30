﻿using System.Collections.Generic;
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
            _userService = userService;
            _departmentService = departmentService;
            _categoryService = categoryService;
            _positionService = positionService;
            _positionLevelService = positionLevelService;
            _roleService = roleService;
        }

        // GET: User
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

        [HttpPost]
        public ActionResult CreationUser(UserViewModel user)
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