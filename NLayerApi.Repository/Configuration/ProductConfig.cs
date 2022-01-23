using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApi.Core.Models;

namespace NLayerApi.Repository.Configuration;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).UseIdentityColumn();
        builder.Property(t => t.Name).IsRequired().HasMaxLength(200);
        builder.Property(t => t.Stock).IsRequired();
        builder.Property(t => t.Price).IsRequired().HasColumnType("decimal(18,2)");

        builder.ToTable("Products");
    }
}