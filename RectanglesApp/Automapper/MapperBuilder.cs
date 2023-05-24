using AutoMapper;

namespace RectanglesApp.Automapper;

public static class MapperBuilder
{
    public static IMapper CreateMapper()
    {
        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        return mapperConfig.CreateMapper();

    }
}
