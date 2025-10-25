using GameTracker.Entity.Account;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.ViewModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Controllers.Account
{
    public class ProfileController : Controller
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IUpdateProfileService _updateProfileService;
        private readonly IUserStatusService _deleteUserService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountVerificationService _accountVerificationService;

        public ProfileController(IUserAuthService userAuthService, IUpdateProfileService updateProfile,
            IUserStatusService deleteUserService, IAuthenticationService authenticationService, IAccountVerificationService accountVerificationService)
        {
            _userAuthService = userAuthService;
            _updateProfileService = updateProfile;
            _deleteUserService = deleteUserService;
            _authenticationService = authenticationService;
            _accountVerificationService = accountVerificationService;
        }

        [Authorize]
        public IActionResult Page()
        {
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userAuthService.GetUser(id);

            if(user == null) return RedirectToAction("Logout", "Account");

            // =========TEST===========

            Console.WriteLine(User.FindFirstValue("Status").ToString());
            Console.WriteLine(user.Status.ToString());
            Console.WriteLine(user.Status.ToString() == User.FindFirstValue("Status").ToString());

            // =========================

            return View("~/Views/Account/Page.cshtml", user);
        }

        [HttpPost]
        public IActionResult ConfirmEmail(ConfirmEmailViewModel data)
        {
            bool isActive;
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _updateProfileService.ActivateUser(_userAuthService.GetUser(id), data.Code, out isActive);

            if (!isActive)
                ModelState.AddModelError(string.Empty, "Неверный код подтверждения");

            return View("~/Views/Account/Page.cshtml", _userAuthService.GetUser(id));
        }

        [HttpPost]
        public IActionResult SendCode()
        {
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userAuthService.GetUser(id);
            _accountVerificationService.SendActivationCode(user);

            return RedirectToAction("Page", "Profile");
        }

        [HttpPost]
        public IActionResult UpdateProfile(ProfileUpdateViewModel profileData)
        {
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userAuthService.GetUser(id);

            _updateProfileService.UpdateProfile(profileData, user);
            return RedirectToAction("Page", "Profile");
        }

        [HttpPost]
        public IActionResult DeleteUser(Guid id)
        {
            _deleteUserService.DeleteUser(_userAuthService.GetUser(id));
            _authenticationService.SignOutAuth();
            return RedirectToAction("Index", "Home");
        }
    }
}
