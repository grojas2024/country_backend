using Microsoft.EntityFrameworkCore;
using OfimaWebApi.Models;

namespace OfimaWebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
    }
}
