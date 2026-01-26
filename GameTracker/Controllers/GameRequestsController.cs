using GameTracker.Interfaces;
using GameTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Controllers
{
    [Authorize]
    public class GameRequestsController : Controller
    {
        private readonly IGameRequestService _gameRequestService;

        public GameRequestsController(IGameRequestService gameRequestService)
        {
            _gameRequestService = gameRequestService;
        }

        public IActionResult CreateGameRequest()
        {
            return View("~/Views/CreateGameRequest.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGameRequest(GameRequestViewModel viewModel)
        {
            if (!ModelState.IsValid) 
                return View("~/Views/CreateGameRequest.cshtml", viewModel);

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _gameRequestService.CreateGameRequest(viewModel, userId);

            return RedirectToAction("Catalog", "Catalog");
        }
    }
}
