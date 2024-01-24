using Microsoft.EntityFrameworkCore;
using ProfitTest.Core.Models;
using ProfitTest.DAL.Configurations;

namespace ProfitTest.DAL
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext() { }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
