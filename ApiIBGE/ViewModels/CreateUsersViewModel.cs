using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.ViewModels
{
    /// <summary>
    /// Classe utilizada para passar as propriedades de usuário
    /// </summary>
    public class CreateUsersViewModel
    {
        /// <summary>
        /// Construtor vazio da classe CreateUsersViewModel
        /// </summary>
        public CreateUsersViewModel() { }

        /// <summary>
        /// Propriedade Email
        /// </summary>
        [Required]
        [MaxLength(255, ErrorMessage = "The email must contain a maximum of 255 characters.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email in invalid format.")]
        public string? Email { get; set; }

        /// <summary>
        /// Propriedade Password
        /// </summary>
        [Required]
        [MinLength(8, ErrorMessage = "The password must contain at least 8 characters.")]
        [MaxLength(15, ErrorMessage = "The password must contain a maximum of 15 characters.")]
        public string? Password { get; set; }

    }
}
