using GameTracker.Entity.Games;

namespace GameTracker.Interfaces.Games
{
    public interface IUserLibraryService
    {
        public void AddGame(Guid userId, Guid gameId);
        public void RemoveGame(Guid userId, Guid gameId);
        public void ChangeGameStatus(Guid userId, Guid gameId, GameStatus status);
        public void RateGame(Guid userId, Guid gameId, int rating);
        public UserGame? GetUserGame(Guid userId, Guid gameId);
        public List<UserGame> GetUserLibrary(Guid userId);
    }
}
