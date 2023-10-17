using ApiIBGE.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiIBGE.Data;

public class AppDbContext : DbContext
{
    public DbSet<Ibge> ibge { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite(connectionString:"DataSource=bd_ibge.db;Cache=Shared");
}
