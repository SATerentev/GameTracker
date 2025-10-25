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

        public void SendConfirmationCode(string email, string code)
        {
            _emailSender.SendEmail(email, "Account Confirmation", $"Your confirmation code is: {code}");
        }

        public void SendPasswordResetCode(string email, string code)
        {
            Console.WriteLine($"Sending password reset code {code} to email {email}");
        }
    }
}
