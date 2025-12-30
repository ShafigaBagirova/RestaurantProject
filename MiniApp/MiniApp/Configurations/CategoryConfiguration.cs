using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniApp.Data.Entities;

namespace MiniApp.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(c => c.Description)
            .HasMaxLength(500);
        builder.HasMany(c => c.Restaurants)
               .WithMany(r => r.Categories)
               .UsingEntity(j => j.ToTable("RestaurantCategory"));
    }
}
