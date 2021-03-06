using HotelResAPI.Data;
using HotelResAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string json = File.ReadAllText(@"appsettings.json");
            JObject jo = JObject.Parse(json);
            AppSettingsSingleton.Instance = new();
            AppSettingsSingleton.Instance = JsonConvert.DeserializeObject<AppSettingsSingleton>(jo["AppSettings"].ToString());

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    HotelResDbContext context = services.GetRequiredService<HotelResDbContext>();

                    DbInitializer.Initialize(context); //Initialisera databasen om den ?r tom.
                }
                catch (Exception epicFail)
                {
                    Debug.WriteLine(epicFail.Message);
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
