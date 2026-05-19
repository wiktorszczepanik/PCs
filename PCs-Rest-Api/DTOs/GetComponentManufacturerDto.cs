namespace PCs_Rest_Api.DTOs;

public class GetComponentManufacturerDto {
    
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateOnly FoundationDate { get; set; }
    
}