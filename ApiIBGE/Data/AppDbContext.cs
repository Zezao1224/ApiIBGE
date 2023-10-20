using ApiIBGE.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiIBGE.Data;

/// <summary>
/// Classe para inclusão das tabelas no banco de dados em EF
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Instância da conexão com o banco de dados
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Tabela ibge
    /// </summary>
    public DbSet<Ibge> ibge { get; set; }

    /// <summary>
    /// Tabela users
    /// </summary>
    public DbSet<Users> users { get; set; }

}
