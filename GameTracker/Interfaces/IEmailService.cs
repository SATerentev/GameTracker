namespace GameTracker.Interfaces
{
    public interface IEmailService
    {
        void SendConfirmationCode(string email, string code);
        void SendPasswordResetCode(string email, string code);
    }
}
