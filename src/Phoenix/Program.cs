using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Phoenix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) {
            var builder = new WebHostBuilder();

            // Configure Hosting Server (Kestrel)
            builder.UseKestrel(k => {
                k.AddServerHeader = false;
                k.Listen(System.Net.IPAddress.Loopback, 6576);
            });

            // Configure Root Directory
            builder.UseContentRoot(Directory.GetCurrentDirectory());

            // Configure the Startup Class
            builder.UseStartup<Startup>();

            // Configure Logging
            builder.ConfigureLogging(log => {
                log.AddConsole();
                log.SetMinimumLevel(LogLevel.Debug);
            });
                        
            return builder.Build();
        }            
    }
}
