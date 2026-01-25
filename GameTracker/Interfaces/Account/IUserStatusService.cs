using GameTracker.Entity.Account;

namespace GameTracker.Interfaces.Account
{
    public interface IUserStatusService
    {
        void DeleteUser(User user);
        void RecoveryUser(User user);
        void ChangeModeratorStatus(User user);
    }
}
