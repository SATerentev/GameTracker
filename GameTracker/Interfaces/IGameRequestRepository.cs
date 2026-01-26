using GameTracker.Entity;

namespace GameTracker.Interfaces
{
    public interface IGameRequestRepository
    {
        public void Create(GameRequest model);
        public void Remove(GameRequest model);
        public GameRequest Get(Guid id);
        public List<GameRequest> GetAll();
    }
}
