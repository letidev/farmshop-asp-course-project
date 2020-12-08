using FarmShop.Entities;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace FarmShop.DataAccess {
    public class MyDbContext : DbContext {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        public MyDbContext() {
            Roles = this.Set<Role>();
            Products = this.Set<Product>();
            Users = this.Set<User>();
            Orders = this.Set<Order>();
            OrderProducts = this.Set<OrderProduct>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FarmShopDb;User Id=letidev;Password=!Letipass1;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Role>().HasData(
                new Role() {
                    Id = 1,
                    Name = "Admin"
                },
                new Role() {
                    Id = 2,
                    Name = "User"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User() {
                    Id = 1,
                    Username = "admin",
                    Password = BC.HashPassword("admin"),
                    IsDeleted = false,
                    RoleId = 1
                }
                );
        }
    }
}
