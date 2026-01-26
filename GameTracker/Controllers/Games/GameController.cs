using GameTracker.Interfaces.Account;
using GameTracker.Interfaces.Games;
using GameTracker.ViewModel.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Controllers.Games
{
    public class GameController : Controller
    {
        private readonly IGameCatalogService _gameCatalogService;
        private readonly IUserAuthService _userAuthService;
        private readonly IUserLibraryService _userLibraryService;

        public GameController(IGameCatalogService gameCatalogService, IUserAuthService userAuthService, IUserLibraryService userLibraryService)
        {
            _gameCatalogService = gameCatalogService;
            _userAuthService = userAuthService;
            _userLibraryService = userLibraryService;
        }

        public IActionResult Game(Guid gameId)
        {
            Console.WriteLine($"GAME ID FROM ROUTE = {gameId}");
            var game = _gameCatalogService.GetGame(gameId);
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _userAuthService.GetUser(userId);

            if (user == null) return RedirectToAction("Login", "Account");

            var userGame = _userLibraryService.GetUserGame(user.Id, game.Id);
            var gameVm = new GameViewModel(game, userGame);
            var vm = new GamePageViewModel(gameVm);
            return View("~/Views/Games/Game.cshtml", vm);
        }

        [HttpGet]
        [Authorize(Roles = "Moderator,Admin")]
        public IActionResult EditGame(Guid gameId)
        {
            var game = _gameCatalogService.GetGame(gameId);
            var vm = new EditGameViewModel(game);

            return View("~/Views/Games/EditGame.cshtml", vm);
        }

        [HttpPost]
        [Authorize(Roles = "Moderator,Admin")]
        public IActionResult EditGame(EditGameViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Games/EditGame.cshtml", vm);
            }

            _gameCatalogService.UpdateGame(vm.Id, vm);
            return RedirectToAction("Game", "Catalog", new { gameId = vm.Id });
        }
    }
}
