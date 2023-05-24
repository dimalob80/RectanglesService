using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RectanglesApp.Models;

public class Rectangle
{
    [Key]
    public int Id { get; set; }
    public int StartX { get; set; }
    public int StartY { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int ColorId { get; set; }

    [ForeignKey("ColorId")]
    public virtual Color Color { get; set; }

}
