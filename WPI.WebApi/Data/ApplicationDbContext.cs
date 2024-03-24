using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WPI.WebApi.Data.Models;
namespace WPI.WebApi.Data
{  
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Product_Category> Product_Category { get; set; }
        public DbSet<Product_Inventory> Product_Inventory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Shopping_Session> Shopping_Session { get; set; }
        public DbSet<Payment_Details> Payment_Details { get; set; }
        public DbSet<Order_Details> Order_Details { get; set; }
        public DbSet<Order_Items> Order_Items { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Cart_Item> Cart_Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Category>()
                        .HasMany(e => e.Product)
                        .WithOne(e => e.Product_Category)
                        .HasForeignKey(e => e.Category_Id)
                        .IsRequired();

            modelBuilder.Entity<Product_Inventory>()
                       .HasMany(e => e.Product)
                       .WithOne(e => e.Product_Inventory)
                       .HasForeignKey(e => e.Inventory_Id)
                       .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
