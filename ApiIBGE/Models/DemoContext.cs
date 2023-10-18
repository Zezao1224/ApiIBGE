using Microsoft.EntityFrameworkCore;

namespace ApiIBGE.Models
{
    public class DemoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=" + Path.Combine(Environment.CurrentDirectory, "BD\\Bd_ibge"));

        public DbSet<ibge> ibge { get; set; }

        public DbSet<Users> users { get; set; }

    }
}
