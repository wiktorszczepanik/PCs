using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCs_Rest_Api.Entities;

namespace PCs_Rest_Api.Configurations;

public class ComputerConfiguration : IEntityTypeConfiguration<Computer> {
    
    public void Configure(EntityTypeBuilder<Computer> builder) {
        builder.HasKey(computer => computer.Id);
        builder.Property(computer => computer.Name).HasMaxLength(50);
        builder.Property(computer => computer.Weight).HasColumnType("float").HasMaxLength(5);
        builder.Property(computer => computer.Warranty);
        builder.Property(computer => computer.CreatedAt);
        builder.Property(computer => computer.Stock);
        builder.ToTable("Computer");
        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<Computer> builder) {
        builder.HasData(new List<Computer> {
            new() { Id = 1, Name = "Asus TUF Gaming", Weight = 2.2f, Warranty = 1, CreatedAt = new DateTime(2026, 2, 1), Stock = 10},
            new() { Id = 2, Name = "Dell Alienware",  Weight = 2.5f, Warranty = 2, CreatedAt = new DateTime(2026, 3, 1),  Stock = 5  },
            new() { Id = 3, Name = "Lenovo ThinkPad", Weight = 2.7f, Warranty = 3, CreatedAt = new DateTime(2026, 4, 1), Stock = 12 }
        });
    }
    
}