using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WPI.WebApi.Data.Models.EF;
namespace WPI.WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductInventory> ProductInventory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingSession> ShoppingSession { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<CartItem> CartItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductCategory>()
            //            .HasMany(e => e.Product)
            //            .WithOne(e => e.ProductCategory)
            //            .HasForeignKey(e => e.CategoryId)
            //            .IsRequired();

            //modelBuilder.Entity<ProductInventory>()
            //           .HasMany(e => e.Product)
            //           .WithOne(e => e.ProductInventory)
            //           .HasForeignKey(e => e.InventoryId)
            //           .IsRequired();

            modelBuilder.Entity<OrderDetails>()
            .HasOne(e => e.PaymentDetails)
            .WithOne(e => e.OrderDetails)
            .HasForeignKey<PaymentDetails>(e => e.Order_Id)
            .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
