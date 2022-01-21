using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApi.Core.Models;

namespace NLayerApi.Repository.Configuration;

public class ProductFeatureConfig : IEntityTypeConfiguration<ProductFeature>
{
    public void Configure(EntityTypeBuilder<ProductFeature> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).UseIdentityColumn();
        builder.HasOne(t => t.Product)
            .WithOne(t => t.ProductFeature)
            .HasForeignKey<ProductFeature>(t => t.ProductId);
    }
}