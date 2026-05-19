namespace PCs_Rest_Api.DTOs;

public class PostComputerDto {
    
    public string Name { get; set; } = String.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    
}