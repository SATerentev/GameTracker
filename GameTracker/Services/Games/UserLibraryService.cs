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
                // Assuming there's a method to get Game by its ID
                var game = _gameCatalogService.GetGame(userGame.GameId);
                games.Add(game);
            }

            return games;
        }
        public void ChangeGameStatus(Guid userId, Guid gameId, GameStatus status)
        {
            throw new NotImplementedException();
        }
        public void RateGame(Guid userId, Guid gameId, int rating)
        {
            throw new NotImplementedException();
        }
        public void RemoveGame(Guid userId, Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}
