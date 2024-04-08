using EntityFrameworkConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkConsole.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-7GHJ7SJ\\SQLEXPRESS;Database=EntityFrameworkPB101Db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");


        }
    }
}
