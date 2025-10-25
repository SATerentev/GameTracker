using GameTracker.Entity.Account;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.ViewModel.Account;

namespace GameTracker.Services.Account
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPasswordService _hashPasswordService;

        public RegisterService(IUserRepository userRepository, IHashPasswordService hashPasswordService)
        {
            _userRepository = userRepository;
            _hashPasswordService = hashPasswordService;
        }

        public User? Register(UserRegistrationViewModel userData)
        {
            if (_userRepository.GetUser(userData.Login) != null)
                return null;

            var hashedPassword = _hashPasswordService.HashPassword(userData.Password);
            var newUser = new User(userData, hashedPassword);
            _userRepository.AddUser(newUser);
            return newUser;
        }
    }
}
