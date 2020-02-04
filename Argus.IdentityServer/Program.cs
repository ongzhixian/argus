using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Argus.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Argus";

            // Placeholder to remind myself that this should really be a Windows Service on Windows 
            //bool isService = !(System.Diagnostics.Debugger.IsAttached || args.Contains("--console")); // Environment.UserInteractive

            IConfigurationRoot config = new ConfigurationBuilder()
                // Add other configuration files (if any) here
                //.AddJsonFile("hosting.json")
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // IWebHost host = CreateWebHostBuilder(config).Build();
            // host.Run();

            CreateWebHostBuilder(config).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(IConfiguration config) =>
            new WebHostBuilder()
            .UseConfiguration(config)
            .UseKestrel()
            .UseStartup<Startup>()
            .UseSerilog((context, configuration) => 
            {
                // context          // WebHostbuilderContext
                // configuration    // LoggerConfiguration
                
                configuration.ReadFrom.Configuration(config);
                //.CreateLogger(); // ZX: Think `UseSerilog` will implicitly call CreateLogger() already; comment out as multiple calls is fatal.
            });
    }
}
