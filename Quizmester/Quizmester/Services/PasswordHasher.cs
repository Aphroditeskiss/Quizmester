using System;
using System.Security.Cryptography;

namespace Quizmester.Services
{
    public static class PasswordHasher
    {
        public static (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                100_000,
                HashAlgorithmName.SHA256,
                32
                );

            return (
                Convert.ToBase64String(hash),
                Convert.ToBase64String(salt)
                );
        }

        public static bool VerifyPassword(
            string password,
            string sotredHash,
            string storedSalt)
        {
            byte[] salt =
                Convert.FromBase64String(storedSalt);

            byte[] expectedHash =
                Convert.FromBase64String(storedHash);

            byte[] actualHash =
                Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    100_000,
                    HashAlgorithmName.SHA256,
                    32
                    );

            return CryptographicOperations.FixedTimeEquals(
                actualHash,
                expectedHash
                );
        }
    }
}

