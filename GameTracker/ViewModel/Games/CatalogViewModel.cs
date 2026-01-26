namespace GameTracker.ViewModel.Games
{
    public class CatalogViewModel
    {
        public List<GameCardViewModel> Games { get; set; }
        public int AllGamesQuantity { get; set; }
        public int GamesPerPage { get; set; }
        public CatalogViewModel(List<GameCardViewModel> games, int GamesQuantity, int gamesPerPage)
        {
            Games = games;
            AllGamesQuantity = GamesQuantity;
            GamesPerPage = gamesPerPage;
        }
    }
}
