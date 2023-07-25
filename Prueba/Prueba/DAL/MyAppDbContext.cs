using Prueba.Models;
using Microsoft.EntityFrameworkCore;
namespace Prueba.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
