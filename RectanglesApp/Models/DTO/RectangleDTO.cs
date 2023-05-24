using RectanglesApp.Models;

namespace RectanglesApp.Models.DTO;

public class RectangleDTO
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public ColorDTO Color { get; set; }

}
