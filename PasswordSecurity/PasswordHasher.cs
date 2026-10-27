using System.Security.Cryptography;
using System.Text;

namespace PasswordSecurity
{
    public class PasswordHasher
    {

        public static string GetPasswordHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder hashBuilder = new StringBuilder();
                foreach (byte currentByte in hashBytes)
                {
                    hashBuilder.Append(currentByte.ToString("X2"));
                }

                return hashBuilder.ToString();
            }
        }
    }
}
