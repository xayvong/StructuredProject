using CKK.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace CKK.Logic.Repository.Data
{
    public class CKKDbContext : DbContext
    {
        public CKKDbContext(DbContextOptions<CKKDbContext> options)
            :base(options)
        {

        }
        public CKKDbContext()
            :base()
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> InventoryItems { get; set; }
        public DbSet<Product> Products { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StructuredProjectDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(c => c.Customer)
                .WithOne(s => s.Cart)
                .HasForeignKey<Customer>(s => s.CustomerId);
            modelBuilder.Entity<Product>()
                .HasMany(s => s.Items)
                .WithOne(i => i.Product)
                .HasForeignKey(a => a.ProductId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
