using GameTracker.Entity.Games;

namespace GameTracker.Interfaces.Games
{
    public interface IUserLibraryService
    {
        public UserGame AddGame(Guid userId, Guid gameId);
        public void RemoveUserGame(Guid userId, Guid gameId);
        public void RemoveGameFromLibraries(Guid gameId);
        public void ChangeGameStatus(Guid userId, Guid gameId, GameStatus status);
        public void RateGame(Guid userId, Guid gameId, int rating);
        public UserGame? GetUserGame(Guid userId, Guid gameId);
        public List<Game> GetUserLibrary(Guid userId, string filter);
    }
}
