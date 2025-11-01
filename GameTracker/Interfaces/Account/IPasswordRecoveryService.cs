namespace GameTracker.Interfaces.Account;
using GameTracker.Entity.Account;

public interface IPasswordRecoveryService
{
    void SendRecoveryCode(User user);
    bool TryConfirmRecoveryCode(string email, string recoveryCode, out string errorMessage);
}

