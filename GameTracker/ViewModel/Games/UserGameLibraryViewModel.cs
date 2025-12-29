using GameTracker.Entity.Games;

namespace GameTracker.ViewModel.Games
{
    public class UserGameLibraryViewModel
    {
        public List<GameCardViewModel> UserGames { get; set; }
        
        public UserGameLibraryViewModel(List<Game> userGames)
        {
            UserGames = new List<GameCardViewModel>();

            foreach (var game in userGames)
            {
                UserGames.Add(new GameCardViewModel(game));
            }
        }
    }
}
