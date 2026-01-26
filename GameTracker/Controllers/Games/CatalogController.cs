using GameTracker.Interfaces.Account;
using GameTracker.Interfaces.Games;
using GameTracker.ViewModel.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker.Controllers.Games
{
    [Authorize]
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

        public IActionResult Catalog(string search, string sort, int page)
        {
            var games = _gameCatalogService.GetGames(search, sort, page);
            ViewBag.Search = search;
            ViewBag.Sort = sort;
            ViewBag.Page = page;
            List<GameCardViewModel> cards = new List<GameCardViewModel>();

            foreach (var game in games)
            {
                var card = new GameCardViewModel(game);
                cards.Add(card);
            }

            int allGamesQuantity = _gameCatalogService.GetQuantityGames(search);
            int gamesPerPage = _gameCatalogService.GamesPerPage();
            var catalog = new CatalogViewModel(cards, allGamesQuantity, gamesPerPage);

            return View("~/Views/Games/Catalog.cshtml", catalog);
        }

        [HttpPost]
        [Authorize(Roles = "Moderator,Admin")]
        public IActionResult AddGame(AddGameToCatalogViewModel vm)
        {
            if(!ModelState.IsValid)
                return View("~/Views/Moder/AddNewGame.cshtml", vm);

            var id = _gameCatalogService.AddGame(vm);

            return RedirectToAction("Game", "Game", new { gameId = id});
        }

        [HttpPost]
        [Authorize(Roles = "Moderator,Admin")]
        public IActionResult RemoveGame(Guid gameId)
        {
            _gameCatalogService.RemoveGame(gameId);
            _userLibraryService.RemoveGameFromLibraries(gameId);

            return RedirectToAction("Catalog", "Catalog");
        }
    }
}
