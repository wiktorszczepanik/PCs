using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCs_Rest_Api.Entities;

namespace PCs_Rest_Api.Configurations;

public class ComputerComponentConfiguration : IEntityTypeConfiguration<ComputerComponent> {
    
    public void Configure(EntityTypeBuilder<ComputerComponent> builder) {
        builder.HasKey(computerComponent => new { computerComponent.ComputerId, computerComponent.ComponentCode });
        builder.HasOne(computerComponent => computerComponent.Computer)
            .WithMany(computer => computer.ComputerComponents)
            .HasForeignKey(computerComponent => computerComponent.ComputerId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(computerComponent => computerComponent.Component)
            .WithMany(component => component.ComputerComponents)
            .HasForeignKey(computerComponent => computerComponent.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(computerComponent => computerComponent.Amount);
        builder.ToTable("ComputerComponent");
        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<ComputerComponent> builder) {
        builder.HasData(new List<ComputerComponent> {
            new() { ComputerId = 1, ComponentCode = "A", Amount = 1 },
            new() { ComputerId = 2, ComponentCode = "B", Amount = 1 },
            new() { ComputerId = 3, ComponentCode = "C", Amount = 1 }
        });
    }
    
}