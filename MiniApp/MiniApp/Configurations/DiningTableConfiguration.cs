using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Entities;

namespace MiniApp.Configurations;

public class DiningTableConfiguration : IEntityTypeConfiguration<DiningTable>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DiningTable> builder)
    {
        builder.ToTable("DiningTables");
        builder.HasKey(dt => dt.Id);
        builder.Property(dt => dt.DiningTableNumber)
            .IsRequired();
        builder.Property(dt => dt.Capacity)
            .IsRequired();
        builder.ToTable(t=>t.HasCheckConstraint("CK_DiningTable_Capacity", "\"Capacity\" > 0"));
        builder.Property(dt => dt.IsActive)
            .IsRequired()
            .HasDefaultValue(true);
        builder.Property(dt => dt.RestaurantId)
            .IsRequired();
        builder.HasOne(dt => dt.Restaurant)
            .WithMany(r => r.DiningTables)
            .HasForeignKey(dt => dt.RestaurantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
