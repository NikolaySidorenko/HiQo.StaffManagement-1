using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.FluentValidator;
using HiQo.StaffManagement.Core.ViewModels;
using HiQo.StaffManagement.WEB.App_Start.Filters;

namespace HiQo.StaffManagement.WEB.Areas.Admin.Controllers
{
    [LogActionFilter]
    public class ProfileController : Controller
    {
        private readonly IUpsertService _upsertService;
        private readonly IUserService _userService;
        private readonly IValidatorFactory _validatorFactory;

        public ProfileController(IUserService userService, IUpsertService upsertService, IValidatorFactory validatorFactory)
        {
            _userService = userService;
            _upsertService = upsertService;
            _validatorFactory = validatorFactory;
        }

        public ActionResult Index()
        {
            var listOfUsersForView =
                Mapper.Map<IEnumerable<UserDto>, IEnumerable<UserViewModel>>(_userService.GetAll());

            return View(listOfUsersForView);
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
            var listOfUsersForView =
                Mapper.Map<IEnumerable<UserDto>, IEnumerable<UserViewModel>>(_userService.GetAll());

            return View("Index", listOfUsersForView);
        }

        [HttpPost]
        public ActionResult Creation(UserViewModel user)
        {
            var validator = _validatorFactory.GetValidator<UserViewModel>();
            var result = validator.Validate(user);

            if (result.IsValid)
            {
                if (user.UserId != 0)
                {
                    _userService.Update(Mapper.Map<UserViewModel, UserDto>(user));
                }
                else
                {
                    _userService.Add(Mapper.Map<UserViewModel, UserDto>(user));
                }

                var listOfUsersForView =
                    Mapper.Map<IEnumerable<UserDto>, IEnumerable<UserViewModel>>(_userService.GetAll());

                return View("Index", listOfUsersForView);
            }
            else
            {
                InitializeDictionary(user);
                return View(user);
            }

        }

        private void InitializeDictionary(UserViewModel user)
        {
            user.DictionaryOfDepartments = _upsertService.getDictionaryNameByIdDepartment();
            user.DictionaryOfCategories = _upsertService.getDictionaryNameByIdCategory();
            user.DictionaryOfPositions = _upsertService.getDictionaryNameByIdPosition();
            user.DictionaryOfPositionLevels = _upsertService.getDictionaryNameByIdPositionLevel();
            user.DictionaryOfRoles = _upsertService.getDictionaryNameByIdRole();
        }
    }
}