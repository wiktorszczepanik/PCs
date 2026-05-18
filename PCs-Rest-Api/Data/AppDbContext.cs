using Microsoft.EntityFrameworkCore;
using PCs_Rest_Api.Entities;

namespace PCs_Rest_Api.Data;

public class AppDbContext : DbContext {
    
    protected AppDbContext() {}

    public AppDbContext(DbContextOptions options) : base(options) {}
    
    public DbSet<Computer> Computers { get; set; }
    public DbSet<ComputerComponent> ComputerComponents { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; } // 9:39
    
}