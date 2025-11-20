using GameTracker.Interfaces.Account;
using GameTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IUserStatusService _userStatusService;
        private IUserAuthService _userAuthService;

        public AdminController(IUserStatusService userStatusService, IUserAuthService userAuthService)
        {
            _userStatusService = userStatusService;
            _userAuthService = userAuthService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeModerator(MakeModeratorViewModel userData)
        {
            var user = _userAuthService.GetUser(userData.Login);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с такими логином не найден.");
                return View("~/Views/Account/Login.cshtml", userData);
            }

            _userStatusService.MakeModerator(user);

            return RedirectToAction("Index", "Admin");
        }
    }
}
