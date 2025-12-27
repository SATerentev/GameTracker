using GameTracker.Entity.Games;

namespace GameTracker.ViewModel.Games
{
    public class UserGameLibraryViewModel
    {
        List<Game> UserGames { get; set; }
        
        public UserGameLibraryViewModel(List<Game> userGames)
        {
            UserGames = userGames;
        }
    }
}
