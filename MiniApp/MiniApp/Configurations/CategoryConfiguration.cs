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
        builder.HasIndex(c => c.Name)
               .IsUnique();
        builder.Property(c => c.Description)
            .HasMaxLength(500);
        builder.HasMany(c => c.Restaurants)
          .WithMany(r => r.Categories)
          .UsingEntity<Dictionary<string, object>>(
              "RestaurantCategory", 
              j => j.HasOne<Restaurant>()
                    .WithMany()
                    .HasForeignKey("RestaurantId")
                    .OnDelete(DeleteBehavior.Restrict),
              j => j.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Restrict),
              j => j.ToTable("RestaurantCategory"));

    }
}
