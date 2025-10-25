using GameTracker.Entity.Account;

namespace GameTracker.Interfaces.Account
{
    public interface IAccountVerificationService
    {
        void SendActivationCode(User user);
        bool ConfirmActivationCode(User user, string activationCode);
    }
}
