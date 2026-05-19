using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCs_Rest_Api.Entities;

namespace PCs_Rest_Api.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer> {
    
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder) {
        builder.HasKey(componentManufacturer => componentManufacturer.Id);
        builder.Property(componentManufacturer => componentManufacturer.Abbreviation).HasMaxLength(30);
        builder.Property(componentManufacturer => componentManufacturer.FullName).HasMaxLength(300);
        builder.Property(componentManufacturer => componentManufacturer.FoundationDate).HasColumnType("date");
        builder.ToTable("ComponentManufacturer");
        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<ComponentManufacturer> builder) {
        builder.HasData(new List<ComponentManufacturer> {
            new() {Id = 1, Abbreviation = "CRU", FullName = "Crucial Technology", FoundationDate = new DateOnly(1996, 1, 1)},
            new() {Id = 2, Abbreviation = "SND", FullName = "Samsung Electronics", FoundationDate = new DateOnly(1938, 3, 1)},
            new() {Id = 3, Abbreviation = "NVD", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5)}
        });
    }
}