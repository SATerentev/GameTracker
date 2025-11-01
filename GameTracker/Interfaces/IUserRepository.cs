using GameTracker.Entity.Account;

namespace GameTracker.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);
        User GetUser(string Login);
        User GetUser(Guid id);
        User GetUserByEmail(string email);
    }
}
