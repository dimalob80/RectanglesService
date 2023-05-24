using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RectanglesApp.Models.DTO;
using RectanglesApp.Models;

namespace RectanglesApp.Services;

public interface IRegtanglesService
{
    Task<List<RectangleDTO>> GetRectanglesAsync();
    Task<List<RectangleDTO>> GetMatchingRectanglesAsync(int x, int y);
}

public class RegtanglesService : IRegtanglesService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public RegtanglesService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<RectangleDTO>> GetRectanglesAsync()
    {
        var rectangles = await _dbContext
            .Rectangles
            .Include(r => r.Color)
            .ToListAsync();

        var dtos = _mapper.Map<List<RectangleDTO>>(rectangles);
        return dtos;
    }

    public async Task<List<RectangleDTO>> GetMatchingRectanglesAsync(int x, int y)
    {
        return await _dbContext.Rectangles
            .Where(r => r.StartX <= x && x <= (r.StartX + r.Length)
                     && r.StartY <= y && x <= (r.StartY + r.Width))
            .Include(r => r.Color)
            .Select(r => _mapper.Map<RectangleDTO>(r))
            .ToListAsync();

    }
}
