using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalendarApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/availabledates", async context =>
                {
                    var random = new Random();
                    var nextDate = DateTime.Now.AddDays(random.Next(3, 5));
                    var response = new GetNextAvailableDateResponse(nextDate);
                    var resonseJson = JsonSerializer.Serialize(response);
                    context.Response.Headers.Add("Content-Type", "application/json");
                    await context.Response.WriteAsync(resonseJson);
                });
            });
        }
    }

    public record GetNextAvailableDateResponse(DateTime date);
}
