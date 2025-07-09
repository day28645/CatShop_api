using System.Security.Cryptography;
using System.Text;

namespace CatShop_api
{
    public class AESOparation
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                  Encoding.UTF8.GetBytes(password),
                  storedSalt,
                  iterations,
                  hashAlgorithm,
                  keySize);



            return hashToCompare.SequenceEqual(storedHash);
        }

        public byte[] HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            // return Convert.ToHexString(hash);
            return hash;
        }
    }
}
