using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Controllers.Account
{
    public class AccountRecovery : Controller
    {
        IUserAuthService _userAuthService;
        IUserStatusService _userStatusService;
        IAuthenticationService _authenticationService;

        public AccountRecovery(IUserAuthService userAuthService, IUserStatusService userStatusService, IAuthenticationService authenticationService)
        {
            _userAuthService = userAuthService;
            _userStatusService = userStatusService;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View("~/Views/Account/AccountRecovery.cshtml");
        }

        [HttpPost]
        public IActionResult Recovery()
        {
            var user = _userAuthService.GetUser(Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            _userStatusService.RecoveryUser(user);
            user = _userAuthService.GetUser(Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            _authenticationService.SignInAuth(user.Id, user.Nickname, user.Status, user.Role);

            return RedirectToAction("Page", "Profile");
        }
    }
}
