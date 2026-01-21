namespace GameTracker.ViewModel.Games
{
    public class GamePageViewModel
    {
        public GameViewModel GameViewModel { get; set; }
        public GameRateAndStatusViewModel GameRateAndStatusViewModel { get; set; }
        public GamePageViewModel(GameViewModel gameViewModel)
        {
            GameViewModel = gameViewModel;
            GameRateAndStatusViewModel = new GameRateAndStatusViewModel();
        }
    }
}
