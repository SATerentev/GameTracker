using GameTracker.Entity.Account;

namespace GameTracker.Services
{
    public interface IHashPasswordService
    {
        HashedPassword HashPassword(string password);
        HashedPassword HashPassword(string password, string salt);
    }

    public interface IHashApiKeyService
    {
        string HashApiKey(string apiKey);
    }
}
