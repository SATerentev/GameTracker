using GameTracker.Entity.Games;
using GameTracker.Interfaces.Games;
using GameTracker.ViewModel.Games;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Controllers.Games
{
    public class UserLibraryController : Controller
    {
        private readonly IUserLibraryService _userLibraryService;
        private readonly IGameCatalogService _gameCatalogService;

        public UserLibraryController(IUserLibraryService userLibraryService, IGameCatalogService gameCatalogService)
        {
            _userLibraryService = userLibraryService;
            _gameCatalogService = gameCatalogService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGameToLibrary(Guid gameId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _userLibraryService.AddGame(userId, gameId);
            return RedirectToAction("Game", "Catalog", new { gameId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeStatusAndRate(Guid gameId, GameRateAndStatusViewModel data)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _userLibraryService.ChangeGameStatus(userId, gameId, data.Status);
            _userLibraryService.RateGame(userId, gameId, data.Rating);
            return RedirectToAction("Game", "Catalog", new { gameId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromLibrary(Guid gameId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _userLibraryService.RemoveGame(userId, gameId);
            return RedirectToAction("Game", "Catalog", new { gameId });
        }
    }
}
