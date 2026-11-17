using LuniShop.Module.Products.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuniShop.Module.Products.Core.Infrastructure.Context.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasMaxLength(256);

        builder
            .Property(x => x.Price.Amount)
            .HasPrecision(8,2); // I'm not sure about mapping this via ORM

        builder
            .HasMany(x => x.Categories)
            .WithMany();
    }
}
