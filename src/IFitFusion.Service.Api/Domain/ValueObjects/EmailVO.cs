using System.Text.RegularExpressions;

namespace IFitFusion.Service.Api.Domain.ValueObjects
{
    public class EmailVO
    {
        public const int EnderecoMaxLength = 256;
        public const int EnderecoMinLength = 5;

        protected EmailVO()
        { }

        public EmailVO(string adreess)
        {
            Adreess = adreess;
        }
        
        public string Adreess { get; private set; }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regexEmail.IsMatch(email?.ToLower() ?? "");
        }
    }
}
