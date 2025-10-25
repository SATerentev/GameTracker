using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.Services.Account;
using GameTracker.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers.Account
{
    public class AuthController : Controller
    {
        private IUserAuthService _userAuthService;
        private IAuthenticationService _authenticationService;
        private IRegisterService _registerService;

        public AuthController(IUserAuthService loginService, IAuthenticationService authenticationService, IRegisterService registerService)
        {
            _userAuthService = loginService;
            _authenticationService = authenticationService;
            _registerService = registerService;
        }

        public IActionResult Auth()
        {
            return View("~/Views/Account/Auth.cshtml");
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userData)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/Auth.cshtml", userData);

            var user = _userAuthService.Login(userData);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с такими логином и паролем не найден");
                return View("~/Views/Account/Auth.cshtml", userData);
            }
            else
            {
                _authenticationService.SignInAuth(user.Id, user.Nickname, user.Status, user.Role);
                return RedirectToAction("Page", "Profile");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _authenticationService.SignOutAuth();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Registration(UserRegistrationViewModel userData)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/Auth.cshtml", userData);

            var user = _registerService.Register(userData);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с таким логином уже существует");
                return View("~/Views/Account/Auth.cshtml", userData);
            }

            _authenticationService.SignInAuth(user.Id, user.Nickname, user.Status, user.Role);
            return RedirectToAction("Page", "Profile");
        }
    }
}
