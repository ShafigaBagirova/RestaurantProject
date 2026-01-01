using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniApp.Data.Entities;

namespace MiniApp.Configurations;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("Staff");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FullName)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(s => s.Position)
                .IsRequired()
                .HasMaxLength(50);
        builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);
        builder.HasIndex(s => s.Email)
                .IsUnique();
        builder.Property(s => s.Phone)
                .IsRequired()
                .HasMaxLength(15);
        builder.HasIndex(s => s.Phone)
                .IsUnique();
        builder.Property(s => s.Age)
                .IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Staff_Age", "Age >= 18"));
        builder.HasMany(s => s.Restaurants)
            .WithMany(r => r.Staffs)
            .UsingEntity<Dictionary<string, object>>(
                "StaffRestaurant",
                j => j
                    .HasOne<Restaurant>()
                    .WithMany()
                    .HasForeignKey("RestaurantId")
                    .HasConstraintName("FK_StaffRestaurant_Restaurant")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<Staff>()
                    .WithMany()
                    .HasForeignKey("StaffId")
                    .HasConstraintName("FK_StaffRestaurant_Staff")
                    .OnDelete(DeleteBehavior.Restrict),
                j =>
                {
                    j.HasKey("StaffId", "RestaurantId");
                    j.ToTable("StaffRestaurant");
                });
    }
}
