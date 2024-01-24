using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfitTest.Core.Models;

namespace ProfitTest.DAL.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Price).HasPrecision(2).IsRequired();
            builder.Property(p => p.Weight).HasPrecision(3).IsRequired();
        }
    }
}
