using GameTracker.Entity.Account;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;

namespace GameTracker.Services.Account
{
    public class UserStatusService : IUserStatusService
    {
        private readonly IUserRepository _userRepository;

        public UserStatusService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUser(User user)
        {
            user.MarkAsDeleted();
            _userRepository.UpdateUser(user);
        }

        public void RecoveryUser(User user)
        {
            user.MarkAsNotDeleted();
            _userRepository.UpdateUser(user);
        }

        public void MakeModerator(User user)
        {
            user.MakeModerator();
            _userRepository.UpdateUser(user);
        }
    }
}
