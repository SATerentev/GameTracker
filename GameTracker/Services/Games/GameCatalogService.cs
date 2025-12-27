using GameTracker.Entity.Games;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Games;
using GameTracker.ViewModel.Games;

namespace GameTracker.Services.Games
{
    public class GameCatalogService : IGameCatalogService
    {
        private readonly ICatalogRepository _repository;

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

        public List<Game> GetAllGames()
        {
            return _repository.GetAll();
        }
    }
}
