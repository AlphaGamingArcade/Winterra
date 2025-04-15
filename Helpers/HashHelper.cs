using System.Security.Cryptography;
using System.Text;

namespace Winterra.Helpers
{
    public class HashHelper
    {
        const int SaltSize = 16;
        const int HashSize = 32;
        const int iterations = 100000;

        public static string ComputeSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                foreach(byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string HashPassword(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512))
                {
                    byte[] hash = pbkdf2.GetBytes(HashSize);
                    byte[] hashBytes = new byte[SaltSize + HashSize];
                    Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                    Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }

    }
}
