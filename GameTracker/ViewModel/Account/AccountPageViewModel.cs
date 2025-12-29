using GameTracker.Entity.Games;
using GameTracker.ViewModel.Games;

namespace GameTracker.ViewModel.Account
{
    public class AccountPageViewModel
    {
        public AccountDataViewModel AccountData { get; set; }
        public ConfirmEmailViewModel ConfirmEmail { get; set; }
        public UserGameLibraryViewModel UserGames { get; set; }

        public AccountPageViewModel(AccountDataViewModel accountDataViewModel, ConfirmEmailViewModel confirmEmailViewModel, List<Game> userGames)
        {
            AccountData = accountDataViewModel;
            ConfirmEmail = confirmEmailViewModel;
            UserGames = new UserGameLibraryViewModel(userGames);
        }
    }
}
