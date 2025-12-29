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

            var userGame = _userLibraryService.AddGame(userId, gameId);
            var game = _gameCatalogService.GetGame(gameId);

            var vm = new GameViewModel(game, userGame);

            return View("~/Views/Games/Game.cshtml", vm);
        }
    }
}
