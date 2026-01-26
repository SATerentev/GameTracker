using GameTracker.Entity.Games;
using GameTracker.ViewModel.Games;

namespace GameTracker.Interfaces.Games
{
    public interface IGameCatalogService
    {
        public Guid AddGame(AddGameToCatalogViewModel data);
        public void UpdateGame(Guid gameId, EditGameViewModel data);
        public void IncrementGamePopularity(Guid gameId);
        public void DecrementGamePopularity(Guid gameId);
        public void RemoveGame(Guid gameId);
        public Game? GetGame(Guid gameId);
        public Game? GetGame(string name);
        public List<Game> GetGames(string search, string sort, int page);
        public int GetQuantityGames(string search);
        public int GamesPerPage();
    }
}
