using System.ComponentModel.DataAnnotations;

namespace ApiIBGE.Models;

/// <summary>
/// Classe com as principais propriedades do IBGE
/// </summary>
public class Ibge
{
    /// <summary>
    /// Id da localidade IBGE
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// State (Estado) da localidade IBGE
    /// </summary>
    public string? State { get; set; }
    /// <summary>
    /// City (Cidade) da localidade IBGE
    /// </summary>
    public string? City { get; set; }
}
