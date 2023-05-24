using AutoMapper;
using RectanglesApp.Models.DTO;
using RectanglesApp.Models;

namespace RectanglesApp.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Color, ColorDTO>().ReverseMap();

        CreateMap<Rectangle, RectangleDTO>()
            .ForMember(dto => dto.X, opt => opt.MapFrom(rec => rec.StartX))
            .ForMember(dto => dto.Y, opt => opt.MapFrom(rec => rec.StartY))
            .ReverseMap();
    }
}