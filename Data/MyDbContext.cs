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
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderDetail> OrderDetails{get; set;}
        public DbSet<User> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Order>(e=>
            {
                e.ToTable("Order");
                e.HasKey(dh=>dh.IdOrder);
                e.Property(dh=>dh.DateDelivery).HasDefaultValueSql("getutcdate()");
                e.Property(dh=>dh.NameCus).IsRequired().HasMaxLength(100);
            });

             modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(od => new { od.Id, od.IdOrder });

                e.HasOne(od => od.Order)
                    .WithMany(od => od.OrderDetails)
                    .HasForeignKey(od => od.IdOrder)
                    .HasConstraintName("FK_OrderDetail_Order");

                e.HasOne(od => od.Product)
                    .WithMany(od => od.OrderDetails)
                    .HasForeignKey(e => e.Id)
                    .HasConstraintName("FK_OrderDetail_Product");
            });
            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            });
        }
    }
}