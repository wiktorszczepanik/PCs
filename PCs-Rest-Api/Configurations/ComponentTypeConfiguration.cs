using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCs_Rest_Api.Entities;

namespace PCs_Rest_Api.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType> {
    
    public void Configure(EntityTypeBuilder<ComponentType> builder) {
        builder.HasKey(componentType => componentType.Id);
        builder.Property(componentType => componentType.Abbreviation).HasMaxLength(30);
        builder.Property(componentType => componentType.Name).HasMaxLength(150);
        builder.ToTable("ComponentType");
        SeedData(builder);
    }

    private void SeedData(EntityTypeBuilder<ComponentType> builder) {
        builder.HasData(new List<ComponentType> {
            new() { Id = 1, Abbreviation = "RAM", Name = "Memory (RAM)" },
            new() { Id = 2, Abbreviation = "SSD", Name = "Solid State Drive" },
            new() { Id = 3, Abbreviation = "GPU", Name = "Graphics Card" },
            new() { Id = 4, Abbreviation = "CPU", Name = "Central Processing Unit" }
        });
    }
    
}