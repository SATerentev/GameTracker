namespace GameTracker.ViewModel.Games
{
    public class CatalogViewModel
    {
        public List<GameCardViewModel> Games { get; set; }
        public CatalogViewModel(List<GameCardViewModel> games)
        {
            Games = games;
        }
    }
}
