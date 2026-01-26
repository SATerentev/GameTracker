using GameTracker.Entity;
using GameTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.Infrastructure
{
    public class GameRequestRepository : IGameRequestRepository
    {
        private readonly AppDbContext _context;

        public GameRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(GameRequest model)
        {
            _context.GameRequests.Add(model);
            _context.SaveChanges();
        }

        public void Remove(GameRequest model)
        {
            _context.GameRequests.Remove(model);
            _context.SaveChanges();
        }

        public GameRequest? Get(Guid id)
        {
            return _context.GameRequests.SingleOrDefault(gr => gr.Id == id);
        }

        public List<GameRequest> GetAll()
        {
            return _context.GameRequests.ToList();
        }
    }
}
