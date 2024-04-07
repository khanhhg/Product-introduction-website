using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<ProductCategory>()
                        .HasMany(e => e.Product)
                        .WithOne(e => e.ProductCategory)
                        .HasForeignKey(e => e.CategoryId)
                        .IsRequired();

            modelBuilder.Entity<ProductInventory>()
                       .HasMany(e => e.Product)
                       .WithOne(e => e.ProductInventory)
                       .HasForeignKey(e => e.InventoryId)
                       .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
