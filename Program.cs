using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Destinations
{
    public class Program
    {
        /*public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder =>
            { builder.AddYamlFile("appymlsettings.yml", optional: false);
            })
                .UseStartup<Startup>();
        .Build();*/

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder =>
                {
                    builder
                        .AddYamlFile("appsettings.yml", optional: false)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                       // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
    
                })
                .UseStartup<Startup>()
                .Build();


    }
}
