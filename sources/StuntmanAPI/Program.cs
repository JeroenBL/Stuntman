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

            e.MapGet("/stuntman", c =>
            {
                c.Response.ContentType = "application/json";
                return c.Response.WriteAsJsonAsync(dataAccessService.GetStuntman());
            });

            e.MapGet("/departments", c =>
            {
                c.Response.ContentType = "application/json";
                return c.Response.WriteAsJsonAsync(dataAccessService.GetDepartments());
            });
        });
    }).Build().RunAsync();