using GameTracker.Entity;
using GameTracker.Interfaces;
using GameTracker.ViewModel;

namespace GameTracker.Services
{
    public class GameRequestService : IGameRequestService
    {
        private readonly IGameRequestRepository _gameRequestRepository;

        public GameRequestService(IGameRequestRepository gameRequestRepository)
        {
            _gameRequestRepository = gameRequestRepository;
        }

        public GameRequest CreateGameRequest(GameRequestViewModel data, Guid userId)
        {
            var gameRequest = new GameRequest(data.GameName, data.GameLink, userId);
            _gameRequestRepository.Create(gameRequest);
            return gameRequest;
        }

        public void DeleteGameRequest(Guid id)
        {
            var gameRequest = _gameRequestRepository.Get(id);
            _gameRequestRepository.Remove(gameRequest);
        }

        public GameRequest GetGameRequest(Guid id)
        {
            return _gameRequestRepository.Get(id);
        }

        public List<GameRequest> GetAll()
        {
            return _gameRequestRepository.GetAll();
        }
    }
}
