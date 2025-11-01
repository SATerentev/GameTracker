using GameTracker.Entity.Account;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using Microsoft.Extensions.Caching.Memory;

namespace GameTracker.Services.Account
{
    public class PassowrdRecoveryService : IPasswordRecoveryService
    {
        private readonly ICodeGenerator _codeGenerator;
        private readonly IEmailService _emailService;
        private readonly IUserAuthService _userAuthService;
        private readonly IMemoryCache _memoryCache;

        public PassowrdRecoveryService(ICodeGenerator codeGenerator, IEmailService emailService, IUserAuthService userAuthService,
            IMemoryCache memoryCache)
        {
            _codeGenerator = codeGenerator;
            _emailService = emailService;
            _userAuthService = userAuthService;
            _memoryCache = memoryCache;
        }

        public void SendRecoveryCode(User user)
        {
            var code = _codeGenerator.GenerateRecoveryCode(user.Id);

            _memoryCache.Set(user.Email, code, TimeSpan.FromMinutes(15));
            _emailService.SendRecoveryCode(user.Email, code);
        }

        public bool TryConfirmRecoveryCode(string email, string recoveryCode, out string errorMessage)
        {
            var user = _userAuthService.GetUserByEmail(email);
            string code;

            if (user == null)
            {
                errorMessage = "Пользователь с таким email не найден";
                return false;
            }

            if (!_memoryCache.TryGetValue(user.Email, out code)) // TODO: достать код из кэша
            {
                errorMessage = "Код не найден или истек срок действия";
                return false;
            }

            if (code != recoveryCode)
            {
                errorMessage = "Неверный код восстановления";
                return false;
            }

            _memoryCache.Remove(user.Email);

            errorMessage = string.Empty;
            return true;
        }
    }
}
