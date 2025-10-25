using GameTracker.Entity.Account;
using GameTracker.Infrastructure;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.ViewModel.Account;

namespace GameTracker.Services.Account
{
    public class UpdateProfileService : IUpdateProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPasswordService _hashService;
        private readonly IAccountVerificationService _accountVerificationService;

        public UpdateProfileService(IUserRepository userRepository, IHashPasswordService hashService, IAccountVerificationService accountVerificationService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
            _accountVerificationService = accountVerificationService;
        }

        public User UpdateProfile(ProfileUpdateViewModel profileData, User user)
        {
            if (profileData.Nickname.Length < 64) user.ChangeNickname(profileData.Nickname);
            if (profileData.Email.Length < 64) user.ChangeEmail(profileData.Email);

            if (profileData.Password.Length > 8 && profileData.Password.Length < 32)
            {
                var newHashedPassword = _hashService.HashPassword(profileData.Password, user.Password.Salt);
                user.ChangePassword(newHashedPassword);
            }

            return _userRepository.UpdateUser(user);
        }

        public User ActivateUser(User user, string confirmationCode, out bool isActive)
        {
            isActive = false;

            if (_accountVerificationService.ConfirmActivationCode(user, confirmationCode))
            {
                user.Activate();
                _userRepository.UpdateUser(user);
                isActive = true;
            }

            return user;
        }
    }
}
