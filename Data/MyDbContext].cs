using Microsoft.EntityFrameworkCore;

namespace Dotnet_API.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
    }
}