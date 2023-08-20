using IFitFusion.Infrastructure.CrossCutting.DomainHelper;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Enuns;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.ValueObjects;

namespace IFitFusion.Domain.Entities
{

    public class User : Entity
    {
        protected User()
        {}

        public User(string name, DateTime birthDate, GenderEnum gender, string email, string phone, decimal height, decimal weight, string goal, string password)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            SetEmail(email);
            Phone = phone;
            Height = height;
            Weight = weight;
            Goal = goal;
            SetPasswordWithHash(password);
            Active = true;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public EmailVO Email { get; set; }
        public PasswordVO Password { get; set; }
        public bool Active { get; set; }
        public string Phone { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string? Goal { get; set; }
        public DateTime? RegistrationDate { get; set; }

        private string PasswordStr
        {
            set
            {
                if (value != null)
                    Password = new PasswordVO(value, false);
            }
        }

        private string EmailStr
        {
            set
            {
                if (value != null)
                    Email = new EmailVO(value);
            }
        }

        public void SetPasswordWithHash(string password)
        {
            Password = new PasswordVO(password);
        }

        public void SetEmail(string email)
        {
            Email = new EmailVO(email);
        }
    }
}
