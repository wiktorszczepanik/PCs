namespace PCs_Rest_Api.Entities;

public class Component {

    public char Code { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int ComponentManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }
    
    public ComponentType ComponentType { get; set; }
    public ComponentManufacturer ComponentManufacturer { get; set; }
    public ICollection<ComputerComponent> ComputerComponents { get; set; }
    
}