using GameTracker.Entity.Account;
using GameTracker.ViewModel.Account;

namespace GameTracker.Interfaces.Account
{
    public interface IUserAuthService
    {
        User Login(UserLoginViewModel userLoginData);
        User GetUser(Guid id);
        User GetUser(string login);
    }
}
