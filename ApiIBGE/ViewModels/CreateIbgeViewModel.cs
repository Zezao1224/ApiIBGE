using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.ViewModels;

public class CreateIbgeViewModel
{
    public int id { get; set; }
    public string State { get; set; }
    public string city { get; set; }
}
