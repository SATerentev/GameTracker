using GameTracker.Entity.Account;
using GameTracker.Entity.Games;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Infrastructure
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games {get; set; }
        public DbSet<UserGame> UserGames { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => entity.OwnsOne(u => u.Password));
        }
    }
}
