using GameTracker.Entity.Account;
using GameTracker.ViewModel.Account;

namespace GameTracker.Interfaces.Account
{
    public interface IRegisterService
    {
        User Register(UserRegistrationViewModel userRegistrationData);
    }
}
