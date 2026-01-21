using GameTracker.Interfaces.Account;
using GameTracker.Interfaces.Games;
using GameTracker.ViewModel.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Controllers.Games
{
    public class CatalogController : Controller
    {
        private readonly IGameCatalogService _gameCatalogService;
        private readonly IUserLibraryService _userLibraryService;
        private readonly IUserAuthService _userAuthService;

        public CatalogController(IGameCatalogService gameCatalogService, IUserLibraryService userLibraryService, IUserAuthService userAuthService)
        {
            _gameCatalogService = gameCatalogService;
            _userAuthService = userAuthService;
            _userLibraryService = userLibraryService;
        }

        public IActionResult Catalog()
        {
            var games = _gameCatalogService.GetAllGames();
            List<GameCardViewModel> cards = new List<GameCardViewModel>();

            foreach (var game in games)
            {
                var card = new GameCardViewModel(game);
                cards.Add(card);
            }

            var catalog = new CatalogViewModel(cards);

            return View("~/Views/Games/Catalog.cshtml", catalog);
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

        [HttpPost]
        [Authorize(Roles = "Moderator,Admin")]
        public IActionResult AddGame(AddGameToCatalogViewModel vm)
        {
            var id = _gameCatalogService.AddGame(vm);

            return RedirectToAction("Game", "Catalog", new { gameId = id});
        }
    }
}
