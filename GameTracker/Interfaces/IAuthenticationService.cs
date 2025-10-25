using GameTracker.Entity.Account;

namespace GameTracker.Interfaces
{
    public interface IAuthenticationService
    {
        void SignInAuth(Guid id, string userNickname, UserStatus status, UserRole role);
        void SignOutAuth();
    }
}
