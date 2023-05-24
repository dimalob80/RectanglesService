using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace RectanglesApp.Infrustructure;

public static class ExceptionHandler
{
    public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appBuilder=>
        
            appBuilder.Run(async context=>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>().Error;

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest; 
                await context.Response.WriteAsync(exception.Message);
            })
        );
    }
}
