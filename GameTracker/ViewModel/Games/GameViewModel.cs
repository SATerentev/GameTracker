using GameTracker.Entity.Games;

namespace GameTracker.ViewModel.Games
{
    public class GameViewModel
    {
        public GameViewModel(Game game, UserGame userGame)
        {
            Id = game.Id;
            Name = game.Name;
            Link = game.Link;
            Description = game.Description;
            ImageUrl = game.ImageUrl;
            DeveloperName = game.DeveloperName;
            PublisherName = game.PublisherName;
            Genre = game.Genre;
            ReleaseDate = game.ReleaseDate;
            
            if (userGame != null)
            {
                Status = userGame.Status;

                if (userGame.UserRating == null)
                    Rate = 0;
                else
                    Rate = userGame.UserRating;
            }
            else
            {
                Status = GameStatus.Nothing;
                Rate = null;
            }
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string DeveloperName { get; set; }
        public string PublisherName { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GameStatus Status { get; set; }
        public int? Rate { get; set; }
        }
}
