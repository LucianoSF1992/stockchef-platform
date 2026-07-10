using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockChef.Domain.Entities;

namespace StockChef.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Sku)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CostPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.SalePrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.CurrentStock)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.MinimumStock)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);

        builder.HasOne(x => x.Supplier)
            .WithMany()
            .HasForeignKey(x => x.SupplierId);
    }
}