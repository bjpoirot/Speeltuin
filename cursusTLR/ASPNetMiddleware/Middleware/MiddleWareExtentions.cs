using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetMiddleware.Middleware
{

    // zie deze link voor hoe het echt moet
    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-5.0


    public static class MiddleWareExtentions
    {
        public static IApplicationBuilder UseSecondMiddleware(this IApplicationBuilder app)
        {
            string s = "hello";
            s.Spacer();
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Starting my second Middleware\r\n");
                await next();
                await context.Response.WriteAsync("Ending my second Middleware\r\n");
            });
            return app;
        }

        public static string Spacer(this String value)
        {
            return value + " " + value;
        }
    }
}
