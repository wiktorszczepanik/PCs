namespace PCs_Rest_Api.DTOs;

public class GetComponentDto {
    
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public GetComponentManufacturerDto manufacturer { get; set; }
    public GetComponentTypeDto type { get; set; }
    
}