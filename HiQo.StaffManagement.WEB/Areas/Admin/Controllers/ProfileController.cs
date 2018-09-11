using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
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

        [Authorize]
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
            var user = Mapper.Map<UpdateUserViewModel>(Mapper.Map<UserUpdateDto>(userDto));
            ViewBag.Key = ConfigurationManager.AppSettings["APIBingMaps"];

            InitializeDictionary(user);

            return View("Creation", user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = new UpdateUserViewModel();
            ViewBag.Key = ConfigurationManager.AppSettings["APIBingMaps"];
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
        public ActionResult Creation(UpdateUserViewModel user)
        {
            var validator = _validatorFactory.GetValidator<UpdateUserViewModel>();
            var result = validator.Validate(user);

            if (result.IsValid)
            {
                if (user.UserId != 0)
                {
                    _userService.Update(Mapper.Map<UpdateUserViewModel, UserUpdateDto>(user));
                }
                else
                {
                    _userService.Add(Mapper.Map<UpdateUserViewModel, UserDto>(user));
                }

                return RedirectToAction("Index");
            }
            else
            {
                SetErrorsInModelState(result.Errors);
                InitializeDictionary(user);

                return View(user);
            }

        }

        private void InitializeDictionary(UpdateUserViewModel user)
        {
            user.DictionaryOfDepartments = _upsertService.GetDictionaryNameByIdDepartment();
            user.DictionaryOfCategories = _upsertService.GetDictionaryNameByIdCategory();
            user.DictionaryOfPositions = _upsertService.GetDictionaryNameByIdPosition();
            user.DictionaryOfPositionLevels = _upsertService.GetDictionaryNameByIdPositionLevel();
            user.DictionaryOfRoles = _upsertService.GetDictionaryNameByIdRole();
        }

        private void SetErrorsInModelState(IEnumerable<ValidationFailure> errors)
        {
            foreach (var failure in errors)
            {
                ModelState.AddModelError(failure.PropertyName,
                    failure.ErrorMessage);
            }
        }
    }
}