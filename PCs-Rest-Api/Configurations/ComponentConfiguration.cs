using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCs_Rest_Api.Entities;

namespace PCs_Rest_Api.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component> {
    
    public void Configure(EntityTypeBuilder<Component> builder) {
        builder.HasKey(component => component.Code);
        builder.Property(component => component.Code)
            .HasColumnType("char(10)")
            .IsRequired();
        builder.Property(component => component.Name).HasMaxLength(300);
        builder.Property(component => component.Description);
        builder.HasOne(component => component.ComponentType)
            .WithMany(componentType => componentType.Components)
            .HasForeignKey(component => component.ComponentTypeId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(component => component.ComponentManufacturer)
            .WithMany(componentManufacturer => componentManufacturer.Components)
            .HasForeignKey(component => component.ComponentManufacturerId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.ToTable("Component");
        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<Component> builder) {
        builder.HasData(new List<Component>() {
            new() { Code = "RAM0000001", Name = "Corsair Vengeance", Description = "8GB DDR4 3200MHz", ComponentTypeId = 1, ComponentManufacturerId = 1 },
            new() { Code = "SSD0000001", Name = "Samsung SSD", Description = "500GB NVMe M.2 PCIe Gen3", ComponentTypeId = 2, ComponentManufacturerId = 2 },
            new() { Code = "GPU0000001", Name = "RTX 4080 Super", Description = "4GB VRAM", ComponentTypeId = 3, ComponentManufacturerId = 3 },
            new() { Code = "CPU0000001", Name = "Intel Core i5", Description = "4 Cores 8 Threads 4.20 GHz ", ComponentTypeId = 4, ComponentManufacturerId = 4 }
        });
    }
    
}