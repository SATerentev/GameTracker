using GameTracker.Entity.Games;
using GameTracker.ViewModel.Games;

namespace GameTracker.Interfaces.Games
{
    public interface IGameCatalogService
    {
        public Guid AddGame(AddGameToCatalogViewModel data);
        public void RemoveGame(Guid gameId);
        public Game? GetGame(Guid gameId);
        public Game? GetGame(string name);
        public List<Game> GetAllGames();
    }
}
