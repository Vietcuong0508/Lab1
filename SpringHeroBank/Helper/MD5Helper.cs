using System.Security.Cryptography;
using System.Text;

namespace SpringHeroBank.Model
{
    public class MD5Helper
    {
        public string PasswordHash(string password, string salt)
        {
            var passwordString = password + salt;
            var stringPasswordHash = new StringBuilder();
            var md5 = new MD5CryptoServiceProvider();
            var bytes = md5.ComputeHash(new UTF8Encoding().GetBytes(passwordString));
            foreach (var c in bytes)
            {
                stringPasswordHash.Append(c.ToString("x2"));
            }

            return stringPasswordHash.ToString();
        }
    }
}