using GameTracker.Entity.Account;
using GameTracker.Entity.Games;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.Interfaces.Games;
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
        private readonly IUserStatusService _userStatusService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountVerificationService _accountVerificationService;
        private readonly IUserLibraryService _userLibraryService;
        private readonly IGameCatalogService _gameCatalogService;

        public ProfileController(IUserAuthService userAuthService, IUpdateProfileService updateProfile,
            IUserStatusService userStatusService, IAuthenticationService authenticationService, IAccountVerificationService accountVerificationService,
            IUserLibraryService userLibraryService, IGameCatalogService gameCatalogService)
        {
            _userAuthService = userAuthService;
            _updateProfileService = updateProfile;
            _userStatusService = userStatusService;
            _authenticationService = authenticationService;
            _accountVerificationService = accountVerificationService;
            _userLibraryService = userLibraryService;
            _gameCatalogService = gameCatalogService;
        }

        [Authorize]
        public IActionResult Page()
        {
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userAuthService.GetUser(id);
            var userGames = _userLibraryService.GetUserLibrary(user.Id);

            if (user == null) return RedirectToAction("Logout", "Account");

            var accountPageViewModel = new AccountDataViewModel(
                user.Nickname,
                user.Role,
                user.Email,
                user.Login,
                user.Status
            );

            var vm = new AccountPageViewModel
                (
                    accountPageViewModel,
                    new ConfirmEmailViewModel(),
                    userGames
                );

            return View("~/Views/Account/Page.cshtml", vm);
        }

        [HttpPost]
        public IActionResult ConfirmEmail(ConfirmEmailViewModel data)
        {
            bool isActive;
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _updateProfileService.ActivateUser(_userAuthService.GetUser(id), data.Code, out isActive);

            if (!isActive)
                ModelState.AddModelError(string.Empty, "Неверный код подтверждения");

            return RedirectToAction("Page", "Profile");
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
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser()
        {
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            _userStatusService.DeleteUser(_userAuthService.GetUser(id));
            _authenticationService.SignOutAuth();
            return RedirectToAction("Index", "Home");
        }
    }
}
