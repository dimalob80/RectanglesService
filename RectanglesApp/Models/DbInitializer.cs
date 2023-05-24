using Microsoft.EntityFrameworkCore;

namespace RectanglesApp.Models;

public interface IDbInitializer
{
    void Initialize();

}
public class DbInitializer:IDbInitializer
{
    private readonly AppDbContext _dbContext;

    public DbInitializer(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Initialize()
    {
        try
        {
            _dbContext.Database.EnsureCreated();

            Random random = new Random();

            _dbContext.Colors.Add(new Color { Name = "White" });
            _dbContext.Colors.Add(new Color { Name = "Blue" });
            _dbContext.Colors.Add(new Color { Name = "Green" });

            for (int i = 0; i < 199; i++)
            {
                _dbContext.Rectangles.Add(new Rectangle
                {
                    StartX = i * 2,
                    StartY = i * 2,
                    Length = random.Next(1, 50),
                    Width = random.Next(1, 50),
                    ColorId = random.Next(1, 4),
                });
            }

            _dbContext.SaveChanges();   

        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
