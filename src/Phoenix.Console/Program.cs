using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Common.Logging;
using Newtonsoft.Json;

namespace Phoenix.Console
{
    class Program
    {        
        public static void Main(string[] args)
        {
            // Create IoC container
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            
            // Build all the dependencies
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogInformation("Welcome to Phoenix");
            // Get the dependency and execute the behavior
            serviceProvider.GetService<App>().Run();
            System.Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            
            var configuration = builder.Build();

            var loggerFactory = ApplicationLogging.LoggerFactory;
            loggerFactory.AddConsole();

            serviceCollection.AddSingleton<ILoggerFactory>(loggerFactory);

            /*serviceCollection.AddLogging(configure => {
                configure.AddConsole();
            });*/

            serviceCollection.AddTransient<IAppService, AppService>();

            serviceCollection.AddSingleton<App>();
        }
    }
}
