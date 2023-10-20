using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.ViewModels
{
    public class CreateUsersViewModel
    {
        public CreateUsersViewModel() { }
        [Required]
        [MaxLength(255, ErrorMessage = "The email must contain a maximum of 255 characters.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email in invalid format.")]
        public string? Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "The password must contain at least 8 characters.")]
        [MaxLength(15, ErrorMessage = "The password must contain a maximum of 15 characters.")]
        public string? Password { get; set; }

    }
}
