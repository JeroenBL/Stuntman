using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StuntmanAPI;

await WebHost.CreateDefaultBuilder()
    .ConfigureServices(s =>
    {
        s.AddScoped<DataAccess>();
    })
    .Configure(app => {
        
        app.UseRouting();
        app.UseEndpoints(e =>
        {
            var dataAccessService = e.ServiceProvider.GetRequiredService<DataAccess>();
            e.MapGet("/", c =>
            {
                c.Response.ContentType = "application/json";
                return c.Response.WriteAsJsonAsync("Stuntman API");
            });

            e.MapGet("/stuntman", async c =>
            {
                c.Response.ContentType = "application/json";
                await c.Response.WriteAsJsonAsync(await dataAccessService.GetStuntman().ConfigureAwait(false));
            });

            e.MapGet("/stuntman/{id:int}", async c =>
            {
                c.Response.ContentType = "application/json";
                var id = int.Parse((string)(c.Request.RouteValues["id"]));
                await c.Response.WriteAsJsonAsync(await dataAccessService.GetStuntmanById(id).ConfigureAwait(false));
            });

            e.MapGet("/departments", async c =>
            {
                c.Response.ContentType = "application/json";
                await c.Response.WriteAsJsonAsync(await dataAccessService.GetDepartments().ConfigureAwait(false));
            });

            e.MapGet("/departments/{id:int}", async c =>
            {
                c.Response.ContentType = "application/json";
                var id = int.Parse((string)(c.Request.RouteValues["id"]));
                await c.Response.WriteAsJsonAsync(await dataAccessService.GetDepartmentById(id).ConfigureAwait(false));
            });
        });
    }).Build().RunAsync();