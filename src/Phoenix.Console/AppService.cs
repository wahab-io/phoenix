using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Phoenix.Common.Logging;

namespace Phoenix.Console
{
    public class AppService : IAppService
    {
        private readonly ILogger _logger;
        
        public AppService()
        {
            _logger = ApplicationLogging.CreateLogger<AppService>();
        }

        public void Run()
        {
            _logger.LogWarning("AppService::Run");
        }

        public async Task RunAsync()
        {
            _logger.LogWarning("AppService::RunAsync");
            await Task.Delay(5000);
        }
    }
}