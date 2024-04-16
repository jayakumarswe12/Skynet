using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Writers;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        public static async void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var Context = services.GetRequiredService<ApplicationDbContext>();
                    await Context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    var Logger = LoggerFactory.CreateLogger<Startup>();
                    Logger.LogError(ex, "An Error Occured on during Migrations");
                }
            }
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
        
    }
}