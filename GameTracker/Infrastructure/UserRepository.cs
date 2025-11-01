using GameTracker.Entity.Account;
using GameTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) { _context = context; }

        public User? GetUser(string login)
        {
            return _context.Users.Include(u => u.Password).SingleOrDefault(u => u.Login == login);
        }

        public User? GetUser(Guid id)
        {
            return _context.Users.Include(u => u.Password).SingleOrDefault(u => u.Id == id);
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.Include(u => u.Password).SingleOrDefault(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User? UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
