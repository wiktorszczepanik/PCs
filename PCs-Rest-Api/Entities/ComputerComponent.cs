namespace PCs_Rest_Api.Entities;

public class ComputerComponent {

    public int ComputerId { get; set; }
    public char ComponentCode { get; set; }
    public int Amount { get; set; }
    
    public Computer Computer { get; set; }
    public Component Component { get; set; }
    
}