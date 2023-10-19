using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.ViewModels;

public class CreateIbgeViewModel
{
    public CreateIbgeViewModel(){}
    public CreateIbgeViewModel(int id, string state, string city)
    {
        this.id = id;
        State = state;
        this.city = city;
    }

    public int id { get; set; }
    public string? State { get; set; }
    public string? city { get; set; }
}
