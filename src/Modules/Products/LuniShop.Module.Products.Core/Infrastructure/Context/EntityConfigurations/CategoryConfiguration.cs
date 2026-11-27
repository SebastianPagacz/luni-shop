using LuniShop.Module.Products.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuniShop.Module.Products.Core.Infrastructure.Context.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasMaxLength(256);
    }
}
