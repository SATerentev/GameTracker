using GameTracker.Entity.Games;
using GameTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.Infrastructure
{
    public class CatalogRepository : ICatalogRepository
    {
        private AppDbContext _context;

        public CatalogRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public void Update(Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
        }   

        public void Remove(Guid gameId)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == gameId);

            if (game == null)
                return;

            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public Game? Get(Guid gameId)
        {
            return _context.Games.SingleOrDefault(g => g.Id == gameId);
        }

        public Game? Get(string name)
        {
            return _context.Games.SingleOrDefault(g => g.Name == name);
        }

        public List<Game> GetAll()
        {
            return _context.Games.ToList();
        }
    }
}
