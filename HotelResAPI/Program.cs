using HotelResAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    HotelResDbContext _context = services.GetRequiredService<HotelResDbContext>();

                    //DbInitializer.Initialize(_context); //Initialisera databasen om den är tom.
                }
                catch (Exception epicFail)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(epicFail, "Fel uppstod när databasen skulle seedas.");
                }
            }
            host.Run();
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
