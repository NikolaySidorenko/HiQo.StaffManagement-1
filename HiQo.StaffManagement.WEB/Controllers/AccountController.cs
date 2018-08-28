using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await _authService.GetExternalLoginInfoAsync();

            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            //var result = await _authService.ExternalSignInAsync(loginInfo, isPersistent: false);
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToAction("Index", "Home");
            //    case SignInStatus.RequiresVerification:
            //    //   return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
            //    case SignInStatus.Failure:
            //    default:
            //        // If the user does not have an account, then prompt the user to create an account
            //        ViewBag.ReturnUrl = returnUrl;
            //        ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
            //        return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });

            //}
            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var user = new UserViewModel { UserName = model.Email, Email = model.Email };
                var result = await _authService.RegisterUserAsync(Mapper.Map<UserDto>(user));
                if (result)
                {
                    await _authService.LoginUserAsync(Mapper.Map<UserDto>(user));
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [AllowAnonymous]
        [ActionName("signin-google")]
        public ActionResult ExternalLoginCallbackRedirect(string returnUrl)
        {
            return RedirectPermanent("/Account/ExternalLoginCallback");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
            }
            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
    
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
    }
}