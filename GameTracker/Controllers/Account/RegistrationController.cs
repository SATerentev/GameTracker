using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers.Account
{
    public class RegistrationController : Controller
    {
        private IRegisterService _registerService;
        private IAuthenticationService _authenticationService;

        public RegistrationController(IRegisterService registerService, IAuthenticationService authenticationService)
        {
            _registerService = registerService;
            _authenticationService = authenticationService;
        }

        public IActionResult Registration()
        {
            return View("~/Views/Account/Registration.cshtml");
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationViewModel userData)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/Registration.cshtml", userData);

            var user = _registerService.Register(userData);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с таким логином уже существует");
                return View("~/Views/Account/Registration.cshtml", userData);
            }

            _authenticationService.SignInAuth(user.Id, user.Nickname, user.Status, user.Role);
            return RedirectToAction("Page", "Profile");
        }
    }
}
