﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;
using HiQo.StaffManagement.WEB.App_Start.Filters;

namespace HiQo.StaffManagement.WEB.Controllers
{
    [LogActionFilter]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUpsertService _upsertService;

        public UserController(IUserService userService, IUpsertService upsertService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _upsertService = upsertService ?? throw new ArgumentNullException(nameof(userService));
        }
        
        [Authorize]
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

        [HttpGet]
        public ActionResult ShowMap()
        {
            //var locations = new List<MapViewModel>();
            //locations.Add(new MapViewModel() { FullName = "Dima", Latitude = 28.110749, Longitude = 77.34375 });
            //locations.Add(new MapViewModel() { FullName = "Kirill", Latitude = 53.904148, Longitude = 27.5430120 });
            var locations = Mapper.Map<IEnumerable<UserDto>, IEnumerable<MapViewModel>>(_userService.GetAll());

            return View(locations);
        }

        private void InitializeDictionary(UserViewModel user)
        {
            user.DictionaryOfDepartments = _upsertService.GetDictionaryNameByIdDepartment();
            user.DictionaryOfCategories = _upsertService.GetDictionaryNameByIdCategory();
            user.DictionaryOfPositions = _upsertService.GetDictionaryNameByIdPosition();
            user.DictionaryOfPositionLevels = _upsertService.GetDictionaryNameByIdPositionLevel();
            user.DictionaryOfRoles = _upsertService.GetDictionaryNameByIdRole();
        }
    }
}