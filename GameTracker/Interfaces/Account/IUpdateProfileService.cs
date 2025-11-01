using GameTracker.Entity.Account;
using GameTracker.ViewModel.Account;

namespace GameTracker.Interfaces.Account
{
    public interface IUpdateProfileService
    {
        User UpdateProfile(ProfileUpdateViewModel profileData, User user);
        User ActivateUser(User user, string confirmationCode, out bool isActive);
        void ResetPassword(User user, string newPassword);
    }
}
