using GameTracker.Entity.Games;

namespace GameTracker.Interfaces
{
    public interface IUserGameRepository
    {
        public void Add(UserGame userGame);
        public void Remove(UserGame userGame);
        public void Update(UserGame userGame);
        public UserGame? GetByUserAndGameId(Guid userId, Guid gameId);
        public List<UserGame>? GetByUserId(Guid userId);
    }
}
