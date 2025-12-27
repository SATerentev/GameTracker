using GameTracker.Entity.Games;
using GameTracker.Interfaces;

namespace GameTracker.Infrastructure
{
    public class UserGameRepository : IUserGameRepository
    {
        private readonly AppDbContext _context;

        public UserGameRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(UserGame userGame)
        {
            _context.UserGames.Add(userGame);
            _context.SaveChanges();
        }

        public void Update(UserGame userGame)
        {
            _context.UserGames.Update(userGame);
            _context.SaveChanges();
        }

        public void Remove(UserGame userGame)
        {
            _context.UserGames.Remove(userGame);
            _context.SaveChanges();
        }

        public UserGame? GetByUserAndGameId(Guid userId, Guid gameId)
        {
            return _context.UserGames.SingleOrDefault(ug => ug.UserId == userId && ug.GameId == gameId);
        }

        public List<UserGame>? GetByUserId(Guid userId)
        {
            return _context.UserGames.Where(ug => ug.UserId == userId).ToList();
        }
    }
}
