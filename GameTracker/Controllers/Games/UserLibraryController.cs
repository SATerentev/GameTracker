using GameTracker.Interfaces.Games;
using GameTracker.ViewModel.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Controllers.Games
{
    [Authorize]
    public class UserLibraryController : Controller
    {
        private readonly IUserLibraryService _userLibraryService;

        public UserLibraryController(IUserLibraryService userLibraryService)
        {
            _userLibraryService = userLibraryService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGameToLibrary(Guid gameId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _userLibraryService.AddGame(userId, gameId);
            return RedirectToAction("Game", "Game", new { gameId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeStatusAndRate(Guid gameId, GameRateAndStatusViewModel data)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Game", "Game", new { gameId });

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _userLibraryService.ChangeGameStatus(userId, gameId, data.Status);
            _userLibraryService.RateGame(userId, gameId, data.Rating);
            return RedirectToAction("Game", "Game", new { gameId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromLibrary(Guid gameId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _userLibraryService.RemoveUserGame(userId, gameId);
            return RedirectToAction("Game", "Game", new { gameId });
        }
    }
}
