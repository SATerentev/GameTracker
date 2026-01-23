using GameTracker.Interfaces.Account;
using GameTracker.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers.Account
{
    public class PasswordRecoveryController : Controller
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IPasswordRecoveryService _passwordRecoveryService;
        private readonly IUpdateProfileService _userUpdateProfile;

        public PasswordRecoveryController(IUserAuthService userAuthService, IPasswordRecoveryService passwordRecoveryService,
            IUpdateProfileService userUpdateProfile)
        {
            _userAuthService = userAuthService;
            _passwordRecoveryService = passwordRecoveryService;
            _userUpdateProfile = userUpdateProfile;
        }

        public IActionResult RecoveryPasswordCode()
        {
            return View("~/Views/Account/RecoveryPasswordCode.cshtml");
        }

        [HttpPost]
        public IActionResult SendCode(RequestPasswordResetViewModel data)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/RecoveryPasswordCode.cshtml", data);

            var user = _userAuthService.GetUserByEmail(data.Email);

            if (user != null && user.Status == Entity.Account.UserStatus.Active)
            {
                HttpContext.Session.SetString("recoveryEmail", data.Email);
                _passwordRecoveryService.SendRecoveryCode(user);
                return RedirectToAction("RecoveryPasswordEmail");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Пользователь с таким email не найден или пользователь не подтвердил почту");
                return View("~/Views/Account/RecoveryPasswordCode.cshtml", data);
            }
        }

        public IActionResult RecoveryPasswordEmail()
        {
            return View("~/Views/Account/RecoveryPasswordEmail.cshtml");
        }

        [HttpPost]
        public IActionResult RecoveryPasswordEmail(ConfirmRecoveryViewModel data)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/RecoveryPasswordEmail.cshtml", data);

            string email = HttpContext.Session.GetString("recoveryEmail");
            string errorMessage;

            var succes = _passwordRecoveryService.TryConfirmRecoveryCode(email, data.Code, out errorMessage);

            if (succes)
            {
                return RedirectToAction("ResetPassword");
            }
            else
            {
                ModelState.AddModelError(string.Empty, errorMessage);
                return View("~/Views/Account/RecoveryPasswordEmail.cshtml", data);
            }
        }

        public IActionResult ResetPassword()
        {
            return View("~/Views/Account/ResetPassword.cshtml");
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel data)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/ResetPassword.cshtml", data);

            var email = HttpContext.Session.GetString("recoveryEmail");
            var user = _userAuthService.GetUserByEmail(email);

            if (user != null)
            {
                _userUpdateProfile.ResetPassword(user, data.NewPassword);
                HttpContext.Session.Remove("recoveryEmail");
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Account/ResetPassword.cshtml", data);
        }
    }
}
