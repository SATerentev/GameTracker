using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers
{
    [Authorize(Roles="Moderator,Admin")]
    public class ModerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewGame()
        {
            return View("~/Views/Moder/AddNewGame.cshtml");
        }
    }
}
