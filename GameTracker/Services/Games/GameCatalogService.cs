using GameTracker.Entity.Games;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Games;
using GameTracker.ViewModel.Games;

namespace GameTracker.Services.Games
{
    public class GameCatalogService : IGameCatalogService
    {
        private readonly ICatalogRepository _repository;
        private const int _gamesPerPage = 18;

        public GameCatalogService(ICatalogRepository repository)
        {
            _repository = repository;
        }

        public Guid AddGame(AddGameToCatalogViewModel vm)
        {
            var game = new Game(
                vm.Name,
                vm.Link,
                vm.Description,
                vm.ImageUrl,
                vm.DeveloperName,
                vm.PublisherName,
                vm.Genre,
                vm.ReleaseDate
            );

            if (_repository.Get(vm.Name) != null)
                throw new InvalidOperationException("A game with the same name already exists in the catalog.");

            _repository.Add(game);
            return game.Id;
        }

        public void UpdateGame(Guid gameId, EditGameViewModel vm)
        {
            var game = _repository.Get(gameId);
            if (game == null)
                throw new InvalidOperationException("The game to be updated does not exist in the catalog.");
            var updatedGame = game.UpdateDetails(vm);
            _repository.Update(updatedGame);
        }

        public void IncrementGamePopularity(Guid gameId)
        {
            var game = _repository.Get(gameId);
            if (game == null)
                throw new InvalidOperationException("The game to increment popularity does not exist in the catalog.");
            game.ChangePopularity(1);
            _repository.Update(game);
        }

        public void DecrementGamePopularity(Guid gameId)
        {
            var game = _repository.Get(gameId);
            if (game == null)
                throw new InvalidOperationException("The game to decrement popularity does not exist in the catalog.");
            game.ChangePopularity(-1);
            _repository.Update(game);
        }

        public void RemoveGame(Guid gameId)
        {
            if (_repository.Get(gameId) == null)
                throw new InvalidOperationException("The game to be removed does not exist in the catalog.");

            _repository.Remove(gameId);
        }

        public Game? GetGame(Guid gameId)
        {
            return _repository.Get(gameId);
        }

        public Game? GetGame(string name)
        {
            return _repository.Get(name);
        }

        public List<Game> GetGames(string search, string sort, int page)
        {
            if (string.IsNullOrWhiteSpace(search))
                return _repository.GetAll("", sort, page, _gamesPerPage);
            return _repository.GetAll(search, sort, page, _gamesPerPage);
        }

        public int GetQuantityGames(string search)
        {
            if (string.IsNullOrWhiteSpace(search)) 
                return _repository.GetQuantity("");
            return _repository.GetQuantity(search);
        }

        public int GamesPerPage() => _gamesPerPage;
    }
}
