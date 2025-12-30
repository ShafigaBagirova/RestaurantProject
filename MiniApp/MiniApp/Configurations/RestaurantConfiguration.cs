using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniApp.Data.Entities;

namespace MiniApp.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
       builder.ToTable("Restaurant");
         builder.HasKey(r => r.Id);
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);
        builder.HasIndex(r=> r.Name)
                .IsUnique();
            builder.Property(r => r.Phone)
                .IsRequired()
                .HasMaxLength(20);
    }
}
