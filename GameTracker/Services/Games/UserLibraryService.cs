using GameTracker.Entity.Games;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Games;

namespace GameTracker.Services.Games
{
    public class UserLibraryService : IUserLibraryService
    {
        private readonly IUserGameRepository _repository;
        private readonly IGameCatalogService _gameCatalogService;

        public UserLibraryService(IUserGameRepository repository, IGameCatalogService gameCatalogService)
        {
            _repository = repository;
            _gameCatalogService = gameCatalogService;
        }

        public UserGame AddGame(Guid userId, Guid gameId)
        {
            var userGame = new UserGame(userId, gameId);
            _repository.Add(userGame);

            return userGame;
        }
        public UserGame? GetUserGame(Guid userId, Guid gameId)
        {
            return _repository.GetByUserAndGameId(userId, gameId);
        }
        public List<Game> GetUserLibrary(Guid userId)
        {
            var userGames = _repository.GetByUserId(userId);
            var games = new List<Game>();

            foreach (var userGame in userGames)
            {
                var game = _gameCatalogService.GetGame(userGame.GameId);
                games.Add(game);
            }

            return games;
        }
        public void ChangeGameStatus(Guid userId, Guid gameId, GameStatus status)
        {
            var userGame = _repository.GetByUserAndGameId(userId, gameId);
            if (userGame == null)
                throw new InvalidOperationException("Game not found in user's library.");

            userGame.UpdateStatus(status);
            _repository.Update(userGame);
        }
        public void RateGame(Guid userId, Guid gameId, int rating)
        {
            var userGame = _repository.GetByUserAndGameId(userId, gameId);
            if (userGame == null)
                throw new InvalidOperationException("Game not found in user's library.");

            userGame.UpdateUserRating(rating);
            _repository.Update(userGame);
        }
        public void RemoveGame(Guid userId, Guid gameId)
        {
            var userGame = _repository.GetByUserAndGameId(userId, gameId);
            if (userGame == null)
                throw new InvalidOperationException("Game not found in user's library.");
            _repository.Remove(userGame);
        }
    }
}
