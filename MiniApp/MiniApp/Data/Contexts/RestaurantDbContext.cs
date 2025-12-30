using Microsoft.EntityFrameworkCore;
using MiniApp.Configurations;
using MiniApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniApp.Data.Contexts;

public class RestaurantDbContext:DbContext
{
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RestaurantDb;Username=postgres;Password=shafiga;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
        modelBuilder.ApplyConfiguration(new RestaurantDetailConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Restaurant> Restaurant { get; set; } 
    public DbSet<RestaurantDetail> RestaurantDetail { get; set; }
    public DbSet<Category> Category { get; set; }
}
