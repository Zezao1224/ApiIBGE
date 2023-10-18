using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.ViewModels
{
    public class CreateUsersViewModel
    {
        public CreateUsersViewModel() { }
        [Required]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(15)]
        public string Senha { get; set; }

    }
}
