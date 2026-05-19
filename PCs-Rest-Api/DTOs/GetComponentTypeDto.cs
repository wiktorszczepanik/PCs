namespace PCs_Rest_Api.DTOs;

public class GetComponentTypeDto {
    
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}