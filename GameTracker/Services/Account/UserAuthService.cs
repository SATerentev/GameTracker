using GameTracker.Entity.Account;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.ViewModel.Account;

namespace GameTracker.Services.Account
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPasswordService _hashPasswordService;

        public UserAuthService(IUserRepository userRepository, IHashPasswordService hashPasswordService)
        {
            _userRepository = userRepository;
            _hashPasswordService = hashPasswordService;
        }

        public User GetUser(Guid id)
        {
            return _userRepository.GetUser(id);
        }

        public User GetUser(string login)
        {
            return _userRepository.GetUser(login);
        }

        public User? Login(UserLoginViewModel userData)
        {
            var user = _userRepository.GetUser(userData.Login);

            if (user == null)
                return null;

            var hashedPassword = _hashPasswordService.HashPassword(userData.Password, user.Password.Salt);

            if (hashedPassword.Hash == user.Password.Hash)
                return user;
            else
                return null;
        }
    }
}
