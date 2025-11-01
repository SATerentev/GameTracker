using GameTracker.Interfaces;

namespace GameTracker.Services
{
    public class EmailService : IEmailService
    {
        private readonly GameTracker.Interfaces.IEmailSender _emailSender;

        public EmailService(GameTracker.Interfaces.IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendRecoveryCode(string email, string code)
        {
            _emailSender.SendEmail(email, "Password Recovery", $"Your password recovery code is: {code}");
        }

        public void SendConfirmationCode(string email, string code)
        {
            _emailSender.SendEmail(email, "Account Confirmation", $"Your confirmation code is: {code}");
        }
    }
}
