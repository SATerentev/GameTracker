namespace GameTracker.Interfaces
{
    public interface IEmailService
    {
        void SendConfirmationCode(string email, string code);
        void SendRecoveryCode(string email, string code);
    }
}
