﻿using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.ViewModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Controllers.Account
{
    public class AccountRecoveryController : Controller
    {
        IUserAuthService _userAuthService;
        IUserStatusService _userStatusService;
        IAuthenticationService _authenticationService;
        IPasswordRecoveryService _passwordRecoveryService;
        IUpdateProfileService _userUpdateProfile;

        public AccountRecoveryController(IUserAuthService userAuthService, IUserStatusService userStatusService, 
            IAuthenticationService authenticationService, IPasswordRecoveryService passwordRecoveryService, 
            IUpdateProfileService userUpdateProfile)
        {
            _userAuthService = userAuthService;
            _userStatusService = userStatusService;
            _authenticationService = authenticationService;
            _passwordRecoveryService = passwordRecoveryService;
            _userUpdateProfile = userUpdateProfile;
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
