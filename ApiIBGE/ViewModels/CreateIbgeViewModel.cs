using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.ViewModels;

/// <summary>
/// Classe utilizada para passar as propriedades de IBGE
/// </summary>
public class CreateIbgeViewModel
{
    /// <summary>
    /// Construtor vazio da classe CreateIbgeViewModel
    /// </summary>
    public CreateIbgeViewModel(){}

    /// <summary>
    /// Construtor da classe CreateIbgeViewModel com as propriedades da classe
    /// </summary>
    /// <param name="id"></param>
    /// <param name="state"></param>
    /// <param name="city"></param>
    public CreateIbgeViewModel(int id, string state, string city)
    {
        this.id = id;
        State = state;
        this.city = city;
    }

    /// <summary>
    /// Propriedade id da classe IBGE
    /// </summary>
    public int id { get; set; }

    /// <summary>
    /// Propriedade State (Estado) da classe IBGE
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Propriedade city (Cidade) da classe IBGE
    /// </summary>
    public string? city { get; set; }
}

/// <summary>
/// Classe utilizada para passar a propriedade City ao controlador IBGE
/// </summary>
public class CityViewModel
{
    /// <summary>
    /// Propriedade City
    /// </summary>
    public string City { get; set; } = string.Empty;
}

/// <summary>
/// Classe utilizada para passar a propriedade State ao controlador IBGE
/// </summary>
public class StateViewModel
{
    /// <summary>
    /// Propriedade State
    /// </summary>
    public string State { get; set; } = string.Empty;
}