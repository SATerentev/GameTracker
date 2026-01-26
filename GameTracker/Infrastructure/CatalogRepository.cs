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

        
        public List<Game> GetAll(string search, string sort, int page, int pageSize)
        {
            switch (sort)
            {
                case "Name":
                    return _context.Games.Where(g => EF.Functions.Like(g.Name, $"%{search}%"))
                        .OrderBy(g => g.Name).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                case "Year":
                    return _context.Games.Where(g => EF.Functions.Like(g.Name, $"%{search}%"))
                        .OrderByDescending(g => g.ReleaseDate).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                case "YearRev":
                    return _context.Games.Where(g => EF.Functions.Like(g.Name, $"%{search}%"))
                        .OrderBy(g => g.ReleaseDate).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                default:
                    return _context.Games.Where(g => EF.Functions.Like(g.Name, $"%{search}%"))
                        .OrderByDescending(g => g.Popularity).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            }
        }

        public int GetQuantity(string search)
        {
            return _context.Games.Count(g => EF.Functions.Like(g.Name, $"%{search}%"));
        }
    }
}
