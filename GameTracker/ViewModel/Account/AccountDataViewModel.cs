using GameTracker.Entity.Account;
using GameTracker.Entity.Games;

namespace GameTracker.ViewModel.Account
{
    public class AccountDataViewModel
    {
        public string Nickname { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public UserStatus Status { get; set; }

        public AccountDataViewModel(string nickname, UserRole role, string email, string login, UserStatus status)
        {
            Nickname = nickname;
            Role = role;
            Email = email;
            Login = login;
            Status = status;
        }
    }
}
