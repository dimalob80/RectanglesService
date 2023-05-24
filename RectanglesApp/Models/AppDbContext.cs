using Microsoft.EntityFrameworkCore;

namespace RectanglesApp.Models;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options):base(options){}
    public DbSet<Rectangle> Rectangles { get; set; }
    public DbSet<Color> Colors { get; set; }
}
