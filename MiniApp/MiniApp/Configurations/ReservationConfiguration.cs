using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniApp.Data.Entities;

namespace MiniApp.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
      builder.ToTable("Reservations");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.CustomerName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(r => r.CustomerPhone)
            .IsRequired()
            .HasMaxLength(15);
        builder.HasIndex(r => r.CustomerPhone)
            .IsUnique();
        builder.Property(r => r.GuestCount)
            .IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Reservations_GuestCount", "GuestCount > 0"));
        builder.Property(r => r.ReservationDate)
            .IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_ReservationDate_Future", "[ReservationDate] >= GETDATE()"));
        builder.Property(r => r.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");
        builder.Property(r => r.DiningTableId)
            .IsRequired();
        builder.HasOne(r => r.DiningTable)
            .WithMany(dt => dt.Reservations)
            .HasForeignKey(r => r.DiningTableId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
