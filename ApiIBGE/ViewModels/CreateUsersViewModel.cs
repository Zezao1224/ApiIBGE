using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.ViewModels
{
    public class CreateUsersViewModel
    {
        public CreateUsersViewModel() { }
        [Required]
        [MaxLength(255, ErrorMessage = "O e-mail deve conter no máximo 255 caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string? Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres.")]
        [MaxLength(15, ErrorMessage = "A senha deve conter no máximo 15 caracteres.")]
        public string? Senha { get; set; }

    }
}
