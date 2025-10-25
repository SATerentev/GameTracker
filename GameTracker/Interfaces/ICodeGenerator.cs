namespace GameTracker.Interfaces
{
    public interface ICodeGenerator
    {
        string GenerateConfirmationCode(Guid userID, int length);
    }
}
