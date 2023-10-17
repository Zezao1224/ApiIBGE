using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.ViewModels;

public class CreateIbgeViewModel
{
    [Required]
    public string State { get; set; }
}
