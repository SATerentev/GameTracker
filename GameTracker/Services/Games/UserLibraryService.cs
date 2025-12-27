using GameTracker.Entity.Games;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Games;

namespace GameTracker.Services.Games
{
    public class UserLibraryService : IUserLibraryService
    {
        private readonly IUserGameRepository _repository;

        public UserLibraryService(IUserGameRepository repository)
        {
            _repository = repository;
        }

        public void  AddGame(Guid userId, Guid gameId)
        {
            throw new NotImplementedException(); 
        }
        public UserGame? GetUserGame(Guid userId, Guid gameId)
        {
            return _repository.GetByUserAndGameId(userId, gameId);
        }
        public List<UserGame> GetUserLibrary(Guid userId)
        {
            return _repository.GetByUserId(userId);
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
