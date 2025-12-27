using GameTracker.Entity.Account;
using GameTracker.Entity.Games;

namespace GameTracker.ViewModel.Account
{
    public class AccountPageViewModel
    {
        public string Nickname { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public UserStatus Status { get; set; }
        public List<Game> UserGames { get; set; }

        public AccountPageViewModel(string nickname, UserRole role, string email, string login, UserStatus status, List<Game> userGames)
        {
            Nickname = nickname;
            Role = role;
            Email = email;
            Login = login;
            Status = status;
            UserGames = userGames;
        }
    }
}
