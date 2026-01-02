using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniApp.Data.Entities;

namespace MiniApp.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);
        builder.HasIndex(p => p.Name)
               .IsUnique();
        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(p => p.Description)
               .HasMaxLength(500);
        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Restaurants)
               .WithMany(r => r.Products)
               .UsingEntity<Dictionary<string, object>>(
                   "ProductRestaurant",
                   j => j.HasOne<Restaurant>()
                         .WithMany()
                         .HasForeignKey("RestaurantId")
                         .HasConstraintName("FK_ProductRestaurant_Restaurants_RestaurantId")
                         .OnDelete(DeleteBehavior.Cascade),
                   j => j.HasOne<Product>()
                         .WithMany()
                         .HasForeignKey("ProductId")
                         .HasConstraintName("FK_ProductRestaurant_Products_ProductId")
                         .OnDelete(DeleteBehavior.Cascade));

    }
}
