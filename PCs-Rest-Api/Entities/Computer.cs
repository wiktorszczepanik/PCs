namespace PCs_Rest_Api.Entities;

public class Computer {

    public int Id { get; set; }
    public int Type { get; set; }
    public string Name { get; set; } = String.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public ICollection<ComputerComponent> ComputerComponents { get; set; } = [];

}