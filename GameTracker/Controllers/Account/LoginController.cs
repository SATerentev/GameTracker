using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers.Account
{
    public class LoginController : Controller
    {
        private IUserAuthService _userAuthService;
        private IAuthenticationService _authenticationService;

        public LoginController(IUserAuthService loginService, IAuthenticationService authenticationService)
        {
            _userAuthService = loginService;
            _authenticationService = authenticationService;
        }

        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userData)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/Login.cshtml", userData);

            var user = _userAuthService.Login(userData);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с такими логином и паролем не найден");
                return View("~/Views/Account/Login.cshtml", userData);
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
    }
}
