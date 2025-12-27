using GameTracker.Entity.Games;

namespace GameTracker.Interfaces
{
    public interface ICatalogRepository
    {
        public void Add(Game game);
        public void Remove(Guid gameId);
        public Game? Get(Guid gameId);
        public Game? Get(string name);
        public List<Game> GetAll();
    }
}
