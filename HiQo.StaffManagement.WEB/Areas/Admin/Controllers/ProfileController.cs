using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;
using HiQo.StaffManagement.WEB.App_Start.Filters;

namespace HiQo.StaffManagement.WEB.Areas.Admin.Controllers
{
    [LogActionFilter]
    public class ProfileController : Controller
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly IValidatorFactory _validatorFactory;

        public ProfileController(IServiceFactory serviceFactory, IValidatorFactory validatorFactory)
        {
            _serviceFactory = serviceFactory;
            _validatorFactory = validatorFactory;
        }

        [Authorize]
        public ActionResult Index()
        {
            var listOfUsersForView =
                Mapper.Map<IEnumerable<UserDto>, IEnumerable<UpdateUserViewModel>>(_serviceFactory.Create<IUserService>().GetAll());

            return View(listOfUsersForView);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var userDto = _serviceFactory.Create<IUserService>().GetById(id);
            var user = Mapper.Map<UpdateUserViewModel>(userDto);
            ViewBag.Key = _serviceFactory.Create<IConfigurationManager>().GetAppSettings("APIBingMaps");

            InitializeDictionary(user);

            return View("Creation", user);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = new UpdateUserViewModel();
            ViewBag.Key = _serviceFactory.Create<IConfigurationManager>().GetAppSettings("APIBingMaps");
            InitializeDictionary(user);

            return View("Creation", user);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _serviceFactory.Create<IUserService>().Delete(id);
            var listOfUsersForView =
                Mapper.Map<IEnumerable<UserDto>, IEnumerable<UpdateUserViewModel>>(_serviceFactory.Create<IUserService>().GetAll());

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
                    _serviceFactory.Create<IUserService>().Update(Mapper.Map<UpdateUserViewModel, UserDto>(user));
                }
                else
                {
                    _serviceFactory.Create<IUserService>().Add(Mapper.Map<UpdateUserViewModel, UserDto>(user));
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
            user.DictionaryOfDepartments = _serviceFactory.Create<IUpsertService>().GetListNameByIdDepartment();
            user.DictionaryOfCategories = _serviceFactory.Create<IUpsertService>().GetListNameByIdCategory();
            user.DictionaryOfPositions = _serviceFactory.Create<IUpsertService>().GetListNameByIdPosition();
            user.DictionaryOfPositionLevels = _serviceFactory.Create<IUpsertService>().GetListNameByIdPositionLevel();
            user.DictionaryOfRoles = _serviceFactory.Create<IUpsertService>().GetListNameByIdRole();
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