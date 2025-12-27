using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Entity.Games
{
    [Table("UserGames")]
    public class UserGame
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid GameId { get; private set; }
        public int? UserRating { get; private set; }
        public GameStatus Status { get; private set; }
        
        public UserGame(Guid userId, Guid gameId, GameStatus status, int? userRating = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            GameId = gameId;
            Status = status;
            UserRating = userRating;
        }
        
        public UserGame() { } // Вроде без него EF Core не работает. Не удалять.
    }
}

