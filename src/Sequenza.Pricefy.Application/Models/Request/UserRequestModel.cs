using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Enuns;
using System.ComponentModel.DataAnnotations;

namespace IFitFusion.Application.Models.Request
{
    public class UserRequestModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O valor não é um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Password { get; set; }
        public bool Active { get; set; }
        
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 0)]
        public string Phone { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 0)]
        public string Goal { get; set; }
    }
}
