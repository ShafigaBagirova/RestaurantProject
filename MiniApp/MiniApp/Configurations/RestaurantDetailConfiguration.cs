using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniApp.Configurations;

public class RestaurantDetailConfiguration : IEntityTypeConfiguration<RestaurantDetail>
{
    public void Configure(EntityTypeBuilder<RestaurantDetail> builder)
    {
        builder.ToTable("RestaurantDetail");
        builder.HasKey(rd => rd.Id);
        builder.Property(rd => rd.Address)
            .IsRequired()
            .HasMaxLength(200);
        builder.HasIndex(rd=>rd.Address)
            .IsUnique();
        builder.Property(rd => rd.Cuisine)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(rd => rd.City)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasOne(rd => rd.Restaurant)
            .WithOne(r => r.RestaurantDetail)
            .HasForeignKey<RestaurantDetail>(rd => rd.RestaurantId);
    }
}
