using ApiIBGE.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiIBGE.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ibge> ibge { get; set; }

    public DbSet<Users> users { get; set; } 
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=> optionsBuilder.UseSqlite(connectionString:"DataSource=bd_ibge.db;Cache=Shared");

}
