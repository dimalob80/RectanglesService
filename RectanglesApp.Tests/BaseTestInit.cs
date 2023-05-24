using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RectanglesApp.Automapper;
using RectanglesApp.Models;
using RectanglesApp.Services;
using System;

namespace RectanglesApp.Tests;

public abstract class BaseTestInit:IDisposable
{

    public static AppDbContext dbContext;
    public static IMapper mapper; 
    public static RegtanglesService rectanglesService;


    public void Init()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
                        .UseInMemoryDatabase("TestDatabase")
                        .Options;

        dbContext = new AppDbContext(options);

        dbContext.Colors.Add(new Color { Name = "White" });
        dbContext.Colors.Add(new Color { Name = "Blue" });
        dbContext.Colors.Add(new Color { Name = "Green" });

        var testRectangles = new []
            {
                new Rectangle{Id =1, StartX = 1, StartY=1, Length=10, Width=10, ColorId=1 },
                new Rectangle{Id =2, StartX = 2, StartY=2, Length=20, Width=20, ColorId=2 },
                new Rectangle{Id =3, StartX = 3, StartY=3, Length=30, Width=30, ColorId=3 }
            };

        dbContext.Rectangles.AddRange(testRectangles);
        dbContext.SaveChanges();

        mapper = MapperBuilder.CreateMapper();
        rectanglesService = new RegtanglesService(dbContext, mapper);
    }

    public void Dispose()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }

}

