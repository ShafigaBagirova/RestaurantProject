using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniApp.Data.Entities;

namespace MiniApp.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
       builder.ToTable("Menus");
         builder.HasKey(m => m.Id);
        builder.HasMany(m => m.Categories)
        .WithMany(c => c.Menus)
        .UsingEntity<Dictionary<string, object>>(  
         "MenuCategory",
         j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Cascade),
         j => j.HasOne<Menu>().WithMany().HasForeignKey("MenuId").OnDelete(DeleteBehavior.Cascade));

        builder.HasMany(m=>m.Products)
            .WithMany(p=>p.Menus)
            .UsingEntity<Dictionary<string, object>>(
                "MenuProduct",
                j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Menu>().WithMany().HasForeignKey("MenuId").OnDelete(DeleteBehavior.Cascade));
        builder.HasMany(m=>m.Restaurants)
            .WithOne(r=>r.Menu)
          .OnDelete(DeleteBehavior.Restrict);


    }
}
