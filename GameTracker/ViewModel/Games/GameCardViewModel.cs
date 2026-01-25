using GameTracker.Entity.Games;

namespace GameTracker.ViewModel.Games
{
    public class GameCardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }

        public GameCardViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            ImageUrl = game.ImageUrl;
            Year = game.ReleaseDate.Year;
        }
    }
}
