using GameTracker.Entity.Account;
using System.Security.Cryptography;

namespace GameTracker.Services
{
    public class HashService : IHashPasswordService
    {
        public HashedPassword HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            string hashedPassword = Convert.ToBase64String(Rfc2898DeriveBytes.Pbkdf2(
                password: password,
                salt: salt,
                iterations: 100000,
                hashAlgorithm: HashAlgorithmName.SHA512,
                outputLength: 32));

            return new HashedPassword(hashedPassword, Convert.ToBase64String(salt));
        }

        public HashedPassword HashPassword(string password, string salt)
        {
            string hashedPassword = Convert.ToBase64String(Rfc2898DeriveBytes.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                iterations: 100000,
                hashAlgorithm: HashAlgorithmName.SHA512,
                outputLength: 32));

            return new HashedPassword(hashedPassword, salt);
        }
    }
}
