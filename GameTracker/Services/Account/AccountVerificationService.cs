using GameTracker.Entity.Account;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;

namespace GameTracker.Services.Account
{
    public class AccountVerificationService : IAccountVerificationService
    {
        private readonly ICodeGenerator _codeGenerator;
        private readonly IEmailService _emailService;

        public AccountVerificationService(ICodeGenerator codeGenerator, IEmailService emailService)
        {
            _codeGenerator = codeGenerator;
            _emailService = emailService;
        }

        public void SendActivationCode(User user)
        {
            var code = _codeGenerator.GenerateConfirmationCode(user.Id, 5);
            _emailService.SendConfirmationCode(user.Email, code);
        }

        public bool ConfirmActivationCode(User user, string activationCode)
        {
            var code = _codeGenerator.GenerateConfirmationCode(user.Id, 5);
            return code == activationCode;
        }
    }
}
