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

public class CityViewModel
{
    public string City { get; set; } = string.Empty;
}

public class StateViewModel
{
    public string State { get; set; } = string.Empty;
}