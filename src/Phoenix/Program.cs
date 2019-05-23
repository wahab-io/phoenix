using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using App.Metrics.AspNetCore;
using System.Net;

namespace Phoenix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>{
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .UseKestrel(options => 
                    options.Listen(IPAddress.Loopback, 3000))
                .UseMetrics()
                .UseStartup<Startup>();
                
    }
}
