using System.Security.Cryptography;
using System.Text;

namespace IFitFusion.Infrastructure.CrossCutting.DomainHelper.ValueObjects
{
    public class PasswordVO
    {
        public const int MaxLength = 24;
        public const int MinLength = 6;
        public string PasswordStr { get; }

        protected PasswordVO()
        {
            PasswordStr = string.Empty;
        }

        public PasswordVO(string password, bool encrypt = true)
        {
            if (string.IsNullOrEmpty(password))
            {
                PasswordStr = string.Empty;
                return;
            }

            PasswordStr = encrypt ? Encrypt(password) : password;
        }

        public static string Encrypt(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + "|A7F534C3-2292-4D05-BDB9-2C54789B9DFB");
                byte[] hashedBytes = md5.ComputeHash(passwordBytes);

                StringBuilder sbString = new StringBuilder();
                foreach (byte hashedByte in hashedBytes)
                {
                    sbString.Append(hashedByte.ToString("x2"));
                }

                return sbString.ToString();
            }
        }
    }
}
