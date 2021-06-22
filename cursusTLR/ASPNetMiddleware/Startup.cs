using ASPNetMiddleware.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/map", (app) => {
                app.Use(async (context, next) => {
                    await context.Response.WriteAsync("Running my map Middleware\r\n");
                });
            });

            app.Use(async (context, next) => {
                await context.Response.WriteAsync("Starting my first Middleware\r\n");
                if (context.Request.Path.Value.ToLower().Contains("first"))
                {
                    await context.Response.WriteAsync("FFIIRRSSTT!!\n");
                } else
                {
                    await next.Invoke();
                }
                
                await context.Response.WriteAsync("Ending my first Middleware\r\n");
                
            });

            app.UseSecondMiddleware();

            app.Run(async (context) => {
                await  context.Response.WriteAsync($"Hello {context.Request.Query} Peterson!\n");
            });
        }
    }
}
