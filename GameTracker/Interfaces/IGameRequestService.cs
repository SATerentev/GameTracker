using GameTracker.Entity;
using GameTracker.ViewModel;

namespace GameTracker.Interfaces
{
    public interface IGameRequestService
    {
        public GameRequest CreateGameRequest(GameRequestViewModel data, Guid userId);
        public void DeleteGameRequest(Guid id);
        public GameRequest GetGameRequest(Guid id);
        public List<GameRequest> GetAll();
    }
}
