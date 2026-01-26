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
        
        public UserGame(Guid userId, Guid gameId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            GameId = gameId;
            Status = GameStatus.Completed;
            UserRating = null;
        }
        
        public UserGame() { } // Вроде без него EF Core не работает. Не удалять.
        
        public void UpdateStatus(GameStatus newStatus)
        {
            Status = newStatus;
        }

        public void UpdateUserRating(int rating)
        {
            if (rating < 0 || rating > 10)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 0 and 10.");

            UserRating = rating;
        }
    }
}

