using GameTracker.ViewModel.Account;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Entity.Account
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; private set; }
        public string Nickname { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public HashedPassword Password { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public UserStatus Status { get; private set; }
        public UserRole Role { get; private set; }
        public DateTime DeleteDate { get; private set; }

        public User(UserRegistrationViewModel userRegistrationData, HashedPassword hashedPassword)
        {
            Id = Guid.NewGuid();
            Nickname = userRegistrationData.Nickname;
            Login = userRegistrationData.Login;
            Password = hashedPassword;
            Email = userRegistrationData.Email;
            RegistrationDate = DateTime.Now;
            Status = UserStatus.Inactive;
            Role = UserRole.User;
            DeleteDate = DateTime.MaxValue; 
        }

        public User() { } // Вроде без него EF Core не работает. Не удалять.

        public void MarkAsDeleted()
        {
            Status = UserStatus.Deleted;
            DeleteDate = DateTime.Now;
        }

        public void MarkAsNotDeleted()
        {
            Status = UserStatus.Inactive;
            DeleteDate = DateTime.MaxValue;
        }

        public void ChangeNickname(string newNickname) => Nickname = newNickname;

        public void ChangeEmail(string newEmail) => Email = newEmail;

        public void ChangePassword(HashedPassword newPassword) => Password = newPassword;

        public void Activate() => Status = UserStatus.Active;

        public void MakeModerator() => Role = UserRole.Moderator;
    }
}
