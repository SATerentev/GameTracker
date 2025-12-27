namespace GameTracker.ViewModel.Games
{
    public class GameCardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }

        public GameCardViewModel(Guid id, string name, string imageUrl, int year)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Year = year;
        }
    }
}
