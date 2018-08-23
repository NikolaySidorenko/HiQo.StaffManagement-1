using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IValidatorFactory _validatorFactory;

        public AccountController(IAuthService authService, IValidatorFactory validatorFactory)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _validatorFactory = validatorFactory ?? throw new ArgumentNullException(nameof(validatorFactory));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegistrationUserViewModel user)
        {
            var validator = _validatorFactory.GetValidator<RegistrationUserViewModel>();
            var result = validator.Validate(user);

            if (result.IsValid)
            {
                var res = await _authService.RegisterUserAsync(Mapper.Map<UserDto>(user));
                
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            _authService.LogOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel user)
        {
            var validator = _validatorFactory.GetValidator<LoginViewModel>();
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                return View(user);
            }

            var autenticationResult = await _authService.LoginUserAsync(Mapper.Map<UserDto>(user));

            if (!autenticationResult)
            {
                ModelState.AddModelError(string.Empty, "Wrong password or email");
                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}